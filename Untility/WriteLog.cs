using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Untility
{
    public static class WriteLog
    {
        public static void WriteToFile(string log)
        {
            try
            {
                string date = DateTime.Now.ToString("yyyyMMdd");
                string path = @"D:\\HEBScreenSearchWebApiLog-" + date + ".txt";
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(log);
                    sw.WriteLine('\n');
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteToFile(string.Format("日志文件写入异常-异常信息：{0},{1}", ex.Message.ToString(), DateTime.Now.ToString("yyyy-MM-DD HH:mm:ss")));
                throw;
            }
        }
    }
}
