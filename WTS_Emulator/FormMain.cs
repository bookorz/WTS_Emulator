﻿using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTS_Emulator.Comm;
using WTS_Emulator.UI_Update;

namespace WTS_Emulator
{
    public partial class FormMain : Form, IConnectionReport
    {
        const string _CUSTOMER_SERVICE = "客服";
        const string _CUSTOMER = "Customer";
        const string _RD = "RD";
        string version = "1.0.6";
        string category = _CUSTOMER_SERVICE;
        //Controller
        TcpCommClient ctrlSTK;
        TcpCommClient ctrlWHR;
        TcpCommClient ctrlCTU;
        Boolean isCmdFin = true;
        Boolean isPause = false;
        Boolean isScriptRunning = false;
        Boolean autoMode = false;
        Button[] autoBtns;
        //private string[] ptzDir = new string[2] { "Face", "Face" };
        private string[] ptzPos = new string[2] { "Odd", "Even" };
        //private int dirIdx = 0;
        private int posIdx = 0;
        int intCmdTimeOut = 300000;//default 5 mins
        int ackTimeOut = 5000; // default 5 seconds
        int ackSleepTime = 200; // default 0.2 seconds
        string currentCmd = "";
        //for marco
        string macroName = "";
        string index = "";
        Boolean isAdmin = false;
        Dictionary<string, string> error_codes = new Dictionary<string, string>();
        string defaultMarcoPath = "";

        private void setIsRunning(Boolean isRun)
        {
            //isScriptRunning = isRun;
            FormMainUpdate.SetRunBtnEnable(isRun);
        }

