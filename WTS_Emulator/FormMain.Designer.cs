namespace WTS_Emulator
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConn = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnDisConn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHostIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_alarm = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_ConnectState = new System.Windows.Forms.Label();
            this.tabMode = new System.Windows.Forms.TabControl();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.tbCtrlCTU_IP = new System.Windows.Forms.TextBox();
            this.btnCtrlCTUCon = new System.Windows.Forms.Button();
            this.tbCtrlCTUIP = new System.Windows.Forms.Label();
            this.btnCtrlCTUDiscon = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.tbCtrlCTU_Port = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.btnCtrlWHRCon = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.btnCtrlWHRDiscon = new System.Windows.Forms.Button();
            this.tbCtrlWHR_Port = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCtrlWHR_IP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.btnCtrlSTKCon = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.tbCtrlSTK_Port = new System.Windows.Forms.TextBox();
            this.tbCtrlSTK_IP = new System.Windows.Forms.TextBox();
            this.btnCtrlSTKDiscon = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabCmd = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnNewScript = new System.Windows.Forms.Button();
            this.btnStepRun = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTimes = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnScriptStop = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.dgvCmdScript = new System.Windows.Forms.DataGridView();
            this.btnScriptRun = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnInitAll = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAddScript = new System.Windows.Forms.Button();
            this.tbCmd = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tabStocker = new System.Windows.Forms.TabPage();
            this.groupBox46 = new System.Windows.Forms.GroupBox();
            this.btnFoupRotSwitch = new System.Windows.Forms.Button();
            this.groupBox49 = new System.Windows.Forms.GroupBox();
            this.cbDestination = new System.Windows.Forms.ComboBox();
            this.btnFoupRotPlace = new System.Windows.Forms.Button();
            this.btnFoupRotExtendDest = new System.Windows.Forms.Button();
            this.btnFoupRotPrePlace = new System.Windows.Forms.Button();
            this.btnFoupRotRetractDest = new System.Windows.Forms.Button();
            this.btnFoupRotRelease = new System.Windows.Forms.Button();
            this.btnFoupRotDownDest = new System.Windows.Forms.Button();
            this.btnSTKServoOn = new System.Windows.Forms.Button();
            this.btnFoupRotHome = new System.Windows.Forms.Button();
            this.groupBox48 = new System.Windows.Forms.GroupBox();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.btnFoupRotPrePick = new System.Windows.Forms.Button();
            this.btnFoupRotExtendSrc = new System.Windows.Forms.Button();
            this.btnFoupRotRetractSrc = new System.Windows.Forms.Button();
            this.btnFoupRotPick = new System.Windows.Forms.Button();
            this.btnFoupRotGrab = new System.Windows.Forms.Button();
            this.btnFoupRotUpSrc = new System.Windows.Forms.Button();
            this.groupBox47 = new System.Windows.Forms.GroupBox();
            this.btnSTKRefresh = new System.Windows.Forms.Button();
            this.tbPresShelf14 = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.tbPresELPT1 = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.tbPresILPT1 = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.tbPresILPT2 = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.tbPresRobot = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.tbPresShelf1 = new System.Windows.Forms.TextBox();
            this.tbPresELPT2 = new System.Windows.Forms.TextBox();
            this.tbPresShelf3 = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.tbPresShelf5 = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.tbPresShelf4 = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.tbPresShelf7 = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.tbPresShelf11 = new System.Windows.Forms.TextBox();
            this.tbPresShelf9 = new System.Windows.Forms.TextBox();
            this.tbPresShelf8 = new System.Windows.Forms.TextBox();
            this.tbPresShelf15 = new System.Windows.Forms.TextBox();
            this.tbPresShelf13 = new System.Windows.Forms.TextBox();
            this.tbPresShelf12 = new System.Windows.Forms.TextBox();
            this.tbPresShelf16 = new System.Windows.Forms.TextBox();
            this.tbPresShelf6 = new System.Windows.Forms.TextBox();
            this.tbPresShelf10 = new System.Windows.Forms.TextBox();
            this.tbPresShelf2 = new System.Windows.Forms.TextBox();
            this.btnFoupRotAuto = new System.Windows.Forms.Button();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.tbI2Error = new System.Windows.Forms.TextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.tbI2Init = new System.Windows.Forms.Button();
            this.btnI2UnLoad = new System.Windows.Forms.Button();
            this.tbI2SlotMap = new System.Windows.Forms.TextBox();
            this.tbI2Reset = new System.Windows.Forms.Button();
            this.btnI2GetSlotMap = new System.Windows.Forms.Button();
            this.label71 = new System.Windows.Forms.Label();
            this.btnI2Auto = new System.Windows.Forms.Button();
            this.btnI2Load = new System.Windows.Forms.Button();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.tbI1Error = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.tbI1Init = new System.Windows.Forms.Button();
            this.btnI1UnLoad = new System.Windows.Forms.Button();
            this.tbI1SlotMap = new System.Windows.Forms.TextBox();
            this.tbI1Reset = new System.Windows.Forms.Button();
            this.btnI1GetSlotMap = new System.Windows.Forms.Button();
            this.label66 = new System.Windows.Forms.Label();
            this.btnI1Auto = new System.Windows.Forms.Button();
            this.btnI1Load = new System.Windows.Forms.Button();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.tbE2Error = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.btnE2Init = new System.Windows.Forms.Button();
            this.tbE2RFID = new System.Windows.Forms.TextBox();
            this.btnE2Clamp = new System.Windows.Forms.Button();
            this.label68 = new System.Windows.Forms.Label();
            this.btnE2Reset = new System.Windows.Forms.Button();
            this.btnE2MoveOut = new System.Windows.Forms.Button();
            this.btnE2MoveIn = new System.Windows.Forms.Button();
            this.btnE2CloseShutter = new System.Windows.Forms.Button();
            this.btnE2OpenShutter = new System.Windows.Forms.Button();
            this.btnE2Auto = new System.Windows.Forms.Button();
            this.btnE2ReadID = new System.Windows.Forms.Button();
            this.btnE2UnClamp = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.tbE1Error = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.tbE1RFID = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.btnE1Init = new System.Windows.Forms.Button();
            this.btnE1Clamp = new System.Windows.Forms.Button();
            this.btnE1Reset = new System.Windows.Forms.Button();
            this.btnE1MoveOut = new System.Windows.Forms.Button();
            this.btnE1MoveIn = new System.Windows.Forms.Button();
            this.btnE1CloseShutter = new System.Windows.Forms.Button();
            this.btnE1OpenShutter = new System.Windows.Forms.Button();
            this.btnE1Auto = new System.Windows.Forms.Button();
            this.btnE1ReadID = new System.Windows.Forms.Button();
            this.btnE1UnClamp = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.tabWHR = new System.Windows.Forms.TabPage();
            this.groupBox60 = new System.Windows.Forms.GroupBox();
            this.rbWHRPathDirty = new System.Windows.Forms.RadioButton();
            this.label86 = new System.Windows.Forms.Label();
            this.rbWHRPathClean = new System.Windows.Forms.RadioButton();
            this.groupBox50 = new System.Windows.Forms.GroupBox();
            this.btnWHRReset = new System.Windows.Forms.Button();
            this.btnWHRInit = new System.Windows.Forms.Button();
            this.btnWHRAuto = new System.Windows.Forms.Button();
            this.groupBox51 = new System.Windows.Forms.GroupBox();
            this.btnCTUPreparePlaceWHR_1 = new System.Windows.Forms.Button();
            this.label73 = new System.Windows.Forms.Label();
            this.btnWHRMovePickCTU = new System.Windows.Forms.Button();
            this.btnWHRExtendPickCTU = new System.Windows.Forms.Button();
            this.btnCTUPreparePickWHR_1 = new System.Windows.Forms.Button();
            this.btnCTUReleaseWHR_1 = new System.Windows.Forms.Button();
            this.btnCTUGrabWHR_1 = new System.Windows.Forms.Button();
            this.btnWHRRetractPickCTU = new System.Windows.Forms.Button();
            this.btnWHRToPlaceCTU_1 = new System.Windows.Forms.Button();
            this.btnWHRCompPickCTU_1 = new System.Windows.Forms.Button();
            this.btnWHRCompPlaceCTU = new System.Windows.Forms.Button();
            this.btnWHRToPickCTU_1 = new System.Windows.Forms.Button();
            this.btnWHRRetractPlaceCTU = new System.Windows.Forms.Button();
            this.btnWHRCTUAuto = new System.Windows.Forms.Button();
            this.btnWHRExtendPlaceCTU = new System.Windows.Forms.Button();
            this.btnWHRMovePlaceCTU = new System.Windows.Forms.Button();
            this.groupBox52 = new System.Windows.Forms.GroupBox();
            this.cbWHRSelctILPT = new System.Windows.Forms.ComboBox();
            this.btnWHRPlacePort = new System.Windows.Forms.Button();
            this.btnWHRPortAuto = new System.Windows.Forms.Button();
            this.btnWHRRetractPlacePort = new System.Windows.Forms.Button();
            this.btnWHRRetractPickPort = new System.Windows.Forms.Button();
            this.btnWHRMovePlacePort = new System.Windows.Forms.Button();
            this.btnWHRMovePickPort = new System.Windows.Forms.Button();
            this.btnWHRDownPort = new System.Windows.Forms.Button();
            this.btnWHRPickPort = new System.Windows.Forms.Button();
            this.btnWHRExtendPlacePort = new System.Windows.Forms.Button();
            this.btnWHRExtendPickPort = new System.Windows.Forms.Button();
            this.btnWHRUpPort = new System.Windows.Forms.Button();
            this.btnWHRHome = new System.Windows.Forms.Button();
            this.tabCTU_PTZ = new System.Windows.Forms.TabPage();
            this.groupBox61 = new System.Windows.Forms.GroupBox();
            this.tbDegree = new System.Windows.Forms.TextBox();
            this.btnAlign = new System.Windows.Forms.Button();
            this.label89 = new System.Windows.Forms.Label();
            this.groupBox59 = new System.Windows.Forms.GroupBox();
            this.rbCTUPathDirty = new System.Windows.Forms.RadioButton();
            this.label83 = new System.Windows.Forms.Label();
            this.rbCTUPathClean = new System.Windows.Forms.RadioButton();
            this.groupBox56 = new System.Windows.Forms.GroupBox();
            this.tbPtzSlotMap = new System.Windows.Forms.TextBox();
            this.groupBox58 = new System.Windows.Forms.GroupBox();
            this.label87 = new System.Windows.Forms.Label();
            this.rbPTZDirFaceBack = new System.Windows.Forms.RadioButton();
            this.rbPTZDirBackFace = new System.Windows.Forms.RadioButton();
            this.rbPTZDirBack = new System.Windows.Forms.RadioButton();
            this.rbPTZDirFace = new System.Windows.Forms.RadioButton();
            this.btnPTZGetSlotMap = new System.Windows.Forms.Button();
            this.label88 = new System.Windows.Forms.Label();
            this.btnPTZMoveHome_1 = new System.Windows.Forms.Button();
            this.btnPTZReset = new System.Windows.Forms.Button();
            this.btnPTZMoveCTU_1 = new System.Windows.Forms.Button();
            this.btnPTZInit = new System.Windows.Forms.Button();
            this.groupBox57 = new System.Windows.Forms.GroupBox();
            this.label85 = new System.Windows.Forms.Label();
            this.rbPTZPosAuto = new System.Windows.Forms.RadioButton();
            this.rbPTZPosEven = new System.Windows.Forms.RadioButton();
            this.rbPTZPosOdd = new System.Windows.Forms.RadioButton();
            this.btnPTZRorate = new System.Windows.Forms.Button();
            this.btnPTZAuto = new System.Windows.Forms.Button();
            this.groupBox53 = new System.Windows.Forms.GroupBox();
            this.btnCTUReset = new System.Windows.Forms.Button();
            this.btnCTUInit = new System.Windows.Forms.Button();
            this.btnCTUAuto = new System.Windows.Forms.Button();
            this.groupBox54 = new System.Windows.Forms.GroupBox();
            this.label82 = new System.Windows.Forms.Label();
            this.btnPTZMoveCTU_2 = new System.Windows.Forms.Button();
            this.btnPTZMoveHome_2 = new System.Windows.Forms.Button();
            this.btnCTUAutoPTZ = new System.Windows.Forms.Button();
            this.btnCTUPreparePlacePTZ = new System.Windows.Forms.Button();
            this.btnCTUHome_2 = new System.Windows.Forms.Button();
            this.btnCTUPickPTZ = new System.Windows.Forms.Button();
            this.btnCTUPlacePTZ = new System.Windows.Forms.Button();
            this.btnCTUPreparePickPTZ = new System.Windows.Forms.Button();
            this.groupBox55 = new System.Windows.Forms.GroupBox();
            this.label84 = new System.Windows.Forms.Label();
            this.btnWHRCompPlaceCTU_2 = new System.Windows.Forms.Button();
            this.btnWHRCompPickCTU_2 = new System.Windows.Forms.Button();
            this.btnWHRToPlaceCTU_2 = new System.Windows.Forms.Button();
            this.btnCTUPreparePlaceWHR_2 = new System.Windows.Forms.Button();
            this.btnCTUReleaseWHR_2 = new System.Windows.Forms.Button();
            this.btnWHRToPickCTU_2 = new System.Windows.Forms.Button();
            this.btnCTUHome_1 = new System.Windows.Forms.Button();
            this.btnCTUAutoWHR = new System.Windows.Forms.Button();
            this.btnCTUGrabWHR_2 = new System.Windows.Forms.Button();
            this.btnCTUPreparePickWHR_2 = new System.Windows.Forms.Button();
            this.tabIO = new System.Windows.Forms.TabPage();
            this.tabMarco = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRoutine = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rbMarcoCTU = new System.Windows.Forms.RadioButton();
            this.rbMarcoWHR = new System.Windows.Forms.RadioButton();
            this.rbMarcoSTK = new System.Windows.Forms.RadioButton();
            this.btnSetMarco = new System.Windows.Forms.Button();
            this.Load_file = new System.Windows.Forms.Button();
            this.btnClearMsg = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnHold = new System.Windows.Forms.Button();
            this.hint = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.tabMode.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.tabCmd.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmdScript)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tabStocker.SuspendLayout();
            this.groupBox46.SuspendLayout();
            this.groupBox49.SuspendLayout();
            this.groupBox48.SuspendLayout();
            this.groupBox47.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.tabWHR.SuspendLayout();
            this.groupBox60.SuspendLayout();
            this.groupBox50.SuspendLayout();
            this.groupBox51.SuspendLayout();
            this.groupBox52.SuspendLayout();
            this.tabCTU_PTZ.SuspendLayout();
            this.groupBox61.SuspendLayout();
            this.groupBox59.SuspendLayout();
            this.groupBox56.SuspendLayout();
            this.groupBox58.SuspendLayout();
            this.groupBox57.SuspendLayout();
            this.groupBox53.SuspendLayout();
            this.groupBox54.SuspendLayout();
            this.groupBox55.SuspendLayout();
            this.tabMarco.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.GroupBox3);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 66);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect Area";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConn);
            this.groupBox2.Controls.Add(this.tbPort);
            this.groupBox2.Controls.Add(this.btnDisConn);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbHostIP);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(641, 48);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // btnConn
            // 
            this.btnConn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConn.Location = new System.Drawing.Point(408, 12);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(108, 32);
            this.btnConn.TabIndex = 15;
            this.btnConn.Text = "Connect";
            this.btnConn.UseVisualStyleBackColor = true;
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.Location = new System.Drawing.Point(323, 11);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(58, 31);
            this.tbPort.TabIndex = 3;
            this.tbPort.Text = "13000";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDisConn
            // 
            this.btnDisConn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisConn.Enabled = false;
            this.btnDisConn.Location = new System.Drawing.Point(522, 12);
            this.btnDisConn.Name = "btnDisConn";
            this.btnDisConn.Size = new System.Drawing.Size(108, 32);
            this.btnDisConn.TabIndex = 16;
            this.btnDisConn.Text = "Disconnect";
            this.btnDisConn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(281, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // tbHostIP
            // 
            this.tbHostIP.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHostIP.Location = new System.Drawing.Point(89, 11);
            this.tbHostIP.Name = "tbHostIP";
            this.tbHostIP.Size = new System.Drawing.Size(174, 31);
            this.tbHostIP.TabIndex = 1;
            this.tbHostIP.Text = "127.0.0.1";
            this.tbHostIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host IP";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.lbl_alarm);
            this.GroupBox3.Controls.Add(this.GroupBox4);
            this.GroupBox3.Controls.Add(this.lbl_ConnectState);
            this.GroupBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(653, 9);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(282, 52);
            this.GroupBox3.TabIndex = 13;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "WTS Connection State";
            // 
            // lbl_alarm
            // 
            this.lbl_alarm.BackColor = System.Drawing.Color.LimeGreen;
            this.lbl_alarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_alarm.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_alarm.Location = new System.Drawing.Point(144, 17);
            this.lbl_alarm.Name = "lbl_alarm";
            this.lbl_alarm.Size = new System.Drawing.Size(127, 30);
            this.lbl_alarm.TabIndex = 6;
            this.lbl_alarm.Text = "Alarm clear";
            this.lbl_alarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.label4);
            this.GroupBox4.Location = new System.Drawing.Point(8, 56);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(192, 56);
            this.GroupBox4.TabIndex = 5;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Quick GEM init. Result";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(8, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Result";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ConnectState
            // 
            this.lbl_ConnectState.BackColor = System.Drawing.Color.Red;
            this.lbl_ConnectState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ConnectState.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ConnectState.Location = new System.Drawing.Point(9, 17);
            this.lbl_ConnectState.Name = "lbl_ConnectState";
            this.lbl_ConnectState.Size = new System.Drawing.Size(127, 30);
            this.lbl_ConnectState.TabIndex = 0;
            this.lbl_ConnectState.Text = "Disconnection";
            this.lbl_ConnectState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMode
            // 
            this.tabMode.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tabMode.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabMode.Controls.Add(this.tabSetting);
            this.tabMode.Controls.Add(this.tabCmd);
            this.tabMode.Controls.Add(this.tabStocker);
            this.tabMode.Controls.Add(this.tabWHR);
            this.tabMode.Controls.Add(this.tabCTU_PTZ);
            this.tabMode.Controls.Add(this.tabIO);
            this.tabMode.Controls.Add(this.tabMarco);
            this.tabMode.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMode.Location = new System.Drawing.Point(6, 77);
            this.tabMode.Name = "tabMode";
            this.tabMode.SelectedIndex = 0;
            this.tabMode.Size = new System.Drawing.Size(973, 659);
            this.tabMode.TabIndex = 22;
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.groupBox16);
            this.tabSetting.Location = new System.Drawing.Point(4, 33);
            this.tabSetting.Margin = new System.Windows.Forms.Padding(0);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Size = new System.Drawing.Size(965, 622);
            this.tabSetting.TabIndex = 3;
            this.tabSetting.Text = "  WTS Setting  ";
            this.tabSetting.UseVisualStyleBackColor = true;
            this.tabSetting.Click += new System.EventHandler(this.tabSetting_Click);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.groupBox19);
            this.groupBox16.Controls.Add(this.groupBox18);
            this.groupBox16.Controls.Add(this.groupBox21);
            this.groupBox16.Location = new System.Drawing.Point(6, 3);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(734, 177);
            this.groupBox16.TabIndex = 75;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Connection setting";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.tbCtrlCTU_IP);
            this.groupBox19.Controls.Add(this.btnCtrlCTUCon);
            this.groupBox19.Controls.Add(this.tbCtrlCTUIP);
            this.groupBox19.Controls.Add(this.btnCtrlCTUDiscon);
            this.groupBox19.Controls.Add(this.label36);
            this.groupBox19.Controls.Add(this.tbCtrlCTU_Port);
            this.groupBox19.Controls.Add(this.label41);
            this.groupBox19.Font = new System.Drawing.Font("Calibri", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox19.Location = new System.Drawing.Point(18, 119);
            this.groupBox19.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox19.Size = new System.Drawing.Size(702, 44);
            this.groupBox19.TabIndex = 76;
            this.groupBox19.TabStop = false;
            // 
            // tbCtrlCTU_IP
            // 
            this.tbCtrlCTU_IP.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCtrlCTU_IP.Location = new System.Drawing.Point(161, 7);
            this.tbCtrlCTU_IP.Name = "tbCtrlCTU_IP";
            this.tbCtrlCTU_IP.Size = new System.Drawing.Size(174, 31);
            this.tbCtrlCTU_IP.TabIndex = 1;
            this.tbCtrlCTU_IP.Text = "192.168.0.129";
            this.tbCtrlCTU_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCtrlCTUCon
            // 
            this.btnCtrlCTUCon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCtrlCTUCon.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnCtrlCTUCon.Location = new System.Drawing.Point(452, 6);
            this.btnCtrlCTUCon.Name = "btnCtrlCTUCon";
            this.btnCtrlCTUCon.Size = new System.Drawing.Size(108, 31);
            this.btnCtrlCTUCon.TabIndex = 15;
            this.btnCtrlCTUCon.Text = "Connect";
            this.btnCtrlCTUCon.UseVisualStyleBackColor = true;
            this.btnCtrlCTUCon.Click += new System.EventHandler(this.btnCtrlCTUCon_Click);
            // 
            // tbCtrlCTUIP
            // 
            this.tbCtrlCTUIP.AutoSize = true;
            this.tbCtrlCTUIP.BackColor = System.Drawing.SystemColors.Highlight;
            this.tbCtrlCTUIP.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.tbCtrlCTUIP.ForeColor = System.Drawing.Color.White;
            this.tbCtrlCTUIP.Location = new System.Drawing.Point(7, 10);
            this.tbCtrlCTUIP.Name = "tbCtrlCTUIP";
            this.tbCtrlCTUIP.Size = new System.Drawing.Size(122, 23);
            this.tbCtrlCTUIP.TabIndex = 40;
            this.tbCtrlCTUIP.Text = "         CTU + PTZ";
            this.tbCtrlCTUIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCtrlCTUDiscon
            // 
            this.btnCtrlCTUDiscon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCtrlCTUDiscon.Enabled = false;
            this.btnCtrlCTUDiscon.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnCtrlCTUDiscon.Location = new System.Drawing.Point(569, 6);
            this.btnCtrlCTUDiscon.Name = "btnCtrlCTUDiscon";
            this.btnCtrlCTUDiscon.Size = new System.Drawing.Size(108, 32);
            this.btnCtrlCTUDiscon.TabIndex = 16;
            this.btnCtrlCTUDiscon.Text = "Disconnect";
            this.btnCtrlCTUDiscon.UseVisualStyleBackColor = true;
            this.btnCtrlCTUDiscon.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(138, 11);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(26, 23);
            this.label36.TabIndex = 0;
            this.label36.Text = "IP";
            // 
            // tbCtrlCTU_Port
            // 
            this.tbCtrlCTU_Port.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCtrlCTU_Port.Location = new System.Drawing.Point(382, 6);
            this.tbCtrlCTU_Port.Name = "tbCtrlCTU_Port";
            this.tbCtrlCTU_Port.Size = new System.Drawing.Size(58, 31);
            this.tbCtrlCTU_Port.TabIndex = 3;
            this.tbCtrlCTU_Port.Text = "23";
            this.tbCtrlCTU_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(340, 11);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(43, 23);
            this.label41.TabIndex = 2;
            this.label41.Text = "Port";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.btnCtrlWHRCon);
            this.groupBox18.Controls.Add(this.label37);
            this.groupBox18.Controls.Add(this.btnCtrlWHRDiscon);
            this.groupBox18.Controls.Add(this.tbCtrlWHR_Port);
            this.groupBox18.Controls.Add(this.label9);
            this.groupBox18.Controls.Add(this.tbCtrlWHR_IP);
            this.groupBox18.Controls.Add(this.label12);
            this.groupBox18.Font = new System.Drawing.Font("Calibri", 1.5F);
            this.groupBox18.Location = new System.Drawing.Point(18, 72);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox18.Size = new System.Drawing.Size(702, 44);
            this.groupBox18.TabIndex = 76;
            this.groupBox18.TabStop = false;
            // 
            // btnCtrlWHRCon
            // 
            this.btnCtrlWHRCon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCtrlWHRCon.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnCtrlWHRCon.Location = new System.Drawing.Point(452, 6);
            this.btnCtrlWHRCon.Name = "btnCtrlWHRCon";
            this.btnCtrlWHRCon.Size = new System.Drawing.Size(108, 31);
            this.btnCtrlWHRCon.TabIndex = 15;
            this.btnCtrlWHRCon.Text = "Connect";
            this.btnCtrlWHRCon.UseVisualStyleBackColor = true;
            this.btnCtrlWHRCon.Click += new System.EventHandler(this.btnCtrlWHRCon_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.SystemColors.Highlight;
            this.label37.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(7, 10);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(121, 23);
            this.label37.TabIndex = 40;
            this.label37.Text = "                  WHR";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCtrlWHRDiscon
            // 
            this.btnCtrlWHRDiscon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCtrlWHRDiscon.Enabled = false;
            this.btnCtrlWHRDiscon.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnCtrlWHRDiscon.Location = new System.Drawing.Point(569, 6);
            this.btnCtrlWHRDiscon.Name = "btnCtrlWHRDiscon";
            this.btnCtrlWHRDiscon.Size = new System.Drawing.Size(108, 32);
            this.btnCtrlWHRDiscon.TabIndex = 16;
            this.btnCtrlWHRDiscon.Text = "Disconnect";
            this.btnCtrlWHRDiscon.UseVisualStyleBackColor = true;
            this.btnCtrlWHRDiscon.Visible = false;
            // 
            // tbCtrlWHR_Port
            // 
            this.tbCtrlWHR_Port.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCtrlWHR_Port.Location = new System.Drawing.Point(382, 6);
            this.tbCtrlWHR_Port.Name = "tbCtrlWHR_Port";
            this.tbCtrlWHR_Port.Size = new System.Drawing.Size(58, 31);
            this.tbCtrlWHR_Port.TabIndex = 3;
            this.tbCtrlWHR_Port.Text = "23";
            this.tbCtrlWHR_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(340, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "Port";
            // 
            // tbCtrlWHR_IP
            // 
            this.tbCtrlWHR_IP.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCtrlWHR_IP.Location = new System.Drawing.Point(161, 7);
            this.tbCtrlWHR_IP.Name = "tbCtrlWHR_IP";
            this.tbCtrlWHR_IP.Size = new System.Drawing.Size(174, 31);
            this.tbCtrlWHR_IP.TabIndex = 1;
            this.tbCtrlWHR_IP.Text = "192.168.0.128";
            this.tbCtrlWHR_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(138, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 23);
            this.label12.TabIndex = 0;
            this.label12.Text = "IP";
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.btnCtrlSTKCon);
            this.groupBox21.Controls.Add(this.label40);
            this.groupBox21.Controls.Add(this.tbCtrlSTK_Port);
            this.groupBox21.Controls.Add(this.tbCtrlSTK_IP);
            this.groupBox21.Controls.Add(this.btnCtrlSTKDiscon);
            this.groupBox21.Controls.Add(this.label7);
            this.groupBox21.Controls.Add(this.label8);
            this.groupBox21.Font = new System.Drawing.Font("Calibri", 1.5F);
            this.groupBox21.Location = new System.Drawing.Point(18, 24);
            this.groupBox21.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox21.Size = new System.Drawing.Size(702, 44);
            this.groupBox21.TabIndex = 76;
            this.groupBox21.TabStop = false;
            // 
            // btnCtrlSTKCon
            // 
            this.btnCtrlSTKCon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCtrlSTKCon.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnCtrlSTKCon.Location = new System.Drawing.Point(452, 6);
            this.btnCtrlSTKCon.Name = "btnCtrlSTKCon";
            this.btnCtrlSTKCon.Size = new System.Drawing.Size(108, 31);
            this.btnCtrlSTKCon.TabIndex = 15;
            this.btnCtrlSTKCon.Text = "Connect";
            this.btnCtrlSTKCon.UseVisualStyleBackColor = true;
            this.btnCtrlSTKCon.Click += new System.EventHandler(this.btnCtrlSTKCon_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.SystemColors.Highlight;
            this.label40.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.White;
            this.label40.Location = new System.Drawing.Point(9, 10);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(119, 23);
            this.label40.TabIndex = 40;
            this.label40.Text = "             Stocker";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbCtrlSTK_Port
            // 
            this.tbCtrlSTK_Port.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCtrlSTK_Port.Location = new System.Drawing.Point(382, 6);
            this.tbCtrlSTK_Port.Name = "tbCtrlSTK_Port";
            this.tbCtrlSTK_Port.Size = new System.Drawing.Size(58, 31);
            this.tbCtrlSTK_Port.TabIndex = 3;
            this.tbCtrlSTK_Port.Text = "23";
            this.tbCtrlSTK_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCtrlSTK_IP
            // 
            this.tbCtrlSTK_IP.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCtrlSTK_IP.Location = new System.Drawing.Point(161, 7);
            this.tbCtrlSTK_IP.Name = "tbCtrlSTK_IP";
            this.tbCtrlSTK_IP.Size = new System.Drawing.Size(174, 31);
            this.tbCtrlSTK_IP.TabIndex = 1;
            this.tbCtrlSTK_IP.Text = "192.168.0.127";
            this.tbCtrlSTK_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCtrlSTKDiscon
            // 
            this.btnCtrlSTKDiscon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCtrlSTKDiscon.Enabled = false;
            this.btnCtrlSTKDiscon.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnCtrlSTKDiscon.Location = new System.Drawing.Point(569, 6);
            this.btnCtrlSTKDiscon.Name = "btnCtrlSTKDiscon";
            this.btnCtrlSTKDiscon.Size = new System.Drawing.Size(108, 32);
            this.btnCtrlSTKDiscon.TabIndex = 16;
            this.btnCtrlSTKDiscon.Text = "Disconnect";
            this.btnCtrlSTKDiscon.UseVisualStyleBackColor = true;
            this.btnCtrlSTKDiscon.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(138, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "IP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(340, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "Port";
            // 
            // tabCmd
            // 
            this.tabCmd.BackColor = System.Drawing.SystemColors.Control;
            this.tabCmd.Controls.Add(this.groupBox7);
            this.tabCmd.Controls.Add(this.groupBox5);
            this.tabCmd.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCmd.Location = new System.Drawing.Point(4, 33);
            this.tabCmd.Name = "tabCmd";
            this.tabCmd.Padding = new System.Windows.Forms.Padding(3);
            this.tabCmd.Size = new System.Drawing.Size(965, 622);
            this.tabCmd.TabIndex = 0;
            this.tabCmd.Text = "Command Mode";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnNewScript);
            this.groupBox7.Controls.Add(this.btnStepRun);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.tbTimes);
            this.groupBox7.Controls.Add(this.btnDel);
            this.groupBox7.Controls.Add(this.btnDown);
            this.groupBox7.Controls.Add(this.btnScriptStop);
            this.groupBox7.Controls.Add(this.btnUp);
            this.groupBox7.Controls.Add(this.dgvCmdScript);
            this.groupBox7.Controls.Add(this.btnScriptRun);
            this.groupBox7.Controls.Add(this.btnExport);
            this.groupBox7.Controls.Add(this.btnImport);
            this.groupBox7.Location = new System.Drawing.Point(7, 84);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(943, 523);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Script Area";
            // 
            // btnNewScript
            // 
            this.btnNewScript.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewScript.Location = new System.Drawing.Point(896, 424);
            this.btnNewScript.Name = "btnNewScript";
            this.btnNewScript.Size = new System.Drawing.Size(38, 32);
            this.btnNewScript.TabIndex = 31;
            this.btnNewScript.Text = "New";
            this.btnNewScript.UseVisualStyleBackColor = true;
            this.btnNewScript.Click += new System.EventHandler(this.btnNewScript_Click);
            // 
            // btnStepRun
            // 
            this.btnStepRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStepRun.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStepRun.Location = new System.Drawing.Point(896, 176);
            this.btnStepRun.Name = "btnStepRun";
            this.btnStepRun.Size = new System.Drawing.Size(38, 32);
            this.btnStepRun.TabIndex = 30;
            this.btnStepRun.Text = "Step";
            this.btnStepRun.UseVisualStyleBackColor = true;
            this.btnStepRun.Click += new System.EventHandler(this.btnStepRun_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(579, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 19);
            this.label6.TabIndex = 29;
            this.label6.Text = "repeat times";
            // 
            // tbTimes
            // 
            this.tbTimes.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimes.Location = new System.Drawing.Point(676, 24);
            this.tbTimes.Name = "tbTimes";
            this.tbTimes.Size = new System.Drawing.Size(74, 30);
            this.tbTimes.TabIndex = 26;
            this.tbTimes.Text = "1";
            this.tbTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDel
            // 
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(896, 219);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(38, 32);
            this.btnDel.TabIndex = 25;
            this.btnDel.Text = "－";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnDown
            // 
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Location = new System.Drawing.Point(896, 262);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(38, 32);
            this.btnDown.TabIndex = 24;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnScriptStop
            // 
            this.btnScriptStop.BackColor = System.Drawing.Color.OrangeRed;
            this.btnScriptStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScriptStop.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScriptStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnScriptStop.Location = new System.Drawing.Point(820, 22);
            this.btnScriptStop.Name = "btnScriptStop";
            this.btnScriptStop.Size = new System.Drawing.Size(58, 32);
            this.btnScriptStop.TabIndex = 21;
            this.btnScriptStop.Text = "STOP";
            this.btnScriptStop.UseVisualStyleBackColor = false;
            this.btnScriptStop.Click += new System.EventHandler(this.btnScriptStop_Click);
            // 
            // btnUp
            // 
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(896, 133);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(38, 32);
            this.btnUp.TabIndex = 23;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // dgvCmdScript
            // 
            this.dgvCmdScript.AllowUserToAddRows = false;
            this.dgvCmdScript.AllowUserToDeleteRows = false;
            this.dgvCmdScript.AllowUserToResizeColumns = false;
            this.dgvCmdScript.AllowUserToResizeRows = false;
            this.dgvCmdScript.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCmdScript.Location = new System.Drawing.Point(8, 60);
            this.dgvCmdScript.Name = "dgvCmdScript";
            this.dgvCmdScript.ReadOnly = true;
            this.dgvCmdScript.RowTemplate.Height = 24;
            this.dgvCmdScript.Size = new System.Drawing.Size(870, 396);
            this.dgvCmdScript.TabIndex = 22;
            this.dgvCmdScript.DoubleClick += new System.EventHandler(this.dgvCmdScript_DoubleClick);
            // 
            // btnScriptRun
            // 
            this.btnScriptRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScriptRun.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScriptRun.Location = new System.Drawing.Point(756, 22);
            this.btnScriptRun.Name = "btnScriptRun";
            this.btnScriptRun.Size = new System.Drawing.Size(58, 32);
            this.btnScriptRun.TabIndex = 20;
            this.btnScriptRun.Text = "RUN";
            this.btnScriptRun.UseVisualStyleBackColor = true;
            this.btnScriptRun.Click += new System.EventHandler(this.btnScriptRun_Click);
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(495, 22);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(58, 32);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(431, 22);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(58, 32);
            this.btnImport.TabIndex = 18;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnInitAll);
            this.groupBox5.Controls.Add(this.btnReset);
            this.groupBox5.Controls.Add(this.btnAddScript);
            this.groupBox5.Controls.Add(this.tbCmd);
            this.groupBox5.Controls.Add(this.btnSend);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(944, 72);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Command Area";
            // 
            // btnInitAll
            // 
            this.btnInitAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInitAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInitAll.Location = new System.Drawing.Point(757, 22);
            this.btnInitAll.Name = "btnInitAll";
            this.btnInitAll.Size = new System.Drawing.Size(87, 39);
            this.btnInitAll.TabIndex = 29;
            this.btnInitAll.Text = "Init All";
            this.btnInitAll.UseVisualStyleBackColor = true;
            this.btnInitAll.Click += new System.EventHandler(this.btnInitAll_Click);
            // 
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(848, 22);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 39);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "Reset Alarm";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAddScript
            // 
            this.btnAddScript.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddScript.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddScript.Location = new System.Drawing.Point(630, 22);
            this.btnAddScript.Name = "btnAddScript";
            this.btnAddScript.Size = new System.Drawing.Size(87, 39);
            this.btnAddScript.TabIndex = 28;
            this.btnAddScript.Text = "Add To Script";
            this.btnAddScript.UseVisualStyleBackColor = true;
            this.btnAddScript.Click += new System.EventHandler(this.btnAddScript_Click);
            // 
            // tbCmd
            // 
            this.tbCmd.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCmd.Location = new System.Drawing.Point(6, 25);
            this.tbCmd.Name = "tbCmd";
            this.tbCmd.Size = new System.Drawing.Size(506, 36);
            this.tbCmd.TabIndex = 23;
            // 
            // btnSend
            // 
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(518, 22);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(106, 39);
            this.btnSend.TabIndex = 19;
            this.btnSend.Text = "Send Command";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tabStocker
            // 
            this.tabStocker.Controls.Add(this.groupBox46);
            this.tabStocker.Controls.Add(this.groupBox24);
            this.tabStocker.Controls.Add(this.groupBox25);
            this.tabStocker.Controls.Add(this.groupBox22);
            this.tabStocker.Controls.Add(this.groupBox17);
            this.tabStocker.Controls.Add(this.label44);
            this.tabStocker.Controls.Add(this.label63);
            this.tabStocker.Controls.Add(this.label62);
            this.tabStocker.Controls.Add(this.label43);
            this.tabStocker.Location = new System.Drawing.Point(4, 33);
            this.tabStocker.Name = "tabStocker";
            this.tabStocker.Size = new System.Drawing.Size(965, 622);
            this.tabStocker.TabIndex = 4;
            this.tabStocker.Text = " Stocker";
            this.tabStocker.UseVisualStyleBackColor = true;
            // 
            // groupBox46
            // 
            this.groupBox46.Controls.Add(this.btnFoupRotSwitch);
            this.groupBox46.Controls.Add(this.groupBox49);
            this.groupBox46.Controls.Add(this.btnSTKServoOn);
            this.groupBox46.Controls.Add(this.btnFoupRotHome);
            this.groupBox46.Controls.Add(this.groupBox48);
            this.groupBox46.Controls.Add(this.groupBox47);
            this.groupBox46.Controls.Add(this.btnFoupRotAuto);
            this.groupBox46.Location = new System.Drawing.Point(580, 89);
            this.groupBox46.Name = "groupBox46";
            this.groupBox46.Size = new System.Drawing.Size(382, 527);
            this.groupBox46.TabIndex = 39;
            this.groupBox46.TabStop = false;
            this.groupBox46.Text = "FOUP Robot Area";
            // 
            // btnFoupRotSwitch
            // 
            this.btnFoupRotSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotSwitch.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotSwitch.Location = new System.Drawing.Point(157, 59);
            this.btnFoupRotSwitch.Name = "btnFoupRotSwitch";
            this.btnFoupRotSwitch.Size = new System.Drawing.Size(68, 39);
            this.btnFoupRotSwitch.TabIndex = 78;
            this.btnFoupRotSwitch.Text = "<->";
            this.btnFoupRotSwitch.UseVisualStyleBackColor = true;
            this.btnFoupRotSwitch.Click += new System.EventHandler(this.btnFoupRotSwitch_Click);
            // 
            // groupBox49
            // 
            this.groupBox49.Controls.Add(this.cbDestination);
            this.groupBox49.Controls.Add(this.btnFoupRotPlace);
            this.groupBox49.Controls.Add(this.btnFoupRotExtendDest);
            this.groupBox49.Controls.Add(this.btnFoupRotPrePlace);
            this.groupBox49.Controls.Add(this.btnFoupRotRetractDest);
            this.groupBox49.Controls.Add(this.btnFoupRotRelease);
            this.groupBox49.Controls.Add(this.btnFoupRotDownDest);
            this.groupBox49.Location = new System.Drawing.Point(231, 29);
            this.groupBox49.Name = "groupBox49";
            this.groupBox49.Size = new System.Drawing.Size(145, 258);
            this.groupBox49.TabIndex = 77;
            this.groupBox49.TabStop = false;
            this.groupBox49.Text = "Destination";
            // 
            // cbDestination
            // 
            this.cbDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestination.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDestination.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDestination.FormattingEnabled = true;
            this.cbDestination.Items.AddRange(new object[] {
            "ELPT1",
            "ELPT2",
            "ILPT1",
            "ILPT2",
            "SHELF1",
            "SHELF2",
            "SHELF3",
            "SHELF4",
            "SHELF5",
            "SHELF6",
            "SHELF7",
            "SHELF8",
            "SHELF9",
            "SHELF10",
            "SHELF11",
            "SHELF12",
            "SHELF13",
            "SHELF14",
            "SHELF15",
            "SHELF16"});
            this.cbDestination.Location = new System.Drawing.Point(9, 34);
            this.cbDestination.Name = "cbDestination";
            this.cbDestination.Size = new System.Drawing.Size(126, 30);
            this.cbDestination.TabIndex = 78;
            // 
            // btnFoupRotPlace
            // 
            this.btnFoupRotPlace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotPlace.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotPlace.Location = new System.Drawing.Point(9, 121);
            this.btnFoupRotPlace.Name = "btnFoupRotPlace";
            this.btnFoupRotPlace.Size = new System.Drawing.Size(127, 39);
            this.btnFoupRotPlace.TabIndex = 19;
            this.btnFoupRotPlace.Text = "Place";
            this.btnFoupRotPlace.UseVisualStyleBackColor = true;
            this.btnFoupRotPlace.Click += new System.EventHandler(this.btnFoupRotPlace_Click);
            // 
            // btnFoupRotExtendDest
            // 
            this.btnFoupRotExtendDest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotExtendDest.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotExtendDest.Location = new System.Drawing.Point(10, 164);
            this.btnFoupRotExtendDest.Name = "btnFoupRotExtendDest";
            this.btnFoupRotExtendDest.Size = new System.Drawing.Size(60, 39);
            this.btnFoupRotExtendDest.TabIndex = 19;
            this.btnFoupRotExtendDest.Text = "Extend";
            this.btnFoupRotExtendDest.UseVisualStyleBackColor = true;
            this.btnFoupRotExtendDest.Click += new System.EventHandler(this.btnFoupRotExtendDest_Click);
            // 
            // btnFoupRotPrePlace
            // 
            this.btnFoupRotPrePlace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotPrePlace.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotPrePlace.Location = new System.Drawing.Point(8, 76);
            this.btnFoupRotPrePlace.Name = "btnFoupRotPrePlace";
            this.btnFoupRotPrePlace.Size = new System.Drawing.Size(127, 39);
            this.btnFoupRotPrePlace.TabIndex = 19;
            this.btnFoupRotPrePlace.Text = "Prepare Place";
            this.btnFoupRotPrePlace.UseVisualStyleBackColor = true;
            this.btnFoupRotPrePlace.Click += new System.EventHandler(this.btnFoupRotPrePlace_Click);
            // 
            // btnFoupRotRetractDest
            // 
            this.btnFoupRotRetractDest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotRetractDest.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotRetractDest.Location = new System.Drawing.Point(10, 209);
            this.btnFoupRotRetractDest.Name = "btnFoupRotRetractDest";
            this.btnFoupRotRetractDest.Size = new System.Drawing.Size(60, 39);
            this.btnFoupRotRetractDest.TabIndex = 19;
            this.btnFoupRotRetractDest.Text = "Retract";
            this.btnFoupRotRetractDest.UseVisualStyleBackColor = true;
            this.btnFoupRotRetractDest.Click += new System.EventHandler(this.btnFoupRotRetractDest_Click);
            // 
            // btnFoupRotRelease
            // 
            this.btnFoupRotRelease.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotRelease.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotRelease.Location = new System.Drawing.Point(76, 164);
            this.btnFoupRotRelease.Name = "btnFoupRotRelease";
            this.btnFoupRotRelease.Size = new System.Drawing.Size(60, 39);
            this.btnFoupRotRelease.TabIndex = 19;
            this.btnFoupRotRelease.Text = "Release";
            this.btnFoupRotRelease.UseVisualStyleBackColor = true;
            this.btnFoupRotRelease.Click += new System.EventHandler(this.btnFoupRotRelease_Click);
            // 
            // btnFoupRotDownDest
            // 
            this.btnFoupRotDownDest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotDownDest.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotDownDest.Location = new System.Drawing.Point(76, 209);
            this.btnFoupRotDownDest.Name = "btnFoupRotDownDest";
            this.btnFoupRotDownDest.Size = new System.Drawing.Size(60, 39);
            this.btnFoupRotDownDest.TabIndex = 19;
            this.btnFoupRotDownDest.Text = "Down";
            this.btnFoupRotDownDest.UseVisualStyleBackColor = true;
            this.btnFoupRotDownDest.Click += new System.EventHandler(this.btnFoupRotDownDest_Click);
            // 
            // btnSTKServoOn
            // 
            this.btnSTKServoOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSTKServoOn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTKServoOn.Location = new System.Drawing.Point(157, 231);
            this.btnSTKServoOn.Name = "btnSTKServoOn";
            this.btnSTKServoOn.Size = new System.Drawing.Size(68, 39);
            this.btnSTKServoOn.TabIndex = 19;
            this.btnSTKServoOn.Text = "Servo";
            this.btnSTKServoOn.UseVisualStyleBackColor = true;
            this.btnSTKServoOn.Click += new System.EventHandler(this.btnSTKServoOn_Click);
            // 
            // btnFoupRotHome
            // 
            this.btnFoupRotHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotHome.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotHome.Location = new System.Drawing.Point(157, 181);
            this.btnFoupRotHome.Name = "btnFoupRotHome";
            this.btnFoupRotHome.Size = new System.Drawing.Size(68, 39);
            this.btnFoupRotHome.TabIndex = 19;
            this.btnFoupRotHome.Text = "Home";
            this.btnFoupRotHome.UseVisualStyleBackColor = true;
            this.btnFoupRotHome.Click += new System.EventHandler(this.btnFoupRotHome_Click);
            // 
            // groupBox48
            // 
            this.groupBox48.Controls.Add(this.cbSource);
            this.groupBox48.Controls.Add(this.btnFoupRotPrePick);
            this.groupBox48.Controls.Add(this.btnFoupRotExtendSrc);
            this.groupBox48.Controls.Add(this.btnFoupRotRetractSrc);
            this.groupBox48.Controls.Add(this.btnFoupRotPick);
            this.groupBox48.Controls.Add(this.btnFoupRotGrab);
            this.groupBox48.Controls.Add(this.btnFoupRotUpSrc);
            this.groupBox48.Location = new System.Drawing.Point(6, 29);
            this.groupBox48.Name = "groupBox48";
            this.groupBox48.Size = new System.Drawing.Size(145, 258);
            this.groupBox48.TabIndex = 77;
            this.groupBox48.TabStop = false;
            this.groupBox48.Text = "Source";
            // 
            // cbSource
            // 
            this.cbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSource.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSource.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Items.AddRange(new object[] {
            "ELPT1",
            "ELPT2",
            "ILPT1",
            "ILPT2",
            "SHELF1",
            "SHELF2",
            "SHELF3",
            "SHELF4",
            "SHELF5",
            "SHELF6",
            "SHELF7",
            "SHELF8",
            "SHELF9",
            "SHELF10",
            "SHELF11",
            "SHELF12",
            "SHELF13",
            "SHELF14",
            "SHELF15",
            "SHELF16"});
            this.cbSource.Location = new System.Drawing.Point(8, 34);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(127, 30);
            this.cbSource.TabIndex = 78;
            // 
            // btnFoupRotPrePick
            // 
            this.btnFoupRotPrePick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotPrePick.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotPrePick.Location = new System.Drawing.Point(8, 76);
            this.btnFoupRotPrePick.Name = "btnFoupRotPrePick";
            this.btnFoupRotPrePick.Size = new System.Drawing.Size(127, 39);
            this.btnFoupRotPrePick.TabIndex = 19;
            this.btnFoupRotPrePick.Text = "Prepare Pick";
            this.btnFoupRotPrePick.UseVisualStyleBackColor = true;
            this.btnFoupRotPrePick.Click += new System.EventHandler(this.btnFoupRotPrePick_Click);
            // 
            // btnFoupRotExtendSrc
            // 
            this.btnFoupRotExtendSrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotExtendSrc.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotExtendSrc.Location = new System.Drawing.Point(9, 164);
            this.btnFoupRotExtendSrc.Name = "btnFoupRotExtendSrc";
            this.btnFoupRotExtendSrc.Size = new System.Drawing.Size(60, 39);
            this.btnFoupRotExtendSrc.TabIndex = 19;
            this.btnFoupRotExtendSrc.Text = "Extend";
            this.btnFoupRotExtendSrc.UseVisualStyleBackColor = true;
            this.btnFoupRotExtendSrc.Click += new System.EventHandler(this.btnFoupRotExtendSrc_Click);
            // 
            // btnFoupRotRetractSrc
            // 
            this.btnFoupRotRetractSrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotRetractSrc.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotRetractSrc.Location = new System.Drawing.Point(9, 209);
            this.btnFoupRotRetractSrc.Name = "btnFoupRotRetractSrc";
            this.btnFoupRotRetractSrc.Size = new System.Drawing.Size(60, 39);
            this.btnFoupRotRetractSrc.TabIndex = 19;
            this.btnFoupRotRetractSrc.Text = "Retract";
            this.btnFoupRotRetractSrc.UseVisualStyleBackColor = true;
            this.btnFoupRotRetractSrc.Click += new System.EventHandler(this.btnFoupRotRetractSrc_Click);
            // 
            // btnFoupRotPick
            // 
            this.btnFoupRotPick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotPick.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotPick.Location = new System.Drawing.Point(8, 121);
            this.btnFoupRotPick.Name = "btnFoupRotPick";
            this.btnFoupRotPick.Size = new System.Drawing.Size(127, 39);
            this.btnFoupRotPick.TabIndex = 19;
            this.btnFoupRotPick.Text = "Pick";
            this.btnFoupRotPick.UseVisualStyleBackColor = true;
            this.btnFoupRotPick.Click += new System.EventHandler(this.btnFoupRotPick_Click);
            // 
            // btnFoupRotGrab
            // 
            this.btnFoupRotGrab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotGrab.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotGrab.Location = new System.Drawing.Point(75, 209);
            this.btnFoupRotGrab.Name = "btnFoupRotGrab";
            this.btnFoupRotGrab.Size = new System.Drawing.Size(60, 39);
            this.btnFoupRotGrab.TabIndex = 19;
            this.btnFoupRotGrab.Text = "Grab";
            this.btnFoupRotGrab.UseVisualStyleBackColor = true;
            this.btnFoupRotGrab.Click += new System.EventHandler(this.btnFoupRotGrab_Click);
            // 
            // btnFoupRotUpSrc
            // 
            this.btnFoupRotUpSrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotUpSrc.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotUpSrc.Location = new System.Drawing.Point(75, 164);
            this.btnFoupRotUpSrc.Name = "btnFoupRotUpSrc";
            this.btnFoupRotUpSrc.Size = new System.Drawing.Size(60, 39);
            this.btnFoupRotUpSrc.TabIndex = 19;
            this.btnFoupRotUpSrc.Text = "Up";
            this.btnFoupRotUpSrc.UseVisualStyleBackColor = true;
            this.btnFoupRotUpSrc.Click += new System.EventHandler(this.btnFoupRotUpSrc_Click);
            // 
            // groupBox47
            // 
            this.groupBox47.Controls.Add(this.btnSTKRefresh);
            this.groupBox47.Controls.Add(this.tbPresShelf14);
            this.groupBox47.Controls.Add(this.label75);
            this.groupBox47.Controls.Add(this.tbPresELPT1);
            this.groupBox47.Controls.Add(this.label77);
            this.groupBox47.Controls.Add(this.tbPresILPT1);
            this.groupBox47.Controls.Add(this.label76);
            this.groupBox47.Controls.Add(this.tbPresILPT2);
            this.groupBox47.Controls.Add(this.label74);
            this.groupBox47.Controls.Add(this.tbPresRobot);
            this.groupBox47.Controls.Add(this.label72);
            this.groupBox47.Controls.Add(this.tbPresShelf1);
            this.groupBox47.Controls.Add(this.tbPresELPT2);
            this.groupBox47.Controls.Add(this.tbPresShelf3);
            this.groupBox47.Controls.Add(this.label80);
            this.groupBox47.Controls.Add(this.tbPresShelf5);
            this.groupBox47.Controls.Add(this.label79);
            this.groupBox47.Controls.Add(this.tbPresShelf4);
            this.groupBox47.Controls.Add(this.label78);
            this.groupBox47.Controls.Add(this.tbPresShelf7);
            this.groupBox47.Controls.Add(this.label70);
            this.groupBox47.Controls.Add(this.tbPresShelf11);
            this.groupBox47.Controls.Add(this.tbPresShelf9);
            this.groupBox47.Controls.Add(this.tbPresShelf8);
            this.groupBox47.Controls.Add(this.tbPresShelf15);
            this.groupBox47.Controls.Add(this.tbPresShelf13);
            this.groupBox47.Controls.Add(this.tbPresShelf12);
            this.groupBox47.Controls.Add(this.tbPresShelf16);
            this.groupBox47.Controls.Add(this.tbPresShelf6);
            this.groupBox47.Controls.Add(this.tbPresShelf10);
            this.groupBox47.Controls.Add(this.tbPresShelf2);
            this.groupBox47.Location = new System.Drawing.Point(6, 288);
            this.groupBox47.Name = "groupBox47";
            this.groupBox47.Size = new System.Drawing.Size(350, 232);
            this.groupBox47.TabIndex = 76;
            this.groupBox47.TabStop = false;
            this.groupBox47.Text = "FOUP Presence";
            // 
            // btnSTKRefresh
            // 
            this.btnSTKRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSTKRefresh.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTKRefresh.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnSTKRefresh.Location = new System.Drawing.Point(10, 44);
            this.btnSTKRefresh.Name = "btnSTKRefresh";
            this.btnSTKRefresh.Size = new System.Drawing.Size(70, 26);
            this.btnSTKRefresh.TabIndex = 76;
            this.btnSTKRefresh.Text = "Refresh";
            this.btnSTKRefresh.UseVisualStyleBackColor = true;
            this.btnSTKRefresh.Click += new System.EventHandler(this.btnSTKRefresh_Click);
            // 
            // tbPresShelf14
            // 
            this.tbPresShelf14.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf14.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf14.Location = new System.Drawing.Point(122, 47);
            this.tbPresShelf14.Name = "tbPresShelf14";
            this.tbPresShelf14.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf14.TabIndex = 74;
            this.tbPresShelf14.Text = "SHELF14";
            this.tbPresShelf14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.BackColor = System.Drawing.SystemColors.Highlight;
            this.label75.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.Color.White;
            this.label75.Location = new System.Drawing.Point(90, 137);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(20, 23);
            this.label75.TabIndex = 75;
            this.label75.Text = "3";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPresELPT1
            // 
            this.tbPresELPT1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresELPT1.ForeColor = System.Drawing.Color.DarkRed;
            this.tbPresELPT1.Location = new System.Drawing.Point(10, 104);
            this.tbPresELPT1.Name = "tbPresELPT1";
            this.tbPresELPT1.Size = new System.Drawing.Size(70, 26);
            this.tbPresELPT1.TabIndex = 74;
            this.tbPresELPT1.Text = "ELPT1";
            this.tbPresELPT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.BackColor = System.Drawing.SystemColors.Highlight;
            this.label77.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.White;
            this.label77.Location = new System.Drawing.Point(90, 47);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(20, 23);
            this.label77.TabIndex = 75;
            this.label77.Text = "6";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPresILPT1
            // 
            this.tbPresILPT1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresILPT1.ForeColor = System.Drawing.Color.DarkRed;
            this.tbPresILPT1.Location = new System.Drawing.Point(198, 167);
            this.tbPresILPT1.Name = "tbPresILPT1";
            this.tbPresILPT1.Size = new System.Drawing.Size(70, 26);
            this.tbPresILPT1.TabIndex = 74;
            this.tbPresILPT1.Text = "ILPT1";
            this.tbPresILPT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.SystemColors.Highlight;
            this.label76.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.Color.White;
            this.label76.Location = new System.Drawing.Point(90, 77);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(20, 23);
            this.label76.TabIndex = 75;
            this.label76.Text = "5";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPresILPT2
            // 
            this.tbPresILPT2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresILPT2.ForeColor = System.Drawing.Color.DarkRed;
            this.tbPresILPT2.Location = new System.Drawing.Point(274, 167);
            this.tbPresILPT2.Name = "tbPresILPT2";
            this.tbPresILPT2.Size = new System.Drawing.Size(70, 26);
            this.tbPresILPT2.TabIndex = 74;
            this.tbPresILPT2.Text = "ILPT2";
            this.tbPresILPT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.SystemColors.Highlight;
            this.label74.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.Color.White;
            this.label74.Location = new System.Drawing.Point(90, 107);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(20, 23);
            this.label74.TabIndex = 75;
            this.label74.Text = "4";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPresRobot
            // 
            this.tbPresRobot.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresRobot.ForeColor = System.Drawing.Color.DarkRed;
            this.tbPresRobot.Location = new System.Drawing.Point(10, 197);
            this.tbPresRobot.Name = "tbPresRobot";
            this.tbPresRobot.Size = new System.Drawing.Size(70, 26);
            this.tbPresRobot.TabIndex = 74;
            this.tbPresRobot.Text = "Robot";
            this.tbPresRobot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.BackColor = System.Drawing.SystemColors.Highlight;
            this.label72.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.White;
            this.label72.Location = new System.Drawing.Point(90, 167);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(20, 23);
            this.label72.TabIndex = 75;
            this.label72.Text = "2";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPresShelf1
            // 
            this.tbPresShelf1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf1.Location = new System.Drawing.Point(122, 197);
            this.tbPresShelf1.Name = "tbPresShelf1";
            this.tbPresShelf1.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf1.TabIndex = 74;
            this.tbPresShelf1.Text = "SHELF1";
            this.tbPresShelf1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPresELPT2
            // 
            this.tbPresELPT2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresELPT2.ForeColor = System.Drawing.Color.DarkRed;
            this.tbPresELPT2.Location = new System.Drawing.Point(10, 137);
            this.tbPresELPT2.Name = "tbPresELPT2";
            this.tbPresELPT2.Size = new System.Drawing.Size(70, 26);
            this.tbPresELPT2.TabIndex = 74;
            this.tbPresELPT2.Text = "ELPT2";
            this.tbPresELPT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPresShelf3
            // 
            this.tbPresShelf3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf3.Location = new System.Drawing.Point(274, 197);
            this.tbPresShelf3.Name = "tbPresShelf3";
            this.tbPresShelf3.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf3.TabIndex = 74;
            this.tbPresShelf3.Text = "SHELF3";
            this.tbPresShelf3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.BackColor = System.Drawing.SystemColors.Highlight;
            this.label80.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.White;
            this.label80.Location = new System.Drawing.Point(302, 21);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(20, 23);
            this.label80.TabIndex = 37;
            this.label80.Text = "3";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPresShelf5
            // 
            this.tbPresShelf5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf5.Location = new System.Drawing.Point(122, 137);
            this.tbPresShelf5.Name = "tbPresShelf5";
            this.tbPresShelf5.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf5.TabIndex = 74;
            this.tbPresShelf5.Text = "SHELF5";
            this.tbPresShelf5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.BackColor = System.Drawing.SystemColors.Highlight;
            this.label79.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.Color.White;
            this.label79.Location = new System.Drawing.Point(226, 21);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(20, 23);
            this.label79.TabIndex = 37;
            this.label79.Text = "2";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPresShelf4
            // 
            this.tbPresShelf4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf4.Location = new System.Drawing.Point(122, 167);
            this.tbPresShelf4.Name = "tbPresShelf4";
            this.tbPresShelf4.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf4.TabIndex = 74;
            this.tbPresShelf4.Text = "SHELF4";
            this.tbPresShelf4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.BackColor = System.Drawing.SystemColors.Highlight;
            this.label78.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.Color.White;
            this.label78.Location = new System.Drawing.Point(150, 21);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(20, 23);
            this.label78.TabIndex = 37;
            this.label78.Text = "1";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPresShelf7
            // 
            this.tbPresShelf7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf7.Location = new System.Drawing.Point(274, 137);
            this.tbPresShelf7.Name = "tbPresShelf7";
            this.tbPresShelf7.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf7.TabIndex = 74;
            this.tbPresShelf7.Text = "SHELF7";
            this.tbPresShelf7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.BackColor = System.Drawing.SystemColors.Highlight;
            this.label70.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.White;
            this.label70.Location = new System.Drawing.Point(90, 197);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(20, 23);
            this.label70.TabIndex = 37;
            this.label70.Text = "1";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPresShelf11
            // 
            this.tbPresShelf11.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf11.Location = new System.Drawing.Point(122, 77);
            this.tbPresShelf11.Name = "tbPresShelf11";
            this.tbPresShelf11.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf11.TabIndex = 74;
            this.tbPresShelf11.Text = "SHELF11";
            this.tbPresShelf11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPresShelf9
            // 
            this.tbPresShelf9.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf9.Location = new System.Drawing.Point(198, 107);
            this.tbPresShelf9.Name = "tbPresShelf9";
            this.tbPresShelf9.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf9.TabIndex = 74;
            this.tbPresShelf9.Text = "SHELF9";
            this.tbPresShelf9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPresShelf8
            // 
            this.tbPresShelf8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf8.Location = new System.Drawing.Point(122, 107);
            this.tbPresShelf8.Name = "tbPresShelf8";
            this.tbPresShelf8.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf8.TabIndex = 74;
            this.tbPresShelf8.Text = "SHELF8";
            this.tbPresShelf8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPresShelf15
            // 
            this.tbPresShelf15.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf15.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf15.Location = new System.Drawing.Point(198, 47);
            this.tbPresShelf15.Name = "tbPresShelf15";
            this.tbPresShelf15.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf15.TabIndex = 74;
            this.tbPresShelf15.Text = "SHELF15";
            this.tbPresShelf15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPresShelf13
            // 
            this.tbPresShelf13.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf13.Location = new System.Drawing.Point(274, 77);
            this.tbPresShelf13.Name = "tbPresShelf13";
            this.tbPresShelf13.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf13.TabIndex = 74;
            this.tbPresShelf13.Text = "SHELF13";
            this.tbPresShelf13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPresShelf12
            // 
            this.tbPresShelf12.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf12.Location = new System.Drawing.Point(198, 77);
            this.tbPresShelf12.Name = "tbPresShelf12";
            this.tbPresShelf12.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf12.TabIndex = 74;
            this.tbPresShelf12.Text = "SHELF12";
            this.tbPresShelf12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPresShelf16
            // 
            this.tbPresShelf16.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf16.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf16.Location = new System.Drawing.Point(274, 47);
            this.tbPresShelf16.Name = "tbPresShelf16";
            this.tbPresShelf16.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf16.TabIndex = 74;
            this.tbPresShelf16.Text = "SHELF16";
            this.tbPresShelf16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPresShelf6
            // 
            this.tbPresShelf6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf6.Location = new System.Drawing.Point(198, 137);
            this.tbPresShelf6.Name = "tbPresShelf6";
            this.tbPresShelf6.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf6.TabIndex = 74;
            this.tbPresShelf6.Text = "SHELF6";
            this.tbPresShelf6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPresShelf10
            // 
            this.tbPresShelf10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf10.Location = new System.Drawing.Point(274, 107);
            this.tbPresShelf10.Name = "tbPresShelf10";
            this.tbPresShelf10.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf10.TabIndex = 74;
            this.tbPresShelf10.Text = "SHELF10";
            this.tbPresShelf10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPresShelf2
            // 
            this.tbPresShelf2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPresShelf2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPresShelf2.Location = new System.Drawing.Point(198, 197);
            this.tbPresShelf2.Name = "tbPresShelf2";
            this.tbPresShelf2.Size = new System.Drawing.Size(70, 26);
            this.tbPresShelf2.TabIndex = 74;
            this.tbPresShelf2.Text = "SHELF2";
            this.tbPresShelf2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFoupRotAuto
            // 
            this.btnFoupRotAuto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFoupRotAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoupRotAuto.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoupRotAuto.Location = new System.Drawing.Point(157, 132);
            this.btnFoupRotAuto.Name = "btnFoupRotAuto";
            this.btnFoupRotAuto.Size = new System.Drawing.Size(68, 39);
            this.btnFoupRotAuto.TabIndex = 19;
            this.btnFoupRotAuto.Text = "Auto";
            this.btnFoupRotAuto.UseVisualStyleBackColor = false;
            this.btnFoupRotAuto.Click += new System.EventHandler(this.btnFoupRotAuto_Click);
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.tbI2Error);
            this.groupBox24.Controls.Add(this.label81);
            this.groupBox24.Controls.Add(this.tbI2Init);
            this.groupBox24.Controls.Add(this.btnI2UnLoad);
            this.groupBox24.Controls.Add(this.tbI2SlotMap);
            this.groupBox24.Controls.Add(this.tbI2Reset);
            this.groupBox24.Controls.Add(this.btnI2GetSlotMap);
            this.groupBox24.Controls.Add(this.label71);
            this.groupBox24.Controls.Add(this.btnI2Auto);
            this.groupBox24.Controls.Add(this.btnI2Load);
            this.groupBox24.Location = new System.Drawing.Point(3, 466);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(568, 150);
            this.groupBox24.TabIndex = 17;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "ILPT2 Area";
            // 
            // tbI2Error
            // 
            this.tbI2Error.Enabled = false;
            this.tbI2Error.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbI2Error.Location = new System.Drawing.Point(129, 107);
            this.tbI2Error.Name = "tbI2Error";
            this.tbI2Error.Size = new System.Drawing.Size(319, 30);
            this.tbI2Error.TabIndex = 38;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.BackColor = System.Drawing.SystemColors.Highlight;
            this.label81.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.ForeColor = System.Drawing.Color.White;
            this.label81.Location = new System.Drawing.Point(9, 107);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(114, 23);
            this.label81.TabIndex = 37;
            this.label81.Text = "                Error";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbI2Init
            // 
            this.tbI2Init.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbI2Init.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbI2Init.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbI2Init.ForeColor = System.Drawing.Color.OrangeRed;
            this.tbI2Init.Location = new System.Drawing.Point(475, 22);
            this.tbI2Init.Name = "tbI2Init";
            this.tbI2Init.Size = new System.Drawing.Size(87, 39);
            this.tbI2Init.TabIndex = 29;
            this.tbI2Init.Text = "Init";
            this.tbI2Init.UseVisualStyleBackColor = false;
            this.tbI2Init.Click += new System.EventHandler(this.tbI2Init_Click);
            // 
            // btnI2UnLoad
            // 
            this.btnI2UnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnI2UnLoad.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnI2UnLoad.Location = new System.Drawing.Point(118, 22);
            this.btnI2UnLoad.Name = "btnI2UnLoad";
            this.btnI2UnLoad.Size = new System.Drawing.Size(106, 39);
            this.btnI2UnLoad.TabIndex = 19;
            this.btnI2UnLoad.Text = "Unload";
            this.btnI2UnLoad.UseVisualStyleBackColor = true;
            this.btnI2UnLoad.Click += new System.EventHandler(this.btnI2UnLoad_Click);
            // 
            // tbI2SlotMap
            // 
            this.tbI2SlotMap.Enabled = false;
            this.tbI2SlotMap.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbI2SlotMap.Location = new System.Drawing.Point(129, 70);
            this.tbI2SlotMap.Name = "tbI2SlotMap";
            this.tbI2SlotMap.Size = new System.Drawing.Size(319, 30);
            this.tbI2SlotMap.TabIndex = 38;
            // 
            // tbI2Reset
            // 
            this.tbI2Reset.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbI2Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbI2Reset.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbI2Reset.ForeColor = System.Drawing.Color.Black;
            this.tbI2Reset.Location = new System.Drawing.Point(475, 67);
            this.tbI2Reset.Name = "tbI2Reset";
            this.tbI2Reset.Size = new System.Drawing.Size(87, 39);
            this.tbI2Reset.TabIndex = 29;
            this.tbI2Reset.Text = "Reset";
            this.tbI2Reset.UseVisualStyleBackColor = false;
            this.tbI2Reset.Click += new System.EventHandler(this.tbI2Reset_Click);
            // 
            // btnI2GetSlotMap
            // 
            this.btnI2GetSlotMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnI2GetSlotMap.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnI2GetSlotMap.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnI2GetSlotMap.Location = new System.Drawing.Point(230, 22);
            this.btnI2GetSlotMap.Name = "btnI2GetSlotMap";
            this.btnI2GetSlotMap.Size = new System.Drawing.Size(106, 39);
            this.btnI2GetSlotMap.TabIndex = 19;
            this.btnI2GetSlotMap.Text = "Get Mapping";
            this.btnI2GetSlotMap.UseVisualStyleBackColor = true;
            this.btnI2GetSlotMap.Click += new System.EventHandler(this.btnI2GetSlotMap_Click);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.SystemColors.Highlight;
            this.label71.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.Color.White;
            this.label71.Location = new System.Drawing.Point(8, 72);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(115, 23);
            this.label71.TabIndex = 37;
            this.label71.Text = " Slot Mapping";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnI2Auto
            // 
            this.btnI2Auto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnI2Auto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnI2Auto.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnI2Auto.Location = new System.Drawing.Point(342, 22);
            this.btnI2Auto.Name = "btnI2Auto";
            this.btnI2Auto.Size = new System.Drawing.Size(106, 39);
            this.btnI2Auto.TabIndex = 19;
            this.btnI2Auto.Text = "Auto";
            this.btnI2Auto.UseVisualStyleBackColor = false;
            this.btnI2Auto.Click += new System.EventHandler(this.btnI2Auto_Click);
            // 
            // btnI2Load
            // 
            this.btnI2Load.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnI2Load.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnI2Load.Location = new System.Drawing.Point(6, 22);
            this.btnI2Load.Name = "btnI2Load";
            this.btnI2Load.Size = new System.Drawing.Size(106, 39);
            this.btnI2Load.TabIndex = 19;
            this.btnI2Load.Text = "Load";
            this.btnI2Load.UseVisualStyleBackColor = true;
            this.btnI2Load.Click += new System.EventHandler(this.btnI2Load_Click);
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.tbI1Error);
            this.groupBox25.Controls.Add(this.label67);
            this.groupBox25.Controls.Add(this.tbI1Init);
            this.groupBox25.Controls.Add(this.btnI1UnLoad);
            this.groupBox25.Controls.Add(this.tbI1SlotMap);
            this.groupBox25.Controls.Add(this.tbI1Reset);
            this.groupBox25.Controls.Add(this.btnI1GetSlotMap);
            this.groupBox25.Controls.Add(this.label66);
            this.groupBox25.Controls.Add(this.btnI1Auto);
            this.groupBox25.Controls.Add(this.btnI1Load);
            this.groupBox25.Location = new System.Drawing.Point(3, 310);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(568, 150);
            this.groupBox25.TabIndex = 17;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "ILPT1 Area";
            // 
            // tbI1Error
            // 
            this.tbI1Error.Enabled = false;
            this.tbI1Error.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbI1Error.Location = new System.Drawing.Point(129, 107);
            this.tbI1Error.Name = "tbI1Error";
            this.tbI1Error.Size = new System.Drawing.Size(319, 30);
            this.tbI1Error.TabIndex = 38;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.BackColor = System.Drawing.SystemColors.Highlight;
            this.label67.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.Color.White;
            this.label67.Location = new System.Drawing.Point(9, 109);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(114, 23);
            this.label67.TabIndex = 37;
            this.label67.Text = "                Error";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbI1Init
            // 
            this.tbI1Init.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbI1Init.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbI1Init.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbI1Init.ForeColor = System.Drawing.Color.OrangeRed;
            this.tbI1Init.Location = new System.Drawing.Point(475, 22);
            this.tbI1Init.Name = "tbI1Init";
            this.tbI1Init.Size = new System.Drawing.Size(87, 39);
            this.tbI1Init.TabIndex = 29;
            this.tbI1Init.Text = "Init";
            this.tbI1Init.UseVisualStyleBackColor = false;
            this.tbI1Init.Click += new System.EventHandler(this.tbI1Init_Click);
            // 
            // btnI1UnLoad
            // 
            this.btnI1UnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnI1UnLoad.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnI1UnLoad.Location = new System.Drawing.Point(118, 22);
            this.btnI1UnLoad.Name = "btnI1UnLoad";
            this.btnI1UnLoad.Size = new System.Drawing.Size(106, 39);
            this.btnI1UnLoad.TabIndex = 19;
            this.btnI1UnLoad.Text = "Unload";
            this.btnI1UnLoad.UseVisualStyleBackColor = true;
            this.btnI1UnLoad.Click += new System.EventHandler(this.btnI1UnLoad_Click);
            // 
            // tbI1SlotMap
            // 
            this.tbI1SlotMap.Enabled = false;
            this.tbI1SlotMap.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbI1SlotMap.Location = new System.Drawing.Point(129, 70);
            this.tbI1SlotMap.Name = "tbI1SlotMap";
            this.tbI1SlotMap.Size = new System.Drawing.Size(319, 30);
            this.tbI1SlotMap.TabIndex = 38;
            // 
            // tbI1Reset
            // 
            this.tbI1Reset.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbI1Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbI1Reset.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbI1Reset.ForeColor = System.Drawing.Color.Black;
            this.tbI1Reset.Location = new System.Drawing.Point(475, 67);
            this.tbI1Reset.Name = "tbI1Reset";
            this.tbI1Reset.Size = new System.Drawing.Size(87, 39);
            this.tbI1Reset.TabIndex = 29;
            this.tbI1Reset.Text = "Reset";
            this.tbI1Reset.UseVisualStyleBackColor = false;
            this.tbI1Reset.Click += new System.EventHandler(this.tbI1Reset_Click);
            // 
            // btnI1GetSlotMap
            // 
            this.btnI1GetSlotMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnI1GetSlotMap.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnI1GetSlotMap.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnI1GetSlotMap.Location = new System.Drawing.Point(230, 22);
            this.btnI1GetSlotMap.Name = "btnI1GetSlotMap";
            this.btnI1GetSlotMap.Size = new System.Drawing.Size(106, 39);
            this.btnI1GetSlotMap.TabIndex = 19;
            this.btnI1GetSlotMap.Text = "Get Mapping";
            this.btnI1GetSlotMap.UseVisualStyleBackColor = true;
            this.btnI1GetSlotMap.Click += new System.EventHandler(this.btnI1GetSlotMap_Click);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.SystemColors.Highlight;
            this.label66.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.Color.White;
            this.label66.Location = new System.Drawing.Point(8, 72);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(115, 23);
            this.label66.TabIndex = 37;
            this.label66.Text = " Slot Mapping";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnI1Auto
            // 
            this.btnI1Auto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnI1Auto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnI1Auto.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnI1Auto.Location = new System.Drawing.Point(342, 22);
            this.btnI1Auto.Name = "btnI1Auto";
            this.btnI1Auto.Size = new System.Drawing.Size(106, 39);
            this.btnI1Auto.TabIndex = 19;
            this.btnI1Auto.Text = "Auto";
            this.btnI1Auto.UseVisualStyleBackColor = false;
            this.btnI1Auto.Click += new System.EventHandler(this.btnI1Auto_Click);
            // 
            // btnI1Load
            // 
            this.btnI1Load.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnI1Load.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnI1Load.Location = new System.Drawing.Point(6, 22);
            this.btnI1Load.Name = "btnI1Load";
            this.btnI1Load.Size = new System.Drawing.Size(106, 39);
            this.btnI1Load.TabIndex = 19;
            this.btnI1Load.Text = "Load";
            this.btnI1Load.UseVisualStyleBackColor = true;
            this.btnI1Load.Click += new System.EventHandler(this.btnI1Load_Click);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.tbE2Error);
            this.groupBox22.Controls.Add(this.label69);
            this.groupBox22.Controls.Add(this.btnE2Init);
            this.groupBox22.Controls.Add(this.tbE2RFID);
            this.groupBox22.Controls.Add(this.btnE2Clamp);
            this.groupBox22.Controls.Add(this.label68);
            this.groupBox22.Controls.Add(this.btnE2Reset);
            this.groupBox22.Controls.Add(this.btnE2MoveOut);
            this.groupBox22.Controls.Add(this.btnE2MoveIn);
            this.groupBox22.Controls.Add(this.btnE2CloseShutter);
            this.groupBox22.Controls.Add(this.btnE2OpenShutter);
            this.groupBox22.Controls.Add(this.btnE2Auto);
            this.groupBox22.Controls.Add(this.btnE2ReadID);
            this.groupBox22.Controls.Add(this.btnE2UnClamp);
            this.groupBox22.Location = new System.Drawing.Point(3, 154);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(568, 150);
            this.groupBox22.TabIndex = 17;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "ELPT2 Area";
            // 
            // tbE2Error
            // 
            this.tbE2Error.Enabled = false;
            this.tbE2Error.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbE2Error.Location = new System.Drawing.Point(289, 114);
            this.tbE2Error.Name = "tbE2Error";
            this.tbE2Error.Size = new System.Drawing.Size(273, 30);
            this.tbE2Error.TabIndex = 38;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.BackColor = System.Drawing.SystemColors.Highlight;
            this.label69.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.White;
            this.label69.Location = new System.Drawing.Point(232, 116);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(50, 23);
            this.label69.TabIndex = 37;
            this.label69.Text = "Error";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnE2Init
            // 
            this.btnE2Init.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnE2Init.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE2Init.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE2Init.ForeColor = System.Drawing.Color.Black;
            this.btnE2Init.Location = new System.Drawing.Point(475, 22);
            this.btnE2Init.Name = "btnE2Init";
            this.btnE2Init.Size = new System.Drawing.Size(87, 39);
            this.btnE2Init.TabIndex = 29;
            this.btnE2Init.Text = "Init";
            this.btnE2Init.UseVisualStyleBackColor = false;
            this.btnE2Init.Click += new System.EventHandler(this.btnE2Init_Click);
            // 
            // tbE2RFID
            // 
            this.tbE2RFID.Enabled = false;
            this.tbE2RFID.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbE2RFID.Location = new System.Drawing.Point(65, 114);
            this.tbE2RFID.Name = "tbE2RFID";
            this.tbE2RFID.Size = new System.Drawing.Size(159, 30);
            this.tbE2RFID.TabIndex = 38;
            // 
            // btnE2Clamp
            // 
            this.btnE2Clamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE2Clamp.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE2Clamp.Location = new System.Drawing.Point(118, 22);
            this.btnE2Clamp.Name = "btnE2Clamp";
            this.btnE2Clamp.Size = new System.Drawing.Size(106, 39);
            this.btnE2Clamp.TabIndex = 19;
            this.btnE2Clamp.Text = "Clamp";
            this.btnE2Clamp.UseVisualStyleBackColor = true;
            this.btnE2Clamp.Click += new System.EventHandler(this.btnE2Clamp_Click);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.BackColor = System.Drawing.SystemColors.Highlight;
            this.label68.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.Color.White;
            this.label68.Location = new System.Drawing.Point(8, 116);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(51, 23);
            this.label68.TabIndex = 37;
            this.label68.Text = " RFID";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnE2Reset
            // 
            this.btnE2Reset.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnE2Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE2Reset.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE2Reset.ForeColor = System.Drawing.Color.Black;
            this.btnE2Reset.Location = new System.Drawing.Point(475, 67);
            this.btnE2Reset.Name = "btnE2Reset";
            this.btnE2Reset.Size = new System.Drawing.Size(87, 39);
            this.btnE2Reset.TabIndex = 29;
            this.btnE2Reset.Text = "Reset";
            this.btnE2Reset.UseVisualStyleBackColor = false;
            this.btnE2Reset.Click += new System.EventHandler(this.btnE2Reset_Click);
            // 
            // btnE2MoveOut
            // 
            this.btnE2MoveOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE2MoveOut.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE2MoveOut.Location = new System.Drawing.Point(342, 68);
            this.btnE2MoveOut.Name = "btnE2MoveOut";
            this.btnE2MoveOut.Size = new System.Drawing.Size(106, 39);
            this.btnE2MoveOut.TabIndex = 19;
            this.btnE2MoveOut.Text = "Move Out";
            this.btnE2MoveOut.UseVisualStyleBackColor = true;
            this.btnE2MoveOut.Click += new System.EventHandler(this.btnE2MoveOut_Click);
            // 
            // btnE2MoveIn
            // 
            this.btnE2MoveIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE2MoveIn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE2MoveIn.Location = new System.Drawing.Point(342, 22);
            this.btnE2MoveIn.Name = "btnE2MoveIn";
            this.btnE2MoveIn.Size = new System.Drawing.Size(106, 39);
            this.btnE2MoveIn.TabIndex = 19;
            this.btnE2MoveIn.Text = "Move In";
            this.btnE2MoveIn.UseVisualStyleBackColor = true;
            this.btnE2MoveIn.Click += new System.EventHandler(this.btnE2MoveIn_Click);
            // 
            // btnE2CloseShutter
            // 
            this.btnE2CloseShutter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE2CloseShutter.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE2CloseShutter.Location = new System.Drawing.Point(230, 68);
            this.btnE2CloseShutter.Name = "btnE2CloseShutter";
            this.btnE2CloseShutter.Size = new System.Drawing.Size(106, 39);
            this.btnE2CloseShutter.TabIndex = 19;
            this.btnE2CloseShutter.Text = "Close Shutter";
            this.btnE2CloseShutter.UseVisualStyleBackColor = true;
            this.btnE2CloseShutter.Click += new System.EventHandler(this.btnE2CloseShutter_Click);
            // 
            // btnE2OpenShutter
            // 
            this.btnE2OpenShutter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE2OpenShutter.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE2OpenShutter.Location = new System.Drawing.Point(230, 22);
            this.btnE2OpenShutter.Name = "btnE2OpenShutter";
            this.btnE2OpenShutter.Size = new System.Drawing.Size(106, 39);
            this.btnE2OpenShutter.TabIndex = 19;
            this.btnE2OpenShutter.Text = "Open Shutter";
            this.btnE2OpenShutter.UseVisualStyleBackColor = true;
            this.btnE2OpenShutter.Click += new System.EventHandler(this.btnE2OpenShutter_Click);
            // 
            // btnE2Auto
            // 
            this.btnE2Auto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnE2Auto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE2Auto.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE2Auto.Location = new System.Drawing.Point(6, 68);
            this.btnE2Auto.Name = "btnE2Auto";
            this.btnE2Auto.Size = new System.Drawing.Size(106, 39);
            this.btnE2Auto.TabIndex = 19;
            this.btnE2Auto.Text = "Auto";
            this.btnE2Auto.UseVisualStyleBackColor = false;
            this.btnE2Auto.Click += new System.EventHandler(this.btnE2Auto_Click);
            // 
            // btnE2ReadID
            // 
            this.btnE2ReadID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE2ReadID.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE2ReadID.Location = new System.Drawing.Point(6, 22);
            this.btnE2ReadID.Name = "btnE2ReadID";
            this.btnE2ReadID.Size = new System.Drawing.Size(106, 39);
            this.btnE2ReadID.TabIndex = 19;
            this.btnE2ReadID.Text = "Read RFID";
            this.btnE2ReadID.UseVisualStyleBackColor = true;
            this.btnE2ReadID.Click += new System.EventHandler(this.btnE2ReadID_Click);
            // 
            // btnE2UnClamp
            // 
            this.btnE2UnClamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE2UnClamp.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE2UnClamp.Location = new System.Drawing.Point(118, 67);
            this.btnE2UnClamp.Name = "btnE2UnClamp";
            this.btnE2UnClamp.Size = new System.Drawing.Size(106, 39);
            this.btnE2UnClamp.TabIndex = 19;
            this.btnE2UnClamp.Text = "UnClamp";
            this.btnE2UnClamp.UseVisualStyleBackColor = true;
            this.btnE2UnClamp.Click += new System.EventHandler(this.btnE2UnClamp_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.tbE1Error);
            this.groupBox17.Controls.Add(this.label65);
            this.groupBox17.Controls.Add(this.tbE1RFID);
            this.groupBox17.Controls.Add(this.label64);
            this.groupBox17.Controls.Add(this.btnE1Init);
            this.groupBox17.Controls.Add(this.btnE1Clamp);
            this.groupBox17.Controls.Add(this.btnE1Reset);
            this.groupBox17.Controls.Add(this.btnE1MoveOut);
            this.groupBox17.Controls.Add(this.btnE1MoveIn);
            this.groupBox17.Controls.Add(this.btnE1CloseShutter);
            this.groupBox17.Controls.Add(this.btnE1OpenShutter);
            this.groupBox17.Controls.Add(this.btnE1Auto);
            this.groupBox17.Controls.Add(this.btnE1ReadID);
            this.groupBox17.Controls.Add(this.btnE1UnClamp);
            this.groupBox17.Location = new System.Drawing.Point(3, 3);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(568, 150);
            this.groupBox17.TabIndex = 17;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "ELPT1 Area";
            // 
            // tbE1Error
            // 
            this.tbE1Error.Enabled = false;
            this.tbE1Error.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbE1Error.Location = new System.Drawing.Point(289, 113);
            this.tbE1Error.Name = "tbE1Error";
            this.tbE1Error.Size = new System.Drawing.Size(273, 30);
            this.tbE1Error.TabIndex = 38;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.BackColor = System.Drawing.SystemColors.Highlight;
            this.label65.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.Color.White;
            this.label65.Location = new System.Drawing.Point(232, 115);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(50, 23);
            this.label65.TabIndex = 37;
            this.label65.Text = "Error";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbE1RFID
            // 
            this.tbE1RFID.Enabled = false;
            this.tbE1RFID.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbE1RFID.Location = new System.Drawing.Point(65, 113);
            this.tbE1RFID.Name = "tbE1RFID";
            this.tbE1RFID.Size = new System.Drawing.Size(159, 30);
            this.tbE1RFID.TabIndex = 38;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.BackColor = System.Drawing.SystemColors.Highlight;
            this.label64.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.Color.White;
            this.label64.Location = new System.Drawing.Point(8, 115);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(51, 23);
            this.label64.TabIndex = 37;
            this.label64.Text = " RFID";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnE1Init
            // 
            this.btnE1Init.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnE1Init.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE1Init.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE1Init.ForeColor = System.Drawing.Color.Black;
            this.btnE1Init.Location = new System.Drawing.Point(475, 22);
            this.btnE1Init.Name = "btnE1Init";
            this.btnE1Init.Size = new System.Drawing.Size(87, 39);
            this.btnE1Init.TabIndex = 29;
            this.btnE1Init.Text = "Init";
            this.btnE1Init.UseVisualStyleBackColor = false;
            this.btnE1Init.Click += new System.EventHandler(this.btnE1Init_Click);
            // 
            // btnE1Clamp
            // 
            this.btnE1Clamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE1Clamp.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE1Clamp.Location = new System.Drawing.Point(118, 22);
            this.btnE1Clamp.Name = "btnE1Clamp";
            this.btnE1Clamp.Size = new System.Drawing.Size(106, 39);
            this.btnE1Clamp.TabIndex = 19;
            this.btnE1Clamp.Text = "Clamp";
            this.btnE1Clamp.UseVisualStyleBackColor = true;
            this.btnE1Clamp.Click += new System.EventHandler(this.btnE1Clamp_Click);
            // 
            // btnE1Reset
            // 
            this.btnE1Reset.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnE1Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE1Reset.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE1Reset.ForeColor = System.Drawing.Color.Black;
            this.btnE1Reset.Location = new System.Drawing.Point(475, 67);
            this.btnE1Reset.Name = "btnE1Reset";
            this.btnE1Reset.Size = new System.Drawing.Size(87, 39);
            this.btnE1Reset.TabIndex = 29;
            this.btnE1Reset.Text = "Reset";
            this.btnE1Reset.UseVisualStyleBackColor = false;
            this.btnE1Reset.Click += new System.EventHandler(this.btnE1Reset_Click);
            // 
            // btnE1MoveOut
            // 
            this.btnE1MoveOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE1MoveOut.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE1MoveOut.Location = new System.Drawing.Point(342, 68);
            this.btnE1MoveOut.Name = "btnE1MoveOut";
            this.btnE1MoveOut.Size = new System.Drawing.Size(106, 39);
            this.btnE1MoveOut.TabIndex = 19;
            this.btnE1MoveOut.Text = "Move Out";
            this.btnE1MoveOut.UseVisualStyleBackColor = true;
            this.btnE1MoveOut.Click += new System.EventHandler(this.btnE1MoveOut_Click);
            // 
            // btnE1MoveIn
            // 
            this.btnE1MoveIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE1MoveIn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE1MoveIn.Location = new System.Drawing.Point(342, 22);
            this.btnE1MoveIn.Name = "btnE1MoveIn";
            this.btnE1MoveIn.Size = new System.Drawing.Size(106, 39);
            this.btnE1MoveIn.TabIndex = 19;
            this.btnE1MoveIn.Text = "Move In";
            this.btnE1MoveIn.UseVisualStyleBackColor = true;
            this.btnE1MoveIn.Click += new System.EventHandler(this.btnE1MoveIn_Click);
            // 
            // btnE1CloseShutter
            // 
            this.btnE1CloseShutter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE1CloseShutter.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE1CloseShutter.Location = new System.Drawing.Point(230, 68);
            this.btnE1CloseShutter.Name = "btnE1CloseShutter";
            this.btnE1CloseShutter.Size = new System.Drawing.Size(106, 39);
            this.btnE1CloseShutter.TabIndex = 19;
            this.btnE1CloseShutter.Text = "Close Shutter";
            this.btnE1CloseShutter.UseVisualStyleBackColor = true;
            this.btnE1CloseShutter.Click += new System.EventHandler(this.btnE1CloseShutter_Click);
            // 
            // btnE1OpenShutter
            // 
            this.btnE1OpenShutter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE1OpenShutter.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE1OpenShutter.Location = new System.Drawing.Point(230, 22);
            this.btnE1OpenShutter.Name = "btnE1OpenShutter";
            this.btnE1OpenShutter.Size = new System.Drawing.Size(106, 39);
            this.btnE1OpenShutter.TabIndex = 19;
            this.btnE1OpenShutter.Text = "Open Shutter";
            this.btnE1OpenShutter.UseVisualStyleBackColor = true;
            this.btnE1OpenShutter.Click += new System.EventHandler(this.btnE1OpenShutter_Click);
            // 
            // btnE1Auto
            // 
            this.btnE1Auto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnE1Auto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE1Auto.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE1Auto.Location = new System.Drawing.Point(6, 67);
            this.btnE1Auto.Name = "btnE1Auto";
            this.btnE1Auto.Size = new System.Drawing.Size(106, 39);
            this.btnE1Auto.TabIndex = 19;
            this.btnE1Auto.Text = "Auto";
            this.btnE1Auto.UseVisualStyleBackColor = false;
            this.btnE1Auto.Click += new System.EventHandler(this.btnE1Auto_Click);
            // 
            // btnE1ReadID
            // 
            this.btnE1ReadID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE1ReadID.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE1ReadID.Location = new System.Drawing.Point(6, 22);
            this.btnE1ReadID.Name = "btnE1ReadID";
            this.btnE1ReadID.Size = new System.Drawing.Size(106, 39);
            this.btnE1ReadID.TabIndex = 19;
            this.btnE1ReadID.Text = "Read RFID";
            this.btnE1ReadID.UseVisualStyleBackColor = true;
            this.btnE1ReadID.Click += new System.EventHandler(this.btnE1ReadID_Click);
            // 
            // btnE1UnClamp
            // 
            this.btnE1UnClamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnE1UnClamp.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE1UnClamp.Location = new System.Drawing.Point(118, 67);
            this.btnE1UnClamp.Name = "btnE1UnClamp";
            this.btnE1UnClamp.Size = new System.Drawing.Size(106, 39);
            this.btnE1UnClamp.TabIndex = 19;
            this.btnE1UnClamp.Text = "UnClamp";
            this.btnE1UnClamp.UseVisualStyleBackColor = true;
            this.btnE1UnClamp.Click += new System.EventHandler(this.btnE1UnClamp_Click);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label44.Location = new System.Drawing.Point(802, 40);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(150, 21);
            this.label44.TabIndex = 31;
            this.label44.Text = "<- UnLoad Sequence";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.Location = new System.Drawing.Point(577, 61);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(373, 13);
            this.label63.TabIndex = 30;
            this.label63.Text = "UnClamp <- Close Shutter <- Move Out <- Open Shutter <- Clamp";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(577, 27);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(367, 13);
            this.label62.TabIndex = 30;
            this.label62.Text = "Clamp -> Open Shutter -> Move In -> Close Shutter -> Unclamp";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label43.Location = new System.Drawing.Point(576, 5);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(130, 21);
            this.label43.TabIndex = 30;
            this.label43.Text = "Load Sequence ->";
            // 
            // tabWHR
            // 
            this.tabWHR.Controls.Add(this.groupBox60);
            this.tabWHR.Controls.Add(this.groupBox50);
            this.tabWHR.Location = new System.Drawing.Point(4, 33);
            this.tabWHR.Name = "tabWHR";
            this.tabWHR.Size = new System.Drawing.Size(965, 622);
            this.tabWHR.TabIndex = 5;
            this.tabWHR.Text = "  WHR";
            this.tabWHR.UseVisualStyleBackColor = true;
            // 
            // groupBox60
            // 
            this.groupBox60.Controls.Add(this.rbWHRPathDirty);
            this.groupBox60.Controls.Add(this.label86);
            this.groupBox60.Controls.Add(this.rbWHRPathClean);
            this.groupBox60.Location = new System.Drawing.Point(7, 3);
            this.groupBox60.Name = "groupBox60";
            this.groupBox60.Size = new System.Drawing.Size(584, 58);
            this.groupBox60.TabIndex = 84;
            this.groupBox60.TabStop = false;
            this.groupBox60.Text = "Path Option";
            // 
            // rbWHRPathDirty
            // 
            this.rbWHRPathDirty.AutoSize = true;
            this.rbWHRPathDirty.Checked = true;
            this.rbWHRPathDirty.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWHRPathDirty.Location = new System.Drawing.Point(183, 27);
            this.rbWHRPathDirty.Name = "rbWHRPathDirty";
            this.rbWHRPathDirty.Size = new System.Drawing.Size(62, 25);
            this.rbWHRPathDirty.TabIndex = 82;
            this.rbWHRPathDirty.TabStop = true;
            this.rbWHRPathDirty.Text = "Dirty";
            this.rbWHRPathDirty.UseVisualStyleBackColor = true;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.SystemColors.Highlight;
            this.label86.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.Color.White;
            this.label86.Location = new System.Drawing.Point(21, 27);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(81, 23);
            this.label86.TabIndex = 37;
            this.label86.Text = "         Path";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbWHRPathClean
            // 
            this.rbWHRPathClean.AutoSize = true;
            this.rbWHRPathClean.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWHRPathClean.Location = new System.Drawing.Point(116, 27);
            this.rbWHRPathClean.Name = "rbWHRPathClean";
            this.rbWHRPathClean.Size = new System.Drawing.Size(66, 25);
            this.rbWHRPathClean.TabIndex = 81;
            this.rbWHRPathClean.Text = "Clean";
            this.rbWHRPathClean.UseVisualStyleBackColor = true;
            // 
            // groupBox50
            // 
            this.groupBox50.Controls.Add(this.btnWHRReset);
            this.groupBox50.Controls.Add(this.btnWHRInit);
            this.groupBox50.Controls.Add(this.btnWHRAuto);
            this.groupBox50.Controls.Add(this.groupBox51);
            this.groupBox50.Controls.Add(this.groupBox52);
            this.groupBox50.Controls.Add(this.btnWHRHome);
            this.groupBox50.Location = new System.Drawing.Point(7, 61);
            this.groupBox50.Name = "groupBox50";
            this.groupBox50.Size = new System.Drawing.Size(863, 406);
            this.groupBox50.TabIndex = 40;
            this.groupBox50.TabStop = false;
            this.groupBox50.Text = "Load Port Access";
            // 
            // btnWHRReset
            // 
            this.btnWHRReset.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnWHRReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRReset.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRReset.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnWHRReset.Location = new System.Drawing.Point(378, 103);
            this.btnWHRReset.Name = "btnWHRReset";
            this.btnWHRReset.Size = new System.Drawing.Size(106, 39);
            this.btnWHRReset.TabIndex = 78;
            this.btnWHRReset.Text = "Reset Alarm";
            this.btnWHRReset.UseVisualStyleBackColor = false;
            // 
            // btnWHRInit
            // 
            this.btnWHRInit.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnWHRInit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRInit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRInit.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnWHRInit.Location = new System.Drawing.Point(378, 58);
            this.btnWHRInit.Name = "btnWHRInit";
            this.btnWHRInit.Size = new System.Drawing.Size(106, 39);
            this.btnWHRInit.TabIndex = 79;
            this.btnWHRInit.Text = "Init";
            this.btnWHRInit.UseVisualStyleBackColor = false;
            // 
            // btnWHRAuto
            // 
            this.btnWHRAuto.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnWHRAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRAuto.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRAuto.Location = new System.Drawing.Point(378, 193);
            this.btnWHRAuto.Name = "btnWHRAuto";
            this.btnWHRAuto.Size = new System.Drawing.Size(106, 39);
            this.btnWHRAuto.TabIndex = 77;
            this.btnWHRAuto.Text = "Auto";
            this.btnWHRAuto.UseVisualStyleBackColor = false;
            this.btnWHRAuto.Click += new System.EventHandler(this.btnWHRAuto_Click);
            // 
            // groupBox51
            // 
            this.groupBox51.Controls.Add(this.btnCTUPreparePlaceWHR_1);
            this.groupBox51.Controls.Add(this.label73);
            this.groupBox51.Controls.Add(this.btnWHRMovePickCTU);
            this.groupBox51.Controls.Add(this.btnWHRExtendPickCTU);
            this.groupBox51.Controls.Add(this.btnCTUPreparePickWHR_1);
            this.groupBox51.Controls.Add(this.btnCTUReleaseWHR_1);
            this.groupBox51.Controls.Add(this.btnCTUGrabWHR_1);
            this.groupBox51.Controls.Add(this.btnWHRRetractPickCTU);
            this.groupBox51.Controls.Add(this.btnWHRToPlaceCTU_1);
            this.groupBox51.Controls.Add(this.btnWHRCompPickCTU_1);
            this.groupBox51.Controls.Add(this.btnWHRCompPlaceCTU);
            this.groupBox51.Controls.Add(this.btnWHRToPickCTU_1);
            this.groupBox51.Controls.Add(this.btnWHRRetractPlaceCTU);
            this.groupBox51.Controls.Add(this.btnWHRCTUAuto);
            this.groupBox51.Controls.Add(this.btnWHRExtendPlaceCTU);
            this.groupBox51.Controls.Add(this.btnWHRMovePlaceCTU);
            this.groupBox51.Location = new System.Drawing.Point(490, 27);
            this.groupBox51.Name = "groupBox51";
            this.groupBox51.Size = new System.Drawing.Size(357, 368);
            this.groupBox51.TabIndex = 77;
            this.groupBox51.TabStop = false;
            this.groupBox51.Text = "CTU Access";
            // 
            // btnCTUPreparePlaceWHR_1
            // 
            this.btnCTUPreparePlaceWHR_1.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnCTUPreparePlaceWHR_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUPreparePlaceWHR_1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUPreparePlaceWHR_1.ForeColor = System.Drawing.Color.Brown;
            this.btnCTUPreparePlaceWHR_1.Location = new System.Drawing.Point(243, 31);
            this.btnCTUPreparePlaceWHR_1.Name = "btnCTUPreparePlaceWHR_1";
            this.btnCTUPreparePlaceWHR_1.Size = new System.Drawing.Size(106, 39);
            this.btnCTUPreparePlaceWHR_1.TabIndex = 41;
            this.btnCTUPreparePlaceWHR_1.Text = "CTU Prepare to Place*";
            this.btnCTUPreparePlaceWHR_1.UseVisualStyleBackColor = false;
            this.btnCTUPreparePlaceWHR_1.Click += new System.EventHandler(this.btnCTUPreparePlaceWHR_1_Click);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.Color.Brown;
            this.label73.Location = new System.Drawing.Point(62, 343);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(287, 15);
            this.label73.TabIndex = 41;
            this.label73.Text = "*: [CTU] Prepare, Grab or Release motion";
            // 
            // btnWHRMovePickCTU
            // 
            this.btnWHRMovePickCTU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRMovePickCTU.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRMovePickCTU.Location = new System.Drawing.Point(243, 76);
            this.btnWHRMovePickCTU.Name = "btnWHRMovePickCTU";
            this.btnWHRMovePickCTU.Size = new System.Drawing.Size(106, 39);
            this.btnWHRMovePickCTU.TabIndex = 19;
            this.btnWHRMovePickCTU.Text = "Move to Pick";
            this.btnWHRMovePickCTU.UseVisualStyleBackColor = true;
            this.btnWHRMovePickCTU.Click += new System.EventHandler(this.btnWHRMovePickCTU_Click);
            // 
            // btnWHRExtendPickCTU
            // 
            this.btnWHRExtendPickCTU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRExtendPickCTU.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRExtendPickCTU.Location = new System.Drawing.Point(243, 121);
            this.btnWHRExtendPickCTU.Name = "btnWHRExtendPickCTU";
            this.btnWHRExtendPickCTU.Size = new System.Drawing.Size(106, 39);
            this.btnWHRExtendPickCTU.TabIndex = 19;
            this.btnWHRExtendPickCTU.Text = "Extend(Pick)";
            this.btnWHRExtendPickCTU.UseVisualStyleBackColor = true;
            this.btnWHRExtendPickCTU.Click += new System.EventHandler(this.btnWHRExtendPickCTU_Click);
            // 
            // btnCTUPreparePickWHR_1
            // 
            this.btnCTUPreparePickWHR_1.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnCTUPreparePickWHR_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUPreparePickWHR_1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUPreparePickWHR_1.ForeColor = System.Drawing.Color.Brown;
            this.btnCTUPreparePickWHR_1.Location = new System.Drawing.Point(131, 31);
            this.btnCTUPreparePickWHR_1.Name = "btnCTUPreparePickWHR_1";
            this.btnCTUPreparePickWHR_1.Size = new System.Drawing.Size(106, 39);
            this.btnCTUPreparePickWHR_1.TabIndex = 42;
            this.btnCTUPreparePickWHR_1.Text = "CTU Prepare to Pick*";
            this.btnCTUPreparePickWHR_1.UseVisualStyleBackColor = false;
            this.btnCTUPreparePickWHR_1.Click += new System.EventHandler(this.btnCTUPreparePickWHR_1_Click);
            // 
            // btnCTUReleaseWHR_1
            // 
            this.btnCTUReleaseWHR_1.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnCTUReleaseWHR_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUReleaseWHR_1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUReleaseWHR_1.ForeColor = System.Drawing.Color.Brown;
            this.btnCTUReleaseWHR_1.Location = new System.Drawing.Point(243, 256);
            this.btnCTUReleaseWHR_1.Name = "btnCTUReleaseWHR_1";
            this.btnCTUReleaseWHR_1.Size = new System.Drawing.Size(106, 39);
            this.btnCTUReleaseWHR_1.TabIndex = 19;
            this.btnCTUReleaseWHR_1.Text = "CTU Release*";
            this.btnCTUReleaseWHR_1.UseVisualStyleBackColor = false;
            this.btnCTUReleaseWHR_1.Click += new System.EventHandler(this.btnCTUReleaseWHR_1_Click);
            // 
            // btnCTUGrabWHR_1
            // 
            this.btnCTUGrabWHR_1.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnCTUGrabWHR_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUGrabWHR_1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUGrabWHR_1.ForeColor = System.Drawing.Color.Brown;
            this.btnCTUGrabWHR_1.Location = new System.Drawing.Point(131, 256);
            this.btnCTUGrabWHR_1.Name = "btnCTUGrabWHR_1";
            this.btnCTUGrabWHR_1.Size = new System.Drawing.Size(106, 39);
            this.btnCTUGrabWHR_1.TabIndex = 19;
            this.btnCTUGrabWHR_1.Text = "CTU Grab*";
            this.btnCTUGrabWHR_1.UseVisualStyleBackColor = false;
            this.btnCTUGrabWHR_1.Click += new System.EventHandler(this.btnCTUGrabWHR_1_Click);
            // 
            // btnWHRRetractPickCTU
            // 
            this.btnWHRRetractPickCTU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRRetractPickCTU.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRRetractPickCTU.Location = new System.Drawing.Point(243, 166);
            this.btnWHRRetractPickCTU.Name = "btnWHRRetractPickCTU";
            this.btnWHRRetractPickCTU.Size = new System.Drawing.Size(106, 39);
            this.btnWHRRetractPickCTU.TabIndex = 19;
            this.btnWHRRetractPickCTU.Text = "Retract(Pick)";
            this.btnWHRRetractPickCTU.UseVisualStyleBackColor = true;
            this.btnWHRRetractPickCTU.Click += new System.EventHandler(this.btnWHRRetractPickCTU_Click);
            // 
            // btnWHRToPlaceCTU_1
            // 
            this.btnWHRToPlaceCTU_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRToPlaceCTU_1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRToPlaceCTU_1.Location = new System.Drawing.Point(131, 211);
            this.btnWHRToPlaceCTU_1.Name = "btnWHRToPlaceCTU_1";
            this.btnWHRToPlaceCTU_1.Size = new System.Drawing.Size(106, 39);
            this.btnWHRToPlaceCTU_1.TabIndex = 19;
            this.btnWHRToPlaceCTU_1.Text = "To Place";
            this.btnWHRToPlaceCTU_1.UseVisualStyleBackColor = true;
            this.btnWHRToPlaceCTU_1.Click += new System.EventHandler(this.btnWHRToPlaceCTU_1_Click);
            // 
            // btnWHRCompPickCTU_1
            // 
            this.btnWHRCompPickCTU_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRCompPickCTU_1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRCompPickCTU_1.Location = new System.Drawing.Point(243, 301);
            this.btnWHRCompPickCTU_1.Name = "btnWHRCompPickCTU_1";
            this.btnWHRCompPickCTU_1.Size = new System.Drawing.Size(106, 39);
            this.btnWHRCompPickCTU_1.TabIndex = 19;
            this.btnWHRCompPickCTU_1.Text = "Complete Pick";
            this.btnWHRCompPickCTU_1.UseVisualStyleBackColor = true;
            this.btnWHRCompPickCTU_1.Click += new System.EventHandler(this.btnWHRCompPickCTU_1_Click);
            // 
            // btnWHRCompPlaceCTU
            // 
            this.btnWHRCompPlaceCTU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRCompPlaceCTU.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRCompPlaceCTU.Location = new System.Drawing.Point(131, 301);
            this.btnWHRCompPlaceCTU.Name = "btnWHRCompPlaceCTU";
            this.btnWHRCompPlaceCTU.Size = new System.Drawing.Size(106, 39);
            this.btnWHRCompPlaceCTU.TabIndex = 19;
            this.btnWHRCompPlaceCTU.Text = "Complete Place";
            this.btnWHRCompPlaceCTU.UseVisualStyleBackColor = true;
            this.btnWHRCompPlaceCTU.Click += new System.EventHandler(this.btnWHRCompPlaceCTU_Click);
            // 
            // btnWHRToPickCTU_1
            // 
            this.btnWHRToPickCTU_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRToPickCTU_1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRToPickCTU_1.Location = new System.Drawing.Point(243, 211);
            this.btnWHRToPickCTU_1.Name = "btnWHRToPickCTU_1";
            this.btnWHRToPickCTU_1.Size = new System.Drawing.Size(106, 39);
            this.btnWHRToPickCTU_1.TabIndex = 19;
            this.btnWHRToPickCTU_1.Text = "To Pick";
            this.btnWHRToPickCTU_1.UseVisualStyleBackColor = true;
            this.btnWHRToPickCTU_1.Click += new System.EventHandler(this.btnWHRToPickCTU_1_Click);
            // 
            // btnWHRRetractPlaceCTU
            // 
            this.btnWHRRetractPlaceCTU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRRetractPlaceCTU.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRRetractPlaceCTU.Location = new System.Drawing.Point(131, 166);
            this.btnWHRRetractPlaceCTU.Name = "btnWHRRetractPlaceCTU";
            this.btnWHRRetractPlaceCTU.Size = new System.Drawing.Size(106, 39);
            this.btnWHRRetractPlaceCTU.TabIndex = 19;
            this.btnWHRRetractPlaceCTU.Text = "Retract(Place)";
            this.btnWHRRetractPlaceCTU.UseVisualStyleBackColor = true;
            this.btnWHRRetractPlaceCTU.Click += new System.EventHandler(this.btnWHRRetractPlaceCTU_Click);
            // 
            // btnWHRCTUAuto
            // 
            this.btnWHRCTUAuto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnWHRCTUAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRCTUAuto.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRCTUAuto.Location = new System.Drawing.Point(19, 301);
            this.btnWHRCTUAuto.Name = "btnWHRCTUAuto";
            this.btnWHRCTUAuto.Size = new System.Drawing.Size(106, 39);
            this.btnWHRCTUAuto.TabIndex = 77;
            this.btnWHRCTUAuto.Text = "Auto";
            this.btnWHRCTUAuto.UseVisualStyleBackColor = false;
            this.btnWHRCTUAuto.Click += new System.EventHandler(this.btnWHRCTUAuto_Click);
            // 
            // btnWHRExtendPlaceCTU
            // 
            this.btnWHRExtendPlaceCTU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRExtendPlaceCTU.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRExtendPlaceCTU.Location = new System.Drawing.Point(131, 121);
            this.btnWHRExtendPlaceCTU.Name = "btnWHRExtendPlaceCTU";
            this.btnWHRExtendPlaceCTU.Size = new System.Drawing.Size(106, 39);
            this.btnWHRExtendPlaceCTU.TabIndex = 19;
            this.btnWHRExtendPlaceCTU.Text = "Extend(Place)";
            this.btnWHRExtendPlaceCTU.UseVisualStyleBackColor = true;
            this.btnWHRExtendPlaceCTU.Click += new System.EventHandler(this.btnWHRExtendPlaceCTU_Click);
            // 
            // btnWHRMovePlaceCTU
            // 
            this.btnWHRMovePlaceCTU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRMovePlaceCTU.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRMovePlaceCTU.Location = new System.Drawing.Point(131, 76);
            this.btnWHRMovePlaceCTU.Name = "btnWHRMovePlaceCTU";
            this.btnWHRMovePlaceCTU.Size = new System.Drawing.Size(106, 39);
            this.btnWHRMovePlaceCTU.TabIndex = 19;
            this.btnWHRMovePlaceCTU.Text = "Move to Place";
            this.btnWHRMovePlaceCTU.UseVisualStyleBackColor = true;
            this.btnWHRMovePlaceCTU.Click += new System.EventHandler(this.btnWHRMovePlaceCTU_Click);
            // 
            // groupBox52
            // 
            this.groupBox52.Controls.Add(this.cbWHRSelctILPT);
            this.groupBox52.Controls.Add(this.btnWHRPlacePort);
            this.groupBox52.Controls.Add(this.btnWHRPortAuto);
            this.groupBox52.Controls.Add(this.btnWHRRetractPlacePort);
            this.groupBox52.Controls.Add(this.btnWHRRetractPickPort);
            this.groupBox52.Controls.Add(this.btnWHRMovePlacePort);
            this.groupBox52.Controls.Add(this.btnWHRMovePickPort);
            this.groupBox52.Controls.Add(this.btnWHRDownPort);
            this.groupBox52.Controls.Add(this.btnWHRPickPort);
            this.groupBox52.Controls.Add(this.btnWHRExtendPlacePort);
            this.groupBox52.Controls.Add(this.btnWHRExtendPickPort);
            this.groupBox52.Controls.Add(this.btnWHRUpPort);
            this.groupBox52.Location = new System.Drawing.Point(15, 27);
            this.groupBox52.Name = "groupBox52";
            this.groupBox52.Size = new System.Drawing.Size(357, 295);
            this.groupBox52.TabIndex = 77;
            this.groupBox52.TabStop = false;
            this.groupBox52.Text = "ILPT Access";
            // 
            // cbWHRSelctILPT
            // 
            this.cbWHRSelctILPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWHRSelctILPT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbWHRSelctILPT.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWHRSelctILPT.FormattingEnabled = true;
            this.cbWHRSelctILPT.Items.AddRange(new object[] {
            "ILPT1",
            "ILPT2"});
            this.cbWHRSelctILPT.Location = new System.Drawing.Point(14, 34);
            this.cbWHRSelctILPT.Name = "cbWHRSelctILPT";
            this.cbWHRSelctILPT.Size = new System.Drawing.Size(106, 36);
            this.cbWHRSelctILPT.TabIndex = 78;
            // 
            // btnWHRPlacePort
            // 
            this.btnWHRPlacePort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRPlacePort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRPlacePort.Location = new System.Drawing.Point(238, 211);
            this.btnWHRPlacePort.Name = "btnWHRPlacePort";
            this.btnWHRPlacePort.Size = new System.Drawing.Size(106, 39);
            this.btnWHRPlacePort.TabIndex = 19;
            this.btnWHRPlacePort.Text = "Place";
            this.btnWHRPlacePort.UseVisualStyleBackColor = true;
            this.btnWHRPlacePort.Click += new System.EventHandler(this.btnWHRPlacePort_Click);
            // 
            // btnWHRPortAuto
            // 
            this.btnWHRPortAuto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnWHRPortAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRPortAuto.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRPortAuto.Location = new System.Drawing.Point(14, 211);
            this.btnWHRPortAuto.Name = "btnWHRPortAuto";
            this.btnWHRPortAuto.Size = new System.Drawing.Size(106, 39);
            this.btnWHRPortAuto.TabIndex = 77;
            this.btnWHRPortAuto.Text = "Auto";
            this.btnWHRPortAuto.UseVisualStyleBackColor = false;
            this.btnWHRPortAuto.Click += new System.EventHandler(this.btnWHRPortAuto_Click);
            // 
            // btnWHRRetractPlacePort
            // 
            this.btnWHRRetractPlacePort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRRetractPlacePort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRRetractPlacePort.Location = new System.Drawing.Point(238, 121);
            this.btnWHRRetractPlacePort.Name = "btnWHRRetractPlacePort";
            this.btnWHRRetractPlacePort.Size = new System.Drawing.Size(106, 39);
            this.btnWHRRetractPlacePort.TabIndex = 19;
            this.btnWHRRetractPlacePort.Text = "Retract(Place)";
            this.btnWHRRetractPlacePort.UseVisualStyleBackColor = true;
            this.btnWHRRetractPlacePort.Click += new System.EventHandler(this.btnWHRRetractPlacePort_Click);
            // 
            // btnWHRRetractPickPort
            // 
            this.btnWHRRetractPickPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRRetractPickPort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRRetractPickPort.Location = new System.Drawing.Point(126, 121);
            this.btnWHRRetractPickPort.Name = "btnWHRRetractPickPort";
            this.btnWHRRetractPickPort.Size = new System.Drawing.Size(106, 39);
            this.btnWHRRetractPickPort.TabIndex = 19;
            this.btnWHRRetractPickPort.Text = "Retract(Pick)";
            this.btnWHRRetractPickPort.UseVisualStyleBackColor = true;
            this.btnWHRRetractPickPort.Click += new System.EventHandler(this.btnWHRRetractPickPort_Click);
            // 
            // btnWHRMovePlacePort
            // 
            this.btnWHRMovePlacePort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRMovePlacePort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRMovePlacePort.Location = new System.Drawing.Point(238, 31);
            this.btnWHRMovePlacePort.Name = "btnWHRMovePlacePort";
            this.btnWHRMovePlacePort.Size = new System.Drawing.Size(106, 39);
            this.btnWHRMovePlacePort.TabIndex = 19;
            this.btnWHRMovePlacePort.Text = "Move to Place";
            this.btnWHRMovePlacePort.UseVisualStyleBackColor = true;
            this.btnWHRMovePlacePort.Click += new System.EventHandler(this.btnWHRMovePlacePort_Click);
            // 
            // btnWHRMovePickPort
            // 
            this.btnWHRMovePickPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRMovePickPort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRMovePickPort.Location = new System.Drawing.Point(126, 31);
            this.btnWHRMovePickPort.Name = "btnWHRMovePickPort";
            this.btnWHRMovePickPort.Size = new System.Drawing.Size(106, 39);
            this.btnWHRMovePickPort.TabIndex = 19;
            this.btnWHRMovePickPort.Text = "Move to Pick";
            this.btnWHRMovePickPort.UseVisualStyleBackColor = true;
            this.btnWHRMovePickPort.Click += new System.EventHandler(this.btnWHRMovePickPort_Click);
            // 
            // btnWHRDownPort
            // 
            this.btnWHRDownPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRDownPort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRDownPort.Location = new System.Drawing.Point(238, 166);
            this.btnWHRDownPort.Name = "btnWHRDownPort";
            this.btnWHRDownPort.Size = new System.Drawing.Size(106, 39);
            this.btnWHRDownPort.TabIndex = 19;
            this.btnWHRDownPort.Text = "Down";
            this.btnWHRDownPort.UseVisualStyleBackColor = true;
            this.btnWHRDownPort.Click += new System.EventHandler(this.btnWHRDownPort_Click);
            // 
            // btnWHRPickPort
            // 
            this.btnWHRPickPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRPickPort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRPickPort.Location = new System.Drawing.Point(126, 211);
            this.btnWHRPickPort.Name = "btnWHRPickPort";
            this.btnWHRPickPort.Size = new System.Drawing.Size(106, 39);
            this.btnWHRPickPort.TabIndex = 19;
            this.btnWHRPickPort.Text = "Pick";
            this.btnWHRPickPort.UseVisualStyleBackColor = true;
            this.btnWHRPickPort.Click += new System.EventHandler(this.btnWHRPickPort_Click);
            // 
            // btnWHRExtendPlacePort
            // 
            this.btnWHRExtendPlacePort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRExtendPlacePort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRExtendPlacePort.Location = new System.Drawing.Point(238, 76);
            this.btnWHRExtendPlacePort.Name = "btnWHRExtendPlacePort";
            this.btnWHRExtendPlacePort.Size = new System.Drawing.Size(106, 39);
            this.btnWHRExtendPlacePort.TabIndex = 19;
            this.btnWHRExtendPlacePort.Text = "Extend(Place)";
            this.btnWHRExtendPlacePort.UseVisualStyleBackColor = true;
            this.btnWHRExtendPlacePort.Click += new System.EventHandler(this.btnWHRExtendPlacePort_Click);
            // 
            // btnWHRExtendPickPort
            // 
            this.btnWHRExtendPickPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRExtendPickPort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRExtendPickPort.Location = new System.Drawing.Point(126, 76);
            this.btnWHRExtendPickPort.Name = "btnWHRExtendPickPort";
            this.btnWHRExtendPickPort.Size = new System.Drawing.Size(106, 39);
            this.btnWHRExtendPickPort.TabIndex = 19;
            this.btnWHRExtendPickPort.Text = "Extend(Pick)";
            this.btnWHRExtendPickPort.UseVisualStyleBackColor = true;
            this.btnWHRExtendPickPort.Click += new System.EventHandler(this.btnWHRExtendPickPort_Click);
            // 
            // btnWHRUpPort
            // 
            this.btnWHRUpPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRUpPort.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRUpPort.Location = new System.Drawing.Point(126, 166);
            this.btnWHRUpPort.Name = "btnWHRUpPort";
            this.btnWHRUpPort.Size = new System.Drawing.Size(106, 39);
            this.btnWHRUpPort.TabIndex = 19;
            this.btnWHRUpPort.Text = "Up";
            this.btnWHRUpPort.UseVisualStyleBackColor = true;
            this.btnWHRUpPort.Click += new System.EventHandler(this.btnWHRUpPort_Click);
            // 
            // btnWHRHome
            // 
            this.btnWHRHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRHome.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRHome.Location = new System.Drawing.Point(378, 148);
            this.btnWHRHome.Name = "btnWHRHome";
            this.btnWHRHome.Size = new System.Drawing.Size(106, 39);
            this.btnWHRHome.TabIndex = 19;
            this.btnWHRHome.Text = "Home";
            this.btnWHRHome.UseVisualStyleBackColor = true;
            this.btnWHRHome.Click += new System.EventHandler(this.btnWHRHome_Click);
            // 
            // tabCTU_PTZ
            // 
            this.tabCTU_PTZ.Controls.Add(this.groupBox61);
            this.tabCTU_PTZ.Controls.Add(this.groupBox59);
            this.tabCTU_PTZ.Controls.Add(this.groupBox56);
            this.tabCTU_PTZ.Controls.Add(this.groupBox53);
            this.tabCTU_PTZ.Location = new System.Drawing.Point(4, 33);
            this.tabCTU_PTZ.Name = "tabCTU_PTZ";
            this.tabCTU_PTZ.Size = new System.Drawing.Size(965, 622);
            this.tabCTU_PTZ.TabIndex = 6;
            this.tabCTU_PTZ.Text = "CTU & PTZ";
            this.tabCTU_PTZ.UseVisualStyleBackColor = true;
            // 
            // groupBox61
            // 
            this.groupBox61.Controls.Add(this.tbDegree);
            this.groupBox61.Controls.Add(this.btnAlign);
            this.groupBox61.Controls.Add(this.label89);
            this.groupBox61.Location = new System.Drawing.Point(707, 171);
            this.groupBox61.Name = "groupBox61";
            this.groupBox61.Size = new System.Drawing.Size(238, 137);
            this.groupBox61.TabIndex = 77;
            this.groupBox61.TabStop = false;
            this.groupBox61.Text = "Aligner Area";
            // 
            // tbDegree
            // 
            this.tbDegree.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDegree.Location = new System.Drawing.Point(73, 40);
            this.tbDegree.Name = "tbDegree";
            this.tbDegree.Size = new System.Drawing.Size(139, 30);
            this.tbDegree.TabIndex = 86;
            this.hint.SetToolTip(this.tbDegree, "DEG : 0~359000 (Degree * 1000)");
            this.tbDegree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDegree_KeyPress);
            // 
            // btnAlign
            // 
            this.btnAlign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlign.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlign.Location = new System.Drawing.Point(106, 80);
            this.btnAlign.Name = "btnAlign";
            this.btnAlign.Size = new System.Drawing.Size(106, 39);
            this.btnAlign.TabIndex = 19;
            this.btnAlign.Text = "Align";
            this.btnAlign.UseVisualStyleBackColor = true;
            this.btnAlign.Click += new System.EventHandler(this.btnAlign_Click);
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.BackColor = System.Drawing.SystemColors.Highlight;
            this.label89.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.Color.White;
            this.label89.Location = new System.Drawing.Point(14, 45);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(53, 23);
            this.label89.TabIndex = 85;
            this.label89.Text = "Angle";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox59
            // 
            this.groupBox59.Controls.Add(this.rbCTUPathDirty);
            this.groupBox59.Controls.Add(this.label83);
            this.groupBox59.Controls.Add(this.rbCTUPathClean);
            this.groupBox59.Location = new System.Drawing.Point(7, 3);
            this.groupBox59.Name = "groupBox59";
            this.groupBox59.Size = new System.Drawing.Size(584, 58);
            this.groupBox59.TabIndex = 83;
            this.groupBox59.TabStop = false;
            this.groupBox59.Text = "Path Option";
            // 
            // rbCTUPathDirty
            // 
            this.rbCTUPathDirty.AutoSize = true;
            this.rbCTUPathDirty.Checked = true;
            this.rbCTUPathDirty.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCTUPathDirty.Location = new System.Drawing.Point(183, 27);
            this.rbCTUPathDirty.Name = "rbCTUPathDirty";
            this.rbCTUPathDirty.Size = new System.Drawing.Size(62, 25);
            this.rbCTUPathDirty.TabIndex = 82;
            this.rbCTUPathDirty.TabStop = true;
            this.rbCTUPathDirty.Text = "Dirty";
            this.rbCTUPathDirty.UseVisualStyleBackColor = true;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.BackColor = System.Drawing.SystemColors.Highlight;
            this.label83.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.Color.White;
            this.label83.Location = new System.Drawing.Point(21, 27);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(81, 23);
            this.label83.TabIndex = 37;
            this.label83.Text = "         Path";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbCTUPathClean
            // 
            this.rbCTUPathClean.AutoSize = true;
            this.rbCTUPathClean.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCTUPathClean.Location = new System.Drawing.Point(116, 27);
            this.rbCTUPathClean.Name = "rbCTUPathClean";
            this.rbCTUPathClean.Size = new System.Drawing.Size(66, 25);
            this.rbCTUPathClean.TabIndex = 81;
            this.rbCTUPathClean.Text = "Clean";
            this.rbCTUPathClean.UseVisualStyleBackColor = true;
            // 
            // groupBox56
            // 
            this.groupBox56.Controls.Add(this.tbPtzSlotMap);
            this.groupBox56.Controls.Add(this.groupBox58);
            this.groupBox56.Controls.Add(this.btnPTZGetSlotMap);
            this.groupBox56.Controls.Add(this.label88);
            this.groupBox56.Controls.Add(this.btnPTZMoveHome_1);
            this.groupBox56.Controls.Add(this.btnPTZReset);
            this.groupBox56.Controls.Add(this.btnPTZMoveCTU_1);
            this.groupBox56.Controls.Add(this.btnPTZInit);
            this.groupBox56.Controls.Add(this.groupBox57);
            this.groupBox56.Controls.Add(this.btnPTZRorate);
            this.groupBox56.Controls.Add(this.btnPTZAuto);
            this.groupBox56.Location = new System.Drawing.Point(7, 64);
            this.groupBox56.Name = "groupBox56";
            this.groupBox56.Size = new System.Drawing.Size(687, 244);
            this.groupBox56.TabIndex = 78;
            this.groupBox56.TabStop = false;
            this.groupBox56.Text = "PTZ Area";
            // 
            // tbPtzSlotMap
            // 
            this.tbPtzSlotMap.Enabled = false;
            this.tbPtzSlotMap.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPtzSlotMap.Location = new System.Drawing.Point(246, 196);
            this.tbPtzSlotMap.Name = "tbPtzSlotMap";
            this.tbPtzSlotMap.Size = new System.Drawing.Size(435, 30);
            this.tbPtzSlotMap.TabIndex = 86;
            // 
            // groupBox58
            // 
            this.groupBox58.Controls.Add(this.label87);
            this.groupBox58.Controls.Add(this.rbPTZDirFaceBack);
            this.groupBox58.Controls.Add(this.rbPTZDirBackFace);
            this.groupBox58.Controls.Add(this.rbPTZDirBack);
            this.groupBox58.Controls.Add(this.rbPTZDirFace);
            this.groupBox58.Location = new System.Drawing.Point(15, 80);
            this.groupBox58.Name = "groupBox58";
            this.groupBox58.Size = new System.Drawing.Size(659, 58);
            this.groupBox58.TabIndex = 20;
            this.groupBox58.TabStop = false;
            this.groupBox58.Text = "Direction Option";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BackColor = System.Drawing.SystemColors.Highlight;
            this.label87.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.Color.White;
            this.label87.Location = new System.Drawing.Point(7, 27);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(81, 23);
            this.label87.TabIndex = 37;
            this.label87.Text = "Direction";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbPTZDirFaceBack
            // 
            this.rbPTZDirFaceBack.AutoSize = true;
            this.rbPTZDirFaceBack.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPTZDirFaceBack.Location = new System.Drawing.Point(231, 25);
            this.rbPTZDirFaceBack.Name = "rbPTZDirFaceBack";
            this.rbPTZDirFaceBack.Size = new System.Drawing.Size(133, 25);
            this.rbPTZDirFaceBack.TabIndex = 82;
            this.rbPTZDirFaceBack.Text = "1: Back to Back";
            this.rbPTZDirFaceBack.UseVisualStyleBackColor = true;
            this.rbPTZDirFaceBack.CheckedChanged += new System.EventHandler(this.PTZDir_CheckedChanged);
            // 
            // rbPTZDirBackFace
            // 
            this.rbPTZDirBackFace.AutoSize = true;
            this.rbPTZDirBackFace.Checked = true;
            this.rbPTZDirBackFace.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPTZDirBackFace.Location = new System.Drawing.Point(99, 25);
            this.rbPTZDirBackFace.Name = "rbPTZDirBackFace";
            this.rbPTZDirBackFace.Size = new System.Drawing.Size(131, 25);
            this.rbPTZDirBackFace.TabIndex = 82;
            this.rbPTZDirBackFace.TabStop = true;
            this.rbPTZDirBackFace.Text = "0: Face to Face";
            this.rbPTZDirBackFace.UseVisualStyleBackColor = true;
            this.rbPTZDirBackFace.CheckedChanged += new System.EventHandler(this.PTZDir_CheckedChanged);
            // 
            // rbPTZDirBack
            // 
            this.rbPTZDirBack.AutoSize = true;
            this.rbPTZDirBack.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPTZDirBack.Location = new System.Drawing.Point(370, 25);
            this.rbPTZDirBack.Name = "rbPTZDirBack";
            this.rbPTZDirBack.Size = new System.Drawing.Size(128, 25);
            this.rbPTZDirBack.TabIndex = 82;
            this.rbPTZDirBack.Text = "2:Face to Back";
            this.rbPTZDirBack.UseVisualStyleBackColor = true;
            this.rbPTZDirBack.CheckedChanged += new System.EventHandler(this.PTZDir_CheckedChanged);
            // 
            // rbPTZDirFace
            // 
            this.rbPTZDirFace.AutoSize = true;
            this.rbPTZDirFace.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPTZDirFace.Location = new System.Drawing.Point(504, 25);
            this.rbPTZDirFace.Name = "rbPTZDirFace";
            this.rbPTZDirFace.Size = new System.Drawing.Size(132, 25);
            this.rbPTZDirFace.TabIndex = 81;
            this.rbPTZDirFace.Text = "3:Back to Face ";
            this.rbPTZDirFace.UseVisualStyleBackColor = true;
            this.rbPTZDirFace.CheckedChanged += new System.EventHandler(this.PTZDir_CheckedChanged);
            // 
            // btnPTZGetSlotMap
            // 
            this.btnPTZGetSlotMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPTZGetSlotMap.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTZGetSlotMap.Location = new System.Drawing.Point(463, 147);
            this.btnPTZGetSlotMap.Name = "btnPTZGetSlotMap";
            this.btnPTZGetSlotMap.Size = new System.Drawing.Size(106, 39);
            this.btnPTZGetSlotMap.TabIndex = 84;
            this.btnPTZGetSlotMap.Text = "Get Mapping";
            this.btnPTZGetSlotMap.UseVisualStyleBackColor = true;
            this.btnPTZGetSlotMap.Click += new System.EventHandler(this.btnPTZGetSlotMap_Click);
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.BackColor = System.Drawing.SystemColors.Highlight;
            this.label88.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.Color.White;
            this.label88.Location = new System.Drawing.Point(128, 202);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(115, 23);
            this.label88.TabIndex = 85;
            this.label88.Text = " Slot Mapping";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPTZMoveHome_1
            // 
            this.btnPTZMoveHome_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPTZMoveHome_1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTZMoveHome_1.Location = new System.Drawing.Point(351, 147);
            this.btnPTZMoveHome_1.Name = "btnPTZMoveHome_1";
            this.btnPTZMoveHome_1.Size = new System.Drawing.Size(106, 39);
            this.btnPTZMoveHome_1.TabIndex = 19;
            this.btnPTZMoveHome_1.Text = "Move(Home)";
            this.btnPTZMoveHome_1.UseVisualStyleBackColor = true;
            this.btnPTZMoveHome_1.Click += new System.EventHandler(this.btnPTZMoveHome_Click);
            // 
            // btnPTZReset
            // 
            this.btnPTZReset.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnPTZReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPTZReset.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTZReset.ForeColor = System.Drawing.Color.Black;
            this.btnPTZReset.Location = new System.Drawing.Point(568, 40);
            this.btnPTZReset.Name = "btnPTZReset";
            this.btnPTZReset.Size = new System.Drawing.Size(106, 39);
            this.btnPTZReset.TabIndex = 78;
            this.btnPTZReset.Text = "Reset Alarm";
            this.btnPTZReset.UseVisualStyleBackColor = false;
            this.btnPTZReset.Click += new System.EventHandler(this.btnPTZReset_Click);
            // 
            // btnPTZMoveCTU_1
            // 
            this.btnPTZMoveCTU_1.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnPTZMoveCTU_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPTZMoveCTU_1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTZMoveCTU_1.ForeColor = System.Drawing.Color.Brown;
            this.btnPTZMoveCTU_1.Location = new System.Drawing.Point(127, 147);
            this.btnPTZMoveCTU_1.Name = "btnPTZMoveCTU_1";
            this.btnPTZMoveCTU_1.Size = new System.Drawing.Size(218, 39);
            this.btnPTZMoveCTU_1.TabIndex = 19;
            this.btnPTZMoveCTU_1.Text = "Prepare or Transfer(Odd)";
            this.btnPTZMoveCTU_1.UseVisualStyleBackColor = false;
            this.btnPTZMoveCTU_1.Click += new System.EventHandler(this.btnPTZMoveCTU_Click);
            // 
            // btnPTZInit
            // 
            this.btnPTZInit.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnPTZInit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPTZInit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTZInit.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnPTZInit.Location = new System.Drawing.Point(456, 40);
            this.btnPTZInit.Name = "btnPTZInit";
            this.btnPTZInit.Size = new System.Drawing.Size(106, 39);
            this.btnPTZInit.TabIndex = 79;
            this.btnPTZInit.Text = "Init";
            this.btnPTZInit.UseVisualStyleBackColor = false;
            // 
            // groupBox57
            // 
            this.groupBox57.Controls.Add(this.label85);
            this.groupBox57.Controls.Add(this.rbPTZPosAuto);
            this.groupBox57.Controls.Add(this.rbPTZPosEven);
            this.groupBox57.Controls.Add(this.rbPTZPosOdd);
            this.groupBox57.Location = new System.Drawing.Point(15, 21);
            this.groupBox57.Name = "groupBox57";
            this.groupBox57.Size = new System.Drawing.Size(435, 58);
            this.groupBox57.TabIndex = 20;
            this.groupBox57.TabStop = false;
            this.groupBox57.Text = "Position Option";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.BackColor = System.Drawing.SystemColors.Highlight;
            this.label85.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.ForeColor = System.Drawing.Color.White;
            this.label85.Location = new System.Drawing.Point(6, 24);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(81, 23);
            this.label85.TabIndex = 37;
            this.label85.Text = "  Position";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbPTZPosAuto
            // 
            this.rbPTZPosAuto.AutoSize = true;
            this.rbPTZPosAuto.Checked = true;
            this.rbPTZPosAuto.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPTZPosAuto.Location = new System.Drawing.Point(231, 24);
            this.rbPTZPosAuto.Name = "rbPTZPosAuto";
            this.rbPTZPosAuto.Size = new System.Drawing.Size(197, 25);
            this.rbPTZPosAuto.TabIndex = 82;
            this.rbPTZPosAuto.TabStop = true;
            this.rbPTZPosAuto.Text = "Auto(1st:Odd.2nd:Even)";
            this.rbPTZPosAuto.UseVisualStyleBackColor = true;
            this.rbPTZPosAuto.CheckedChanged += new System.EventHandler(this.PTZPos_CheckedChanged);
            // 
            // rbPTZPosEven
            // 
            this.rbPTZPosEven.AutoSize = true;
            this.rbPTZPosEven.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPTZPosEven.Location = new System.Drawing.Point(168, 24);
            this.rbPTZPosEven.Name = "rbPTZPosEven";
            this.rbPTZPosEven.Size = new System.Drawing.Size(61, 25);
            this.rbPTZPosEven.TabIndex = 82;
            this.rbPTZPosEven.Text = "Even";
            this.rbPTZPosEven.UseVisualStyleBackColor = true;
            this.rbPTZPosEven.CheckedChanged += new System.EventHandler(this.PTZPos_CheckedChanged);
            // 
            // rbPTZPosOdd
            // 
            this.rbPTZPosOdd.AutoSize = true;
            this.rbPTZPosOdd.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPTZPosOdd.Location = new System.Drawing.Point(101, 24);
            this.rbPTZPosOdd.Name = "rbPTZPosOdd";
            this.rbPTZPosOdd.Size = new System.Drawing.Size(57, 25);
            this.rbPTZPosOdd.TabIndex = 81;
            this.rbPTZPosOdd.Text = "Odd";
            this.rbPTZPosOdd.UseVisualStyleBackColor = true;
            this.rbPTZPosOdd.CheckedChanged += new System.EventHandler(this.PTZPos_CheckedChanged);
            // 
            // btnPTZRorate
            // 
            this.btnPTZRorate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPTZRorate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTZRorate.Location = new System.Drawing.Point(15, 147);
            this.btnPTZRorate.Name = "btnPTZRorate";
            this.btnPTZRorate.Size = new System.Drawing.Size(106, 39);
            this.btnPTZRorate.TabIndex = 19;
            this.btnPTZRorate.Text = "Rorate(Face)";
            this.btnPTZRorate.UseVisualStyleBackColor = true;
            this.btnPTZRorate.Click += new System.EventHandler(this.btnPTZRorate_Click);
            // 
            // btnPTZAuto
            // 
            this.btnPTZAuto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPTZAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPTZAuto.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTZAuto.Location = new System.Drawing.Point(15, 192);
            this.btnPTZAuto.Name = "btnPTZAuto";
            this.btnPTZAuto.Size = new System.Drawing.Size(106, 39);
            this.btnPTZAuto.TabIndex = 77;
            this.btnPTZAuto.Text = "Auto";
            this.btnPTZAuto.UseVisualStyleBackColor = false;
            this.btnPTZAuto.Click += new System.EventHandler(this.btnPTZAuto_Click);
            // 
            // groupBox53
            // 
            this.groupBox53.Controls.Add(this.btnCTUReset);
            this.groupBox53.Controls.Add(this.btnCTUInit);
            this.groupBox53.Controls.Add(this.btnCTUAuto);
            this.groupBox53.Controls.Add(this.groupBox54);
            this.groupBox53.Controls.Add(this.groupBox55);
            this.groupBox53.Location = new System.Drawing.Point(7, 304);
            this.groupBox53.Name = "groupBox53";
            this.groupBox53.Size = new System.Drawing.Size(938, 315);
            this.groupBox53.TabIndex = 41;
            this.groupBox53.TabStop = false;
            this.groupBox53.Text = "CTU Area";
            // 
            // btnCTUReset
            // 
            this.btnCTUReset.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnCTUReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUReset.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUReset.ForeColor = System.Drawing.Color.Black;
            this.btnCTUReset.Location = new System.Drawing.Point(378, 103);
            this.btnCTUReset.Name = "btnCTUReset";
            this.btnCTUReset.Size = new System.Drawing.Size(106, 39);
            this.btnCTUReset.TabIndex = 78;
            this.btnCTUReset.Text = "Reset Alarm";
            this.btnCTUReset.UseVisualStyleBackColor = false;
            this.btnCTUReset.Click += new System.EventHandler(this.btnCTUReset_Click);
            // 
            // btnCTUInit
            // 
            this.btnCTUInit.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnCTUInit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUInit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUInit.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnCTUInit.Location = new System.Drawing.Point(378, 58);
            this.btnCTUInit.Name = "btnCTUInit";
            this.btnCTUInit.Size = new System.Drawing.Size(106, 39);
            this.btnCTUInit.TabIndex = 79;
            this.btnCTUInit.Text = "Init";
            this.btnCTUInit.UseVisualStyleBackColor = false;
            // 
            // btnCTUAuto
            // 
            this.btnCTUAuto.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCTUAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUAuto.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUAuto.Location = new System.Drawing.Point(378, 148);
            this.btnCTUAuto.Name = "btnCTUAuto";
            this.btnCTUAuto.Size = new System.Drawing.Size(106, 39);
            this.btnCTUAuto.TabIndex = 77;
            this.btnCTUAuto.Text = "Auto";
            this.btnCTUAuto.UseVisualStyleBackColor = false;
            this.btnCTUAuto.Click += new System.EventHandler(this.btnCTUAuto_Click);
            // 
            // groupBox54
            // 
            this.groupBox54.Controls.Add(this.label82);
            this.groupBox54.Controls.Add(this.btnPTZMoveCTU_2);
            this.groupBox54.Controls.Add(this.btnPTZMoveHome_2);
            this.groupBox54.Controls.Add(this.btnCTUAutoPTZ);
            this.groupBox54.Controls.Add(this.btnCTUPreparePlacePTZ);
            this.groupBox54.Controls.Add(this.btnCTUHome_2);
            this.groupBox54.Controls.Add(this.btnCTUPickPTZ);
            this.groupBox54.Controls.Add(this.btnCTUPlacePTZ);
            this.groupBox54.Controls.Add(this.btnCTUPreparePickPTZ);
            this.groupBox54.Location = new System.Drawing.Point(490, 27);
            this.groupBox54.Name = "groupBox54";
            this.groupBox54.Size = new System.Drawing.Size(357, 282);
            this.groupBox54.TabIndex = 77;
            this.groupBox54.TabStop = false;
            this.groupBox54.Text = "PTZ Access";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.Color.Brown;
            this.label82.Location = new System.Drawing.Point(197, 253);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(147, 15);
            this.label82.TabIndex = 41;
            this.label82.Text = "*: [PTZ] Move motion";
            // 
            // btnPTZMoveCTU_2
            // 
            this.btnPTZMoveCTU_2.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnPTZMoveCTU_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPTZMoveCTU_2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTZMoveCTU_2.ForeColor = System.Drawing.Color.Brown;
            this.btnPTZMoveCTU_2.Location = new System.Drawing.Point(126, 76);
            this.btnPTZMoveCTU_2.Name = "btnPTZMoveCTU_2";
            this.btnPTZMoveCTU_2.Size = new System.Drawing.Size(218, 39);
            this.btnPTZMoveCTU_2.TabIndex = 19;
            this.btnPTZMoveCTU_2.Text = "PTZ Prepare or Transfer(Odd)*";
            this.btnPTZMoveCTU_2.UseVisualStyleBackColor = false;
            this.btnPTZMoveCTU_2.Click += new System.EventHandler(this.btnPTZMoveCTU_Click);
            // 
            // btnPTZMoveHome_2
            // 
            this.btnPTZMoveHome_2.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnPTZMoveHome_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPTZMoveHome_2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTZMoveHome_2.ForeColor = System.Drawing.Color.Brown;
            this.btnPTZMoveHome_2.Location = new System.Drawing.Point(126, 166);
            this.btnPTZMoveHome_2.Name = "btnPTZMoveHome_2";
            this.btnPTZMoveHome_2.Size = new System.Drawing.Size(218, 39);
            this.btnPTZMoveHome_2.TabIndex = 19;
            this.btnPTZMoveHome_2.Text = "PTZ Move Home*";
            this.btnPTZMoveHome_2.UseVisualStyleBackColor = false;
            this.btnPTZMoveHome_2.Click += new System.EventHandler(this.btnPTZMoveHome_Click);
            // 
            // btnCTUAutoPTZ
            // 
            this.btnCTUAutoPTZ.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCTUAutoPTZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUAutoPTZ.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUAutoPTZ.Location = new System.Drawing.Point(14, 31);
            this.btnCTUAutoPTZ.Name = "btnCTUAutoPTZ";
            this.btnCTUAutoPTZ.Size = new System.Drawing.Size(106, 39);
            this.btnCTUAutoPTZ.TabIndex = 77;
            this.btnCTUAutoPTZ.Text = "Auto";
            this.btnCTUAutoPTZ.UseVisualStyleBackColor = false;
            this.btnCTUAutoPTZ.Click += new System.EventHandler(this.btnCTUAutoPTZ_Click);
            // 
            // btnCTUPreparePlacePTZ
            // 
            this.btnCTUPreparePlacePTZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUPreparePlacePTZ.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUPreparePlacePTZ.Location = new System.Drawing.Point(126, 31);
            this.btnCTUPreparePlacePTZ.Name = "btnCTUPreparePlacePTZ";
            this.btnCTUPreparePlacePTZ.Size = new System.Drawing.Size(106, 39);
            this.btnCTUPreparePlacePTZ.TabIndex = 19;
            this.btnCTUPreparePlacePTZ.Text = "Place(Prepare)";
            this.btnCTUPreparePlacePTZ.UseVisualStyleBackColor = true;
            this.btnCTUPreparePlacePTZ.Click += new System.EventHandler(this.btnCTUPreparePlacePTZ_Click);
            // 
            // btnCTUHome_2
            // 
            this.btnCTUHome_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUHome_2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUHome_2.Location = new System.Drawing.Point(126, 211);
            this.btnCTUHome_2.Name = "btnCTUHome_2";
            this.btnCTUHome_2.Size = new System.Drawing.Size(218, 39);
            this.btnCTUHome_2.TabIndex = 19;
            this.btnCTUHome_2.Text = "CTU Move Home";
            this.btnCTUHome_2.UseVisualStyleBackColor = true;
            this.btnCTUHome_2.Click += new System.EventHandler(this.btnCTUHome_Click);
            // 
            // btnCTUPickPTZ
            // 
            this.btnCTUPickPTZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUPickPTZ.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUPickPTZ.Location = new System.Drawing.Point(238, 121);
            this.btnCTUPickPTZ.Name = "btnCTUPickPTZ";
            this.btnCTUPickPTZ.Size = new System.Drawing.Size(106, 39);
            this.btnCTUPickPTZ.TabIndex = 19;
            this.btnCTUPickPTZ.Text = "Pick(Pick)";
            this.btnCTUPickPTZ.UseVisualStyleBackColor = true;
            this.btnCTUPickPTZ.Click += new System.EventHandler(this.btnCTUPickPTZ_Click);
            // 
            // btnCTUPlacePTZ
            // 
            this.btnCTUPlacePTZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUPlacePTZ.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUPlacePTZ.Location = new System.Drawing.Point(126, 121);
            this.btnCTUPlacePTZ.Name = "btnCTUPlacePTZ";
            this.btnCTUPlacePTZ.Size = new System.Drawing.Size(106, 39);
            this.btnCTUPlacePTZ.TabIndex = 19;
            this.btnCTUPlacePTZ.Text = "Place(Place)";
            this.btnCTUPlacePTZ.UseVisualStyleBackColor = true;
            this.btnCTUPlacePTZ.Click += new System.EventHandler(this.btnCTUPlacePTZ_Click);
            // 
            // btnCTUPreparePickPTZ
            // 
            this.btnCTUPreparePickPTZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUPreparePickPTZ.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUPreparePickPTZ.Location = new System.Drawing.Point(238, 31);
            this.btnCTUPreparePickPTZ.Name = "btnCTUPreparePickPTZ";
            this.btnCTUPreparePickPTZ.Size = new System.Drawing.Size(106, 39);
            this.btnCTUPreparePickPTZ.TabIndex = 19;
            this.btnCTUPreparePickPTZ.Text = "Pick(Prepare)";
            this.btnCTUPreparePickPTZ.UseVisualStyleBackColor = true;
            this.btnCTUPreparePickPTZ.Click += new System.EventHandler(this.btnCTUPreparePickPTZ_Click);
            // 
            // groupBox55
            // 
            this.groupBox55.Controls.Add(this.label84);
            this.groupBox55.Controls.Add(this.btnWHRCompPlaceCTU_2);
            this.groupBox55.Controls.Add(this.btnWHRCompPickCTU_2);
            this.groupBox55.Controls.Add(this.btnWHRToPlaceCTU_2);
            this.groupBox55.Controls.Add(this.btnCTUPreparePlaceWHR_2);
            this.groupBox55.Controls.Add(this.btnCTUReleaseWHR_2);
            this.groupBox55.Controls.Add(this.btnWHRToPickCTU_2);
            this.groupBox55.Controls.Add(this.btnCTUHome_1);
            this.groupBox55.Controls.Add(this.btnCTUAutoWHR);
            this.groupBox55.Controls.Add(this.btnCTUGrabWHR_2);
            this.groupBox55.Controls.Add(this.btnCTUPreparePickWHR_2);
            this.groupBox55.Location = new System.Drawing.Point(15, 27);
            this.groupBox55.Name = "groupBox55";
            this.groupBox55.Size = new System.Drawing.Size(357, 282);
            this.groupBox55.TabIndex = 77;
            this.groupBox55.TabStop = false;
            this.groupBox55.Text = "WHR Access";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.ForeColor = System.Drawing.Color.Brown;
            this.label84.Location = new System.Drawing.Point(134, 253);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(210, 15);
            this.label84.TabIndex = 41;
            this.label84.Text = "*: [WHR] Pick or Place motion";
            // 
            // btnWHRCompPlaceCTU_2
            // 
            this.btnWHRCompPlaceCTU_2.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnWHRCompPlaceCTU_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRCompPlaceCTU_2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRCompPlaceCTU_2.ForeColor = System.Drawing.Color.Brown;
            this.btnWHRCompPlaceCTU_2.Location = new System.Drawing.Point(126, 166);
            this.btnWHRCompPlaceCTU_2.Name = "btnWHRCompPlaceCTU_2";
            this.btnWHRCompPlaceCTU_2.Size = new System.Drawing.Size(106, 39);
            this.btnWHRCompPlaceCTU_2.TabIndex = 19;
            this.btnWHRCompPlaceCTU_2.Text = "WHR Complete Place*";
            this.btnWHRCompPlaceCTU_2.UseVisualStyleBackColor = false;
            this.btnWHRCompPlaceCTU_2.Click += new System.EventHandler(this.btnWHRCompPlaceCTU_2_Click);
            // 
            // btnWHRCompPickCTU_2
            // 
            this.btnWHRCompPickCTU_2.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnWHRCompPickCTU_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRCompPickCTU_2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRCompPickCTU_2.ForeColor = System.Drawing.Color.Brown;
            this.btnWHRCompPickCTU_2.Location = new System.Drawing.Point(238, 167);
            this.btnWHRCompPickCTU_2.Name = "btnWHRCompPickCTU_2";
            this.btnWHRCompPickCTU_2.Size = new System.Drawing.Size(106, 39);
            this.btnWHRCompPickCTU_2.TabIndex = 19;
            this.btnWHRCompPickCTU_2.Text = "WHR Complete Pick*";
            this.btnWHRCompPickCTU_2.UseVisualStyleBackColor = false;
            this.btnWHRCompPickCTU_2.Click += new System.EventHandler(this.btnWHRCompPickCTU_2_Click);
            // 
            // btnWHRToPlaceCTU_2
            // 
            this.btnWHRToPlaceCTU_2.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnWHRToPlaceCTU_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRToPlaceCTU_2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRToPlaceCTU_2.ForeColor = System.Drawing.Color.Brown;
            this.btnWHRToPlaceCTU_2.Location = new System.Drawing.Point(126, 76);
            this.btnWHRToPlaceCTU_2.Name = "btnWHRToPlaceCTU_2";
            this.btnWHRToPlaceCTU_2.Size = new System.Drawing.Size(106, 39);
            this.btnWHRToPlaceCTU_2.TabIndex = 19;
            this.btnWHRToPlaceCTU_2.Text = "WHR To Place*";
            this.btnWHRToPlaceCTU_2.UseVisualStyleBackColor = false;
            this.btnWHRToPlaceCTU_2.Click += new System.EventHandler(this.btnWHRToPlaceCTU_2_Click);
            // 
            // btnCTUPreparePlaceWHR_2
            // 
            this.btnCTUPreparePlaceWHR_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUPreparePlaceWHR_2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUPreparePlaceWHR_2.Location = new System.Drawing.Point(238, 31);
            this.btnCTUPreparePlaceWHR_2.Name = "btnCTUPreparePlaceWHR_2";
            this.btnCTUPreparePlaceWHR_2.Size = new System.Drawing.Size(106, 39);
            this.btnCTUPreparePlaceWHR_2.TabIndex = 19;
            this.btnCTUPreparePlaceWHR_2.Text = "Prepare to Place";
            this.btnCTUPreparePlaceWHR_2.UseVisualStyleBackColor = true;
            this.btnCTUPreparePlaceWHR_2.Click += new System.EventHandler(this.btnCTUPreparePlaceWHR_2_Click);
            // 
            // btnCTUReleaseWHR_2
            // 
            this.btnCTUReleaseWHR_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUReleaseWHR_2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUReleaseWHR_2.Location = new System.Drawing.Point(238, 121);
            this.btnCTUReleaseWHR_2.Name = "btnCTUReleaseWHR_2";
            this.btnCTUReleaseWHR_2.Size = new System.Drawing.Size(106, 39);
            this.btnCTUReleaseWHR_2.TabIndex = 19;
            this.btnCTUReleaseWHR_2.Text = "Release";
            this.btnCTUReleaseWHR_2.UseVisualStyleBackColor = true;
            this.btnCTUReleaseWHR_2.Click += new System.EventHandler(this.btnCTUReleaseWHR_2_Click);
            // 
            // btnWHRToPickCTU_2
            // 
            this.btnWHRToPickCTU_2.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnWHRToPickCTU_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHRToPickCTU_2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHRToPickCTU_2.ForeColor = System.Drawing.Color.Brown;
            this.btnWHRToPickCTU_2.Location = new System.Drawing.Point(238, 76);
            this.btnWHRToPickCTU_2.Name = "btnWHRToPickCTU_2";
            this.btnWHRToPickCTU_2.Size = new System.Drawing.Size(106, 39);
            this.btnWHRToPickCTU_2.TabIndex = 19;
            this.btnWHRToPickCTU_2.Text = "WHR To Pick*";
            this.btnWHRToPickCTU_2.UseVisualStyleBackColor = false;
            this.btnWHRToPickCTU_2.Click += new System.EventHandler(this.btnWHRToPickCTU_2_Click);
            // 
            // btnCTUHome_1
            // 
            this.btnCTUHome_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUHome_1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUHome_1.Location = new System.Drawing.Point(126, 211);
            this.btnCTUHome_1.Name = "btnCTUHome_1";
            this.btnCTUHome_1.Size = new System.Drawing.Size(218, 39);
            this.btnCTUHome_1.TabIndex = 19;
            this.btnCTUHome_1.Text = "CTU Move Home";
            this.btnCTUHome_1.UseVisualStyleBackColor = true;
            this.btnCTUHome_1.Click += new System.EventHandler(this.btnCTUHome_Click);
            // 
            // btnCTUAutoWHR
            // 
            this.btnCTUAutoWHR.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCTUAutoWHR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUAutoWHR.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUAutoWHR.Location = new System.Drawing.Point(11, 31);
            this.btnCTUAutoWHR.Name = "btnCTUAutoWHR";
            this.btnCTUAutoWHR.Size = new System.Drawing.Size(106, 39);
            this.btnCTUAutoWHR.TabIndex = 77;
            this.btnCTUAutoWHR.Text = "Auto";
            this.btnCTUAutoWHR.UseVisualStyleBackColor = false;
            this.btnCTUAutoWHR.Click += new System.EventHandler(this.btnCTUAutoWHR_Click);
            // 
            // btnCTUGrabWHR_2
            // 
            this.btnCTUGrabWHR_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUGrabWHR_2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUGrabWHR_2.Location = new System.Drawing.Point(126, 121);
            this.btnCTUGrabWHR_2.Name = "btnCTUGrabWHR_2";
            this.btnCTUGrabWHR_2.Size = new System.Drawing.Size(106, 39);
            this.btnCTUGrabWHR_2.TabIndex = 19;
            this.btnCTUGrabWHR_2.Text = "Grab";
            this.btnCTUGrabWHR_2.UseVisualStyleBackColor = true;
            this.btnCTUGrabWHR_2.Click += new System.EventHandler(this.btnCTUGrabWHR_2_Click);
            // 
            // btnCTUPreparePickWHR_2
            // 
            this.btnCTUPreparePickWHR_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTUPreparePickWHR_2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTUPreparePickWHR_2.Location = new System.Drawing.Point(126, 31);
            this.btnCTUPreparePickWHR_2.Name = "btnCTUPreparePickWHR_2";
            this.btnCTUPreparePickWHR_2.Size = new System.Drawing.Size(106, 39);
            this.btnCTUPreparePickWHR_2.TabIndex = 19;
            this.btnCTUPreparePickWHR_2.Text = "Prepare to Pick";
            this.btnCTUPreparePickWHR_2.UseVisualStyleBackColor = true;
            this.btnCTUPreparePickWHR_2.Click += new System.EventHandler(this.btnCTUPreparePickWHR_2_Click);
            // 
            // tabIO
            // 
            this.tabIO.Location = new System.Drawing.Point(4, 33);
            this.tabIO.Name = "tabIO";
            this.tabIO.Size = new System.Drawing.Size(965, 622);
            this.tabIO.TabIndex = 8;
            this.tabIO.Text = "     IO";
            this.tabIO.UseVisualStyleBackColor = true;
            // 
            // tabMarco
            // 
            this.tabMarco.Controls.Add(this.label3);
            this.tabMarco.Controls.Add(this.cbRoutine);
            this.tabMarco.Controls.Add(this.textBox3);
            this.tabMarco.Controls.Add(this.textBox2);
            this.tabMarco.Controls.Add(this.textBox1);
            this.tabMarco.Controls.Add(this.rbMarcoCTU);
            this.tabMarco.Controls.Add(this.rbMarcoWHR);
            this.tabMarco.Controls.Add(this.rbMarcoSTK);
            this.tabMarco.Controls.Add(this.btnSetMarco);
            this.tabMarco.Controls.Add(this.Load_file);
            this.tabMarco.Location = new System.Drawing.Point(4, 33);
            this.tabMarco.Name = "tabMarco";
            this.tabMarco.Size = new System.Drawing.Size(965, 622);
            this.tabMarco.TabIndex = 9;
            this.tabMarco.Text = "Marco";
            this.tabMarco.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 21);
            this.label3.TabIndex = 90;
            this.label3.Text = "Routine Type";
            // 
            // cbRoutine
            // 
            this.cbRoutine.FormattingEnabled = true;
            this.cbRoutine.Items.AddRange(new object[] {
            "M",
            "S"});
            this.cbRoutine.Location = new System.Drawing.Point(440, 13);
            this.cbRoutine.Name = "cbRoutine";
            this.cbRoutine.Size = new System.Drawing.Size(48, 29);
            this.cbRoutine.TabIndex = 89;
            this.cbRoutine.Text = "M";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox3.Location = new System.Drawing.Point(7, 251);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(938, 33);
            this.textBox3.TabIndex = 88;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox2.Location = new System.Drawing.Point(7, 191);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(938, 33);
            this.textBox2.TabIndex = 87;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(7, 133);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(938, 33);
            this.textBox1.TabIndex = 86;
            // 
            // rbMarcoCTU
            // 
            this.rbMarcoCTU.AutoSize = true;
            this.rbMarcoCTU.Checked = true;
            this.rbMarcoCTU.Font = new System.Drawing.Font("Calibri", 12.75F);
            this.rbMarcoCTU.Location = new System.Drawing.Point(161, 14);
            this.rbMarcoCTU.Name = "rbMarcoCTU";
            this.rbMarcoCTU.Size = new System.Drawing.Size(115, 25);
            this.rbMarcoCTU.TabIndex = 85;
            this.rbMarcoCTU.TabStop = true;
            this.rbMarcoCTU.Text = "CTU and PTZ";
            this.rbMarcoCTU.UseVisualStyleBackColor = true;
            // 
            // rbMarcoWHR
            // 
            this.rbMarcoWHR.AutoSize = true;
            this.rbMarcoWHR.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMarcoWHR.Location = new System.Drawing.Point(92, 14);
            this.rbMarcoWHR.Name = "rbMarcoWHR";
            this.rbMarcoWHR.Size = new System.Drawing.Size(63, 25);
            this.rbMarcoWHR.TabIndex = 84;
            this.rbMarcoWHR.Text = "WHR";
            this.rbMarcoWHR.UseVisualStyleBackColor = true;
            // 
            // rbMarcoSTK
            // 
            this.rbMarcoSTK.AutoSize = true;
            this.rbMarcoSTK.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMarcoSTK.Location = new System.Drawing.Point(7, 14);
            this.rbMarcoSTK.Name = "rbMarcoSTK";
            this.rbMarcoSTK.Size = new System.Drawing.Size(79, 25);
            this.rbMarcoSTK.TabIndex = 83;
            this.rbMarcoSTK.Text = "Stocker";
            this.rbMarcoSTK.UseVisualStyleBackColor = true;
            // 
            // btnSetMarco
            // 
            this.btnSetMarco.Location = new System.Drawing.Point(839, 313);
            this.btnSetMarco.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetMarco.Name = "btnSetMarco";
            this.btnSetMarco.Size = new System.Drawing.Size(106, 50);
            this.btnSetMarco.TabIndex = 2;
            this.btnSetMarco.Text = "Set Marco";
            this.btnSetMarco.UseVisualStyleBackColor = true;
            this.btnSetMarco.Click += new System.EventHandler(this.btnSetMarco_Click);
            // 
            // Load_file
            // 
            this.Load_file.Location = new System.Drawing.Point(7, 62);
            this.Load_file.Margin = new System.Windows.Forms.Padding(2);
            this.Load_file.Name = "Load_file";
            this.Load_file.Size = new System.Drawing.Size(83, 50);
            this.Load_file.TabIndex = 2;
            this.Load_file.Text = "Load file";
            this.Load_file.UseVisualStyleBackColor = true;
            this.Load_file.Click += new System.EventHandler(this.Load_file_Click);
            // 
            // btnClearMsg
            // 
            this.btnClearMsg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearMsg.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearMsg.Location = new System.Drawing.Point(6, 657);
            this.btnClearMsg.Name = "btnClearMsg";
            this.btnClearMsg.Size = new System.Drawing.Size(108, 32);
            this.btnClearMsg.TabIndex = 18;
            this.btnClearMsg.Text = "Clear Message";
            this.btnClearMsg.UseVisualStyleBackColor = true;
            this.btnClearMsg.Click += new System.EventHandler(this.btnClearMsg_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblStatus);
            this.groupBox6.Controls.Add(this.rtbMsg);
            this.groupBox6.Controls.Add(this.btnClearMsg);
            this.groupBox6.Controls.Add(this.btnAbort);
            this.groupBox6.Controls.Add(this.btnRestart);
            this.groupBox6.Controls.Add(this.btnHold);
            this.groupBox6.Location = new System.Drawing.Point(981, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(398, 720);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Message Area";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(10, 424);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 23);
            this.lblStatus.TabIndex = 19;
            // 
            // rtbMsg
            // 
            this.rtbMsg.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMsg.Location = new System.Drawing.Point(6, 56);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.Size = new System.Drawing.Size(385, 595);
            this.rtbMsg.TabIndex = 0;
            this.rtbMsg.Text = "$2SET:RESET\n$2CMD:HOME_\n$2CMD:GET__:pno,slot,arm,al,opt[CR]\n$3CMD:MOVDP:205,10\n$1" +
    "SET:SERVO:1\n$1SET:RESET\n$1CMD:EORG_:6\n";
            this.rtbMsg.WordWrap = false;
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.Red;
            this.btnAbort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAbort.Location = new System.Drawing.Point(202, 17);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(92, 32);
            this.btnAbort.TabIndex = 21;
            this.btnAbort.Text = "ABORT";
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Visible = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.ForestGreen;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestart.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRestart.Location = new System.Drawing.Point(104, 17);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(92, 32);
            this.btnRestart.TabIndex = 21;
            this.btnRestart.Text = "RESTR";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnHold
            // 
            this.btnHold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnHold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHold.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHold.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHold.Location = new System.Drawing.Point(6, 18);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(92, 32);
            this.btnHold.TabIndex = 21;
            this.btnHold.Text = "HOLD";
            this.btnHold.UseVisualStyleBackColor = false;
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 746);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabMode);
            this.Controls.Add(this.groupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WTS Emulator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.tabMode.ResumeLayout(false);
            this.tabSetting.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.tabCmd.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmdScript)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabStocker.ResumeLayout(false);
            this.tabStocker.PerformLayout();
            this.groupBox46.ResumeLayout(false);
            this.groupBox49.ResumeLayout(false);
            this.groupBox48.ResumeLayout(false);
            this.groupBox47.ResumeLayout(false);
            this.groupBox47.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.tabWHR.ResumeLayout(false);
            this.groupBox60.ResumeLayout(false);
            this.groupBox60.PerformLayout();
            this.groupBox50.ResumeLayout(false);
            this.groupBox51.ResumeLayout(false);
            this.groupBox51.PerformLayout();
            this.groupBox52.ResumeLayout(false);
            this.tabCTU_PTZ.ResumeLayout(false);
            this.groupBox61.ResumeLayout(false);
            this.groupBox61.PerformLayout();
            this.groupBox59.ResumeLayout(false);
            this.groupBox59.PerformLayout();
            this.groupBox56.ResumeLayout(false);
            this.groupBox56.PerformLayout();
            this.groupBox58.ResumeLayout(false);
            this.groupBox58.PerformLayout();
            this.groupBox57.ResumeLayout(false);
            this.groupBox57.PerformLayout();
            this.groupBox53.ResumeLayout(false);
            this.groupBox54.ResumeLayout(false);
            this.groupBox54.PerformLayout();
            this.groupBox55.ResumeLayout(false);
            this.groupBox55.PerformLayout();
            this.tabMarco.ResumeLayout(false);
            this.tabMarco.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnDisConn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbHostIP;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label lbl_alarm;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label lbl_ConnectState;
        private System.Windows.Forms.TabControl tabMode;
        private System.Windows.Forms.TabPage tabCmd;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnNewScript;
        private System.Windows.Forms.Button btnStepRun;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTimes;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnScriptStop;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.DataGridView dgvCmdScript;
        private System.Windows.Forms.Button btnScriptRun;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnInitAll;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAddScript;
        private System.Windows.Forms.TextBox tbCmd;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClearMsg;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RichTextBox rtbMsg;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Label tbCtrlCTUIP;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox tbCtrlCTU_IP;
        private System.Windows.Forms.Button btnCtrlCTUCon;
        private System.Windows.Forms.Button btnCtrlCTUDiscon;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox tbCtrlCTU_Port;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btnCtrlWHRCon;
        private System.Windows.Forms.Button btnCtrlWHRDiscon;
        private System.Windows.Forms.TextBox tbCtrlWHR_Port;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCtrlWHR_IP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCtrlSTKCon;
        private System.Windows.Forms.TextBox tbCtrlSTK_Port;
        private System.Windows.Forms.TextBox tbCtrlSTK_IP;
        private System.Windows.Forms.Button btnCtrlSTKDiscon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabStocker;
        private System.Windows.Forms.TabPage tabWHR;
        private System.Windows.Forms.TabPage tabCTU_PTZ;
        private System.Windows.Forms.TabPage tabIO;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Button btnE1Init;
        private System.Windows.Forms.Button btnE1Clamp;
        private System.Windows.Forms.Button btnE1Reset;
        private System.Windows.Forms.Button btnE1MoveOut;
        private System.Windows.Forms.Button btnE1MoveIn;
        private System.Windows.Forms.Button btnE1CloseShutter;
        private System.Windows.Forms.Button btnE1OpenShutter;
        private System.Windows.Forms.Button btnE1ReadID;
        private System.Windows.Forms.Button btnE1UnClamp;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Button btnE2Clamp;
        private System.Windows.Forms.Button btnE2CloseShutter;
        private System.Windows.Forms.Button btnE2OpenShutter;
        private System.Windows.Forms.Button btnE2ReadID;
        private System.Windows.Forms.Button btnE2UnClamp;
        private System.Windows.Forms.Button btnE2Auto;
        private System.Windows.Forms.Button btnE1Auto;
        private System.Windows.Forms.TextBox tbI1Error;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox tbI1SlotMap;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox tbE1Error;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox tbE1RFID;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.Button tbI1Init;
        private System.Windows.Forms.Button btnI1UnLoad;
        private System.Windows.Forms.Button tbI1Reset;
        private System.Windows.Forms.Button btnI1GetSlotMap;
        private System.Windows.Forms.Button btnI1Auto;
        private System.Windows.Forms.Button btnI1Load;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox tbE2RFID;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.TextBox tbI2Error;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Button tbI2Init;
        private System.Windows.Forms.Button btnI2UnLoad;
        private System.Windows.Forms.TextBox tbI2SlotMap;
        private System.Windows.Forms.Button tbI2Reset;
        private System.Windows.Forms.Button btnI2GetSlotMap;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Button btnI2Auto;
        private System.Windows.Forms.Button btnI2Load;
        private System.Windows.Forms.GroupBox groupBox46;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox tbPresELPT2;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.TextBox tbPresShelf9;
        private System.Windows.Forms.TextBox tbPresShelf15;
        private System.Windows.Forms.TextBox tbPresShelf12;
        private System.Windows.Forms.TextBox tbPresShelf6;
        private System.Windows.Forms.TextBox tbPresShelf2;
        private System.Windows.Forms.TextBox tbPresShelf10;
        private System.Windows.Forms.TextBox tbPresShelf16;
        private System.Windows.Forms.TextBox tbPresShelf13;
        private System.Windows.Forms.TextBox tbPresShelf14;
        private System.Windows.Forms.TextBox tbPresShelf8;
        private System.Windows.Forms.TextBox tbPresShelf11;
        private System.Windows.Forms.TextBox tbPresShelf7;
        private System.Windows.Forms.TextBox tbPresShelf4;
        private System.Windows.Forms.TextBox tbPresShelf5;
        private System.Windows.Forms.TextBox tbPresShelf3;
        private System.Windows.Forms.TextBox tbPresShelf1;
        private System.Windows.Forms.TextBox tbPresRobot;
        private System.Windows.Forms.TextBox tbPresILPT2;
        private System.Windows.Forms.TextBox tbPresILPT1;
        private System.Windows.Forms.TextBox tbPresELPT1;
        private System.Windows.Forms.TextBox tbE2Error;
        private System.Windows.Forms.Button btnE2Init;
        private System.Windows.Forms.Button btnE2Reset;
        private System.Windows.Forms.Button btnE2MoveOut;
        private System.Windows.Forms.Button btnE2MoveIn;
        private System.Windows.Forms.GroupBox groupBox47;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.GroupBox groupBox48;
        private System.Windows.Forms.ComboBox cbSource;
        private System.Windows.Forms.Button btnFoupRotPick;
        private System.Windows.Forms.Button btnFoupRotPrePick;
        private System.Windows.Forms.Button btnFoupRotSwitch;
        private System.Windows.Forms.GroupBox groupBox49;
        private System.Windows.Forms.ComboBox cbDestination;
        private System.Windows.Forms.Button btnFoupRotPlace;
        private System.Windows.Forms.Button btnFoupRotPrePlace;
        private System.Windows.Forms.GroupBox groupBox50;
        private System.Windows.Forms.GroupBox groupBox52;
        private System.Windows.Forms.ComboBox cbWHRSelctILPT;
        private System.Windows.Forms.Button btnWHRPickPort;
        private System.Windows.Forms.Button btnWHRUpPort;
        private System.Windows.Forms.Button btnWHRReset;
        private System.Windows.Forms.Button btnWHRInit;
        private System.Windows.Forms.Button btnWHRAuto;
        private System.Windows.Forms.GroupBox groupBox51;
        private System.Windows.Forms.Button btnWHRToPlaceCTU_1;
        private System.Windows.Forms.Button btnWHRCTUAuto;
        private System.Windows.Forms.Button btnWHRRetractPickCTU;
        private System.Windows.Forms.Button btnWHRCompPlaceCTU;
        private System.Windows.Forms.Button btnWHRToPickCTU_1;
        private System.Windows.Forms.Button btnWHRExtendPickCTU;
        private System.Windows.Forms.Button btnWHRCompPickCTU_1;
        private System.Windows.Forms.Button btnWHRPlacePort;
        private System.Windows.Forms.Button btnWHRPortAuto;
        private System.Windows.Forms.Button btnWHRRetractPickPort;
        private System.Windows.Forms.Button btnWHRMovePickPort;
        private System.Windows.Forms.Button btnWHRDownPort;
        private System.Windows.Forms.Button btnWHRExtendPickPort;
        private System.Windows.Forms.Button btnWHRMovePlacePort;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Button btnWHRMovePlaceCTU;
        private System.Windows.Forms.Button btnWHRMovePickCTU;
        private System.Windows.Forms.Button btnCTUGrabWHR_1;
        private System.Windows.Forms.Button btnCTUReleaseWHR_1;
        private System.Windows.Forms.GroupBox groupBox53;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.RadioButton rbCTUPathDirty;
        private System.Windows.Forms.RadioButton rbCTUPathClean;
        private System.Windows.Forms.Button btnCTUReset;
        private System.Windows.Forms.Button btnCTUInit;
        private System.Windows.Forms.Button btnCTUAuto;
        private System.Windows.Forms.GroupBox groupBox54;
        private System.Windows.Forms.Button btnPTZMoveHome_2;
        private System.Windows.Forms.Button btnCTUAutoPTZ;
        private System.Windows.Forms.GroupBox groupBox55;
        private System.Windows.Forms.Button btnCTUAutoWHR;
        private System.Windows.Forms.Button btnCTUPreparePlacePTZ;
        private System.Windows.Forms.Button btnCTUPreparePickPTZ;
        private System.Windows.Forms.Button btnCTUPlacePTZ;
        private System.Windows.Forms.Button btnCTUPickPTZ;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.GroupBox groupBox56;
        private System.Windows.Forms.Button btnPTZRorate;
        private System.Windows.Forms.Button btnPTZMoveHome_1;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Button btnWHRCompPlaceCTU_2;
        private System.Windows.Forms.Button btnWHRCompPickCTU_2;
        private System.Windows.Forms.Button btnWHRToPlaceCTU_2;
        private System.Windows.Forms.Button btnWHRToPickCTU_2;
        private System.Windows.Forms.Button btnCTUPreparePlaceWHR_1;
        private System.Windows.Forms.Button btnCTUPreparePickWHR_1;
        private System.Windows.Forms.GroupBox groupBox59;
        private System.Windows.Forms.GroupBox groupBox58;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.RadioButton rbPTZDirFaceBack;
        private System.Windows.Forms.RadioButton rbPTZDirBackFace;
        private System.Windows.Forms.RadioButton rbPTZDirBack;
        private System.Windows.Forms.RadioButton rbPTZDirFace;
        private System.Windows.Forms.Button btnPTZMoveCTU_1;
        private System.Windows.Forms.GroupBox groupBox57;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.RadioButton rbPTZPosAuto;
        private System.Windows.Forms.RadioButton rbPTZPosEven;
        private System.Windows.Forms.RadioButton rbPTZPosOdd;
        private System.Windows.Forms.Button btnPTZMoveCTU_2;
        private System.Windows.Forms.Button btnCTUPreparePlaceWHR_2;
        private System.Windows.Forms.Button btnCTUReleaseWHR_2;
        private System.Windows.Forms.Button btnCTUGrabWHR_2;
        private System.Windows.Forms.Button btnCTUPreparePickWHR_2;
        private System.Windows.Forms.Button btnPTZReset;
        private System.Windows.Forms.Button btnPTZInit;
        private System.Windows.Forms.GroupBox groupBox60;
        private System.Windows.Forms.RadioButton rbWHRPathDirty;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.RadioButton rbWHRPathClean;
        private System.Windows.Forms.TextBox tbPtzSlotMap;
        private System.Windows.Forms.Button btnPTZGetSlotMap;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Button btnPTZAuto;
        private System.Windows.Forms.GroupBox groupBox61;
        private System.Windows.Forms.TextBox tbDegree;
        private System.Windows.Forms.ToolTip hint;
        private System.Windows.Forms.Button btnAlign;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Button btnSTKRefresh;
        private System.Windows.Forms.Button btnFoupRotAuto;
        private System.Windows.Forms.Button btnFoupRotRetractSrc;
        private System.Windows.Forms.Button btnFoupRotExtendSrc;
        private System.Windows.Forms.Button btnFoupRotUpSrc;
        private System.Windows.Forms.Button btnFoupRotExtendDest;
        private System.Windows.Forms.Button btnFoupRotRetractDest;
        private System.Windows.Forms.Button btnFoupRotRelease;
        private System.Windows.Forms.Button btnFoupRotDownDest;
        private System.Windows.Forms.Button btnFoupRotGrab;
        private System.Windows.Forms.Button btnFoupRotHome;
        private System.Windows.Forms.Button btnWHRExtendPlacePort;
        private System.Windows.Forms.Button btnWHRRetractPlacePort;
        private System.Windows.Forms.Button btnWHRHome;
        private System.Windows.Forms.Button btnWHRRetractPlaceCTU;
        private System.Windows.Forms.Button btnWHRExtendPlaceCTU;
        private System.Windows.Forms.Button btnCTUHome_1;
        private System.Windows.Forms.Button btnSTKServoOn;
        private System.Windows.Forms.TabPage tabMarco;
        private System.Windows.Forms.RadioButton rbMarcoCTU;
        private System.Windows.Forms.RadioButton rbMarcoWHR;
        private System.Windows.Forms.RadioButton rbMarcoSTK;
        private System.Windows.Forms.Button Load_file;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSetMarco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRoutine;
        private System.Windows.Forms.Button btnCTUHome_2;
    }
}

