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
        //Controller
        TcpCommClient ctrlSTK;
        TcpCommClient ctrlWHR;
        TcpCommClient ctrlCTU;
        Boolean isCmdFin = true;
        Boolean isPause = false;
        Boolean isScriptRunning = false;
        Boolean autoMode = false;
        Button[] autoBtns;
        private string[] ptzDir = new string[2] { "Face", "Face" };
        private string[] ptzPos = new string[2] { "Odd", "Even" };
        private int dirIdx = 0;
        private int posIdx = 0;
        int intCmdTimeOut = 300000;//default 5 mins
        int ackTimeOut = 5000; // default 5 seconds
        int ackSleepTime = 200; // default 0.2 seconds
        string currentCmd = "";
        //for marco
        string macroName = "";
        string index = "";

        private void setIsRunning(Boolean isRun)
        {
            //isScriptRunning = isRun;
            FormMainUpdate.SetRunBtnEnable(isRun);
        }

        public FormMain()
        {
            InitializeComponent();
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
            //Initial_I_O();
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
            string cmd = "";
            switch (port)
            {
                case Const.STK_ELPT1:
                    cmd = "$1GET:TAGID:1";// "$1GET:CID__:1";
                    break;
                case Const.STK_ELPT2:
                    cmd = "$1GET:TAGID:2";// "$1GET:CID__:2";
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
            FormMainUpdate.ChangeRunTab(1);
            FormMainUpdate.refreshScriptSet();
            // run script
            //btnScriptRun_Click(btnScriptRun, e);

            //int cnt = 1;//repeat count 
            //while (cnt > 0)
            //{
            //    foreach(String cmd in cmds)
            //    {
            //        isCmdFin = false;                   
            //        sendCommand(cmd);
            //        currentCmd = cmd.Replace("MOV", "").Replace("SET", "").Replace("GET", "");
            //        SpinWait.SpinUntil(() => isCmdFin, 500);// wait for command complete       
            //        if (!isCmdFin)
            //        {
            //            FormMainUpdate.LogUpdate("Command Timeout");
            //            //FormMainUpdate.ShowMessage("Command Timeout");
            //            //FormMainUpdate.AlarmUpdate(true);
            //            //return;//exit for
            //        }
            //    }
            //    cnt--;
            //}
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
                FormMainUpdate.LogUpdate(cmd);
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

            //string replyMsg = (string)Msg;
            string[] MsgAry = ((string)Msg).Split(new string[] { ";\r" }, StringSplitOptions.None);
            foreach (string replyMsg in MsgAry)
            {
                FormMainUpdate.LogUpdate("Reveive <= " + replyMsg);
                //if (replyMsg.StartsWith("NAK") || replyMsg.StartsWith("CAN") || replyMsg.StartsWith("ABS"))
                if (replyMsg.StartsWith("ABS"))
                {
                    FormMainUpdate.AlarmUpdate(true);
                    setIsRunning(false);//ABS stop script
                }
                else if (replyMsg.StartsWith("CAN") || replyMsg.StartsWith("NAK"))
                {
                    setIsRunning(false);//CAN  or  NAK stop script
                    isScriptRunning = false;
                    isCmdFin = true;
                }
                else if (replyMsg.StartsWith("$1ACK") || replyMsg.StartsWith("$2ACK") || replyMsg.StartsWith("$3ACK"))
                {
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
                    if (!isScriptRunning)
                    {
                        setIsRunning(false);
                    }
                    //FormMainUpdate.SetRunBtnEnable(true);
                    isCmdFin = true;
                    if (replyMsg.Contains("MCR"))
                    {
                        if (!replyMsg.Split(',')[1].Equals("00000000"))//"$3FIN: MCR__: 2,00000000,1"
                        {
                            setIsRunning(false);
                            isScriptRunning = false;
                        }
                        if (replyMsg.Split(',').Count() == 27)
                        {
                            //123

                            string[] result = replyMsg.Substring(replyMsg.LastIndexOf(':') + 1).Split(',');
                            string MC = result[0];
                            string MappingResult = "";
                            for (int i = 2; i < result.Count(); i++)
                            {
                                MappingResult += result[i];
                            }
                            int tmp;
                            if (mapCollection.TryGetValue(MC + MappingResult, out tmp))
                            {
                                mapCollection[MC + MappingResult] = tmp + 1;

                            }
                            else
                            {
                                mapCollection.Add(MC + MappingResult, 1);
                            }
                            string log = "";
                            foreach (KeyValuePair<string, int> each in mapCollection)
                            {
                                log += each.Key + ":" + each.Value + "\n";

                            }
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"map_summary.log", false))
                            {
                                file.WriteLine(log);
                            }
                        }
                        //123
                    }
                    else
                    {
                        if (!replyMsg.EndsWith("00000000"))//"$3FIN: MCR__: 2,00000000,1"
                        {
                            setIsRunning(false);
                            isScriptRunning = false;
                        }
                    }
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

        void IConnectionReport.On_Connection_Connecting(string Msg)
        {
            FormMainUpdate.LogUpdate("連線中!!");
        }

        void IConnectionReport.On_Connection_Connected(object Msg)
        {
            FormMainUpdate.LogUpdate("連線成功!!");
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
            //連線
            btnCtrlSTKCon_Click(sender, e);
            btnCtrlWHRCon_Click(sender, e);
            btnCtrlCTUCon_Click(sender, e);
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

        private void btnI1Load_Click(object sender, EventArgs e)
        {
            string cmd = ILPT_Load(Const.STK_ILPT1);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnI2Load_Click(object sender, EventArgs e)
        {
            string cmd = ILPT_Load(Const.STK_ILPT2);
            sendCommand(Const.CONTROLLER_STK, cmd);
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
                    cmd = "$1MCR:ILOPN:3,1," + (cbWithMap1.Checked ? "1" : "0");//$1MCR:ILOPN:MC,LTP,MPEN[CR]
                    break;
                case Const.STK_ILPT2:
                    //cmd = "$1MCR:DROPN:4,2";
                    cmd = "$1MCR:ILOPN:4,2," + (cbWithMap2.Checked ? "1" : "0");//$1MCR:ILOPN:MC,LTP,MPEN[CR]
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
                case Const.STK_ILPT1:
                    //cmd = "$1MCR:DRCLS:3,1";
                    cmd = "$1MCR:ILCLS:3,1," + (cbWithMap1.Checked ? "1" : "0");//$1MCR:ILCLS:MC,LTP,MPEN[CR]
                    break;
                case Const.STK_ILPT2:
                    //cmd = "$1MCR:DRCLS:4,2";
                    cmd = "$1MCR:ILCLS:4,2," + (cbWithMap2.Checked ? "1" : "0");//$1MCR:ILCLS:MC,LTP,MPEN[CR]
                    break;
            }
            return cmd;
        }

        private void btnI1UnLoad_Click(object sender, EventArgs e)
        {
            string cmd = ILPT_Unload(Const.STK_ILPT1);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnI2UnLoad_Click(object sender, EventArgs e)
        {
            string cmd = ILPT_Unload(Const.STK_ILPT2);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnI1Maping_Click(object sender, EventArgs e)
        {
            string cmd = ILPT_Mapping(Const.STK_ILPT1, rbMapUp1.Checked);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnI2Maping_Click(object sender, EventArgs e)
        {
            string cmd = ILPT_Mapping(Const.STK_ILPT2, rbMapUp2.Checked);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

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
                    cmd = "$1MCR:ELINI:1,6"; //$1MCR: ELINI: MC,MO
                    break;
                case Const.STK_ELPT2:
                    //cmd = "$1MCR:MEORG:2,7";//$1MCR:MEORG:MC,MO
                    cmd = "$1MCR:ELINI:2,7"; //$1MCR: ELINI: MC,MO
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
            ILPT_INIT(Const.STK_ILPT1);
        }

        private void tbI2Init_Click(object sender, EventArgs e)
        {
            ILPT_INIT(Const.STK_ILPT2);
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

        private void btnSTKRefresh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("查詢Stocker 在席!");
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
                case Const.STK_SHELF1:
                    result = "11";
                    break;
                case Const.STK_SHELF2:
                    result = "12";
                    break;
                case Const.STK_SHELF3:
                    result = "13";
                    break;
                case Const.STK_SHELF4:
                    result = "21";
                    break;
                case Const.STK_SHELF5:
                    result = "31";
                    break;
                case Const.STK_SHELF6:
                    result = "22"; // kuma 應該是32?
                    break;
                case Const.STK_SHELF7:
                    result = "33";
                    break;
                case Const.STK_SHELF8:
                    result = "41";
                    break;
                case Const.STK_SHELF9:
                    result = "42";
                    break;
                case Const.STK_SHELF10:
                    result = "43";
                    break;
                case Const.STK_SHELF11:
                    result = "51";
                    break;
                case Const.STK_SHELF12:
                    result = "52";
                    break;
                case Const.STK_SHELF13:
                    result = "53";
                    break;
                case Const.STK_SHELF14:
                    result = "61";
                    break;
                case Const.STK_SHELF15:
                    result = "62";
                    break;
                case Const.STK_SHELF16:
                    result = "63";
                    break;
            }
            return result;
        }

        /// <summary>
        /// $1CMD:GETST:PNO,001,1,1[CR]	"Robot Arm 移動至取 FOUP 等待位置
        /// </summary>
        /// <param name="source"></param>
        private string FoupRobot_PrePick(string source)
        {
            string cmd = "";
            string position = STK_GET_POSITION(source);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD:GETST:" + position + ",001,1,1";
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
        /// $1CMD:GETST:PNO,001,1,0[CR]
        /// </summary>
        /// <param name="source"></param>
        private string FoupRobot_Pick(string source)
        {
            string cmd = "";
            string position = STK_GET_POSITION(source);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD:GETST:" + position + ",001,1,0";
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
        /// $1CMD:PUTST:PNO,001,1,1[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_PrePlace(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD: PUTST: " + position + ",001,1,1";
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
        /// $1CMD:PUTST:PNO,001,1,0[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Place(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD:PUTST:" + position + ",001,1,0";
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
        /// $1CMD:PUTST:PNO,001,1,0[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Extend_Src(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD: GETST:" + position + ",001,1,2";
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
        /// $1CMD:PUTST:PNO,001,1,0[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Up_Src(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD: GETST: " + position + ",001,1,5";
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
        /// $1CMD:PUTST:PNO,001,1,0[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Grab_Src(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD:GETST:" + position + ",001,1,4";
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
        /// $1CMD:PUTST:PNO,001,1,0[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Retract_Src(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD: GETST:" + position + ",001,1,0";
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
        /// $1CMD:PUTST:PNO,001,1,0[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Extend_Dest(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD:PUTST:" + position + ",001,1,2";
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
        /// $1CMD:PUTST:PNO,001,1,0[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Release_Dest(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD:PUTST:" + position + ",001,1,4";
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
        /// $1CMD:PUTST:PNO,001,1,0[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Retract_Dest(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD:PUTST:" + position + ",001,1,0";
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
        /// $1CMD:PUTST:PNO,001,1,0[CR]
        /// </summary>
        /// <param name="dest"></param>
        private string FoupRobot_Down_Dest(string dest)
        {
            string cmd = "";
            string position = STK_GET_POSITION(dest);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD:PUTST:" + position + ",001,1,5";
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
            string cmd = "$1CMD:HOME_";
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
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:GETST:" + position + ",001,1,1";
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
                    result = "301";
                    break;
                case Const.WHR_ILPT2_CLEAN:
                    result = "302";
                    break;
                case Const.WHR_CTU_CLEAN:
                    result = "303";
                    break;
                case Const.WHR_ILPT1_DIRTY:
                    result = "311";
                    break;
                case Const.WHR_ILPT2_DIRTY:
                    result = "312";
                    break;
                case Const.WHR_CTU_DIRTY:
                    result = "313";
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
        private string WHR_MovePlace(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:PUTST:" + position + ",001,1,1";
            }
            return cmd;
        }

        private void btnWHRRetractPickPort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                string cmd = WHR_RetractPick(ilpt, path);
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        private string WHR_RetractPick(string ilpt, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(ilpt + "-" + path);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:GETST:" + position + ",001,1,0";
            }
            return cmd;
        }

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

        private string WHR_ExtendPick(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:GETST:" + position + ",001,1,2";
            }
            return cmd;
        }

        private void btnWHRUpPort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                string cmd = WHR_UpPort(ilpt, path);
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        private string WHR_UpPort(string ilpt, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(ilpt + "-" + path);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:GETST:" + position + ",001,1,5";
            }
            return cmd;
        }

        private void btnWHRDownPort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                string cmd = WHR_DownPort(ilpt, path);
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        private string WHR_DownPort(string ilpt, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(ilpt + "-" + path);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:PUTST:" + position + ",001,1,5";
            }
            return cmd;
        }

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

        private string WHR_PickPort(string ilpt, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(ilpt + "-" + path);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:GETST:" + position + ",001,1,0";
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

        private string WHR_PlacePort(string ilpt, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(ilpt + "-" + path);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:PUTST:" + position + ",001,1,0";
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

        private string WHR_ExtendPlace(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:PUTST:" + position + ",001,1,2";
            }
            return cmd;
        }

        private void btnWHRRetractPlacePort_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string ilpt = cbWHRSelctILPT.Text;
                string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
                string cmd = WHR_RetractPlace(ilpt, path);
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        private string WHR_RetractPlace(string device, string path)
        {
            string cmd = "";
            string position = WHR_ACCESS_POSITION(device + "-" + path);
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:PUTST:" + position + ",001,1,0";
            }
            return cmd;
        }

        private void btnWHRHome_Click(object sender, EventArgs e)
        {
            if (checkWHRAccessPort())
            {
                string cmd = WHR_Home();
                sendCommand(Const.CONTROLLER_WHR, cmd);
            }
        }

        private string WHR_Home()
        {
            string cmd = "$2CMD:HOME_";
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
            string device = Const.DEVICE_CTU;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHR_RetractPick(device, path);
            sendCommand(Const.CONTROLLER_WHR, cmd);
        }

        private void btnWHRRetractPlaceCTU_Click(object sender, EventArgs e)
        {
            string device = Const.DEVICE_CTU;
            string path = rbWHRPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string cmd = WHR_RetractPlace(device, path);
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
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:GETST:" + position + ",001,1,3";
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
            if (position != null && !position.Trim().Equals(""))
            {
                cmd = "$2CMD:PUTST:" + position + ",001,1,3";
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
            cmds.Add(WHRToPlaceCTU(ctu, path));//WHR to Place
            cmds.Add(CTU_Grab(path));//CTU Grab
            cmds.Add(WHRCompPlaceCTU(ctu, path));//CTU Complete Place
            cmds.Add(WHR_Home());//WHR Home

            //WHR Pick(GET)
            cmds.Add(CTU_PLACE(whr, path, prepare));//CTU prepare place
            cmds.Add(WHR_MovePick(ctu, path));//WHR move to pick
            cmds.Add(WHR_ExtendPick(ctu, path));//WHR Extend(Pick)
            cmds.Add(WHRToPickCTU(ctu, path));//WHR to Pick
            cmds.Add(CTU_Release(path));//CTU Release
            cmds.Add(WHRCompPickCTU(ctu, path));//CTU Complete Pick
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
                cmds.Add(WHRToPlaceCTU(ctu, path));//WHR to Place
                cmds.Add(CTU_Grab(path));//CTU Grab
                cmds.Add(WHRCompPlaceCTU(ctu, path));//CTU Complete Place
                cmds.Add(WHR_Home());//WHR Home

                //WHR Pick(GET)
                cmds.Add(CTU_PLACE(whr, path, prepare));//CTU prepare place
                cmds.Add(WHR_MovePick(ctu, path));//WHR move to pick
                cmds.Add(WHR_ExtendPick(ctu, path));//WHR Extend(Pick)
                cmds.Add(WHRToPickCTU(ctu, path));//WHR to Pick
                cmds.Add(CTU_Release(path));//CTU Release
                cmds.Add(WHRCompPickCTU(ctu, path));//CTU Complete Pick
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
            resetPtzDir();
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
            posIdx = 0; //reset index
        }

        private void resetPtzDir()
        {
            if (this.rbPTZDirFace.Checked == true)
            {
                btnPTZRorate.Text = "Rorate(Face)";
                ptzDir = new string[2] { "Face", "Face" };
            }
            else if (this.rbPTZDirFaceBack.Checked == true)
            {
                btnPTZRorate.Text = "Rorate(Face)";
                ptzDir = new string[2] { "Face", "Back" };
            }
            else if (this.rbPTZDirBack.Checked == true)
            {
                btnPTZRorate.Text = "Rorate(Back)";
                ptzDir = new string[2] { "Back", "Back" };
            }
            else if (this.rbPTZDirBackFace.Checked == true)
            {
                btnPTZRorate.Text = "Rorate(Back)";
                ptzDir = new string[2] { "Back", "Face" };
            }
            dirIdx = 0; //reset index
        }

        private void btnPTZRorate_Click(object sender, EventArgs e)
        {
            string dir = ptzDir[dirIdx];
            dirIdx = (dirIdx + 1) % 2;
            btnPTZRorate.Text = "Rorate(" + ptzDir[dirIdx] + ")";
            string cmd = PTZ_Rorate(ptzDir[dirIdx]);
            sendCommand(Const.CONTROLLER_CTU_PTZ, cmd);
        }

        /// <summary>
        /// $3MCR:PTRAT:MC,DIR[CR]
        /// MC：Macro Container(Always 2)      
        /// DIR : 0 = Face ,1 = Back
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        private string PTZ_Rorate(string dir)
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
            string dir = ptzDir[dirIdx];
            dirIdx = (dirIdx + 1) % 2;
            btnPTZRorate.Text = "Rorate(" + ptzDir[dirIdx] + ")";
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
            string position = pos.Equals(Const.PTZ_POSITION_ODD) ? "0" : "1";
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
            //Pick(GET)
            cmds.Add(PTZ_Move_CTU(ptzPos[0], ptzDir[0], path));//transfer 1st time
            cmds.Add(PTZ_Move_Home("PTR"));//home
            cmds.Add(PTZ_Move_CTU(ptzPos[1], ptzDir[1], path));//transfer 2nd time
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
               e.KeyChar == (Char)13 || e.KeyChar == (Char)8)
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
            string action = Const.CTU_ACTION_PREPARE;
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;

            showAutoDialog();
            ArrayList cmds = new ArrayList();
            //CTU GET from WHR(WHR put)
            cmds.Add(CTU_PICK(Const.DEVICE_WHR, path, action));//CTU prepare pick
            //cmds.Add(WHR_MovePlace(Const.DEVICE_CTU, path));//WHR move to place
            //cmds.Add(WHR_ExtendPlace(Const.DEVICE_CTU, path));//WHR Extend(Place)
            cmds.Add(WHRToPlaceCTU(Const.DEVICE_CTU, path));//WHR to Place
            cmds.Add(CTU_Grab(path));//CTU Grab
            cmds.Add(WHRCompPlaceCTU(Const.DEVICE_CTU, path));//WHR Complete Place
            //cmds.Add(CTU_HOME());//CTU Home

            //CTU put to WHR(WHR get)
            cmds.Add(CTU_PLACE(Const.DEVICE_WHR, path, action));//CTU prepare place
            //cmds.Add(WHR_MovePick(Const.DEVICE_CTU, path));//WHR move to pick
            //cmds.Add(WHR_ExtendPick(Const.DEVICE_CTU, path));//WHR Extend(Pick)
            cmds.Add(WHRToPickCTU(Const.DEVICE_CTU, path));//WHR to Pick
            cmds.Add(CTU_Release(path));//CTU Release
            cmds.Add(WHRCompPickCTU(Const.DEVICE_CTU, path));//WHR Complete Pick
            //cmds.Add(CTU_HOME());//CTU Home

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

            //Put to PTZ 1st time
            cmds.Add(CTU_PLACE(device, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], ptzDir[0], path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PLACE(device, path, place));//CTU put to PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home
            //Put to PTZ 2nd time
            cmds.Add(CTU_PLACE(device, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[1], ptzDir[1], path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PLACE(device, path, place));//CTU put to PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home
            //GET from PTZ 1st time
            cmds.Add(CTU_PICK(device, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], ptzDir[0], path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PICK(device, path, pick));//CTU get from PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home
            //GET from PTZ 2nd time
            cmds.Add(CTU_PICK(device, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], ptzDir[0], path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PICK(device, path, pick));//CTU get fromPTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home

            //send commands
            sendCommands(cmds);
        }

        private void btnCTUAuto_Click(object sender, EventArgs e)
        {
            string path = rbCTUPathClean.Checked ? Const.PATH_CLEAN : Const.PATH_DIRTY;
            string prepare = Const.CTU_ACTION_PREPARE;
            string pick = Const.CTU_ACTION_PICK;
            string place = Const.CTU_ACTION_PLACE;
            string ptz = Const.DEVICE_PTZ;
            string whr = Const.DEVICE_PTZ;
            string ctu = Const.DEVICE_CTU;

            showAutoDialog();
            ArrayList cmds = new ArrayList();

            /**********************************  Dirty:1st 取片加工 **********************************/
            //WHR put wafer to CTU 
            cmds.Add(CTU_PICK(whr, path, prepare));//CTU prepare for WHR place
            cmds.Add(WHRToPlaceCTU(ctu, path));//WHR to Place
            cmds.Add(CTU_Grab(path));//CTU Grab
            cmds.Add(WHRCompPlaceCTU(ctu, path));//WHR Complete Place/
            //CTU Put wafer to PTZ 
            cmds.Add(CTU_PLACE(ptz, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], ptzDir[0], path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PLACE(ptz, path, place));//CTU put to PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            //cmds.Add(CTU_HOME());//CTU move Home
            /**********************************  Dirty:2nd 取片加工 **********************************/
            //WHR put wafer to CTU 
            cmds.Add(CTU_PICK(whr, path, prepare));//CTU prepare for WHR place
            cmds.Add(WHRToPlaceCTU(ctu, path));//WHR to Place
            cmds.Add(CTU_Grab(path));//CTU Grab
            cmds.Add(WHRCompPlaceCTU(ctu, path));//WHR Complete Place    /
            //cmds.Add(CTU_HOME());//CTU move Home  
            //CTU Put wafer to PTZ 
            cmds.Add(CTU_PLACE(ptz, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[1], ptzDir[1], path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PLACE(ptz, path, place));//CTU put to PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            //cmds.Add(CTU_HOME());//CTU move Home
            /**********************************  Clean:1st 完工取片 **********************************/
            //CTU GET wafer from PTZ
            cmds.Add(CTU_PICK(ptz, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], ptzDir[0], path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PICK(ptz, path, pick));//CTU get from PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            //cmds.Add(CTU_HOME());//CTU move Home
            //WHR Get Wafer from CTU
            cmds.Add(CTU_PLACE(whr, path, prepare));//CTU prepare for WHR get wafer
            cmds.Add(WHRToPickCTU(ctu, path));//WHR to Pick
            cmds.Add(CTU_Release(path));//CTU Release
            cmds.Add(WHRCompPickCTU(Const.DEVICE_CTU, path));//WHR Complete Pick
            /**********************************  Clean:2nd 完工取片 **********************************/
            //CTU GET wafer from PTZ
            cmds.Add(CTU_PICK(ptz, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[1], ptzDir[1], path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PICK(ptz, path, pick));//CTU get from PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home
            //WHR Get Wafer from CTU
            cmds.Add(CTU_PLACE(whr, path, prepare));//CTU prepare for WHR get wafer
            cmds.Add(WHRToPickCTU(ctu, path));//WHR to Pick
            cmds.Add(CTU_Release(path));//CTU Release
            cmds.Add(WHRCompPickCTU(Const.DEVICE_CTU, path));//WHR Complete Pick

            //send commands
            sendCommands(cmds);
        }

        private void btnClearMsg_Click(object sender, EventArgs e)
        {
            rtbMsg.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbCmd.Text.Trim().Equals(""))
                FormMainUpdate.ShowMessage("Command text is empty.");
            else
            {
                sendCommand(tbCmd.Text);
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
            if (tbCmd.Text.Trim().Equals(""))
            {
                FormMainUpdate.ShowMessage("No command data!");
                return;
            }

            dgvCmdScript.DataSource = null;
            Command.addScriptCmd(tbCmd.Text);
            //int seq = oCmdScript.Count + 1;
            //oCmdScript.Add(new CmdScript { Seq = seq, Command = tbCmd.Text });
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
            btnScriptRun_Click(sender,e);
        }
        private void btnInitAll_Click(object sender, EventArgs e)
        {
            loadScript("wts_init.json", sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            loadScript("wts_reset.json", sender, e);
        }

        private void btnAutoRun_Click(object sender, EventArgs e)
        {
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

        private void runScript(object data)
        {
            int repeatTimes = 0;
            int.TryParse(tbTimes.Text, out repeatTimes);
            //The efem motion is not allowed when the alarm occurs,please reset alarm first.
            int cnt = 1;
            while (cnt <= repeatTimes && !FormMainUpdate.isAlarmSet && isScriptRunning)
            {
                FormMainUpdate.LogUpdate("\n**************  Run Script: " + cnt + "  **************");
                foreach (CmdScript element in Command.oCmdScript)
                {
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
                    FormMainUpdate.LogUpdate("\n**************  Script Commnad Start  **************");
                    sendCommand(cmd);
                    SpinWait.SpinUntil(() => isCmdFin, intCmdTimeOut);// wait for command complete       
                    if (!isCmdFin)
                    {
                        FormMainUpdate.ShowMessage("Command Timeout");
                        FormMainUpdate.AlarmUpdate(true);
                        return;//exit for
                    }
                    //resummn after motion complete               
                    if (FormMainUpdate.isAlarmSet)
                    {
                        FormMainUpdate.ShowMessage("Execute " + cmd + " error.");
                        return;//exit for
                    }
                    currentCmd = ""; //clear command
                    FormMainUpdate.LogUpdate("**************  Script Commnad Finish  **************");
                    SpinWait.SpinUntil(() => false, 500);
                }
                cnt++;
            }
            //FormMainUpdate.ShowMessage("Command Script done.");他們說訊息看了很煩!!
            setIsRunning(false);//執行結束
            isScriptRunning = false;//執行結束

        }

        private void btnScriptStop_Click(object sender, EventArgs e)
        {
            FormMainUpdate.AlarmUpdate(false);
            isPause = false;
            FormMainUpdate.LogUpdate("\n*************   Manual Stop     *************");
            isScriptRunning = false;
            setIsRunning(false);//執行結束
        }

        private void dgvCmdScript_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCmdScript.SelectedCells[0].ColumnIndex < 1)
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
                            cbRoutine.Text = "S";
                        else
                            cbRoutine.Text = "M";
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
                    textBox2.Text = address + "SET:MEDIT:" + cbRoutine.Text + "," + macroName + "," + textBox2.Text;
                    textBox3.Text = address + "SET:MSAVE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception Message", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }


        private void btnSetMarco_Click(object sender, EventArgs e)
        {
            Command.oCmdScript.Clear();//clear script
            //create script
            FormMainUpdate.addScriptCmd(textBox1.Text);
            FormMainUpdate.addScriptCmd(textBox2.Text);
            FormMainUpdate.addScriptCmd(textBox3.Text);
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
            string cmd = "$3MCR:CTORG:1";
            sendCommand(cmd);
        }


        int currentY_I = 15;
        int currentY_O = 15;

        private void InsertIO(string AddressNo, string ID, string Name,string desc, string Type, Panel P)
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
            value.Name = AddressNo+"_" + ID + "_"+ Type;
            value.Text = "●";
            value.ForeColor = Color.Red;
            value.Location = new System.Drawing.Point(0, currentY);
            value.Font = new Font(new FontFamily(value.Font.Name), 12, value.Font.Style);
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
                id.Size = new System.Drawing.Size(130, 20);
            }
            id.Font = new Font(new FontFamily(id.Font.Name), 12, id.Font.Style);
            hint.SetToolTip(id, desc);
            P.Controls.Add(id);

            if (Type.ToUpper().Equals("OUT"))
            {
                Button On = new Button();
                On.Text = "On";
                On.Name = AddressNo + "_" + ID + "_" + Type + "_ON";
                On.Click += On_IO_Click;
                On.Location = new System.Drawing.Point(170, currentY);
                On.Font = new Font(new FontFamily(On.Font.Name), 9, On.Font.Style);
                On.Size = new System.Drawing.Size(45, 20);
                P.Controls.Add(On);

                Button Off = new Button();
                Off.Text = "Off";
                Off.Name = AddressNo + "_" + ID + "_" + Type + "_OFF";
                Off.Click += On_IO_Click;
                Off.Location = new System.Drawing.Point(215, currentY);
                Off.Font = new Font(new FontFamily(On.Font.Name), 9, On.Font.Style);
                Off.Size = new System.Drawing.Size(45, 20);
                P.Controls.Add(Off);
            }
            
        }



        private void Initial_I_O()
        {
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(@"Stocker_IO.csv");
            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    string[] raw = line.Split(',');
                    if (raw[4].ToUpper().Equals("IN"))
                    {
                        InsertIO(raw[0], raw[1], raw[2], raw[3],raw[4], Stocker_I_List);
                    }
                    else
                    {
                        InsertIO(raw[0], raw[1], raw[2], raw[3], raw[4], Stocker_O_List);
                    }

                }catch(Exception e)
                {
                    MessageBox.Show("Stocker_IO.csv read err:" + line + "\n" + e.StackTrace);
                }
            }

            file.Close();
             currentY_I = 15;
             currentY_O = 15;
            file =
                new System.IO.StreamReader(@"WHR_IO.csv");
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
                    MessageBox.Show("WHR_IO.csv read err:" + line + "\n" + e.StackTrace);
                }
            }

            file.Close();
            currentY_I = 15;
            currentY_O = 15;
            file =
                new System.IO.StreamReader(@"CTU_PTZ_IO.csv");
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
                    MessageBox.Show("CTU_PTZ_IO.csv read err:" + line + "\n" + e.StackTrace);
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
            string type = key.Substring(key.LastIndexOf("_")+1);
            key = key.Substring(0,key.LastIndexOf("_"));

            switch (type.ToUpper())
            {
                case "ON":
                    FormMainUpdate.Update_IO(key,"1");
                    break;

                case "OFF":
                    FormMainUpdate.Update_IO(key, "0");
                    break;
            }

        }

    }
}