        public FormMain()
        {
            InitializeComponent();
            XmlConfigurator.Configure();
            autoBtns = new Button[] {
                btnE1Auto, btnE2Auto, btnFoupRotAuto,btnI1Auto, btnI2Auto,
                btnWHRAuto, btnWHRCTUAuto, btnWHRPortAuto,
                btnCTUAuto, btnCTUAutoPTZ, btnCTUAutoWHR,
                btnPTZAuto };

            //備份Mapping 統計資料
            FileInfo fi = new FileInfo(@"map_summary.log");
            if (fi.Exists)
            {
                System.IO.File.Move(@"map_summary.log", @"map_summary.log" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            }
        }

        private void btnE1ReadID_Click(object sender, EventArgs e)
        {

            sendCommand(Const.CONTROLLER_STK, readRFID(Const.STK_ELPT1));
            //tbE1RFID.Text = ;
        }

        private string readRFID(string port)
        {
            //$1GET:CID__:LPT[CR]
            //LPT：1 = ELPT1 2 = ELPT2
            //$1MCR:ELTAG:MC,LPT[CR]
            string cmd = "";
            switch (port)
            {
                case Const.STK_ELPT1:
                    //cmd = "$1GET:TAGID:1";// "$1GET:CID__:1";
                    cmd = "$1MCR:ELTAG:1,1";
                    break;
                case Const.STK_ELPT2:
                    //cmd = "$1GET:TAGID:2";// "$1GET:CID__:2";
                    cmd = "$1MCR:ELTAG:2,2";
                    break;
            }
            return cmd;
        }


        private void sendCommands(Object obj)
        {
            ArrayList cmds = (ArrayList)obj;
            Command.oCmdScript.Clear();//clear script
            //create script
            foreach (String cmd in cmds)
            {
                FormMainUpdate.addScriptCmd(cmd);
            }
            FormMainUpdate.ChangeRunTab(6);
            FormMainUpdate.refreshScriptSet();
        }
        private void sendCommand(string cmd)
        {
            string deviceName = "";
            if (cmd.StartsWith("$1"))
            {
                deviceName = Const.CONTROLLER_STK;
            }
            else if (cmd.StartsWith("$2"))
            {
                deviceName = Const.CONTROLLER_WHR;
            }
            else if (cmd.StartsWith("$3"))
            {
                deviceName = Const.CONTROLLER_CTU_PTZ;
            }
            sendCommand(deviceName, cmd);
        }

        private void sendCommand(string deviceName, string cmd)
        {

            TcpCommClient device;
            switch (deviceName)
            {
                case Const.CONTROLLER_STK:
                    device = ctrlSTK;
                    break;
                case Const.CONTROLLER_WHR:
                    device = ctrlWHR;
                    break;
                case Const.CONTROLLER_CTU_PTZ:
                    device = ctrlCTU;
                    break;
                default:
                    device = null;
                    break;
            }

            if (device == null)
            {
                MessageBox.Show("無對應設備!!");
            }
            else if (cmd == null || cmd.Trim().Equals(""))
            {
                MessageBox.Show("無指令!!");
            }
            else
            {
                //FormMainUpdate.LogUpdate(cmd);
                logUpdate(cmd);
                currentCmd = cmd;
                device.Send(cmd + "\r"); //暫時先不送指令, 先跳
            }
        }

        private void connDevice(string device, DeviceConfig config)
        {
            // 暫時沒有連線
            config.Vendor = "SANWA";
            switch (device)
            {
                case Const.CONTROLLER_STK:
                    ctrlSTK = new TcpCommClient(config, this);
                    ctrlSTK.Start();
                    break;
                case Const.CONTROLLER_WHR:
                    ctrlWHR = new TcpCommClient(config, this);
                    ctrlWHR.Start();
                    break;
                case Const.CONTROLLER_CTU_PTZ:
                    ctrlCTU = new TcpCommClient(config, this);
                    ctrlCTU.Start();
                    break;
            }
        }

        private void btnCtrlSTKCon_Click(object sender, EventArgs e)
        {
            DeviceConfig config = new DeviceConfig();
            config.IPAdress = tbCtrlSTK_IP.Text;
            config.Port = int.Parse(tbCtrlSTK_Port.Text);
            config.ConnectionType = "Socket";

            connDevice(Const.CONTROLLER_STK, config);
        }

        private void btnCtrlWHRCon_Click(object sender, EventArgs e)
        {
            DeviceConfig config = new DeviceConfig();
            config.IPAdress = tbCtrlWHR_IP.Text;
            config.Port = int.Parse(tbCtrlWHR_Port.Text);
            config.ConnectionType = "Socket";

            connDevice(Const.CONTROLLER_WHR, config);
        }

        private void btnCtrlCTUCon_Click(object sender, EventArgs e)
        {
            DeviceConfig config = new DeviceConfig();
            config.IPAdress = tbCtrlCTU_IP.Text;
            config.Port = int.Parse(tbCtrlCTU_Port.Text);
            config.ConnectionType = "Socket";

            connDevice(Const.CONTROLLER_CTU_PTZ, config);
        }
        Dictionary<string, int> mapCollection = new Dictionary<string, int>();
        void IConnectionReport.On_Connection_Message(object Msg)
        {

            //Msg = "$1FIN:MCR__:4,83800600";
            //string replyMsg = (string)Msg;
            //string[] MsgAry = ((string)Msg).Split(new string[] { ";\r" }, StringSplitOptions.None);
            string[] MsgAry = ((string)Msg).Split(new string[] { "\r" }, StringSplitOptions.None);
            foreach (string replyMsg in MsgAry)
            {
                //FormMainUpdate.LogUpdate("Receive <= " + replyMsg);
                //logUpdate("Receive <= " + replyMsg + " isCmdFin:" + (isCmdFin?"true":"false"));//debug
                logUpdate("Receive <= " + replyMsg);
                //if (replyMsg.StartsWith("NAK") || replyMsg.StartsWith("CAN") || replyMsg.StartsWith("ABS"))
                if (replyMsg.StartsWith("ABS"))
                {
                    FormMainUpdate.AlarmUpdate(true);
                    setIsRunning(false);//ABS stop script
                }
                else if (replyMsg.StartsWith("$1EVT:INPUT") || replyMsg.StartsWith("$2EVT:INPUT") || replyMsg.StartsWith("$3EVT:INPUT"))
                {
                    FormMainUpdate.Log(replyMsg);
                    // IO Event 不需要做任何事
                }
                else if (replyMsg.StartsWith("$1EVT:ERROR") || replyMsg.StartsWith("$2EVT:ERROR") || replyMsg.StartsWith("$3EVT:ERROR"))
                {
                    showError(replyMsg);
                    setIsRunning(false);//CAN  or  NAK stop script
                    isScriptRunning = false;
                    isCmdFin = true;
                }
                else if (replyMsg.StartsWith("$1NAK") || replyMsg.StartsWith("$2NAK") || replyMsg.StartsWith("$3NAK"))
                {
                    showError(replyMsg);
                    setIsRunning(false);//CAN  or  NAK stop script
                    isScriptRunning = false;
                    isCmdFin = true;
                }
                else if (replyMsg.StartsWith("$1ACK") || replyMsg.StartsWith("$2ACK") || replyMsg.StartsWith("$3ACK"))
                {
                    if (replyMsg.StartsWith("$1ACK:BRDIO:20,1,05,"))
                    {
                        setFoupPresenceByBoard(replyMsg);//UPDATE 畫面在席狀況
                    }
                    //UPDATE IO:$1ACK:RIO__:no,vl[CR]
                    if (replyMsg.Contains("ACK:RELIO:"))
                    {
                        FormMainUpdate.IOUpdate(replyMsg);
                    }
                    else if (replyMsg.Contains("ACK:NMEIO:"))
                    {
                        FormMainUpdate.IONameUpdate(replyMsg);
                    }

                    if (currentCmd.StartsWith("$1SET:MEDIT") || currentCmd.StartsWith("$2SET:MEDIT") || currentCmd.StartsWith("$3SET:MEDIT"))
                    {
                        setIsRunning(false);
                        isCmdFin = true;
                    }
                    else if (currentCmd.Contains("CMD") || replyMsg.Contains("MCR"))
                    {

                        setIsRunning(true);
                        isCmdFin = false;
                    }
                    else
                    {
                        setIsRunning(false);
                        isCmdFin = true;
                    }

                }
                else if (replyMsg.StartsWith("$1FIN") || replyMsg.StartsWith("$2FIN") || replyMsg.StartsWith("$3FIN"))
                {
                    //setIsRunning(false);
                    if (replyMsg.StartsWith("$1FIN:MCR__:5,00000000,"))
                    {
                        setFoupPresenceByFoups(replyMsg);//UPDATE 畫面在席狀況
                    }
                    if (!isScriptRunning)
                    {
                        setIsRunning(false);
                    }
                    //FormMainUpdate.SetRunBtnEnable(true);
                    if (replyMsg.Contains("MCR"))
                    {
                        if (!replyMsg.Split(',')[1].Equals("00000000"))//"$3FIN: MCR__: 2,00000000,1"
                        {
                            showError(replyMsg);
                            setIsRunning(false);
                            isScriptRunning = false;
                        }
                        //if (replyMsg.Split(',').Count() == 27)
                        //{
                        //    //123

                        //    string[] result = replyMsg.Substring(replyMsg.LastIndexOf(':') + 1).Split(',');
                        //    string MC = result[0];
                        //    string MappingResult = "";
                        //    for (int i = 2; i < result.Count(); i++)
                        //    {
                        //        MappingResult += result[i];
                        //    }
                        //    int tmp;
                        //    if (mapCollection.TryGetValue(MC + MappingResult, out tmp))
                        //    {
                        //        mapCollection[MC + MappingResult] = tmp + 1;

                        //    }
                        //    else
                        //    {
                        //        mapCollection.Add(MC + MappingResult, 1);
                        //    }
                        //    string log = "";
                        //    foreach (KeyValuePair<string, int> each in mapCollection)
                        //    {
                        //        log += each.Key + ":" + each.Value + "\n";

                        //    }
                        //    //using (System.IO.StreamWriter file =
                        //    //new System.IO.StreamWriter(@"map_summary.log", false))
                        //    //{
                        //    //    file.WriteLine(log);
                        //    //}
                        //}
                        ////123
                    }
                    else
                    {
                        if (!replyMsg.EndsWith("00000000"))//"$3FIN: MCR__: 2,00000000,1"
                        {
                            showError(replyMsg);
                            setIsRunning(false);
                            isScriptRunning = false;
                        }
                    }
                    isCmdFin = true;
                }

                //if (replyMsg.StartsWith("INF") || replyMsg.StartsWith("ABS"))
                //{
                //    string[] cmd = replyMsg.Split(new char[] { ':', '/' });
                //    //收到INF,ABS 一律自動回ACK
                //    string ackMsg = replyMsg.Replace("INF:", "ACK:").Replace("ABS:", "ACK:") + ";";
                //    Thread.Sleep(ackSleepTime);
                //    sendCommand(ackMsg);
                //    if (!currentCmd.Equals("") && replyMsg.EndsWith(currentCmd.Replace(";", "")))
                //    {
                //        isCmdFin = true;
                //    }
                //}
                //if (replyMsg.StartsWith("INF:RESTR"))
                //{
                //    isPause = false;
                //}
                //else if (replyMsg.StartsWith("INF:ABORT"))
                //{
                //    isPause = false;
                //    setIsRunning(false);// ABORT 
                //}
                //else if (replyMsg.StartsWith("INF:ERROR/CLEAR"))
                //{
                //    FormMainUpdate.AlarmUpdate(false);
                //    //isAlarmSet = false;
                //    setIsRunning(false); //ERROR CLEAR
                //}

            }
        }

        public void showError(string msg)
        {
            try
            {
                msg = msg.ToUpper();
                if (msg.Contains(","))
                {
                    msg = msg.Split(',')[1];
                }
                else if (msg.Contains(":"))
                {
                    msg = msg.Split(':')[2];
                }
                else
                {
                    //FormMainUpdate.LogUpdate("未定義異常");
                    logUpdate("未定義異常");
                }
                string desc = "未定義異常";
                string key = msg.Substring(msg.IndexOf(",") + 1, 5) + "000";
                string axis = msg.Substring(msg.IndexOf(",") + 1 + 5);
                switch (axis)
                {
                    case ("100"):
                        axis = "(R軸)";
                        break;
                    case ("200"):
                        axis = "(L軸)";
                        break;
                    case ("300"):
                        axis = "(T軸)";
                        break;
                    case ("400"):
                        axis = "(Z軸)";
                        break;
                    case ("500"):
                        axis = "(X軸)";
                        break;
                    case ("600"):
                        axis = "(R1軸)";
                        break;
                    case ("700"):
                        axis = "(L1軸)";
                        break;
                    case ("800"):
                        axis = "(T1軸)";
                        break;
                    case ("900"):
                        axis = "(Z1軸)";
                        break;
                    default:
                        axis = "";
                        break;
                }
                error_codes.TryGetValue(key, out desc);
                //FormMainUpdate.LogUpdate("異常描述:" + desc + axis);
                logUpdate("異常描述:" + desc + axis);
            }
            catch (Exception)
            {
                //FormMainUpdate.LogUpdate("異常資訊解析失敗");
                logUpdate("異常資訊解析失敗");
            }
        }

        void IConnectionReport.On_Connection_Connecting(string Msg)
        {
            //FormMainUpdate.LogUpdate("連線中!!");
            logUpdate("連線中!!");
        }

        void IConnectionReport.On_Connection_Connected(object Msg)
        {
            //FormMainUpdate.LogUpdate("連線成功!!");
            logUpdate("連線成功!!");
        }

        void IConnectionReport.On_Connection_Disconnected(string Msg)
        {
            throw new NotImplementedException();
        }

        void IConnectionReport.On_Connection_Error(string Msg)
        {
            throw new NotImplementedException();
        }

        private void btnE2ReadID_Click(object sender, EventArgs e)
        {
            sendCommand(Const.CONTROLLER_STK, readRFID(Const.STK_ELPT2));
            //tbE2RFID.Text = readRFID(Const.STK_ELPT2);
        }

        private void btnE1Clamp_Click(object sender, EventArgs e)
        {
            string cmd = STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_ON);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnE2Clamp_Click(object sender, EventArgs e)
        {
            string cmd = STK_SET_SV(Const.SV_STK_ELPT2_CLAMP, Const.SV_STATUS_ON);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnE1UnClamp_Click(object sender, EventArgs e)
        {
            string cmd = STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_OFF);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnE2UnClamp_Click(object sender, EventArgs e)
        {
            string cmd = STK_SET_SV(Const.SV_STK_ELPT2_CLAMP, Const.SV_STATUS_OFF);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        /// <summary>
        ///     $1SET: SV___: NO,SW[CR] 電磁閥控制命令, SW: On => OPEN or CLAMP
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="sw">ON,OFF</param>
        private string STK_SET_SV(string unit, string sw)
        {
            /*
             * NO：
             *   17 = ELPT1 Clamp
             *   18 = ELPT2 Clamp
             *   19 = ELPT1 Shutter
             *   20 = ELPT2 Shutter
             * SW：
             *   0 = Close(Unclamp)
             *   1 = Open(Clamp)
             */
            string cmd = "";
            switch (unit)
            {
                case Const.SV_STK_ELPT1_CLAMP:
                    //cmd = "$1SET:SV___:17," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
                    cmd = "$1MCR:ELCLP:1,1," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
                    break;
                case Const.SV_STK_ELPT2_CLAMP:
                    //cmd = "$1SET:SV___:18," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
                    cmd = "$1MCR:ELCLP:2,2," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
                    break;
                case Const.SV_STK_ELPT1_SHUTTER:
                    //cmd = "$1SET:SV___:19," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
                    cmd = "$1MCR:ELSTR:1,1," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
                    break;
                case Const.SV_STK_ELPT2_SHUTTER:
                    //cmd = "$1SET:SV___:20," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
                    cmd = "$1MCR:ELSTR:2,2," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
                    break;
            }
            return cmd;
        }

        private void btnE1OpenShutter_Click(object sender, EventArgs e)
        {
            string cmd = STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_ON);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnE1CloseShutter_Click(object sender, EventArgs e)
        {
            string cmd = STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_OFF);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnE2OpenShutter_Click(object sender, EventArgs e)
        {
            string cmd = STK_SET_SV(Const.SV_STK_ELPT2_SHUTTER, Const.SV_STATUS_ON);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnE2CloseShutter_Click(object sender, EventArgs e)
        {
            string cmd = STK_SET_SV(Const.SV_STK_ELPT2_SHUTTER, Const.SV_STATUS_OFF);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " (" + category + " Version: " + version + ")";
            //連線
            hideGUI();
            btnCtrlSTKCon_Click(sender, e);
            btnCtrlWHRCon_Click(sender, e);
            btnCtrlCTUCon_Click(sender, e);
            tabMode.SelectedIndex = 1;
            Initial_I_O();
            Initial_Error();
            Initial_Command();
            resetPtzPosition();
        }

        private void hideGUI()
        {
            //20190412 預設不使用以下頁面功能
            btnLogin.Visible = false;
            tabMode.TabPages.Remove(tabILPTEasy);
            tabMode.TabPages.Remove(tbCTUEasy);
            tabMode.TabPages.Remove(tabMarco);
            tabMode.TabPages.Remove(tabCmd);
            //20190412 改用版本別加是否登入判斷
            //if (isAdmin)
            //{
            //    tabMode.TabPages.Add(tabCmd);
            //    tabMode.TabPages.Add(tabMarco);
            //    tabMode.TabPages.Add(tabILPTEasy);
            //    tabMode.TabPages.Add(tbCTUEasy);
            //}
            //else
            //{
            //    tabMode.TabPages.Remove(tabCmd);
            //    tabMode.TabPages.Remove(tabMarco);
            //    tabMode.TabPages.Remove(tabILPTEasy);
            //    tabMode.TabPages.Remove(tbCTUEasy);
            //}
            switch (category)
            {
                case _RD:
                    btnLogin.Visible = true;
                    if (isAdmin)
                    {
                        tabMode.TabPages.Add(tabCmd);
                        tabMode.TabPages.Add(tabMarco);
                    }
                    else
                    {
                        tabMode.TabPages.Remove(tabCmd);
                        tabMode.TabPages.Remove(tabMarco);
                    }
                    break;
                case _CUSTOMER_SERVICE:
                    btnLogin.Visible = true;
                    if (isAdmin)
                    {
                        tabMode.TabPages.Add(tabCmd);
                    }
                    else
                    {
                        tabMode.TabPages.Remove(tabCmd);
                    }
                    break;
            }
            btnE1Auto.Visible = isAdmin;
            btnE2Auto.Visible = isAdmin;
            btnI1Auto.Visible = isAdmin;
            btnI2Auto.Visible = isAdmin;
            btnFoupRotAuto.Visible = isAdmin;
            btnWHRPortAuto.Visible = isAdmin;
            btnWHRCTUAuto.Visible = isAdmin;
            btnWHRAuto.Visible = isAdmin;
            btnPTZAuto.Visible = isAdmin;
            btnCTUAutoWHR.Visible = isAdmin;
            btnCTUAutoPTZ.Visible = isAdmin;
            btnCTUAuto.Visible = isAdmin;
        }

        private void btnE1MoveIn_Click(object sender, EventArgs e)
        {
            string cmd = ELPT_Move(Const.STK_ELPT1, Const.POSITION_ELPT_STOCK_IN);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnE1MoveOut_Click(object sender, EventArgs e)
        {
            string cmd = ELPT_Move(Const.STK_ELPT1, Const.POSITION_ELPT_STOCK_OUT);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnE2MoveIn_Click(object sender, EventArgs e)
        {
            string cmd = ELPT_Move(Const.STK_ELPT2, Const.POSITION_ELPT_STOCK_IN);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnE2MoveOut_Click(object sender, EventArgs e)
        {
            string cmd = ELPT_Move(Const.STK_ELPT2, Const.POSITION_ELPT_STOCK_OUT);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        /// <summary>
        ///     $1MCR:SLIDE:MC,LPT,PST[CR] , PST: 0 = Move Out 點位 1 = Move In 點位
        /// </summary>
        /// <param name="port"></param>
        /// <param name="position">IN,OUT</param>
        private string ELPT_Move(string port, string position)
        {
            /*
             *  MC：Macro Container
             *      1: when LPT = 1
             *      2: when LPT = 2
             *  LPT：
             *      1 = ELPT1
             *       2 = ELPT2
             */
            string cmd = "";
            switch (port)
            {
                case Const.STK_ELPT1:
                    cmd = "$1MCR:ELMOV:1,1," + (position.Equals(Const.POSITION_ELPT_STOCK_IN) ? "1" : "0");
                    break;
                case Const.STK_ELPT2:
                    cmd = "$1MCR:ELMOV:2,2," + (position.Equals(Const.POSITION_ELPT_STOCK_IN) ? "1" : "0");
                    break;
            }
            return cmd;
        }

        private Boolean confirmWHRArm()
        {
            string msg = "請確認 WHR Arm 是否已縮回?";
            DialogResult confirm = MessageBox.Show(msg, "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (confirm != System.Windows.Forms.DialogResult.Yes)
                return false;
            else
                return true;
        }
        private void btnI1Load_Click(object sender, EventArgs e)
        {
            if (confirmWHRArm())
            {
                string cmd = ILPT_Load(Const.STK_ILPT1);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        private void btnI2Load_Click(object sender, EventArgs e)
        {
            if (confirmWHRArm())
            {
                string cmd = ILPT_Load(Const.STK_ILPT2);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// $1MCR:DROPN:MC,LTP[CR]
        /// MC：Macro Container
        ///     3: when LPT = 1
        ///     4: when LPT = 2 
        /// LPT：    
        ///     1 = ILPT1
        ///     2 = ILPT2
        /// </summary>
        /// <param name="port"></param>
        private string ILPT_Load(string port)
        {
            string cmd = "";
            switch (port)
            {
                case Const.STK_ILPT1:
                    //cmd = "$1MCR:DROPN:3,1";
                    //cmd = "$1MCR:ILOPN:3,1," + (cbWithMap1.Checked ? "1" : "0");//$1MCR:ILOPN:MC,LTP,MPEN[CR]
                    //20191122 update load marco command
                    cmd = "$1MCR:ILLOD:3,1," + (cbWithMap1.Checked ? "1" : "0");//$1MCR:ILLOD:MC,LPT,MPEN[CR]
                    break;
                case Const.STK_ILPT2:
                    //cmd = "$1MCR:DROPN:4,2";
                    //20191122 update load marco command
                    //cmd = "$1MCR:ILOPN:4,2," + (cbWithMap2.Checked ? "1" : "0");//$1MCR:ILOPN:MC,LTP,MPEN[CR]
                    cmd = "$1MCR:ILLOD:4,2," + (cbWithMap2.Checked ? "1" : "0");//$1MCR:ILLOD:MC,LPT,MPEN[CR]
                    break;
            }
            return cmd;
        }

        /// <summary>
        /// $1MCR:DRCLS:MC,LTP[CR]
        /// MC：Macro Container
        ///     3: when LPT = 1
        ///     4: when LPT = 2 
        /// LPT：    
        ///     1 = ILPT1
        ///     2 = ILPT2
        /// </summary>
        /// <param name="port"></param>
        private string ILPT_Unload(string port)
        {
            string cmd = "";
            switch (port)
            {
                //$1MCR:ILULD:MC,LPT[CR]
                case Const.STK_ILPT1:
                    //cmd = "$1MCR:DRCLS:3,1";
                    //cmd = "$1MCR:ILCLS:3,1," + (cbWithMap1.Checked ? "1" : "0");//$1MCR:ILCLS:MC,LTP,MPEN[CR]
                    cmd = "$1MCR:ILULD:3,1," + (cbWithMap1.Checked ? "1" : "0");
                    break;
                case Const.STK_ILPT2:
                    //cmd = "$1MCR:DRCLS:4,2";
                    //cmd = "$1MCR:ILCLS:4,2," + (cbWithMap2.Checked ? "1" : "0");//$1MCR:ILCLS:MC,LTP,MPEN[CR]
                    cmd = "$1MCR:ILULD:4,2," + (cbWithMap2.Checked ? "1" : "0");
                    break;
            }
            return cmd;
        }

        private void btnI1UnLoad_Click(object sender, EventArgs e)
        {
            if (confirmWHRArm())
            {
                string cmd = ILPT_Unload(Const.STK_ILPT1);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        private void btnI2UnLoad_Click(object sender, EventArgs e)
        {
            if (confirmWHRArm())
            {
                string cmd = ILPT_Unload(Const.STK_ILPT2);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        //private void btnI1Maping_Click(object sender, EventArgs e)
        //{
        //    string cmd = ILPT_Mapping(Const.STK_ILPT1, rbMapUp1.Checked);
        //    sendCommand(Const.CONTROLLER_STK, cmd);
        //}

        //private void btnI2Maping_Click(object sender, EventArgs e)
        //{
        //    string cmd = ILPT_Mapping(Const.STK_ILPT2, rbMapUp2.Checked);
        //    sendCommand(Const.CONTROLLER_STK, cmd);
        //}

        private string ILPT_Mapping(string port, Boolean isMappingUpward)
        {
            //int timeout = 9999;
            //string result;
            string cmd = "";
            switch (port)
            {
                case Const.STK_ILPT1:
                    cmd = "$1MCR:ILMAP:3,1," + (isMappingUpward ? "1" : "0");//$1MCR:ILMAP:MC,LPT,DIR[CR]
                    break;
                case Const.STK_ILPT2:
                    cmd = "$1MCR:ILMAP:4,2," + (isMappingUpward ? "1" : "0");//$1MCR:ILMAP:MC,LPT,DIR[CR]
                    break;
            }
            return cmd;
            //SpinWait.SpinUntil(() => (Port.PortUnloadAndLoadFinished , timeout);
            //return result;
        }


        //private void autoRunELPT(string portName)
        //{
        //    readRFID(portName);
        //    this.s
        //}

        private void btnE1Init_Click(object sender, EventArgs e)
        {
            ELPT_INIT(Const.STK_ELPT1);
        }

        private void ELPT_INIT(string port)
        {
            string cmd = "";
            switch (port)
            {
                case Const.STK_ELPT1:
                    //cmd = "$1MCR:MEORG:1,6";//$1MCR:MEORG:MC,MO
                    cmd = "$1MCR:ELINI:1,1"; //$1MCR: ELINI: MC,MO
                    break;
                case Const.STK_ELPT2:
                    //cmd = "$1MCR:MEORG:2,7";//$1MCR:MEORG:MC,MO
                    cmd = "$1MCR:ELINI:2,2"; //$1MCR: ELINI: MC,MO
                    break;
            }
            sendCommand(cmd);
        }

        private void ILPT_INIT(string port)
        {
            string cmd = "";
            switch (port)
            {
                case Const.STK_ILPT1:
                    cmd = "$1MCR:ILINI:3,1"; //$1MCR:ILINI:MC,LTP
                    break;
                case Const.STK_ILPT2:
                    cmd = "$1MCR:ILINI:4,2"; //$1MCR:ILINI:MC,LTP
                    break;
            }
            sendCommand(cmd);
        }

        private void btnE2Init_Click(object sender, EventArgs e)
        {
            ELPT_INIT(Const.STK_ELPT2);
        }

        private void tbI1Init_Click(object sender, EventArgs e)
        {
            if (confirmWHRArm())
            {
                ILPT_INIT(Const.STK_ILPT1);
            }
        }

        private void tbI2Init_Click(object sender, EventArgs e)
        {
            if (confirmWHRArm())
            {
                ILPT_INIT(Const.STK_ILPT2);
            }
        }

        private void btnE1Reset_Click(object sender, EventArgs e)
        {
            ResetController(Const.CONTROLLER_STK);
        }

        private void btnE2Reset_Click(object sender, EventArgs e)
        {
            ResetController(Const.CONTROLLER_STK);
        }

        private void tbI1Reset_Click(object sender, EventArgs e)
        {
            ResetController(Const.CONTROLLER_STK);
        }

        private void tbI2Reset_Click(object sender, EventArgs e)
        {
            ResetController(Const.CONTROLLER_STK);
        }

        /// <summary>
        /// MC：Macro Container(Always 5)
        /// STN：
        /// 0 = ALL
        /// 1 = Robot Arm
        /// 2 = ELPT1
        /// 3 = ELPT2
        /// 4 = ILPT1
        /// 5 = ILPT2
        /// 6~21 = SHELF1 ~SHLEF16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSTKRefresh_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("查詢Stocker 在席!");
            //string cmd = "$1GET:BRDIO:20,1,05";
            string cmd = "$1MCR:FOUPS:5,0";//$1MCR:FOUPS:MC,STN[CR]//Container:5,0=>ALL
            sendCommand(cmd);
            //測試用
            //setFoupPresenceByBoard("$1ACK:BRDIO:20,1,5,00143,00241,00128,00055,00155");
            //setFoupPresenceByFoups("$1FIN:MCR__:5,00000000,1,2,1,2,1,0,0,0,1,0,0,0,1,2,1,0,0,0,1,2,1");
            //setFoupPresenceByFoups("$1FIN:MCR__:5,00000000,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1");
        }
        /// 0 = ALL        /// 1 = Robot Arm    /// 2 = ELPT1
        /// 3 = ELPT2      /// 4 = ILPT1        /// 5 = ILPT2
        /// 6~21 = SHELF1 ~SHLEF16
        /// $1FIN:MCR__:5,00000000,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1
        private void setFoupPresenceByFoups(string msg)
        {
            string[] rsltPresence = new string[21];
            string[] results = msg.Split(',');
            if (results.Length != 23)
                return;
            int idx = 0;
            for (int i = 2; i < results.Length; i++, idx++)//前2個項目非 return 值
            {
                rsltPresence[idx] = results[i];
            }
            FormMainUpdate.updateFoupPresenceByFoups(rsltPresence);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">$3ACK:BRDIO:20,1,5,00008,00008,00008,00008,00000</param>
        private void setFoupPresenceByBoard(string msg)
        {
            string[] rsltPresence = new string[18];
            string[] results = msg.Split(',');
            int boardid = 20;
            for (int i = 3; i < results.Length; i++)//前三個項目非 return 值
            {
                //FormMainUpdate.LogUpdate(Convert.ToString(int.Parse(results[i]), 2).PadLeft(8, '0'));
                logUpdate(Convert.ToString(int.Parse(results[i]), 2).PadLeft(8, '0'));
                string result = Convert.ToString(int.Parse(results[i]), 2).PadLeft(8, '0');
                switch (boardid)
                {
                    case 20:
                        rsltPresence[0] = result.Substring(6, 2);//1-1(2)
                        rsltPresence[1] = result.Substring(4, 2);//1-2(2)
                        rsltPresence[2] = result.Substring(2, 2);//1-3(2)
                        rsltPresence[3] = result.Substring(0, 2);//2-1(2)
                        break;
                    case 21:
                        rsltPresence[4] = result.Substring(5, 3);//ILPT1(3)
                        rsltPresence[5] = result.Substring(2, 3);//ILPT2(3)
                        rsltPresence[6] = result.Substring(0, 2);//3-1(2)
                        break;
                    case 22:
                        rsltPresence[7] = result.Substring(6, 2);//3-2(2)
                        rsltPresence[8] = result.Substring(4, 2);//3-3(2)
                        rsltPresence[9] = result.Substring(2, 2);//4-1(2)
                        rsltPresence[10] = result.Substring(0, 2);//4-2(2)
                        break;
                    case 23:
                        rsltPresence[11] = result.Substring(6, 2);//4-3(2)
                        rsltPresence[12] = result.Substring(4, 2);//5-1(2)
                        rsltPresence[13] = result.Substring(2, 2);//5-2(2)
                        rsltPresence[14] = result.Substring(0, 2);//5-3(2)
                        break;
                    case 24:
                        rsltPresence[15] = result.Substring(6, 2);//6-1(2)
                        rsltPresence[16] = result.Substring(4, 2);//6-2(2)
                        rsltPresence[17] = result.Substring(2, 2);//6-3(2)
                        break;
                }
                boardid++;
            }
            FormMainUpdate.updateFoupPresenceByBoard(rsltPresence);
        }

        private void btnFoupRotSwitch_Click(object sender, EventArgs e)
        {
            int srcIdx = cbSource.SelectedIndex;
            int destIdx = cbDestination.SelectedIndex;
            cbSource.SelectedIndex = destIdx;
            cbDestination.SelectedIndex = srcIdx;
        }

        private void btnFoupRotPrePick_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotSrc())
            {
                string cmd = FoupRobot_PrePick(cbSource.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        private Boolean checkFoupRobotSrc()
        {
            if (cbSource.Text.Equals(""))
            {
                MessageBox.Show("請選擇 Source!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean checkFoupRobotDest()
        {
            if (cbDestination.Text.Equals(""))
            {
                MessageBox.Show("請選擇 Destination!");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// PNO：1 = ELPT1, 2 = ELPT2, 3 = ILPT1, 4 = ILPT2
        ///     11 = SHELF1, 12 = SHELF2, 13 = SHELF3, 21 = SHELF4, 31 = SHELF5
        ///     22 = SHELF6, 33 = SHELF7, 41 = SHELF8, 42 = SHELF9, 43 = SHELF10
        ///     51 = SHELF11, 52 = SHELF12, 53 = SHELF13, 61 = SHELF14, 62 = SHELF15,63 = SHELF16
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string STK_GET_POSITION(string name)
        {
            string result = "";
            switch (name)
            {
                case Const.STK_ELPT1:
                    result = "1";
                    break;
                case Const.STK_ELPT2:
                    result = "2";
                    break;
                case Const.STK_ILPT1:
                    result = "3";
                    break;
                case Const.STK_ILPT2:
                    result = "4";
                    break;
                case Const.STK_SHELF1_1:
                    result = "11";
                    break;
                case Const.STK_SHELF1_2:
                    result = "12";
                    break;
                case Const.STK_SHELF1_3:
                    result = "13";
                    break;
                case Const.STK_SHELF2_1:
                    result = "21";
                    break;
                case Const.STK_SHELF3_1:
                    result = "31";
                    break;
                case Const.STK_SHELF3_2:
                    result = "32";
                    break;
                case Const.STK_SHELF3_3:
                    result = "33";
                    break;
                case Const.STK_SHELF4_1:
                    result = "41";
                    break;
                case Const.STK_SHELF4_2:
                    result = "42";
                    break;
                case Const.STK_SHELF4_3:
                    result = "43";
                    break;
                case Const.STK_SHELF5_1:
                    result = "51";
                    break;
                case Const.STK_SHELF5_2:
                    result = "52";
                    break;
                case Const.STK_SHELF5_3:
                    result = "53";
                    break;
                case Const.STK_SHELF6_1:
                    result = "61";
                    break;
                case Const.STK_SHELF6_2:
                    result = "62";
                    break;
                case Const.STK_SHELF6_3:
                    result = "63";
                    break;
            }
            return result;
        }

        /// <summary>
        /// (舊版) $1CMD:GETST:PNO,001,1,1[CR]	"Robot Arm 移動至取 FOUP 等待位置
        /// (新版) $1CMD:GETW_:STN,1,1[CR]
        /// (最新版) $1MCR:GETW_:MC,STN[CR]
        /// </summary>
        /// <param name="source"></param>
        private string FoupRobot_PrePick(string source)
        {
            string cmd = "";
            string position = STK_GET_POSITION(source);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD:GETST:" + position + ",001,1,1";
                //cmd = "$1CMD:GETW_:" + position + ",1,1";
                cmd = "$1MCR:GETW_:0," + position;
            }
            return cmd;
        }

        private void btnFoupRotPick_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotSrc())
            {
                string cmd = FoupRobot_Pick(cbSource.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (舊命令)$1CMD:GETST:PNO,001,1,0[CR]
        /// (新命令)$1CMD:GET__:PNO,1,1,0,0[CR]
        /// (最新命令)$1MCR:GET__:MC,STN[CR]
        /// </summary>
        /// <param name="source"></param>
        private string FoupRobot_Pick(string source)
        {
            string cmd = "";
            string position = STK_GET_POSITION(source);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD:GETST:" + position + ",001,1,0";
                //cmd = "$1CMD:GET__:" + position + ",1,1,0,0";
                cmd = "$1MCR:GET__:0," + position;
            }
            return cmd;
        }

        private void btnFoupRotPrePlace_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotDest())
            {
                string cmd = FoupRobot_PrePlace(cbDestination.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (舊命令)$1CMD:PUTST:PNO,001,1,1[CR]
        /// (新命令)$1CMD:PUTW_:PNO,1,1[CR]
        /// (最新命令)$1MCR:PUTW_:MC,STN[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_PrePlace(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD:PUTST:" + position + ",001,1,1";
                //cmd = "$1CMD:PUTW_:" + position + ",1,1";
                cmd = "$1MCR:PUTW_:0," + position;
            }
            return cmd;
        }

        private void btnFoupRotPlace_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotDest())
            {
                string cmd = FoupRobot_Place(cbDestination.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (舊命令)$1CMD:PUTST:PNO,001,1,0[CR]
        /// (新命令)$1CMD:PUT__:PNO,1,1,0[CR]
        /// (最新命令)$1MCR:PUT__:MC,STN[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Place(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD:PUTST:" + position + ",001,1,0";
                //cmd = "$1CMD:PUT__:" + position + ",1,1,0";
                cmd = "$1MCR:PUT__:0," + position;
            }
            return cmd;
        }

        private void btnFoupRotExtendSrc_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotSrc())
            {
                string cmd = FoupRobot_Extend_Src(cbSource.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (舊命令)$1CMD:PUTST:PNO,001,1,0[CR]
        /// (新命令)$1MCR:RBETD:MC,PNO,ZPOS[CR]
        /// MC：Macro Container(Always 0)
        /// PNO: same as PreparePick
        /// ZPOS : Z Position
        /// 0 : Bottom(Get)
        /// 1 : Top(Put)
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Extend_Src(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD: GETST:" + position + ",001,1,2";
                cmd = "$1MCR:RBETD:0," + position + ",0";
            }
            return cmd;
        }

        private void btnFoupRotUpSrc_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotSrc())
            {
                string cmd = FoupRobot_Up_Src(cbSource.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (舊命令)$1CMD:PUTST:PNO,001,1,0[CR]
        /// (新指令)$1MCR:RBUP_:MC[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Up_Src(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD: GETST: " + position + ",001,1,5";
                cmd = "$1MCR:RBUP_:0";
            }
            return cmd;
        }

        private void btnFoupRotGrab_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotSrc())
            {
                string cmd = FoupRobot_Grab_Src(cbSource.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (舊命令)$1CMD:PUTST:PNO,001,1,0[CR]
        /// (新命令)$1CMD:WHLD_:1,0[CR]
        /// (最新指令)$1MCR:RBHLD:MC[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Grab_Src(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD:GETST:" + position + ",001,1,4";
                //cmd = "$1CMD:WHLD_:1,0";
                cmd = "$1MCR:RBHLD:0";
            }
            return cmd;
        }

        private void btnFoupRotRetractSrc_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotSrc())
            {
                string cmd = FoupRobot_Retract_Src(cbSource.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (舊命令)$1CMD:PUTST:PNO,001,1,0[CR]
        /// (新指令)$1CMD:RET__[CR]
        /// (最新命令)$1MCR:RET__:MC[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Retract_Src(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD: GETST:" + position + ",001,1,0";
                //cmd = "$1CMD:RET__";
                cmd = "$1MCR:RET__:0";
            }
            return cmd;
        }

        private void btnFoupRotExtendDest_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotDest())
            {
                string cmd = FoupRobot_Extend_Dest(cbDestination.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (舊命令)$1CMD:PUTST:PNO,001,1,0[CR]
        /// (新命令)$1MCR:RBETD:MC,PNO,ZPOS[CR]
        /// MC：Macro Container(Always 0)
        /// PNO: same as PreparePick
        /// ZPOS : Z Position
        /// 0 : Bottom(Get)
        /// 1 : Top(Put)
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Extend_Dest(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD:PUTST:" + position + ",001,1,2";
                cmd = "$1MCR:RBETD:0," + position + ",1";
            }
            return cmd;
        }

        private void btnFoupRotRelease_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotDest())
            {
                string cmd = FoupRobot_Release_Dest(cbDestination.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (舊命令)$1CMD:PUTST:PNO,001,1,0[CR]
        /// (新指令)$1CMD:WRLS_:1,0[CR]
        /// (最新指令)$1MCR:RBRLS:MC[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Release_Dest(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD:PUTST:" + position + ",001,1,4";
                //cmd = "$1CMD:WRLS_:1,0";
                cmd = "$1MCR:RBRLS:0";
            }
            return cmd;
        }

        private void btnFoupRotRetractDest_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotDest())
            {
                string cmd = FoupRobot_Retract_Dest(cbDestination.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (舊命令)$1CMD:PUTST:PNO,001,1,0[CR]
        /// (新指令)$1CMD:RET__[CR]
        /// (最新指令)$1MCR:RET__:MC[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Retract_Dest(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD:PUTST:" + position + ",001,1,0";
                //cmd = "$1CMD:RET__";
                cmd = "$1MCR:RET__:0";
            }
            return cmd;
        }

        private void btnFoupRotDownDest_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotDest())
            {
                string cmd = FoupRobot_Down_Dest(cbDestination.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (舊命令)$1CMD:PUTST:PNO,001,1,0[CR]
        /// (新命令)$1MCR:RBDWN:MC[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Down_Dest(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$1CMD:PUTST:" + position + ",001,1,5";
                cmd = "$1MCR:RBDWN:0";
            }
            return cmd;
        }

        private void btnE1Auto_Click(object sender, EventArgs e)
        {
            showAutoDialog();
            ArrayList cmds = new ArrayList();
            cmds.Add(readRFID(Const.STK_ELPT1));//read rfid
            //load
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_ON));//clamp
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_ON));//open shutter
            cmds.Add(ELPT_Move(Const.STK_ELPT1, Const.POSITION_ELPT_STOCK_IN));//move in
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_OFF));//close shutter
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_OFF));//unclamp
            //unload
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_ON));//clamp
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_ON));//open shutter
            cmds.Add(ELPT_Move(Const.STK_ELPT1, Const.POSITION_ELPT_STOCK_OUT));//move out
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_OFF));//close shutter
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_OFF));//unclamp         
            ThreadPool.QueueUserWorkItem(new WaitCallback(sendCommands), cmds);
            //sendCommands(cmds);
        }
        private void sendCmds(Object obj)
        {
            sendCommands((ArrayList)obj);
        }

        private void btnE2Auto_Click(object sender, EventArgs e)
        {
            showAutoDialog();
            ArrayList cmds = new ArrayList();
            cmds.Add(readRFID(Const.STK_ELPT2));//read rfid
            //readRFID(Const.STK_ELPT2);
            //load
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_ON));//clamp
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_ON));//open shutter
            cmds.Add(ELPT_Move(Const.STK_ELPT2, Const.POSITION_ELPT_STOCK_IN));//move in
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_OFF));//close shutter
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_OFF));//unclamp
            //unload
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_ON));//clamp
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_ON));//open shutter
            cmds.Add(ELPT_Move(Const.STK_ELPT2, Const.POSITION_ELPT_STOCK_OUT));//move out
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_OFF));//close shutter
            //cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_OFF));//unclamp            
            sendCommands(cmds);
        }

        private void btnI1Auto_Click(object sender, EventArgs e)
        {
            showAutoDialog();
            ArrayList cmds = new ArrayList();
            cmds.Add(ILPT_Load(Const.STK_ILPT1));
            cmds.Add(ILPT_Unload(Const.STK_ILPT1));
            sendCommands(cmds);
        }

        private void btnFoupRotAuto_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotSrc() && checkFoupRobotDest())
            {
                showAutoDialog();
                ArrayList cmds = new ArrayList();
                //get source
                cmds.Add(FoupRobot_PrePick(cbSource.Text));//prepare pick
                cmds.Add(FoupRobot_Pick(cbSource.Text));//pick
                //put destination
                cmds.Add(FoupRobot_PrePlace(cbDestination.Text));//prepare place
                cmds.Add(FoupRobot_Place(cbDestination.Text));//place
                //home
                cmds.Add(FoupRobot_Home());//Home
                //get destination
                cmds.Add(FoupRobot_PrePick(cbDestination.Text));//prepare pick
                cmds.Add(FoupRobot_Pick(cbDestination.Text));//pick
                //put source
                cmds.Add(FoupRobot_PrePlace(cbSource.Text));//prepare place
                cmds.Add(FoupRobot_Place(cbSource.Text));//place
                //send commands
                sendCommands(cmds);
            }
        }

        private void btnI2Auto_Click(object sender, EventArgs e)
        {
            showAutoDialog();
            ArrayList cmds = new ArrayList();
            cmds.Add(ILPT_Load(Const.STK_ILPT2));
            cmds.Add(ILPT_Unload(Const.STK_ILPT2));
            sendCommands(cmds);
        }


        private void showAutoDialog()
        {
            return;
            //關閉主頁功能
            FormMainUpdate.SetFormEnable("FormMain", false);
            //FormUpdate.SetTextBoxEmpty("FormAuto", "tbMsg");
            //顯示自動功能
            FormAuto autoForm = new FormAuto();
            autoForm.Show();
        }

        private void btnFoupRotHome_Click(object sender, EventArgs e)
        {
            string cmd = FoupRobot_Home();
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private string FoupRobot_Home()
        {
            //string cmd = "$1CMD:HOME_";
            string cmd = "$1MCR:SHOME:0";
            return cmd;
        }

        private Boolean checkWHRAccessPort()
        {
            if (cbWHRSelctILPT.Text.Equals(""))
            {
                MessageBox.Show("請選擇 ILPT !");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnWHRMovePickPort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                string cmd = WHR_MovePick(ilpt, path);
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        //move to pick (get wait)
        private string WHR_MovePick(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$2CMD:GETST:" + position + ",001,1,1";
                cmd = "$2MCR:GETW_:0," + position + "," + mod;
            }
            return cmd;
        }

        /// <summary>
        /// PNO：301 = ILPT1-Clean, 302 = ILPT2-Clean, 303 = CTU-Clean
        ///      311 = ILPT1-Dirty, 312 = ILPT2-Dirty, 313 = CTU-Dirty
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string WHR_ACCESS_POSITION(string name)
        {
            string result = "";
            switch (name)
            {
                case Const.WHR_ILPT1_CLEAN:
                    //result = "301";
                    result = "1";//1: ILPT1, 2:ILPT2, 3:CTU
                    break;
                case Const.WHR_ILPT2_CLEAN:
                    //result = "302";
                    result = "2";//1: ILPT1, 2:ILPT2, 3:CTU
                    break;
                case Const.WHR_CTU_CLEAN:
                    //result = "303";
                    result = "3";//1: ILPT1, 2:ILPT2, 3:CTU
                    break;
                case Const.WHR_ILPT1_DIRTY:
                    //result = "311";
                    result = "1";//1: ILPT1, 2:ILPT2, 3:CTU
                    break;
                case Const.WHR_ILPT2_DIRTY:
                    //result = "312";
                    result = "2";//1: ILPT1, 2:ILPT2, 3:CTU
                    break;
                case Const.WHR_CTU_DIRTY:
                    //result = "313";
                    result = "3";//1: ILPT1, 2:ILPT2, 3:CTU
                    break;
            }
            return result;
        }

        /// <summary>
        /// POS：  0 = WHR   1 = PTZ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string CTU_ACCESS_POSITION(string name)
        {
            string result = "";
            switch (name)
            {
                case Const.DEVICE_WHR:
                    result = "0";
                    break;
                case Const.DEVICE_PTZ:
                    result = "1";
                    break;
            }
            return result;
        }

        /// <summary>
        /// MOD：   0 = Clean   1 = Dirty
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string CTU_ACCESS_PATH(string path)
        {
            string result = "";
            switch (path)
            {
                case Const.PATH_CLEAN:
                    result = "0";
                    break;
                case Const.PATH_DIRTY:
                    result = "1";
                    break;
            }
            return result;
        }

        /// <summary>
        /// ACT:    0: Prepare  1: Pick
        /// ACT:    0: Prepare  1: Place
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private string CTU_ACCESS_TYPE(string action)
        {
            string result = "";
            switch (action)
            {
                case Const.CTU_ACTION_PREPARE:
                    result = "0";
                    break;
                case Const.CTU_ACTION_PICK:
                    result = "1";
                    break;
                case Const.CTU_ACTION_PLACE:
                    result = "1";
                    break;
            }
            return result;
        }

        private void btnWHRMovePlacePort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                string cmd = WHR_MovePlace(ilpt, path);
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        //move to place(put wait)
        //$2MCR:PUTW_:MC,STN,MOD[CR]
        private string WHR_MovePlace(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$2CMD:PUTST:" + position + ",001,1,1";
                cmd = "$2MCR:PUTW_:0," + position + "," + mod;
            }

            return cmd;
        }

        private void btnWHRRetractPickPort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                //string cmd = WHR_RetractPick(ilpt, path);
                string cmd = WHR_Retract();
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        //private string WHR_RetractPick(string ilpt, string path)
        //{
        //    string cmd = "";
        //    string position = WHR_ACCESS_POSITION(ilpt + "-" + path);
        //    string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
        //    if (position != null && !position.Trim().Equals(""))
        //    {
        //        //cmd = "$2CMD:GETST:" + position + ",001,1,0";
        //        cmd = "$2CMD:RET__";
        //    }
        //    return cmd;
        //}

        private void btnWHRExtendPickPort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                string cmd = WHR_ExtendPick(ilpt, path);
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        /// <summary>
        /// $2MCR:EXTND:MC,STN,MOD,ZPOS[CR]
        /// ZPOS : Z Position   0 : Bottom(Get)    1 : Top(Put)
        /// </summary>
        /// <param name="device"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private string WHR_ExtendPick(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$2CMD:GETST:" + position + ",001,1,2";
                cmd = "$2MCR:EXTND:0," + position + "," + mod + ",0";
            }
            return cmd;
        }

        private void btnWHRUpPort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                //string cmd = WHR_UpPort(ilpt, path);
                string cmd = WHR_Up();
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        //private string WHR_UpPort(string ilpt, string path)
        //{
        //    string cmd = "";
        //    string position = WHR_ACCESS_POSITION(ilpt + "-" + path);
        //    if (position != null && !position.Trim().Equals(""))
        //    {
        //        cmd = "$2CMD:GETST:" + position + ",001,1,5";
        //    }
        //    return cmd;
        //}

        //$2MCR:UP___:MC[CR]
        private string WHR_Up()
        {
            string cmd = "$2MCR:UP___:0";
            return cmd;
        }
        //$2MCR:DOWN_:MC[CR]
        private string WHR_Down()
        {
            string cmd = "$2MCR:DOWN_:0";
            return cmd;
        }
        private void btnWHRDownPort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                //string cmd = WHR_DownPort(ilpt, path);
                string cmd = WHR_Down();
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        //private string WHR_DownPort(string ilpt, string path)
        //{
        //    string cmd = "";
        //    string position = WHR_ACCESS_POSITION(ilpt + "-" + path);
        //    if (position != null && !position.Trim().Equals(""))
        //    {
        //        cmd = "$2CMD:PUTST:" + position + ",001,1,5";
        //    }
        //    return cmd;
        //}

        private void btnWHRPickPort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                string cmd = WHR_PickPort(ilpt, path);
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        //$2MCR:GET__:MC,STN,MOD[CR]
        private string WHR_PickPort(string ilpt, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(ilpt + "-" + path);
            string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$2MCR:GETST:" + position + ",001,1,0";
                cmd = "$2MCR:GET__:0," + position + "," + mod;
            }
            return cmd;
        }

        private void btnWHRPlacePort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                string cmd = WHR_PlacePort(ilpt, path);
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        //$2MCR:PUT__:MC,STN,MOD[CR]
        private string WHR_PlacePort(string ilpt, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(ilpt + "-" + path);
            string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$2CMD:PUTST:" + position + ",001,1,0";
                cmd = "$2MCR:PUT__:0," + position + "," + mod;
            }
            return cmd;
        }

        private void btnWHRPortAuto_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                showAutoDialog();
                ArrayList cmds = new ArrayList();
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                //get from foup
                cmds.Add(WHR_MovePick(ilpt, path));//move to pick
                cmds.Add(WHR_PickPort(ilpt, path));//pick
                //Home
                cmds.Add(WHR_Home());//home
                //put to foup
                cmds.Add(WHR_MovePlace(ilpt, path));//move to place
                cmds.Add(WHR_PlacePort(ilpt, path));//place
                //send commands
                sendCommands(cmds);
            }
        }

        private void btnWHRExtendPlacePort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                string cmd = WHR_ExtendPlace(ilpt, path);
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        /// <summary>
        /// $2MCR:EXTND:MC,STN,MOD,ZPOS[CR]
        /// ZPOS : Z Position   0 : Bottom(Get)    1 : Top(Put)
        /// </summary>
        /// <param name="device"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private string WHR_ExtendPlace(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$2CMD:PUTST:" + position + ",001,1,2";
                cmd = "$2MCR:EXTND:0," + position + "," + mod + ",1";
            }
            return cmd;
        }

        private void btnWHRRetractPlacePort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                //string cmd = WHR_RetractPlace(ilpt, path);
                string cmd = WHR_Retract();
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        private string WHR_Retract()
        {
            //string cmd = "$2CMD:RET__";
            string cmd = "$2MCR:RET__:0";
            return cmd;
        }

        private string WHR_RetractPlace(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$2CMD:PUTST:" + position + ",001,1,0";
                cmd = "$2CMD:RET__";
            }
            return cmd;
        }

        private void btnWHRHome_Click(object sender, EventArgs e)
        {
            string cmd = WHR_Home();
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private string WHR_Home()
        {
            //string cmd = "$2CMD:HOME_";
            string cmd = "$2MCR:SHOME:0";
            return cmd;
        }

        private void btnCTUPreparePickWHR_1_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_WHR;//CTU 對 WHR 動作
            string action = Const.CTU_ACTION_PREPARE;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_PICK(device, path, action);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        /// <summary>
        /// $3MCR:CTGET:MC,POS,MOD,ACT[CR]
        /// MC：Macro Container(Always 1)
        /// POS：   0 = WHR      1 = PTZ
        /// MOD：   0 = Clean    1 = Dirty
        /// ACT:    0 = Prepare  1 = Pick
        /// </summary>
        /// <param name="device"></param>
        /// <param name="path"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private string CTU_PICK(string device, string path, string action)
        {
            string cmd = "";
            string POS = CTU_ACCESS_POSITION(device);
            string MOD_PATH = CTU_ACCESS_PATH(path);
            string ACT_TYPE = CTU_ACCESS_TYPE(action);

            if (POS != null && !POS.Trim().Equals("")
                && MOD_PATH != null && !MOD_PATH.Trim().Equals("")
                && ACT_TYPE != null && !ACT_TYPE.Trim().Equals(""))
            {
                cmd = "$3MCR:CTGET:1," + POS + "," + MOD_PATH + "," + ACT_TYPE;
            }
            return cmd;
        }

        private void btnCTUPreparePlaceWHR_1_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_WHR;//CTU 對 WHR 動作
            string action = Const.CTU_ACTION_PREPARE;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_PLACE(device, path, action);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }
        /// <summary>
        /// $3MCR:CTPUT:MC,POS,MOD,ACT
        /// MC：Macro Container(Always 1)
        /// POS：   0 = WHR      1 = PTZ
        /// MOD：   0 = Clean    1 = Dirty
        /// ACT:    0 = Prepare  1 = Pick
        /// </summary>
        /// <param name="device"></param>
        /// <param name="path"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private string CTU_PLACE(string device, string path, string action)
        {
            string cmd = "";
            string POS = CTU_ACCESS_POSITION(device);
            string MOD_PATH = CTU_ACCESS_PATH(path);
            string ACT_TYPE = CTU_ACCESS_TYPE(action);

            if (POS != null && !POS.Trim().Equals("")
                && MOD_PATH != null && !MOD_PATH.Trim().Equals("")
                && ACT_TYPE != null && !ACT_TYPE.Trim().Equals(""))
            {
                cmd = "$3MCR:CTPUT:1," + POS + "," + MOD_PATH + "," + ACT_TYPE;
            }
            return cmd;
        }
        private void btnWHRMovePickCTU_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHR_MovePick(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRMovePlaceCTU_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHR_MovePlace(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRExtendPickCTU_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHR_ExtendPick(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRExtendPlaceCTU_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHR_ExtendPlace(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRRetractPickCTU_Click(object sender, EventArgs e)
        {
            //string device = Const.DEVICE_CTU;
            //string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            //string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            ////string cmd = WHR_RetractPick(device, path);
            string cmd = WHR_Retract();
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRRetractPlaceCTU_Click(object sender, EventArgs e)
        {
            string cmd = WHR_Retract();
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRToPickCTU_1_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHRToPickCTU(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private string WHRToPickCTU(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$2CMD:GETST:" + position + ",001,1,3";
                cmd = "$2MCR:EXTND:0," + position + "," + mod + ",1";

            }
            return cmd;
        }

        private void btnWHRToPlaceCTU_1_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHRToPlaceCTU(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private string WHRToPlaceCTU(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            if (position != null && !position.Trim().Equals(""))
            {
                //cmd = "$2CMD:PUTST:" + position + ",001,1,3";
                cmd = "$2MCR:EXTND:0," + position + "," + mod + ",1";
            }
            return cmd;
        }

        private void btnCTUReleaseWHR_1_Click(object sender, EventArgs e)
        {
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_Release(path);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        /// <summary>
        /// $3MCR:CTRLS:MC,MOD[CR]
        /// MC：Macro Container(Always 1)
        /// MOD : 0 = Clean  1 = Dirty
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string CTU_Release(string path)
        {
            string cmd = "";
            string MOD_PATH = CTU_ACCESS_PATH(path);

            if (MOD_PATH != null && !MOD_PATH.Trim().Equals(""))
            {
                cmd = "$3MCR:CTRLS:1," + MOD_PATH;
            }
            return cmd;
        }

        private void btnCTUGrabWHR_1_Click(object sender, EventArgs e)
        {
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_Grab(path);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        /// <summary>
        /// $3MCR:CTHLD:MC,MOD[CR]
        /// MC：Macro Container(Always 1)
        /// MOD : 0 = Clean  1 = Dirty
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string CTU_Grab(string path)
        {
            string cmd = "";
            string MOD_PATH = CTU_ACCESS_PATH(path);

            if (MOD_PATH != null && !MOD_PATH.Trim().Equals(""))
            {
                cmd = "$3MCR:CTHLD:1," + MOD_PATH;
            }
            return cmd;
        }

        private void btnWHRCompPickCTU_1_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHRCompPickCTU(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private string WHRCompPickCTU(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:GETST:" + position + ",001,1,0";
            }
            return cmd;
        }

        private void btnWHRCompPlaceCTU_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHRCompPlaceCTU(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private string WHRCompPlaceCTU(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            string mod = path.Equals(Const.PATH_CLEAN) ? "0" : "1";
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:PUTST:" + position + ",001,1,0";
            }
            return cmd;
        }

        private void btnWHRCTUAuto_Click(object sender, EventArgs e)
        {
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string prepare = Const.CTU_ACTION_PREPARE;
            string whr = Const.DEVICE_WHR;
            string ctu = Const.DEVICE_CTU;

            showAutoDialog();
            ArrayList cmds = new ArrayList();
            //WHR Place(PUT)
            cmds.Add(CTU_PICK(whr, path, prepare));//CTU prepare pick
            cmds.Add(WHR_MovePlace(ctu, path));//WHR move to place
            cmds.Add(WHR_ExtendPlace(ctu, path));//WHR Extend(Place)
            //cmds.Add(WHRToPlaceCTU(ctu, path));//WHR to Place
            cmds.Add(CTU_Grab(path));//CTU Grab
            //cmds.Add(WHRCompPlaceCTU(ctu, path));//CTU Complete Place
            cmds.Add(WHR_Down());//down
            cmds.Add(WHR_Retract());//retract
            cmds.Add(WHR_Home());//WHR Home

            //WHR Pick(GET)
            cmds.Add(CTU_PLACE(whr, path, prepare));//CTU prepare place
            cmds.Add(WHR_MovePick(ctu, path));//WHR move to pick
            cmds.Add(WHR_ExtendPick(ctu, path));//WHR Extend(Pick)
            cmds.Add(WHR_Up());//Up
            //cmds.Add(WHRToPickCTU(ctu, path));//WHR to Pick
            cmds.Add(CTU_Release(path));//CTU Release
            //cmds.Add(WHRCompPickCTU(ctu, path));//CTU Complete Pick
            cmds.Add(WHR_Retract());//retract
            cmds.Add(WHR_Home());//WHR Home

            //send commands
            sendCommands(cmds);
        }

        private void btnWHRAuto_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                showAutoDialog();
                ArrayList cmds = new ArrayList();
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                string prepare = Const.CTU_ACTION_PREPARE;
                string whr = Const.DEVICE_WHR;
                string ctu = Const.DEVICE_CTU;

                //Get from foup
                cmds.Add(WHR_MovePick(ilpt, path));//move to pick
                cmds.Add(WHR_PickPort(ilpt, path));//pick

                //WHR Place(PUT)
                cmds.Add(CTU_PICK(whr, path, prepare));//CTU prepare pick
                cmds.Add(WHR_MovePlace(ctu, path));//WHR move to place
                cmds.Add(WHR_ExtendPlace(ctu, path));//WHR Extend(Place)
                cmds.Add(CTU_Grab(path));//CTU Grab
                cmds.Add(WHR_Down());//down
                cmds.Add(WHR_Retract());//retract
                cmds.Add(WHR_Home());//WHR Home

                //WHR Pick(GET)
                cmds.Add(CTU_PLACE(whr, path, prepare));//CTU prepare place
                cmds.Add(WHR_MovePick(ctu, path));//WHR move to pick
                cmds.Add(WHR_ExtendPick(ctu, path));//WHR Extend(Pick)
                cmds.Add(WHR_Up());//Up
                cmds.Add(CTU_Release(path));//CTU Release
                cmds.Add(WHR_Retract());//retract
                cmds.Add(WHR_Home());//WHR Home

                //put to foup
                cmds.Add(WHR_MovePlace(ilpt, path));//move to place
                cmds.Add(WHR_PlacePort(ilpt, path));//place

                //send commands
                sendCommands(cmds);
            }
        }

        private void PTZDir_CheckedChanged(object sender, EventArgs e)
        {
            //resetPtzDir();
        }

        private void resetPtzPosition()
        {
            if (this.rbPTZPosOdd.Checked == true)
            {
                btnPTZMoveCTU_1.Text = "Prepare or Transfer(Odd)";
                btnPTZMoveCTU_2.Text = "Prepare or Transfer(Odd)*";
                ptzPos = new string[2] { "Odd", "Odd" };
            }
            else if (this.rbPTZPosEven.Checked == true)
            {
                btnPTZMoveCTU_1.Text = "Prepare or Transfer(Even)";
                btnPTZMoveCTU_2.Text = "Prepare or Transfer(Even)*";
                ptzPos = new string[2] { "Even", "Even" };
            }
            else if (this.rbPTZPosAuto.Checked == true)
            {
                btnPTZMoveCTU_1.Text = "Prepare or Transfer(Odd)";
                btnPTZMoveCTU_2.Text = "Prepare or Transfer(Odd)*";
                ptzPos = new string[2] { "Odd", "Even" };
            }
            else if (this.rbPTZPosHome.Checked == true)
            {
                btnPTZMoveCTU_1.Text = "Prepare or Transfer(Home)";
                btnPTZMoveCTU_2.Text = "Prepare or Transfer(Home)*";
                ptzPos = new string[2] { "Home", "Home" };
            }
            posIdx = 0; //reset index
        }

        //private void resetPtzDir()
        //{
        //    if (this.rbPTZDirFace.Checked == true)
        //    {
        //        btnPTZRotate.Text = "Rotate(Face)";
        //        ptzDir = new string[2] { "Face", "Face" };
        //    }
        //    else if (this.rbPTZDirFaceBack.Checked == true)
        //    {
        //        btnPTZRotate.Text = "Rotate(Face)";
        //        ptzDir = new string[2] { "Face", "Back" };
        //    }
        //    else if (this.rbPTZDirBack.Checked == true)
        //    {
        //        btnPTZRotate.Text = "Rotate(Back)";
        //        ptzDir = new string[2] { "Back", "Back" };
        //    }
        //    else if (this.rbPTZDirBackFace.Checked == true)
        //    {
        //        btnPTZRotate.Text = "Rotate(Back)";
        //        ptzDir = new string[2] { "Back", "Face" };
        //    }
        //    dirIdx = 0; //reset index
        //}

        private void btnPTZRotate_Click(object sender, EventArgs e)
        {
            //string dir = ptzDir[dirIdx];
            //dirIdx = (dirIdx + 1) % 2;
            //btnPTZRotate.Text = "Rotate(" + ptzDir[dirIdx] + ")";
            //string cmd = PTZ_Rotate(ptzDir[dirIdx]);
            string cmd = PTZ_Rotate(cbRotateDir.Text);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        /// <summary>
        /// $3MCR:PTRAT:MC,DIR[CR]
        /// MC：Macro Container(Always 2)      
        /// DIR : 0 = Face ,1 = Back
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        private string PTZ_Rotate(string dir)
        {
            string cmd = "";
            string direction = dir.Equals(Const.PTZ_DIRECTION_FACE) ? "0" : "1";
            cmd = "$3MCR:PTRAT:2," + direction;
            return cmd;
        }

        private void btnPTZMoveCTU_Click(object sender, EventArgs e)
        {
            string pos = ptzPos[posIdx];
            posIdx = (posIdx + 1) % 2;
            btnPTZMoveCTU_1.Text = "Prepare or Transfer(" + ptzPos[posIdx] + ")";
            btnPTZMoveCTU_2.Text = "Prepare or Transfer(" + ptzPos[posIdx] + ")*";
            //string dir = ptzDir[dirIdx];
            //dirIdx = (dirIdx + 1) % 2;
            //btnPTZRotate.Text = "Rotate(" + ptzDir[dirIdx] + ")";
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            //20181225 修改 for 方向參數調整 Start
            //string cmd = PTZ_Move_CTU(pos, ptzDir[dirIdx], path);
            string direction = "";
            if (rbPTZDirBackFace.Checked)
                direction = rbPTZDirBackFace.Text;
            else if (rbPTZDirFaceBack.Checked)
                direction = rbPTZDirFaceBack.Text;
            else if (rbPTZDirBack.Checked)
                direction = rbPTZDirBack.Text;
            else if (rbPTZDirFace.Checked)
                direction = rbPTZDirFace.Text;
            string cmd = PTZ_Move_CTU(pos, direction, path);
            //20181225 修改 for 方向參數調整 End
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        /// <summary>
        /// $3MCR:PTTSF:MC,POS,DIR,MOD[CR]	"PTZ移動至指定接收 Wafer 位置(需要兩個指令)
        /// Odd/Even(SET RELIO)/需要不斷monitor到位sensor的狀態
        /// MC：Macro Container(Always 2)
        /// POS : 0 = Odd   1 = Even
        /// DIR : 0 = Face  1 = Back
        /// MOD : 0 = Clean 1 = Dirty"
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        private string PTZ_Move_CTU(string pos, string dir, string mod)
        {
            string cmd = "";
            string position = "";
            if (pos.Equals(Const.PTZ_POSITION_ODD))
            {
                position = "0";
            }
            else if (pos.Equals(Const.PTZ_POSITION_EVEN))
            {
                position = "1";
            }
            else if (pos.Equals(Const.PTZ_POSITION_HOME))
            {
                position = "2";
            }
            //string direction = dir.Equals(Const.PTZ_DIRECTION_FACE) ? "0" : "1";
            string direction = dir.Substring(0, 1);//20181225 修改 for 方向參數調整
            string path = mod.Equals(Const.PATH_CLEAN) ? "0" : "1";
            cmd = "$3MCR:PTTSF:2," + position + "," + direction + "," + path;
            return cmd;
        }

        private void PTZPos_CheckedChanged(object sender, EventArgs e)
        {
            resetPtzPosition();
        }

        private void btnPTZMoveHome_Click(object sender, EventArgs e)
        {
            string cmd = PTZ_Move_Home("PTR");
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        /// <summary>
        /// $3MCR: PTMOV: MC,POS[CR]  "PTZ移動至指定位置
        /// MC：Macro Container(Always 2)
        /// POS: 0 = Home(PTR) 1 = CTU(Odd) 2 = CTU(Even)"
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private string PTZ_Move_Home(string pos)
        {
            string position = "";
            if (pos.Equals(Const.PTZ_POSITION_PTR))
            {
                position = "0";
            }
            else if (pos.Equals(Const.PTZ_POSITION_ODD))
            {
                position = "1";
            }
            else if (pos.Equals(Const.PTZ_POSITION_EVEN))
            {
                position = "2";
            }
            string cmd = "";
            //cmd = "$3MCR:PTMOV:2," + position;
            cmd = "$3MCR:PTHME:2";//調整命令
            return cmd;
        }

        private void btnPTZGetSlotMap_Click(object sender, EventArgs e)
        {
            string cmd = PTZ_GET_MAP();
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void btnPTZAuto_Click(object sender, EventArgs e)
        {
            showAutoDialog();
            ArrayList cmds = new ArrayList();
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string direction = "";
            if (rbPTZDirBackFace.Checked)
                direction = rbPTZDirBackFace.Text;
            else if (rbPTZDirFaceBack.Checked)
                direction = rbPTZDirFaceBack.Text;
            else if (rbPTZDirBack.Checked)
                direction = rbPTZDirBack.Text;
            else if (rbPTZDirFace.Checked)
                direction = rbPTZDirFace.Text;
            //Pick(GET)
            cmds.Add(PTZ_Move_CTU(ptzPos[0], direction, path));//transfer 1st time
            cmds.Add(PTZ_Move_Home("PTR"));//home
            cmds.Add(PTZ_Move_CTU(ptzPos[1], direction, path));//transfer 2nd time
            cmds.Add(PTZ_Move_Home("PTR"));//home
            //send commands
            sendCommands(cmds);
        }

        private string PTZ_GET_MAP()
        {
            string cmd = "";
            cmd = "$3GET: MAP__";
            return cmd;
        }

        /// <summary>
        /// "Wafer Align
        /// MC：Macro Container(Always 3)
        /// DEG : 0~359000 (Degree* 1000)"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlign_Click(object sender, EventArgs e)
        {
            if (tbDegree.Text.Trim().Equals(""))
            {
                MessageBox.Show("請先輸入角度 !");
                tbDegree.Focus();
                return;
            }
            int DEG = int.Parse(tbDegree.Text) * 1000;
            string cmd = "$3MCR:ALIGN:3," + DEG;
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void tbDegree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)48 || e.KeyChar == (Char)49 ||
               e.KeyChar == (Char)50 || e.KeyChar == (Char)51 ||
               e.KeyChar == (Char)52 || e.KeyChar == (Char)53 ||
               e.KeyChar == (Char)54 || e.KeyChar == (Char)55 ||
               e.KeyChar == (Char)56 || e.KeyChar == (Char)57 ||
               e.KeyChar == (Char)13 || e.KeyChar == (Char)8 || e.KeyChar == (Char)45)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnCTUPreparePickWHR_2_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_WHR;//CTU 對 WHR 動作
            string action = Const.CTU_ACTION_PREPARE;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_PICK(device, path, action);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void btnCTUPreparePlaceWHR_2_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_WHR;//CTU 對 WHR 動作
            string action = Const.CTU_ACTION_PREPARE;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_PLACE(device, path, action);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void btnWHRToPickCTU_2_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHRToPickCTU(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRToPlaceCTU_2_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHRToPlaceCTU(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnCTUReleaseWHR_2_Click(object sender, EventArgs e)
        {
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_Release(path);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void btnCTUGrabWHR_2_Click(object sender, EventArgs e)
        {
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_Grab(path);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void btnWHRCompPickCTU_2_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHRCompPickCTU(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRCompPlaceCTU_2_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHRCompPlaceCTU(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnCTUAutoWHR_Click(object sender, EventArgs e)
        {
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string prepare = Const.CTU_ACTION_PREPARE;
            string whr = Const.DEVICE_WHR;
            string ctu = Const.DEVICE_CTU;

            showAutoDialog();
            ArrayList cmds = new ArrayList();
            //WHR Place(PUT)
            cmds.Add(CTU_PICK(whr, path, prepare));//CTU prepare pick
            cmds.Add(WHR_MovePlace(ctu, path));//WHR move to place
            cmds.Add(WHR_ExtendPlace(ctu, path));//WHR Extend(Place)
            //cmds.Add(WHRToPlaceCTU(ctu, path));//WHR to Place
            cmds.Add(CTU_Grab(path));//CTU Grab
            //cmds.Add(WHRCompPlaceCTU(ctu, path));//CTU Complete Place
            cmds.Add(WHR_Down());//down
            cmds.Add(WHR_Retract());//retract
            cmds.Add(WHR_Home());//WHR Home

            //WHR Pick(GET)
            cmds.Add(CTU_PLACE(whr, path, prepare));//CTU prepare place
            cmds.Add(WHR_MovePick(ctu, path));//WHR move to pick
            cmds.Add(WHR_ExtendPick(ctu, path));//WHR Extend(Pick)
            cmds.Add(WHR_Up());//Up
            //cmds.Add(WHRToPickCTU(ctu, path));//WHR to Pick
            cmds.Add(CTU_Release(path));//CTU Release
            //cmds.Add(WHRCompPickCTU(ctu, path));//CTU Complete Pick
            cmds.Add(WHR_Retract());//retract
            cmds.Add(WHR_Home());//WHR Home

            //send commands
            sendCommands(cmds);
        }

        private void btnCTUHome_Click(object sender, EventArgs e)
        {
            string cmd = CTU_HOME();
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private string CTU_HOME()
        {
            string cmd = "$3MCR:CTHOM:1";
            return cmd;
        }

        private void btnCTUPreparePickPTZ_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_PTZ;//CTU 對 PTZ 動作
            string action = Const.CTU_ACTION_PREPARE;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_PICK(device, path, action);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void btnCTUPreparePlacePTZ_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_PTZ;//CTU 對 PTZ 動作
            string action = Const.CTU_ACTION_PREPARE;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_PLACE(device, path, action);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void btnCTUPickPTZ_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_PTZ;//CTU 對 PTZ 動作
            string action = Const.CTU_ACTION_PICK;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_PICK(device, path, action);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void btnCTUPlacePTZ_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_PTZ;//CTU 對 PTZ 動作
            string action = Const.CTU_ACTION_PLACE;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_PLACE(device, path, action);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void btnCTUAutoPTZ_Click(object sender, EventArgs e)
        {
            string prepare = Const.CTU_ACTION_PREPARE;
            string pick = Const.CTU_ACTION_PICK;
            string place = Const.CTU_ACTION_PLACE;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string device = Const.DEVICE_PTZ;//CTU 對 PTZ 動作

            showAutoDialog();
            ArrayList cmds = new ArrayList();

            string direction = "";
            if (rbPTZDirBackFace.Checked)
                direction = rbPTZDirBackFace.Text;
            else if (rbPTZDirFaceBack.Checked)
                direction = rbPTZDirFaceBack.Text;
            else if (rbPTZDirBack.Checked)
                direction = rbPTZDirBack.Text;
            else if (rbPTZDirFace.Checked)
                direction = rbPTZDirFace.Text;

            //Put to PTZ 1st time
            cmds.Add(CTU_PLACE(device, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], direction, path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PLACE(device, path, place));//CTU put to PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home
            //Put to PTZ 2nd time
            cmds.Add(CTU_PLACE(device, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[1], direction, path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PLACE(device, path, place));//CTU put to PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home
            //GET from PTZ 1st time
            cmds.Add(CTU_PICK(device, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], direction, path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PICK(device, path, pick));//CTU get from PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home
            //GET from PTZ 2nd time
            cmds.Add(CTU_PICK(device, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], direction, path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PICK(device, path, pick));//CTU get fromPTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home

            //send commands
            sendCommands(cmds);
        }

        private void btnCTUAuto_Click(object sender, EventArgs e)
        {
            //string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string path = "";
            string prepare = Const.CTU_ACTION_PREPARE;
            string pick = Const.CTU_ACTION_PICK;
            string place = Const.CTU_ACTION_PLACE;
            string ptz = Const.DEVICE_PTZ;
            string whr = Const.DEVICE_PTZ;
            string ctu = Const.DEVICE_CTU;

            showAutoDialog();
            ArrayList cmds = new ArrayList();


            string direction = "";
            if (rbPTZDirBackFace.Checked)
                direction = rbPTZDirBackFace.Text;
            else if (rbPTZDirFaceBack.Checked)
                direction = rbPTZDirFaceBack.Text;
            else if (rbPTZDirBack.Checked)
                direction = rbPTZDirBack.Text;
            else if (rbPTZDirFace.Checked)
                direction = rbPTZDirFace.Text;

            /**********************************  Dirty:1st 取片加工 **********************************/
            path = Const.PATH_DIRTY;
            //WHR put wafer to CTU 
            cmds.Add(CTU_PICK(whr, path, prepare));//CTU prepare pick for WHR place
            cmds.Add(WHR_MovePlace(ctu, path));//WHR move to place
            cmds.Add(WHR_ExtendPlace(ctu, path));//WHR Extend(Place)
            cmds.Add(CTU_Grab(path));//CTU Grab
            cmds.Add(WHR_Down());//down
            cmds.Add(WHR_Retract());//retract
            cmds.Add(WHR_Home());//WHR Home
            //CTU Put wafer to PTZ 
            cmds.Add(CTU_PLACE(ptz, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], direction, path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PLACE(ptz, path, place));//CTU put to PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            //cmds.Add(CTU_HOME());//CTU move Home
            /**********************************  Dirty:2nd 取片加工 **********************************/
            //WHR put wafer to CTU 
            cmds.Add(CTU_PICK(whr, path, prepare));//CTU prepare pick for WHR place
            cmds.Add(WHR_MovePlace(ctu, path));//WHR move to place
            cmds.Add(WHR_ExtendPlace(ctu, path));//WHR Extend(Place)
            cmds.Add(CTU_Grab(path));//CTU Grab
            cmds.Add(WHR_Down());//down
            cmds.Add(WHR_Retract());//retract
            cmds.Add(WHR_Home());//WHR Home
            //cmds.Add(CTU_HOME());//CTU move Home  
            //CTU Put wafer to PTZ 
            cmds.Add(CTU_PLACE(ptz, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[1], direction, path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PLACE(ptz, path, place));//CTU put to PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            //cmds.Add(CTU_HOME());//CTU move Home
            /**********************************  Clean:1st 完工取片 **********************************/
            path = Const.PATH_CLEAN;
            //CTU GET wafer from PTZ
            cmds.Add(CTU_PICK(ptz, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], direction, path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PICK(ptz, path, pick));//CTU get from PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            //cmds.Add(CTU_HOME());//CTU move Home
            //WHR Get Wafer from CTU
            cmds.Add(CTU_PLACE(whr, path, prepare));//CTU prepare place
            cmds.Add(WHR_MovePick(ctu, path));//WHR move to pick
            cmds.Add(WHR_ExtendPick(ctu, path));//WHR Extend(Pick)
            cmds.Add(WHR_Up());//Up
            cmds.Add(CTU_Release(path));//CTU Release
            cmds.Add(WHR_Retract());//retract
            cmds.Add(WHR_Home());//WHR Home

            /**********************************  Clean:2nd 完工取片 **********************************/
            //CTU GET wafer from PTZ
            cmds.Add(CTU_PICK(ptz, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[1], direction, path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PICK(ptz, path, pick));//CTU get from PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home
            //WHR Get Wafer from CTU
            cmds.Add(CTU_PLACE(whr, path, prepare));//CTU prepare place
            cmds.Add(WHR_MovePick(ctu, path));//WHR move to pick
            cmds.Add(WHR_ExtendPick(ctu, path));//WHR Extend(Pick)
            cmds.Add(WHR_Up());//Up
            cmds.Add(CTU_Release(path));//CTU Release
            cmds.Add(WHR_Retract());//retract
            cmds.Add(WHR_Home());//WHR Home

            //send commands
            sendCommands(cmds);
        }

        private void btnClearMsg_Click(object sender, EventArgs e)
        {
            rtbMsg.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (cbCmd.Text.Trim().Equals(""))
                FormMainUpdate.ShowMessage("Command text is empty.");
            else
            {
                sendCommand(cbCmd.Text);
            }
        }

        private void btnPTZReset_Click(object sender, EventArgs e)
        {
            ResetController(Const.CONTROLLER_CTU_PTZ);
        }

        private void ResetController(string device)
        {
            string address = "";
            switch (device)
            {
                case Const.CONTROLLER_STK:
                    address = "1";
                    break;
                case Const.CONTROLLER_WHR:
                    address = "2";
                    break;
                case Const.CONTROLLER_CTU_PTZ:
                    address = "3";
                    break;
            }
            string cmd = "$" + address + "SET:RESET";
            sendCommand(cmd);
        }

        private void btnCTUReset_Click(object sender, EventArgs e)
        {
            ResetController(Const.CONTROLLER_CTU_PTZ);
        }

        private void btnAddScript_Click(object sender, EventArgs e)
        {
            if (cbCmd.Text.Trim().Equals(""))
            {
                FormMainUpdate.ShowMessage("No command data!");
                return;
            }

            dgvCmdScript.DataSource = null;
            Command.addScriptCmd(cbCmd.Text);
            FormMainUpdate.refreshScriptSet();
        }



        private Boolean checkSelctData()
        {
            Boolean result = false;
            try
            {
                if (dgvCmdScript.RowCount == 0)
                {
                    FormMainUpdate.ShowMessage("No data exists!");
                    return result;
                }
                if (dgvCmdScript.CurrentCell == null)
                {
                    FormMainUpdate.ShowMessage("Please select one row!");
                    return result;
                }
                if (isScriptRunning)
                {
                    FormMainUpdate.ShowMessage("Script is running , please stop it first!");
                    return result;
                }
                result = true;
            }
            catch (Exception e)
            {
                FormMainUpdate.ShowMessage(e.Message);
                //logger.Info(e.StackTrace);
            }
            return result;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (!checkSelctData())
                return;
            int idx = dgvCmdScript.CurrentCell.RowIndex;
            try
            {
                if (idx > 0)
                {
                    CmdScript preItem = Command.getCmdList().FirstOrDefault(predicate: d => d.Seq == idx);
                    CmdScript selItem = Command.getCmdList().FirstOrDefault(predicate: d => d.Seq == idx + 1);
                    preItem.Seq = idx + 1; // change sequence
                    selItem.Seq = idx;
                    Command.oCmdScript = new BindingList<CmdScript>(Command.oCmdScript.OrderBy(x => x.Seq).ToList());
                    dgvCmdScript.DataSource = Command.oCmdScript;
                    dgvCmdScript.ClearSelection();
                    dgvCmdScript.CurrentCell = dgvCmdScript.Rows[idx - 1].Cells[0];
                    dgvCmdScript.Rows[idx - 1].Selected = true;
                }
            }
            catch (Exception ex)
            {
                FormMainUpdate.ShowMessage(ex.Message + ":" + ex.ToString());
            }
        }

        private void setSelectRow(int idx)
        {
            dgvCmdScript.ClearSelection();
            if (dgvCmdScript.RowCount <= 0)
                return;
            else if (dgvCmdScript.RowCount == 1)
                idx = 0;//only one record 
            else if (idx >= dgvCmdScript.RowCount)
                idx = dgvCmdScript.RowCount - 1;//idx more than last 
            dgvCmdScript.CurrentCell = dgvCmdScript.Rows[idx].Cells[0];
            dgvCmdScript.Rows[idx].Selected = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (!checkSelctData())
                return;
            int idx = dgvCmdScript.CurrentCell.RowIndex;
            try
            {
                if (idx < dgvCmdScript.RowCount - 1)
                {
                    CmdScript nexItem = Command.getCmdList().FirstOrDefault(predicate: d => d.Seq == idx + 2);
                    CmdScript selItem = Command.getCmdList().FirstOrDefault(predicate: d => d.Seq == idx + 1);
                    nexItem.Seq = idx + 1; // change sequence
                    selItem.Seq = idx + 2;
                    Command.oCmdScript = new BindingList<CmdScript>(Command.oCmdScript.OrderBy(x => x.Seq).ToList());
                    dgvCmdScript.DataSource = Command.oCmdScript;
                    setSelectRow(idx + 1);
                }
            }
            catch (Exception ex)
            {
                FormMainUpdate.ShowMessage(ex.Message + ":" + ex.ToString());
            }
        }

        private void btnStepRun_Click(object sender, EventArgs e)
        {
            if (!checkSelctData())
                return;

            int idx = dgvCmdScript.CurrentCell.RowIndex;
            string cmd = (string)dgvCmdScript.Rows[idx].Cells["Command"].Value;
            sendCommand(cmd);
            //change index
            if (idx < dgvCmdScript.RowCount - 1)
            {
                setSelectRow(idx + 1);
            }
            else
            {
                setSelectRow(0);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!checkSelctData())
                return;
            string msg = "Are you sure to delete this item?";
            DialogResult confirm = MessageBox.Show(msg, "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (confirm != System.Windows.Forms.DialogResult.Yes)
                return;

            int idx = dgvCmdScript.CurrentCell.RowIndex;
            int delSeq = idx + 1;
            Command.oCmdScript.RemoveAt(idx);
            foreach (CmdScript element in Command.oCmdScript)
            {
                if (element.Seq > delSeq)
                    element.Seq--;
            }
            Command.oCmdScript = new BindingList<CmdScript>(Command.oCmdScript.OrderBy(x => x.Seq).ToList());
            dgvCmdScript.DataSource = Command.oCmdScript;
            setSelectRow(idx);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1;
            StreamReader myStream = null;

            try
            {
                openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "json files (*.json)|*.json";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string line = string.Empty;
                    tbScriptDesc.Text = openFileDialog1.SafeFileName.Replace(".json", "");
                    using (myStream = new StreamReader(openFileDialog1.FileName))
                    {
                        line = myStream.ReadToEnd();
                    }

                    Command.oCmdScript = (BindingList<CmdScript>)Newtonsoft.Json.JsonConvert.DeserializeObject(line, (typeof(BindingList<CmdScript>)));
                    FormMainUpdate.refreshScriptSet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception Message", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvCmdScript.Rows.Count == 0)
            {
                return;
            }

            SaveFileDialog saveFileDialog1;
            StreamWriter sw;

            try
            {
                saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Save file";
                saveFileDialog1.InitialDirectory = ".\\";
                saveFileDialog1.Filter = "json files (*.json)|*.json";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    sw = new StreamWriter(saveFileDialog1.FileName.ToString());

                    sw.WriteLine(JsonConvert.SerializeObject(Command.oCmdScript, Formatting.Indented));

                    sw.Close();

                    MessageBox.Show("Done it.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception Message", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void loadScript(string filename, object sender, EventArgs e)
        {
            StreamReader myStream = null;
            string line = string.Empty;

            using (myStream = new StreamReader(filename))
            {
                line = myStream.ReadToEnd();
            }

            Command.oCmdScript = (BindingList<CmdScript>)Newtonsoft.Json.JsonConvert.DeserializeObject(line, (typeof(BindingList<CmdScript>)));
            FormMainUpdate.refreshScriptSet();
            //btnScriptRun_Click(sender, e);
        }
        private void btnInitAll_Click(object sender, EventArgs e)
        {
            tbTimes.Text = "1";
            loadScript("wts_init.json", sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbTimes.Text = "1";
            loadScript("wts_reset.json", sender, e);
        }

        private void btnAutoRun_Click(object sender, EventArgs e)
        {
            tbTimes.Text = "99999";
            loadScript("wts_run.json", sender, e);
        }

        private void btnScriptRun_Click(object sender, EventArgs e)
        {
            if (dgvCmdScript.RowCount == 0)
            {
                FormMainUpdate.ShowMessage("No data exists!");
                return;
            }
            isScriptRunning = false;//取消 Script 執行中
            Thread.Sleep(300);
            setIsRunning(true);//set Script 執行中
            isScriptRunning = true;//set Script 執行中
            ThreadPool.QueueUserWorkItem(new WaitCallback(runScript));
        }

        private void updateCont(object data)
        {
            FormMainUpdate.CounterUpdate(data.ToString());
        }
        private void updateLog(object data)
        {
            FormMainUpdate.Log(data.ToString());
            FormMainUpdate.LogUpdate(data.ToString());
        }

        private void logUpdate(string log)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(updateLog), log);
        }

        private void runScript(object data)
        {
            int repeatTimes = 0;
            int.TryParse(tbTimes.Text, out repeatTimes);
            TakeTimeInfo timeInfo = new TakeTimeInfo(tbScriptDesc.Text, repeatTimes, Command.oCmdScript.Count);//20191212 add take time 紀錄
            //The efem motion is not allowed when the alarm occurs,please reset alarm first.
            int cnt = 1;
            while (cnt <= repeatTimes && !FormMainUpdate.isAlarmSet && isScriptRunning)
            {
                Thread.Sleep(20);//讓畫面有時間更新, 順序不錯亂
                FormMainUpdate.Log("**************  Run Script: " + cnt + "  **************");
                FormMainUpdate.LogUpdate("\n**************  Run Script: " + cnt + "  **************");//不另起多執行緒
                //logUpdate("\n**************  Run Script: " + cnt + "  **************");
                ThreadPool.QueueUserWorkItem(new WaitCallback(updateCont), cnt);
                int stepIdx = 1;//20191212 add take time 紀錄
                foreach (CmdScript element in Command.oCmdScript)
                {
                    Thread.Sleep(10);//讓畫面有時間更新, 順序不錯亂
                    SpinWait.SpinUntil(() => !isPause, 3600000);// wait for pause 
                    if (isPause)
                    {
                        FormMainUpdate.ShowMessage("Pause Timeout");
                        FormMainUpdate.AlarmUpdate(true);
                        return;//exit for
                    }
                    if (!isScriptRunning)
                    {
                        FormMainUpdate.ShowMessage("Script stop !!");
                        return;//exit for
                    }

                    string cmd = element.Command;
                    isCmdFin = false;
                    //FormMainUpdate.LogUpdate("\n**************  Script Commnad Start  **************");//此 Log 會比動作指令還晚出現, 所以取消
                    //logUpdate("\n**************  Script Commnad Start  **************");
                    timeInfo.records[stepIdx - 1] = new scripStepInfo(stepIdx, cmd);
                    timeInfo.records[stepIdx - 1].SetStartTime(DateTime.Now);//20191212 add take time 紀錄
                    sendCommand(cmd);
                    //intCmdTimeOut = 3000;//kuma test
                    SpinWait.SpinUntil(() => isCmdFin, intCmdTimeOut);// wait for command complete      
                    timeInfo.records[stepIdx - 1].SetEndTime(DateTime.Now);//20191212 add take time 紀錄 
                    if (!isCmdFin)
                    {
                        FormMainUpdate.ShowMessage("Command Timeout");
                        FormMainUpdate.AlarmUpdate(true);
                        timeInfo.Save(cnt);//20191212 add take time 紀錄
                        return;//exit for
                    }
                    //resummn after motion complete               
                    if (FormMainUpdate.isAlarmSet)
                    {
                        FormMainUpdate.ShowMessage("Execute " + cmd + " error.");
                        timeInfo.Save(cnt);//20191212 add take time 紀錄
                        return;//exit for
                    }
                    currentCmd = ""; //clear command
                    //20191122 Fix Stop Rerun Bug
                    if (!isScriptRunning)
                    {
                        FormMainUpdate.ShowMessage("Script is Stop.");
                        timeInfo.Save(cnt);//20191212 add take time 紀錄
                        return;//exit for
                    }
                    stepIdx++;
                }
                timeInfo.Save(cnt);//20191212 add take time 紀錄
                cnt++;
            }
            //FormMainUpdate.ShowMessage("Command Script done.");Tony他們說訊息看了很煩!!
            setIsRunning(false);//執行結束
            isScriptRunning = false;//執行結束

        }

        private void btnScriptStop_Click(object sender, EventArgs e)
        {
            FormMainUpdate.AlarmUpdate(false);
            isPause = false;
            //FormMainUpdate.LogUpdate("\n*************   Manual Stop     *************");
            logUpdate("\n*************   Manual Stop     *************");
            isScriptRunning = false;
            setIsRunning(false);//執行結束
            isCmdFin = true;
        }

        private void dgvCmdScript_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCmdScript.RowCount == 0 || dgvCmdScript.SelectedCells[0].ColumnIndex < 1)
                return;// not command cell
            string o_value = dgvCmdScript.SelectedCells[0].Value.ToString();
            string n_value = ShowDialog("Update", "New Command:", o_value);
            if (n_value.Equals(""))
                return;//cancel update
            else
            {
                CmdScript cmd = Command.oCmdScript.ElementAt(dgvCmdScript.CurrentCell.RowIndex);
                cmd.Command = n_value;
                FormMainUpdate.refreshScriptSet();
            }
        }

        public static string ShowDialog(string title, string label, string text)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = label, Width = 200 };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Text = text };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 90, DialogResult = DialogResult.OK, Height = 35 };
            textLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            confirmation.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void btnNewScript_Click(object sender, EventArgs e)
        {
            try
            {
                Command.oCmdScript.Clear();//remove list
                FormMainUpdate.refreshScriptSet();
            }
            catch (Exception ex)
            {
                FormMainUpdate.ShowMessage(ex.Message + ":" + ex.ToString());
            }
        }

        private void btnSTKServoOn_Click(object sender, EventArgs e)
        {
            string cmd = "$1SET:SERVO:1";
            sendCommand(cmd);
        }

        public string[] ShowMarcoDialog()
        {
            string[] result = new string[] { "", "" };
            Form prompt = new Form()
            {
                Width = 450,
                Height = 280,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Macro info",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label lblUser = new Label() { Left = 30, Top = 20, Text = "Name", Width = 200 };
            TextBox tbUser = new TextBox() { Left = 30, Top = 50, Width = 350, Text = macroName };
            Label lblPassword = new Label() { Left = 30, Top = 90, Text = "Index", Width = 200 };
            TextBox tbPassword = new TextBox() { Left = 30, Top = 120, Width = 350, Text = index };
            //tbPassword.PasswordChar = '';
            Button confirmation = new Button() { Text = "Ok", Left = 280, Width = 100, Top = 170, DialogResult = DialogResult.OK, Height = 35 };
            lblUser.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPassword.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tbUser.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tbPassword.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            confirmation.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(lblUser);
            prompt.Controls.Add(tbUser);
            prompt.Controls.Add(tbPassword);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(lblPassword);
            prompt.AcceptButton = confirmation;
            tbPassword.Focus();
            //tbUser.Enabled = false;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                result[0] = tbUser.Text;
                result[1] = tbPassword.Text;
            }
            return result;
        }

        class Command_Marco
        {
            public string EachCommand { get; set; }
        }

        private void Load_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1;
            StreamReader myStream = null;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            List<Command_Marco> cmds = new List<Command_Marco>();
            string address = "";
            try
            {
                if (rbMarcoSTK.Checked)
                    address = "$1";
                if (rbMarcoWHR.Checked)
                    address = "$2";
                if (rbMarcoCTU.Checked)
                    address = "$3";
                openFileDialog1 = new OpenFileDialog();
                //openFileDialog1.Filter = "json files (*.json)|*.json";
                //openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string[] extName = Path.GetFileName(openFileDialog1.FileName).Split('.');
                    macroName = extName[0].ToUpper();
                    //macroName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName).ToUpper();
                    if (extName.Length > 2)
                    {
                        int idx;
                        if (int.TryParse(extName[1].Replace(".", ""), out idx))
                        {
                            index = idx.ToString();
                        }
                    }
                    //set 
                    if (cbRoutineAuto.Checked)
                    {
                        if (extName[0].Contains("_"))
                        {
                            cbRoutine.Text = "S";
                        }
                        else
                        {
                            cbRoutine.Text = "M";
                        }
                    }

                    string line = string.Empty;
                    //if (macroName.Equals("") || index.Equals(""))
                    //{
                    string[] info = ShowMarcoDialog();
                    macroName = info[0];
                    index = info[1];
                    //}
                    using (myStream = new StreamReader(openFileDialog1.FileName))
                    {
                        //fileName_lb.Text = openFileDialog1.FileName;

                        while ((line = myStream.ReadLine()) != null)
                        {
                            Command_Marco tmp = new Command_Marco();
                            tmp.EachCommand = line.Replace("/", "").Trim();
                            if (tmp.EachCommand.IndexOf("'") != -1)
                            {
                                tmp.EachCommand = tmp.EachCommand.Substring(0, tmp.EachCommand.IndexOf("'")).Trim();
                            }
                            if (!tmp.EachCommand.Equals(""))
                            {
                                cmds.Add(tmp);
                                if (textBox2.Text.Equals(""))
                                {
                                    textBox2.Text = "/";
                                }
                                textBox2.Text += tmp.EachCommand + "/";
                            }
                        }

                    }

                    //dataGridView1.DataSource = cmds;
                    textBox1.Text = address + "SET:MNAME:" + cbRoutine.Text + "," + index + "," + macroName;

                    textBox3.Text = address + "SET:MSAVE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception Message", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void Load_dir_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                if (defaultMarcoPath != "")
                {
                    //設置這次目錄為上次選定目錄
                    fbd.SelectedPath = defaultMarcoPath;
                }
                else
                {
                    fbd.SelectedPath = Directory.GetCurrentDirectory();
                }

                Command.oCmdScript.Clear();//clear script
                                           //create script
                DialogResult result = fbd.ShowDialog();

                string address = "";
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    defaultMarcoPath = fbd.SelectedPath;//紀錄選定的目錄
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    if (rbMarcoSTK.Checked)
                        address = "$1";
                    if (rbMarcoWHR.Checked)
                        address = "$2";
                    if (rbMarcoCTU.Checked)
                        address = "$3";

                    foreach (string file in files)
                    {
                        string filename = Path.GetFileName(file);
                        string[] extName = filename.Split('.');
                        if (!filename.EndsWith(".vb"))
                        {
                            //FormMainUpdate.LogUpdate("不符合 marco 檔名的檔案不處理 => " + filename);
                            logUpdate("不符合 marco 檔名的檔案不處理 => " + filename);
                            continue;
                        }
                        macroName = extName[0].ToUpper();
                        //macroName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName).ToUpper();
                        if (extName.Length > 2)
                        {
                            int idx;
                            if (int.TryParse(extName[1].Replace(".", ""), out idx))
                            {
                                index = idx.ToString();
                            }
                        }
                        //set 
                        if (cbRoutineAuto.Checked)
                        {
                            if (extName[0].Contains("_"))
                                cbRoutine.Text = "S";
                            else
                                cbRoutine.Text = "M";
                        }

                        string line = string.Empty;
                        //if (macroName.Equals("") || index.Equals(""))
                        //{

                        //}
                        using (StreamReader myStream = new StreamReader(file))
                        {
                            //fileName_lb.Text = openFileDialog1.FileName;

                            while ((line = myStream.ReadLine()) != null)
                            {
                                Command_Marco tmp = new Command_Marco();
                                tmp.EachCommand = line.Replace("/", "").Trim();
                                if (tmp.EachCommand.IndexOf("'") != -1)
                                {
                                    tmp.EachCommand = tmp.EachCommand.Substring(0, tmp.EachCommand.IndexOf("'")).Trim();
                                }
                                if (!tmp.EachCommand.Equals(""))
                                {

                                    if (textBox2.Text.Equals(""))
                                    {
                                        textBox2.Text = "/";
                                    }
                                    textBox2.Text += tmp.EachCommand + "/";
                                }
                            }

                        }




                        if (textBox2.Text.Length > 950)//1000
                        {
                            FormMainUpdate.addScriptCmd(address + "SET:MNAME:" + cbRoutine.Text + "," + index + "," + macroName);
                            double pages = Math.Ceiling(textBox2.Text.Length / 950.0);//999.0
                            string eachPage = "";
                            for (int i = 1; i <= pages; i++)
                            {
                                if (pages == i)
                                {
                                    eachPage = textBox2.Text.Substring((i - 1) * 950);//999
                                }
                                else
                                {
                                    eachPage = textBox2.Text.Substring((i - 1) * 950, 950);//999
                                }
                                if (i == 1)
                                {
                                    //FormMainUpdate.addScriptCmd(address + "SET:MEDIT:" + "M" + "," + macroName + "," + eachPage);
                                    FormMainUpdate.addScriptCmd(address + "SET:MEDIT:" + cbRoutine.Text + "," + macroName + "," + eachPage);
                                }
                                else
                                {
                                    //FormMainUpdate.addScriptCmd(address + "SET:MEDIT:" + "MA" + "," + macroName + "," + eachPage);
                                    FormMainUpdate.addScriptCmd(address + "SET:MEDIT:" + cbRoutine.Text + "A" + "," + macroName + "," + eachPage);
                                }
                            }
                        }
                        else
                        {
                            FormMainUpdate.addScriptCmd(address + "SET:MNAME:" + cbRoutine.Text + "," + index + "," + macroName);
                            FormMainUpdate.addScriptCmd(address + "SET:MEDIT:" + cbRoutine.Text + "," + macroName + "," + textBox2.Text);
                        }

                        textBox2.Text = "";
                    }
                    FormMainUpdate.addScriptCmd(address + "SET:MSAVE");
                    FormMainUpdate.refreshScriptSet();
                    // run script
                    btnScriptRun_Click(btnScriptRun, e);

                }
            }
        }


        private void btnSetMarco_Click(object sender, EventArgs e)
        {
            Command.oCmdScript.Clear();//clear script
            //create script
            FormMainUpdate.addScriptCmd(textBox1.Text);
            string address = "";
            if (rbMarcoSTK.Checked)
                address = "$1";
            if (rbMarcoWHR.Checked)
                address = "$2";
            if (rbMarcoCTU.Checked)
                address = "$3";
            if (textBox2.Text.Length > 950)//1000
            {
                //FormMainUpdate.addScriptCmd(address + "SET:MNAME:" + "M" + "," + index + "," + macroName);
                double ttt = textBox2.Text.Length / 950.0;//999.0
                double pages = Math.Ceiling(textBox2.Text.Length / 950.0);//999.0
                string eachPage = "";
                for (int i = 1; i <= pages; i++)
                {
                    if (pages == i)
                    {
                        eachPage = textBox2.Text.Substring((i - 1) * 950);//999
                    }
                    else
                    {
                        eachPage = textBox2.Text.Substring((i - 1) * 950, 950);//999
                    }
                    if (i == 1)
                    {
                        //FormMainUpdate.addScriptCmd(address + "SET:MEDIT:" + "M" + "," + macroName + "," + eachPage);
                        FormMainUpdate.addScriptCmd(address + "SET:MEDIT:" + cbRoutine.Text + "," + macroName + "," + eachPage);
                    }
                    else
                    {
                        //FormMainUpdate.addScriptCmd(address + "SET:MEDIT:" + "MA" + "," + macroName + "," + eachPage);
                        FormMainUpdate.addScriptCmd(address + "SET:MEDIT:" + cbRoutine.Text + "A" + "," + macroName + "," + eachPage);

                    }
                }
                FormMainUpdate.addScriptCmd(textBox3.Text);
            }
            else
            {
                //FormMainUpdate.addScriptCmd(address + "SET:MNAME:" + cbRoutine.Text + "," + index + "," + macroName);
                FormMainUpdate.addScriptCmd(address + "SET:MEDIT:" + cbRoutine.Text + "," + macroName + "," + textBox2.Text);
                FormMainUpdate.addScriptCmd(textBox3.Text);
            }
            //tabMode.SelectedIndex = 1;
            FormMainUpdate.refreshScriptSet();
            // run script
            btnScriptRun_Click(btnScriptRun, e);
        }

        private void btnHold_Click(object sender, EventArgs e)
        {

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {

        }

        private void btnAbort_Click(object sender, EventArgs e)
        {

        }

        private void tabSetting_Click(object sender, EventArgs e)
        {

        }

        private void btnCTUInit_Click(object sender, EventArgs e)
        {
            //string cmd = "$3MCR:CTORG:1";
            string cmd = "$3MCR:CTINI:1";
            sendCommand(cmd);
        }


        int currentY_I = 15;
        int currentY_O = 15;

        private void InsertIO(string AddressNo, string ID, string Name, string desc, string Type, Panel P)
        {
            int currentY = 0;
            if (Type.ToUpper().Equals("IN"))
            {
                currentY = currentY_I;
                currentY_I += 30;
            }
            else
            {
                currentY = currentY_O;
                currentY_O += 30;
            }
            Label value = new Label();
            if (cbUseIOName.Checked)
                //value.Name = AddressNo + "_" + Name.Replace("-", "_") + "_" + Type;
                value.Name = AddressNo + "_" + Name + "_" + Type;
            else
                value.Name = AddressNo + "_" + ID + "_" + Type;
            value.Text = "■";//"●"
            //value.ForeColor = Color.Red;
            value.ForeColor = Color.DimGray;//預設為未知
            value.Location = new System.Drawing.Point(0, currentY);
            value.Font = new Font(new FontFamily(value.Font.Name), 12, value.Font.Style);
            //value.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            value.Size = new System.Drawing.Size(20, 20);
            P.Controls.Add(value);

            Label id = new Label();
            id.Text = ID + "(" + Name + ")";
            id.Location = new System.Drawing.Point(20, currentY);
            if (Type.ToUpper().Equals("IN"))
            {
                id.Size = new System.Drawing.Size(230, 20);
            }
            else
            {
                id.Size = new System.Drawing.Size(180, 20);
            }
            //id.Font = new Font(new FontFamily(id.Font.Name), 12, id.Font.Style);
            id.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            hint.SetToolTip(id, desc);
            P.Controls.Add(id);

            if (Type.ToUpper().Equals("OUT"))
            {
                Button On = new Button();
                On.Text = "On";
                if (cbUseIOName.Checked)
                    //On.Name = AddressNo + "_" + Name.Replace("-", "_") + "_" + Type + "_ON";
                    On.Name = AddressNo + "_" + Name + "_" + Type + "_ON";
                else
                    On.Name = AddressNo + "_" + ID + "_" + Type + "_ON";
                //On.Name = AddressNo + "_" + ID + "_" + Type + "_ON";
                On.Click += On_IO_Click;
                On.Location = new System.Drawing.Point(200, currentY);
                //On.Font = new Font(new FontFamily(On.Font.Name), 9, On.Font.Style);
                On.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                On.Size = new System.Drawing.Size(38, 25);
                P.Controls.Add(On);

                Button Off = new Button();
                Off.Text = "Off";
                if (cbUseIOName.Checked)
                    //Off.Name = AddressNo + "_" + Name.Replace("-", "_") + "_" + Type + "_OFF";
                    Off.Name = AddressNo + "_" + Name + "_" + Type + "_OFF";
                else
                    Off.Name = AddressNo + "_" + ID + "_" + Type + "_OFF";
                //Off.Name = AddressNo + "_" + ID + "_" + Type + "_OFF";
                Off.Click += On_IO_Click;
                Off.Location = new System.Drawing.Point(240, currentY);
                //Off.Font = new Font(new FontFamily(On.Font.Name), 9, On.Font.Style);
                Off.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Off.Size = new System.Drawing.Size(38, 25);
                P.Controls.Add(Off);
            }

        }

        private void Initial_Error()
        {
            string line;
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"error_code.csv");
                while ((line = file.ReadLine()) != null)
                {
                    string[] raw = line.Split(',');
                    error_codes.Add(raw[0], raw[1]);
                }
            }
            catch (Exception e)
            {
                //FormMainUpdate.LogUpdate(e.Message);
                logUpdate(e.Message);
            }
        }
        private void Initial_Command()
        {
            string line;
            ArrayList temp = new ArrayList();
            ArrayList cmds = new ArrayList();
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"cmd_list.csv");
                while ((line = file.ReadLine()) != null)
                {
                    temp.Add(line.Replace("\"", "").Trim());
                }
                temp.Sort();
                foreach (string foo in temp)
                {
                    cmds.Add("");
                    cmds.Add(foo);
                }
                cbCmd.Items.Clear();
                cbCmd.DataSource = cmds;
            }
            catch (Exception e)
            {
                //FormMainUpdate.LogUpdate(e.Message);
                logUpdate(e.Message);
            }
        }

        private void Initial_I_O()
        {
            string line;

            //System.IO.StreamReader file =  new System.IO.StreamReader(@"Stocker_IO.csv");
            System.IO.StreamReader file = new System.IO.StreamReader(@"Stocker_IO_Name.csv");
            Stocker_I_List.Controls.Clear();
            Stocker_O_List.Controls.Clear();
            WHR_I_List.Controls.Clear();
            WHR_O_List.Controls.Clear();
            CTU_PTZ_I_List.Controls.Clear();
            CTU_PTZ_O_List.Controls.Clear();
            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    string[] raw = line.Split(',');
                    if (raw[4].ToUpper().Equals("IN"))
                    {
                        InsertIO(raw[0], raw[1], raw[2], raw[3], raw[4], Stocker_I_List);
                    }
                    else
                    {
                        InsertIO(raw[0], raw[1], raw[2], raw[3], raw[4], Stocker_O_List);
                    }

                }
                catch (Exception e)
                {
                    //MessageBox.Show("Stocker_IO.csv read err:" + line + "\n" + e.StackTrace);
                    MessageBox.Show("Stocker_IO_Name.csv read err:" + line + "\n" + e.StackTrace);
                }
            }

            file.Close();
            currentY_I = 15;
            currentY_O = 15;
            //file =  new System.IO.StreamReader(@"WHR_IO.csv");
            file = new System.IO.StreamReader(@"WHR_IO_Name.csv");
            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    string[] raw = line.Split(',');
                    if (raw[4].ToUpper().Equals("IN"))
                    {
                        InsertIO(raw[0], raw[1], raw[2], raw[3], raw[4], WHR_I_List);
                    }
                    else
                    {
                        InsertIO(raw[0], raw[1], raw[2], raw[3], raw[4], WHR_O_List);
                    }

                }
                catch (Exception e)
                {
                    //MessageBox.Show("WHR_IO.csv read err:" + line + "\n" + e.StackTrace);
                    MessageBox.Show("WHR_IO_Name.csv read err:" + line + "\n" + e.StackTrace);
                }
            }

            file.Close();
            currentY_I = 15;
            currentY_O = 15;
            //file =  new System.IO.StreamReader(@"CTU_PTZ_IO.csv");
            file = new System.IO.StreamReader(@"CTU_PTZ_IO_Name.csv");
            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    string[] raw = line.Split(',');
                    if (raw[4].ToUpper().Equals("IN"))
                    {
                        InsertIO(raw[0], raw[1], raw[2], raw[3], raw[4], CTU_PTZ_I_List);
                    }
                    else
                    {
                        InsertIO(raw[0], raw[1], raw[2], raw[3], raw[4], CTU_PTZ_O_List);
                    }

                }
                catch (Exception e)
                {
                    //MessageBox.Show("CTU_PTZ_IO.csv read err:" + line + "\n" + e.StackTrace);
                    MessageBox.Show("CTU_PTZ_IO_Name.csv read err:" + line + "\n" + e.StackTrace);
                }
            }

            file.Close();


            //for (int i = 0; i < 100; i++)
            //{
            //    InsertIO("1", "9528"+i, "Buzzer1"+i, "OUT", Stocker_IO_List);
            //}
        }

        private void On_IO_Click(object sender, EventArgs e)
        {
            string key = ((Button)sender).Name;
            string type = key.Substring(key.LastIndexOf("_") + 1);
            key = key.Substring(0, key.LastIndexOf("_"));
            string address = key.Split('_')[0];
            string io = key.Split('_')[1];
            string ioCmd = cbUseIOName.Checked ? "SET:NMEIO:" : "SET:RELIO:";
            string cmd = "$" + address + ioCmd + io + ",";
            switch (type.ToUpper())
            {
                case "ON":
                    FormMainUpdate.Update_IO(key, "1");
                    cmd = cmd + "1";
                    break;

                case "OFF":
                    FormMainUpdate.Update_IO(key, "0");
                    cmd = cmd + "0";
                    break;
            }
            //FormMainUpdate.LogUpdate(cmd);
            sendCommand(cmd);

        }

        /// <summary>
        /// MC：Macro Container    3: when LPT = 1    4: when LPT = 2
        /// LPT：                  1 = ILPT1    2 = ILPT2
        /// SW :                   0 = OFF    1 = ON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnILPTClamp_Click(object sender, EventArgs e)
        {
            //$1MCR:ILCLP:MC,LPT,SW
            string cmd = "";
            if (cbILPTManual.Text.Equals("ILPT1"))
            {
                cmd = "$1MCR:ILCLP:3,1,1";
            }
            else
            {
                cmd = "$1MCR:ILCLP:4,2,1";
            }
            sendCommand(cmd);
        }

        private void btnILPTUnClamp_Click(object sender, EventArgs e)
        {
            //$1MCR:ILCLP:MC,LPT,SW
            string cmd = "";
            if (cbILPTManual.Text.Equals("ILPT1"))
            {
                cmd = "$1MCR:ILCLP:3,1,0";
            }
            else
            {
                cmd = "$1MCR:ILCLP:4,2,0";
            }
            sendCommand(cmd);
        }

        private void btnILPTDock_Click(object sender, EventArgs e)
        {
            //$1MCR:ILDCK:MC,LPT,SW[CR]
            string cmd = "";
            if (cbILPTManual.Text.Equals("ILPT1"))
            {
                cmd = "$1MCR:ILDCK:3,1,1";
            }
            else
            {
                cmd = "$1MCR:ILDCK:4,2,1";
            }
            sendCommand(cmd);
        }

        private void btnILPTUnDock_Click(object sender, EventArgs e)
        {
            //$1MCR:ILDCK:MC,LPT,SW[CR]
            string cmd = "";
            if (cbILPTManual.Text.Equals("ILPT1"))
            {
                cmd = "$1MCR:ILDCK:3,1,0";
            }
            else
            {
                cmd = "$1MCR:ILDCK:4,2,0";
            }
            sendCommand(cmd);
        }

        private void btnILPTOpenLatch_Click(object sender, EventArgs e)
        {
            //$1MCR:ILLTH:MC,LPT,SW[CR]
            string cmd = "";
            if (cbILPTManual.Text.Equals("ILPT1"))
            {
                cmd = "$1MCR:ILLTH:3,1,1";
            }
            else
            {
                cmd = "$1MCR:ILLTH:4,2,1";
            }
            sendCommand(cmd);
        }

        private void btnILPTCloseLatch_Click(object sender, EventArgs e)
        {
            //$1MCR:ILLTH:MC,LPT,SW[CR]
            string cmd = "";
            if (cbILPTManual.Text.Equals("ILPT1"))
            {
                cmd = "$1MCR:ILLTH:3,1,0";
            }
            else
            {
                cmd = "$1MCR:ILLTH:4,2,0";
            }
            sendCommand(cmd);
        }

        private void btnILPTVacOn_Click(object sender, EventArgs e)
        {
            //$1MCR:ILVCM:MC,LPT,SW[CR]
            string cmd = "";
            if (cbILPTManual.Text.Equals("ILPT1"))
            {
                cmd = "$1MCR:ILVCM:3,1,1";
            }
            else
            {
                cmd = "$1MCR:ILVCM:4,2,1";
            }
            sendCommand(cmd);
        }

        private void btnILPTVacOff_Click(object sender, EventArgs e)
        {
            //$1MCR:ILVCM:MC,LPT,SW[CR]
            string cmd = "";
            if (cbILPTManual.Text.Equals("ILPT1"))
            {
                cmd = "$1MCR:ILVCM:3,1,0";
            }
            else
            {
                cmd = "$1MCR:ILVCM:4,2,0";
            }
            sendCommand(cmd);
        }

        private void btnILPTOpen_Click(object sender, EventArgs e)
        {
            //$1MCR:ILDOR:MC,LPT,SW[CR]
            string cmd = "";
            if (cbILPTManual.Text.Equals("ILPT1"))
            {
                cmd = "$1MCR:ILDOR:3,1,1";
            }
            else
            {
                cmd = "$1MCR:ILDOR:4,2,1";
            }
            sendCommand(cmd);
        }

        private void btnILPTClose_Click(object sender, EventArgs e)
        {
            //$1MCR:ILDOR:MC,LPT,SW[CR]
            string cmd = "";
            if (cbILPTManual.Text.Equals("ILPT1"))
            {
                cmd = "$1MCR:ILDOR:3,1,0";
            }
            else
            {
                cmd = "$1MCR:ILDOR:4,2,0";
            }
            sendCommand(cmd);
        }

        private void btnWHRMovePlaceCTU_2_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHR_MovePlace(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRMovePickCTU_2_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHR_MovePick(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRUpCTU_Click(object sender, EventArgs e)
        {
            string cmd = WHR_Up();
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRDownCTU_Click(object sender, EventArgs e)
        {
            string cmd = WHR_Down();
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRExtendPlaceCTU_2_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHR_ExtendPlace(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRExtendPickCTU_2_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHR_ExtendPick(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string cmd = "$3MCR:CTORG:1";
            sendCommand(cmd);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ResetController(Const.CONTROLLER_CTU_PTZ);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = rbCTUPathClean2.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_Grab(path);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = rbCTUPathClean2.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_Release(path);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_WHR;//CTU 對 WHR 動作
            string action = Const.CTU_ACTION_PREPARE;
            string path = rbCTUPathClean2.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_PICK(device, path, action);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_WHR;//CTU 對 WHR 動作
            string action = Const.CTU_ACTION_PREPARE;
            string path = rbCTUPathClean2.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = CTU_PLACE(device, path, action);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string cmd = CTU_HOME();
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        private void btnFoupRotTransfer_Click(object sender, EventArgs e)
        {
            if (checkFoupRobotSrc() && checkFoupRobotDest())
            {
                string cmd = FoupRobot_Transfer(cbSource.Text, cbDestination.Text);
                sendCommand(Const.CONTROLLER_STK, cmd);
            }
        }

        /// <summary>
        /// (新命令)$1MCR:CARRY:MC,SSTN,DSTN[CR]
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private string FoupRobot_Transfer(string source, string destination)
        {
            string sstn = STK_GET_POSITION(source);
            string dpno = STK_GET_POSITION(destination);
            //string cmd = "$1CMD:CARRY:" + spno  + ",1,1," + dpno + ",1,1";
            string cmd = "$1MCR:CARRY:0," + sstn + "," + dpno;
            return cmd;
        }

        private void btnFoupRotMap_Click(object sender, EventArgs e)
        {
            string cmd = FoupRobot_Map();
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private string FoupRobot_Map()
        {
            string cmd = "$1MCR:RBMAP:0";
            return cmd;
        }

        private void login(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                MessageBox.Show("Change to normal mode.");
                isAdmin = false;
            }
            else
            {
                //check 密碼
                string[] use_info = ShowLoginDialog();
                string user_id = use_info[0];
                string password = use_info[1];
                string config_password = "27774061";
                if (password.Equals(config_password))
                {
                    isAdmin = true;
                    MessageBox.Show("Success!! Change to administrator mode.");
                }
                else
                {
                    isAdmin = false;
                    MessageBox.Show("Login fail! Change to normal mode.");
                }
            }
            hideGUI();
        }
        private void login_Click(object sender, EventArgs e)
        {

        }

        public static string[] ShowLoginDialog()
        {
            string[] result = new string[] { "", "" };
            Form prompt = new Form()
            {
                Width = 450,
                Height = 280,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Authority check",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label lblUser = new Label() { Left = 30, Top = 20, Text = "User", Width = 200 };
            TextBox tbUser = new TextBox() { Left = 30, Top = 50, Width = 350, Text = "Administrator" };
            Label lblPassword = new Label() { Left = 30, Top = 90, Text = "Password", Width = 200 };
            TextBox tbPassword = new TextBox() { Left = 30, Top = 120, Width = 350 };
            tbPassword.PasswordChar = '*';
            Button confirmation = new Button() { Text = "Ok", Left = 280, Width = 100, Top = 170, DialogResult = DialogResult.OK, Height = 35 };
            lblUser.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPassword.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tbUser.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tbPassword.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            confirmation.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(lblUser);
            prompt.Controls.Add(tbUser);
            prompt.Controls.Add(tbPassword);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(lblPassword);
            prompt.AcceptButton = confirmation;
            tbPassword.Focus();
            tbUser.Enabled = false;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                result[0] = tbUser.Text;
                result[1] = tbPassword.Text;
            }
            return result;
        }


        private void getNMEIO(string address, string name)
        {
            string cmd = "$" + address + "GET:NMEIO:" + name;
            sendCommand(cmd);
        }

        private void getRELIO(string address, string id)
        {
            string cmd = "$" + address + "GET:RELIO:" + id;
            sendCommand(cmd);
        }

        private void QryIOByName(string address, TabControl tc, Panel p_in, Panel p_out)
        {
            if (tc.SelectedTab.Text.Equals("IN"))
            {
                foreach (Control foo in p_in.Controls)
                {
                    if (!foo.GetType().Name.Equals("Label"))
                    {
                        continue;
                    }
                    else if (!foo.Text.Equals("■"))
                    {
                        int start_idx = foo.Text.IndexOf("(") + 1;
                        int length = foo.Text.IndexOf(")") - start_idx;
                        string rio = foo.Text.Substring(start_idx, length);
                        getNMEIO(address, rio);
                    }
                    //else
                    //{
                    //    MessageBox.Show(foo.Name);
                    //}
                }
            }
            else
            {
                foreach (Control foo in p_out.Controls)
                {
                    if (!foo.GetType().Name.Equals("Label"))
                    {
                        continue;
                    }
                    else if (!foo.Text.Equals("■"))
                    {
                        int start_idx = foo.Text.IndexOf("(") + 1;
                        int length = foo.Text.IndexOf(")") - start_idx;
                        string rio = foo.Text.Substring(start_idx, length);
                        getNMEIO(address, rio);
                    }
                }
            }
        }

        private void QryIO(string address, TabControl tc, Panel p_in, Panel p_out)
        {
            if (tc.SelectedTab.Text.Equals("IN"))
            {
                foreach (Control foo in p_in.Controls)
                {
                    if (!foo.GetType().Name.Equals("Label"))
                    {
                        continue;
                    }
                    else if (!foo.Text.Equals("■"))
                    {
                        string rio = foo.Text.Substring(0, foo.Text.IndexOf("("));
                        getRELIO(address, rio);
                    }
                    //else
                    //{
                    //    MessageBox.Show(foo.Name);
                    //}
                }
            }
            else
            {
                foreach (Control foo in p_out.Controls)
                {
                    if (!foo.GetType().Name.Equals("Label"))
                    {
                        continue;
                    }
                    else if (!foo.Text.Equals("■"))
                    {
                        string rio = foo.Text.Substring(0, foo.Text.IndexOf("("));
                        getRELIO(address, rio);
                    }
                }
            }
        }

        private void btnQryIOStk_Click(object sender, EventArgs e)
        {
            if (cbUseIOName.Checked)
                QryIOByName("1", tabIOControl1, Stocker_I_List, Stocker_O_List);
            else
                QryIO("1", tabIOControl1, Stocker_I_List, Stocker_O_List);
            //FormMainUpdate.IONameUpdate("$1ACK:NMEIO:" + "ELPT2-CTRL-Clamp" + ",1"); //IO Hardcode 測試
            //FormMainUpdate.IONameUpdate("$1ACK:NMEIO:" + "STK-ROB-Present1" + ",1"); //IO Hardcode 測試
            //FormMainUpdate.IONameUpdate("$1ACK:NMEIO:" + "STK-ROB-Present2" + ",1"); //IO Hardcode 測試
            //FormMainUpdate.IONameUpdate("$1ACK:NMEIO:" + "STK-ROB-Present3" + ",1"); //IO Hardcode 測試


        }

        private void btnQryIOWHR_Click(object sender, EventArgs e)
        {
            if (cbUseIOName.Checked)
                QryIOByName("2", tabIOControl2, WHR_I_List, WHR_O_List);
            else
                QryIO("2", tabIOControl2, WHR_I_List, WHR_O_List);
        }

        private void btnQryIOCTU_Click(object sender, EventArgs e)
        {
            if (cbUseIOName.Checked)
                QryIOByName("3", tabIOControl3, CTU_PTZ_I_List, CTU_PTZ_O_List);
            else
                QryIO("3", tabIOControl3, CTU_PTZ_I_List, CTU_PTZ_O_List);
        }

        private void cbUseIOName_CheckedChanged(object sender, EventArgs e)
        {
            currentY_I = 15;
            currentY_O = 15;
            Initial_I_O();
        }

        private void btnChangeMode_Click(object sender, EventArgs e)
        {
            string cmd = "";
            switch (((Control)sender).Name)
            {
                case "btnSTKModeN":
                    cmd = "$1SET:MODE_:0,0";//STK normal mode
                    break;
                case "btnSTKModeD":
                    cmd = "$1SET:MODE_:1,0";//STK Dry mode
                    break;
                case "btnWHRModeN":
                    cmd = "$2SET:MODE_:0";//WHR normal mode
                    break;
                case "btnWHRModeD":
                    cmd = "$2SET:MODE_:1";//WHR Dry mode
                    break;
                case "btnCTUModeN":
                    cmd = "$3SET:MODE_:0,1";//CTU normal mode
                    break;
                case "btnCTUModeD":
                    cmd = "$3SET:MODE_:1,1";//CTU Dry mode
                    break;
                default:
                    break;
            }
            sendCommand(cmd);
        }

        private void btnWHRReset_Click(object sender, EventArgs e)
        {
            ResetController(Const.CONTROLLER_WHR);
        }

        private void btnLightCurtainOn_Click(object sender, EventArgs e)
        {
            //Enable 前必須先 Reset
            string cmd = "$1MCR:LCRST:0";//Reset 
            sendCommand(cmd);
            Thread.Sleep(1000);
            //稍微等段時間後再打開光柵功能
            cmd = "$1MCR:LCENA:0,1";//Enable
            sendCommand(cmd);
        }

        private void btnLightCurtainOff_Click(object sender, EventArgs e)
        {
            string cmd = "$1MCR:LCENA:0,0";//Disable (Bypass)
            sendCommand(cmd);
        }

        private void btnLightCurtainReset_Click(object sender, EventArgs e)
        {
            string cmd = "$1MCR:LCRST:0";//Reset
            sendCommand(cmd);
        }
    }
}
