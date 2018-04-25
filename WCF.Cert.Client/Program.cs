using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Cert.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            //wsHttpBinding();

            //baseHttpBinding();

            defaultClient();

            Console.Read();
        }
        static void defaultClient()
        {
            try
            {
                var client = new LogSvc.LoggerClient();

                client.ClientCredentials.UserName.UserName = "admin";
                client.ClientCredentials.UserName.Password = "password01!";
                client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                         System.ServiceModel.Security.X509CertificateValidationMode.None;

                client.Log("", LogSvc.LogType.Info, 1, "1", "证书测试", "证书测试", null, null);
                Console.WriteLine("defaultClient 测试成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine("defaultClient 测试失败");
            }

        }
        static void baseHttpBinding()
        {
            try
            {
                var endpoint = new EndpointAddress("https://crm-dev.itcgb.cn/Log/Logger.svc");

                var binding = new BasicHttpBinding();

                var client = new LogSvc.LoggerClient();

                client.ClientCredentials.UserName.UserName = "admin";
                client.ClientCredentials.UserName.Password = "password01!";
                client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                         System.ServiceModel.Security.X509CertificateValidationMode.None;

                client.Log("", LogSvc.LogType.Info, 1, "1", "证书测试", "证书测试", null, null);
                Console.WriteLine("baseHttpBinding 测试成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine("baseHttpBinding 测试失败");
            }
        }
        static void wsHttpBinding()
        {
            try
            {
                var ServiceendPoint = new EndpointAddress(new Uri("https://crm-dev.itcgb.cn/Log/Logger.svc"));

                var binding = new WSHttpBinding("wsHttpBinding");
                //binding.Security.Mode = SecurityMode.Message;
                binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

                var client = new LogSvc.LoggerClient(binding, ServiceendPoint);

                //client.Endpoint.Binding.MessageVersion

                client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
                client.ClientCredentials.UserName.UserName = "admin";
                client.ClientCredentials.UserName.Password = "password01!";

                client.Log("", LogSvc.LogType.Info, 1, "1", "证书测试", "证书测试", null, null);
                Console.WriteLine("wsHttpBinding 测试成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine("wsHttpBinding 测试失败");
            }
        }
    }
}
