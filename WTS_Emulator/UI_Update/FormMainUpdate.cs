using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTS_Emulator.UI_Update
{
    class FormMainUpdate
    {

        public static Boolean isAlarmSet = false;
        delegate void UpdateLog(string msg);
        delegate void UpdateAlarm(Boolean isAlarm);
        delegate void UpdateBtnEnable(Boolean isRun);
        delegate void MessageShow(string msg);
        delegate void EnableForm(string formName, Boolean enable);
        delegate void ClearMsg(string formName, string tboxName);
        delegate void ChgRunTab(int index);
        delegate void RefreshScript();
        delegate void AddScript(string cmd);


        public static void addScriptCmd(string cmd)
        {
            Form form = Application.OpenForms["FormMain"];
            if (form == null)
                return;

            if (form.InvokeRequired)
            {
                AddScript ph = new AddScript(addScriptCmd);
                form.BeginInvoke(ph, cmd);
            }
            else
            {
                int seq = Command.oCmdScript.Count + 1;
                Command.oCmdScript.Add(new CmdScript { Seq = seq, Command = cmd });
            }
        }

        public static void refreshScriptSet()
        {
            Form form = Application.OpenForms["FormMain"];
            DataGridView dgvCmdScript = form.Controls.Find("dgvCmdScript", true).FirstOrDefault() as DataGridView;
            if (form == null)
                return;

            if (form.InvokeRequired)
            {
                RefreshScript ph = new RefreshScript(refreshScriptSet);
                form.BeginInvoke(ph);
            }
            else
            {
                dgvCmdScript.DataSource = Command.oCmdScript;
                if (dgvCmdScript.RowCount > 0)
                {
                    dgvCmdScript.Columns[0].Width = 50;
                    dgvCmdScript.Columns[1].Width = 700;
                }
            }
        }

        public static void ChangeRunTab(int index)
        {
            Form form = Application.OpenForms["FormMain"];
            TabControl tab = form.Controls.Find("tabMode", true).FirstOrDefault() as TabControl; 
            if (form == null)
                return;

            if (form.InvokeRequired)
            {
                ChgRunTab ph = new ChgRunTab(ChangeRunTab);
                form.BeginInvoke(ph, index);
            }
            else
            {
                tab.SelectedIndex = index;
            }
        }

        public static void SetTextBoxEmpty(string formName, string tboxName)
        {
            Form form = Application.OpenForms[formName];
            if (form == null)
                return;

            if (form.InvokeRequired)
            {
                ClearMsg ph = new ClearMsg(SetTextBoxEmpty);
                form.BeginInvoke(ph, formName, tboxName);
            }
            else
            {
                RichTextBox btnUp = form.Controls.Find(tboxName, true).FirstOrDefault() as RichTextBox;
                btnUp.Text = "";
            }
        }
        public static void SetFormEnable(string formName, Boolean enable)
        {
            Form form = Application.OpenForms[formName];
            if (form == null)
                return;

            if (form.InvokeRequired)
            {
                EnableForm ph = new EnableForm(SetFormEnable);
                form.BeginInvoke(ph, formName, enable);
            }
            else
            {
                form.Enabled = enable;
            }

        }

        public static void ShowMessage(string msg)
        {
            Form form = Application.OpenForms["FormMain"];
            if (form == null)
                return;

            if (form.InvokeRequired)
            {
                MessageShow ph = new MessageShow(ShowMessage);
                form.BeginInvoke(ph, msg);
            }
            else
            {
                MessageBox.Show(form, msg);
            }

        }

        public static void SetRunBtnEnable(Boolean isRun)
        {
            Form form = Application.OpenForms["FormMain"];
            if (form == null)
                return;
            Button btnScriptRun = form.Controls.Find("btnScriptRun", true).FirstOrDefault() as Button;
            Button btnDel = form.Controls.Find("btnDel", true).FirstOrDefault() as Button;
            Button btnUp = form.Controls.Find("btnUp", true).FirstOrDefault() as Button;
            Button btnDown = form.Controls.Find("btnDown", true).FirstOrDefault() as Button;
            Button btnStepRun = form.Controls.Find("btnStepRun", true).FirstOrDefault() as Button;
            Button btnImport = form.Controls.Find("btnImport", true).FirstOrDefault() as Button;
            Button btnExport = form.Controls.Find("btnExport", true).FirstOrDefault() as Button;
            Button btnSend = form.Controls.Find("btnSend", true).FirstOrDefault() as Button;
            Button btnAddScript = form.Controls.Find("btnAddScript", true).FirstOrDefault() as Button;
            Button btnNewScript = form.Controls.Find("btnNewScript", true).FirstOrDefault() as Button;

            if (form.InvokeRequired)
            {
                UpdateBtnEnable ph = new UpdateBtnEnable(SetRunBtnEnable);
                form.BeginInvoke(ph, isRun);
            }
            else
            {
                btnScriptRun.Enabled = !isRun;
                btnDel.Enabled = !isRun;
                btnUp.Enabled = !isRun;
                btnDown.Enabled = !isRun;
                btnStepRun.Enabled = !isRun;
                btnImport.Enabled = !isRun;
                btnExport.Enabled = !isRun;
                btnSend.Enabled = !isRun;
                btnAddScript.Enabled = !isRun;
                btnNewScript.Enabled = !isRun;
            }

        }

        public static void AlarmUpdate(Boolean isAlarm)
        {
            string status = isAlarm ? "Alarm set" : "Alarm clear";
            Form form = Application.OpenForms["FormMain"];
            if (form == null)
                return;
            Label W = form.Controls.Find("lbl_alarm", true).FirstOrDefault() as Label;
            Button btnReset = form.Controls.Find("btnReset", true).FirstOrDefault() as Button;
            Button btnHold = form.Controls.Find("btnHold", true).FirstOrDefault() as Button;
            Button btnAbort = form.Controls.Find("btnAbort", true).FirstOrDefault() as Button;
            Button btnRestart = form.Controls.Find("btnRestart", true).FirstOrDefault() as Button;

            if (W == null)
                return;

            if (W.InvokeRequired)
            {
                UpdateAlarm ph = new UpdateAlarm(AlarmUpdate);
                W.BeginInvoke(ph, isAlarm);
            }
            else
            {
                W.Text = status;
                switch (status)
                {
                    case "Alarm clear":
                        W.BackColor = Color.LimeGreen;
                        //btnReset.Enabled = false; //20180914 change to  always open
                        isAlarmSet = false;
                        btnHold.Visible = true;
                        btnAbort.Visible = false;
                        btnRestart.Visible = false;
                        break;
                    case "Alarm set":
                        W.BackColor = Color.Red;
                        //btnReset.Enabled = true; //20180914 change to  always open
                        isAlarmSet = true;
                        break;
                }
            }
        }

        public static void ConnectUpdate(string state)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];
                Label W;
                if (form == null)
                    return;

                W = form.Controls.Find("lbl_ConnectState", true).FirstOrDefault() as Label;
                Button btnDisConn = form.Controls.Find("btnDisConn", true).FirstOrDefault() as Button;
                Button btnConn = form.Controls.Find("btnConn", true).FirstOrDefault() as Button;
                if (W == null)
                    return;

                if (W.InvokeRequired)
                {
                    UpdateLog ph = new UpdateLog(ConnectUpdate);
                    W.BeginInvoke(ph, state);
                }
                else
                {
                    W.Text = state;
                    switch (state)
                    {
                        case "Connected":
                            W.BackColor = Color.LimeGreen;
                            btnConn.Enabled = false;
                            btnDisConn.Enabled = true;
                            break;
                        case "Disconnected":
                            W.BackColor = Color.Gray;
                            btnConn.Enabled = true;
                            btnDisConn.Enabled = false;
                            break;
                        case "Connection_Error":
                            W.BackColor = Color.Red;
                            btnConn.Enabled = true;
                            btnDisConn.Enabled = false;
                            break;
                        case "Connecting":
                            W.BackColor = Color.Yellow;
                            btnConn.Enabled = false;
                            btnDisConn.Enabled = false;
                            break;
                    }

                }
            }
            catch
            {

            }
        }

        public static void LogUpdate(string msg)
        {
            try
            {
                Form form = Application.OpenForms["FormMain"];
                RichTextBox W;
                TabControl tabMode;
                if (form == null)
                    return;

                W = form.Controls.Find("rtbMsg", true).FirstOrDefault() as RichTextBox;
                tabMode = form.Controls.Find("tabMode", true).FirstOrDefault() as TabControl;

                if (W == null)
                    return;

                if (W.InvokeRequired)
                {
                    UpdateLog ph = new UpdateLog(LogUpdate);
                    W.BeginInvoke(ph, msg);
                }
                else
                {
                    W.AppendText(msg + "\n");
                    //if (W.Text.Length > 1000)
                    //{
                    //    W.Text = W.Text.Substring(W.Text.Length - 1000);
                    //}
                    if (W.Lines.Length > 1000)
                    {
                        W.Select(0, W.GetFirstCharIndexFromLine(W.Lines.Length - 1000));
                        W.SelectedText = "";
                    }
                    W.ScrollToCaret();
                    //if (tabMode.SelectedIndex != 0)
                    //    tabMode.SelectedIndex = 0;
                }
            }
            catch
            {

            }
        }

        public static void Update_IO(string key,string val)
        {
            Form form = Application.OpenForms["FormMain"];
            Label signal = form.Controls.Find(key, true).FirstOrDefault() as Label;
            if (form == null)
                return;

            if (signal.InvokeRequired)
            {
                ClearMsg ph = new ClearMsg(Update_IO);
                signal.BeginInvoke(ph,key,val);
            }
            else
            {
                if (val.Equals("1"))
                {
                    signal.ForeColor = Color.LimeGreen;
                }
                else
                {
                    signal.ForeColor = Color.Red;
                }
            }
        }
    }
}
