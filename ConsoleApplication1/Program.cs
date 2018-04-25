using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            int i = 0;
            if (i > 26)
            {
                str=(char)((i / 26) + 64) +""+ (char)(i % 26 + 65);
            }else
            {
                str = ""+(char)(i + 65);
            }
            Console.WriteLine(str);
            Console.Read();
            
        }
    }
}
