using LogTest.LogSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogTest
{
    public class LogMag
    {
        public static void LogInfo()
        {
            LoggerClient client = new LoggerClient();



            client.Log("", LogType.Info, 1, "zhangqingguang", "证书测试", "证书测试", null, null);
        }
    }
}
