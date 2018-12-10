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

        
        private void sendCommands(string deviceName, ArrayList cmds)
        {
            int cnt = 1;//repeat count 
            while (cnt > 0)
            {
                foreach(String cmd in cmds)
                {
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
            sendCommands(Const.CONTROLLER_STK, cmds);
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
            sendCommands(Const.CONTROLLER_STK, cmds);
        }

        private void btnI1Auto_Click(object sender, EventArgs e)
        {
            showAutoDialog();
            ArrayList cmds = new ArrayList();
            cmds.Add(ILPT_Load(Const.STK_ILPT1));
            cmds.Add(ILPT_Unload(Const.STK_ILPT1));
            sendCommands(Const.CONTROLLER_STK, cmds);
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
                sendCommands(Const.CONTROLLER_STK, cmds);
            }
        }

        private void btnI2Auto_Click(object sender, EventArgs e)
        {
            showAutoDialog();
            ArrayList cmds = new ArrayList();
            cmds.Add(ILPT_Load(Const.STK_ILPT2));
            cmds.Add(ILPT_Unload(Const.STK_ILPT2));
            sendCommands(Const.CONTROLLER_STK, cmds);
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

        //private void autoRun(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    // 根據 button name 決定要跑的動作
        //    switch (btn.Name)
        //    {
        //        case Const.AUTO_RUN_STK_ELPT1:

        //            break;
        //        case Const.AUTO_RUN_STK_ELPT2:

        //            break;
        //        case Const.AUTO_RUN_STK_ILPT1:
        //            break;
        //        case Const.AUTO_RUN_STK_ILPT2:
        //            break;
        //        case Const.AUTO_RUN_STK_FOUP_ROBOT:
        //            autoRunELPT2();
        //            break;
        //        case Const.AUTO_RUN_CTU_ALL:
        //            break;
        //        case Const.AUTO_RUN_CTU_TO_PTZ:
        //            break;
        //        case Const.AUTO_RUN_CTU_TO_WHR:
        //            break;
        //        case Const.AUTO_RUN_PTZ:
        //            break;
        //        case Const.AUTO_RUN_WHR_ALL:
        //            break;
        //        case Const.AUTO_RUN_WHR_TO_CTU:
        //            break;
        //        case Const.AUTO_RUN_WHR_TO_PORT:
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}
