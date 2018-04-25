using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    class Program
    {
        object l = 1;
        static void Main(string[] args)
        {
            sendEmail(25);
            Console.ReadLine();
        }
        static void sendEmail(int port)
        {
            try
            {
                string fromUser = "notice@itcgb.cn";
                string password = "QuShiDa20170421";
                string address = "smtpdm.aliyun.com";
                //创建MailMessage对象    //在ASP.NET利用本机的SMTP虚拟服务器的SMTP来发送邮件     
                MailMessage Msg = new MailMessage();//        
                Msg.From = new MailAddress("\"通知测试\"<" + fromUser + ">");
                Msg.To.Add("zhangqingguang@gsail.net");
                Msg.Subject = "端口号是" + port; //邮件的主题
                Msg.IsBodyHtml = true; //指示邮件正文是否采用HTML文件格式.
                Msg.Body = ""; //邮件内容
                SmtpClient objEmail = new SmtpClient(address); //SMTP服务器主机名，比如GMail的smtp.gmail.com
                objEmail.UseDefaultCredentials = false;
                objEmail.Credentials = new NetworkCredential(fromUser, password);
                objEmail.EnableSsl = true; //是否启用加密连接，GMail的邮箱必须用加密，其他不支持的邮箱用false
                objEmail.Port = port;

                objEmail.Send(Msg);
                Console.WriteLine("Success：" + port);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fault：" + port+"，"+ex.Message);
            }
        }
    }
}
