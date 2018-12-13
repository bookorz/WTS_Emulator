using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        Boolean autoMode = false;
        Button[] autoBtns ;
        private string[] ptzDir = new string[2] { "Face", "Face"};
        private string[] ptzPos = new string[2] { "Odd", "Even" };
        private int dirIdx = 0;
        private int posIdx = 0;

        public FormMain()
        {
            InitializeComponent();
            autoBtns = new Button[] {
                btnE1Auto, btnE2Auto, btnFoupRotAuto,btnI1Auto, btnI2Auto,
                btnWHRAuto, btnWHRCTUAuto, btnWHRPortAuto,
                btnCTUAuto, btnCTUAutoPTZ, btnCTUAutoWHR,
                btnPTZAuto };
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
            switch (port){
                case Const.STK_ELPT1:
                    cmd = "$1GET:CID__:1";
                    break;
                case Const.STK_ELPT2:
                    cmd = "$1GET:CID__:2";
                    break;
            }
            return cmd;
        }

        
        private void sendCommands(ArrayList cmds)
        {
            int cnt = 1;//repeat count 
            while (cnt > 0)
            {
                foreach(String cmd in cmds)
                {
                    string deviceName = "";
                    if (cmd.StartsWith("$1"))
                    {
                        deviceName = Const.CONTROLLER_STK;
                    }else if (cmd.StartsWith("$2"))
                    {
                        deviceName = Const.CONTROLLER_WHR;
                    }
                    else if (cmd.StartsWith("$3"))
                    {
                        deviceName = Const.CONTROLLER_CTU_PTZ;
                    }
                    sendCommand(deviceName, cmd);
                }
                cnt--;
            }
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
                MessageBox.Show(cmd);
                //device.Send(cmd + "\r"); 暫時先不送指令, 先跳
            }
        }

        private void connDevice(string device, DeviceConfig config)
        {
            // 暫時沒有連線
            switch (device)
            {
                case Const.CONTROLLER_STK:
                    ctrlSTK = new TcpCommClient(config, this);
                    //ctrlSTK.Start();
                    break;
                case Const.CONTROLLER_WHR:
                    ctrlWHR = new TcpCommClient(config, this);
                    //ctrlWHR.Start();
                    break;
                case Const.CONTROLLER_CTU_PTZ:
                    ctrlCTU = new TcpCommClient(config, this);
                    //ctrlCTU.Start();
                    break;
            }
        }

        private void btnCtrlSTKCon_Click(object sender, EventArgs e)
        {
            DeviceConfig config = new DeviceConfig();
            config.IPAdress = tbCtrlSTK_IP.Text;
            config.Port = int.Parse(tbCtrlSTK_Port.Text);

            connDevice(Const.CONTROLLER_STK, config);
        }

        private void btnCtrlWHRCon_Click(object sender, EventArgs e)
        {
            DeviceConfig config = new DeviceConfig();
            config.IPAdress = tbCtrlWHR_IP.Text;
            config.Port = int.Parse(tbCtrlWHR_Port.Text);

            connDevice(Const.CONTROLLER_WHR, config);
        }

        private void btnCtrlCTUCon_Click(object sender, EventArgs e)
        {
            DeviceConfig config = new DeviceConfig();
            config.IPAdress = tbCtrlCTU_IP.Text;
            config.Port = int.Parse(tbCtrlCTU_Port.Text);

            connDevice(Const.CONTROLLER_CTU_PTZ, config);
        }

        void IConnectionReport.On_Connection_Message(object Msg)
        {
            throw new NotImplementedException();
        }

        void IConnectionReport.On_Connection_Connecting(string Msg)
        {
            throw new NotImplementedException();
        }

        void IConnectionReport.On_Connection_Connected(object Msg)
        {
            throw new NotImplementedException();
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
                    cmd = "$1SET: SV___: 17," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
                    break;
                case Const.SV_STK_ELPT2_CLAMP:
                    cmd = "$1SET: SV___: 18," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
                    break;
                case Const.SV_STK_ELPT1_SHUTTER:
                    cmd = "$1SET: SV___: 19," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
                    break;
                case Const.SV_STK_ELPT2_SHUTTER:
                    cmd = "$1SET: SV___: 20," + (sw.Equals(Const.SV_STATUS_ON) ? "1" : "0");
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
                    cmd = "$1MCR: SLIDE: 1,1," + (position.Equals(Const.POSITION_ELPT_STOCK_IN) ? "1" : "0");
                    break;
                case Const.STK_ELPT2:
                    cmd = "$1MCR: SLIDE: 2,2," + (position.Equals(Const.POSITION_ELPT_STOCK_IN) ? "1" : "0");
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
                    cmd = "$1MCR:DROPN:3,1";
                    break;
                case Const.STK_ILPT2:
                    cmd = "$1MCR:DROPN:4,2";
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
                    cmd = "$1MCR:DRCLS:3,1";
                    break;
                case Const.STK_ILPT2:
                    cmd = "$1MCR:DRCLS:4,2";
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
        
        private void btnI1GetSlotMap_Click(object sender, EventArgs e)
        {
            string cmd = ILPT_GetSlotMap(Const.STK_ILPT1);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private void btnI2GetSlotMap_Click(object sender, EventArgs e)
        {
            string cmd = ILPT_GetSlotMap(Const.STK_ILPT2);
            sendCommand(Const.CONTROLLER_STK, cmd);
        }

        private string ILPT_GetSlotMap(string port)
        {
            //int timeout = 9999;
            //string result;
            string cmd = "";
            switch (port)
            {
                case Const.STK_ILPT1:
                    cmd = "kuma$1GET:MAP:3,1";//kuma 測試用 非 final 指令
                    break;
                case Const.STK_ILPT2:
                    cmd = "kuma$1GET:MAP:4,2";//kuma 測試用 非 final 指令
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

        }

        private void btnE2Init_Click(object sender, EventArgs e)
        {

        }

        private void tbI1Init_Click(object sender, EventArgs e)
        {

        }

        private void tbI2Init_Click(object sender, EventArgs e)
        {

        }

        private void btnE1Reset_Click(object sender, EventArgs e)
        {

        }

        private void btnE2Reset_Click(object sender, EventArgs e)
        {

        }

        private void tbI1Reset_Click(object sender, EventArgs e)
        {

        }

        private void tbI2Reset_Click(object sender, EventArgs e)
        {

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
            if(position != null && !position.Trim().Equals(""))
            {
                cmd = "$1CMD:GETST:" + position  + ",001,1,1";
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
                cmd = "$1CMD:PUTST:" + position  + ",001,1,0";
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
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_ON));//clamp
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_ON));//open shutter
            cmds.Add(ELPT_Move(Const.STK_ELPT1, Const.POSITION_ELPT_STOCK_IN));//move in
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_OFF));//close shutter
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_OFF));//unclamp
            //unload
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_ON));//clamp
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_ON));//open shutter
            cmds.Add(ELPT_Move(Const.STK_ELPT1, Const.POSITION_ELPT_STOCK_OUT));//move out
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_OFF));//close shutter
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_OFF));//unclamp            
            sendCommands(cmds);
        }

        private void btnE2Auto_Click(object sender, EventArgs e)
        {
            showAutoDialog();
            ArrayList cmds = new ArrayList();
            cmds.Add(readRFID(Const.STK_ELPT2));//read rfid
            //readRFID(Const.STK_ELPT2);
            //load
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_ON));//clamp
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_ON));//open shutter
            cmds.Add(ELPT_Move(Const.STK_ELPT1, Const.POSITION_ELPT_STOCK_IN));//move in
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_OFF));//close shutter
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_OFF));//unclamp
            //unload
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_ON));//clamp
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_ON));//open shutter
            cmds.Add(ELPT_Move(Const.STK_ELPT1, Const.POSITION_ELPT_STOCK_OUT));//move out
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_SHUTTER, Const.SV_STATUS_OFF));//close shutter
            cmds.Add(STK_SET_SV(Const.SV_STK_ELPT1_CLAMP, Const.SV_STATUS_OFF));//unclamp            
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
            //關閉主頁功能
            FormUpdate.SetFormEnable("FormMain", false);
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
                && ACT_TYPE != null && !ACT_TYPE.Trim().Equals("") )
            {
                cmd = "$3MCR:CTGET:1,"+ POS + ","+ MOD_PATH + ","+ ACT_TYPE ;
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

            if ( MOD_PATH != null && !MOD_PATH.Trim().Equals(""))
            {
                cmd = "$3MCR:CTRLS:1," + MOD_PATH ;
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
            cmd = "$3MCR:PTRAT:2,"+ direction;
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
            string cmd = PTZ_Move_CTU(pos, ptzDir[dirIdx], path);
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
            string direction = dir.Equals(Const.PTZ_DIRECTION_FACE) ? "0" : "1";
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
            }else if (pos.Equals(Const.PTZ_POSITION_ODD))
            {
                position = "1";
            }
            else if (pos.Equals(Const.PTZ_POSITION_EVEN))
            {
                position = "2";
            }
            string cmd = "";
            cmd = "$3MCR:PTMOV:2," + position;
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
            cmds.Add(CTU_HOME());//CTU Home

            //CTU put to WHR(WHR get)
            cmds.Add(CTU_PLACE(Const.DEVICE_WHR, path, action));//CTU prepare place
            //cmds.Add(WHR_MovePick(Const.DEVICE_CTU, path));//WHR move to pick
            //cmds.Add(WHR_ExtendPick(Const.DEVICE_CTU, path));//WHR Extend(Pick)
            cmds.Add(WHRToPickCTU(Const.DEVICE_CTU, path));//WHR to Pick
            cmds.Add(CTU_Release(path));//CTU Release
            cmds.Add(WHRCompPickCTU(Const.DEVICE_CTU, path));//WHR Complete Pick
            cmds.Add(CTU_HOME());//CTU Home

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
            string cmd = "$3MCR:CTHOM";
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
            cmds.Add(WHRCompPlaceCTU(ctu, path));//WHR Complete Place   
            cmds.Add(CTU_HOME());//CTU move Home    
            //CTU Put wafer to PTZ 
            cmds.Add(CTU_PLACE(ptz, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], ptzDir[0], path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PLACE(ptz, path, place));//CTU put to PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home
            /**********************************  Dirty:2nd 取片加工 **********************************/
            //WHR put wafer to CTU 
            cmds.Add(CTU_PICK(whr, path, prepare));//CTU prepare for WHR place
            cmds.Add(WHRToPlaceCTU(ctu, path));//WHR to Place
            cmds.Add(CTU_Grab(path));//CTU Grab
            cmds.Add(WHRCompPlaceCTU(ctu, path));//WHR Complete Place     
            cmds.Add(CTU_HOME());//CTU move Home  
            //CTU Put wafer to PTZ 
            cmds.Add(CTU_PLACE(ptz, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[1], ptzDir[1], path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PLACE(ptz, path, place));//CTU put to PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home
            /**********************************  Clean:1st 完工取片 **********************************/
            //CTU GET wafer from PTZ
            cmds.Add(CTU_PICK(ptz, path, prepare));//CTU prepare for PTZ
            cmds.Add(PTZ_Move_CTU(ptzPos[0], ptzDir[0], path));//PTZ 移到 CTU 下方
            cmds.Add(CTU_PICK(ptz, path, pick));//CTU get from PTZ
            cmds.Add(PTZ_Move_Home("PTR"));//PTZ move home
            cmds.Add(CTU_HOME());//CTU move Home
            //WHR Get Wafer from CTU
            cmds.Add(CTU_PLACE(whr, path, prepare));//CTU prepare for WHR get wafer
            cmds.Add(WHRToPickCTU(ctu, path));//WHR to Pick
            cmds.Add(CTU_Release(path));//CTU Release
            cmds.Add(WHRCompPickCTU(Const.DEVICE_CTU, path));//WHR Complete Pick
            cmds.Add(CTU_HOME());//CTU Home
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
            cmds.Add(CTU_HOME());//CTU Home

            //send commands
            sendCommands(cmds);

        }
    }
}
