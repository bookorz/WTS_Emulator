using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTS_Emulator
{
    class TakeTimeInfo
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(TakeTimeInfo));
        private int loop_cnt;
        private string script_desc;
        private string file_name;
        private string date;
        private string time;
        private int step_cnt;
        public scripStepInfo[] records;

        public TakeTimeInfo(string script_desc, int loop_cnt, int step_cnt)
        {
            this.script_desc = script_desc;
            this.loop_cnt = loop_cnt;
            this.step_cnt = step_cnt;
            this.date = System.DateTime.Now.ToString("yyyyMMdd");
            this.time = System.DateTime.Now.ToString("HHmmss");
            records = new scripStepInfo[step_cnt];
        }
        public void Save(int current_cnt)
        {
            try
            {
                this.file_name = time + "_Run_" + loop_cnt  + "_" + current_cnt  + ".csv";
                this.file_name = !this.script_desc.Trim().Equals("") ? script_desc + "_" + this.file_name : this.file_name;
                //string fullPath = @"d:\log\foup\" + file_name;
                string path = "./log/wts/".Replace("\\", "/");
                path = path.EndsWith("/") ? path : path + "/";
                string fullPath = path + "/" + date + "/" + file_name;
                FileInfo fi = new FileInfo(fullPath);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                string data = "";
                //寫出列名稱
                data = "seq,cmd,cmd_start_time,cmd_end_time,duration";
                sw.WriteLine(data);
                //寫出各行數據
                for (int i = 0; i < records.Length; i++)
                {
                    if (records[i] == null)
                    {
                        continue;
                    }
                    data = "";
                    string[] column = records[i].getData();
                    for (int j = 0; j < column.Length; j++)
                    {
                        string str = column[j] == null ? "" : column[j].ToString();
                        str = string.Format("\"{0}\"", str).Replace("\r", "\\r").Replace("\n", "\\n");
                        str = str.StartsWith("\"'") ? str.Replace("\"'", "=\"") : str;//當內容為 ' 開頭 , 變為 ="xxx" , 例如日期
                        data += str;
                        data += ",";
                    }
                    data = data.Substring(0, data.Length - 1);//去掉最後  ;
                    sw.WriteLine(data);
                }
                sw.Close();
                fs.Close();
                //Process.Start(fullPath);打開檔案
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }
        }
    }
    public class scripStepInfo
    {
        int seq;
        string cmd = "";
        DateTime cmd_start_time ;
        DateTime cmd_end_time ;
        string duration = "";

        public string[] getData()
        {
            return new string[] { seq.ToString(), cmd, "'" + cmd_start_time.ToString("yyyy-MM-dd HH:mm:ss.fff"), "'" + cmd_end_time.ToString("yyyy-MM-dd HH:mm:ss.fff"), duration };
        }
        public scripStepInfo(int seq, string cmd)
        {
            this.seq = seq;
            this.cmd = cmd;
        }

        public void SetStartTime(DateTime timeStamp)
        {
            //this.cmd_start_time = timeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
            this.cmd_start_time = timeStamp;
        }
        public void SetEndTime(DateTime timeStamp)
        {
            //this.cmd_end_time = timeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
            this.cmd_end_time = timeStamp;
            TimeSpan ts = cmd_end_time - cmd_start_time;
            this.duration = Math.Round(ts.TotalSeconds, 3).ToString();
        }
    }
}
