using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CompareSystemVersion
{
    class Program
    {
        static  void Main(string[] args)
        {
            var systems = new SystemSvc.SSOSystemClient().GetAllSystems();

            Console.Write("SysCode".PadRight(10, ' ') );
            Console.Write("work".PadRight(15, ' '));
            Console.Write("crm-dev".PadRight(14, ' '));
            Console.WriteLine();

            foreach (var system in systems.OrderBy(s=>s.Code))
            {
                Console.Write(system.Code.PadRight(10,' ') + ":");

                var version1 = downloadVersionFile(system.HostUrl.Replace("crm-dev", "work")).Replace("\n", "").Replace("\r", "");
                Console.Write(version1.PadRight(14, ' '));

                var version2 = downloadVersionFile(system.HostUrl).Replace("\n", "").Replace("\r", "");
                Console.Write(version2.PadRight(14, ' '));

                if(version1 == version2)
                {
                    Console.Write("最新".PadRight(14, ' '));
                }
                else
                {
                    Console.Write("已更新".PadRight(14, ' '));
                }

                Console.WriteLine();
            }
            Console.Read();
        }
        static string downloadVersionFile(string systemPath)
        {
            try
            {
                var path = systemPath + "/version/build.txt";
                var result = new WebClient().DownloadString(path);
                return result;
            }
            catch (Exception ex)
            {
                return "Error";
                throw;
            }
        }

    }
}
