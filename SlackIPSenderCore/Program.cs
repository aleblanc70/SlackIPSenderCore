using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace SlackIPSenderCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //InitLog();
            //ILog log = LogManager.GetLogger(typeof(Program));

            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            // Get the IP
            var myIPs = Dns.GetHostEntry(hostName).AddressList;
            var ips = myIPs.Select(ii => ii.ToString());


            var nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var adapter in nics)
            {
                var physicalAddress = adapter.GetPhysicalAddress();
                var description = adapter.Description;
               Console.WriteLine(physicalAddress + "   " + description);
            }
            var properties = IPGlobalProperties.GetIPGlobalProperties();
            var connections = properties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation information in connections)
            {
                var localEndPoint = information.LocalEndPoint;
                Console.WriteLine(localEndPoint);
            }

            //curl - X POST - H 'Content-type: application/json'--data '{"text":"Hello, World!"}' https://hooks.slack.com/services/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

            string ip = String.Empty;
            foreach (var item in ips.ToList())
            {
                ip = ip + " -> " + item;
            }

            foreach (IPAddress ipAddress in myIPs)
            {
                if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    ip = ip + " ( " + ipAddress + " ) ";
                }
            }




            string webhookUrl = @"https://hooks.slack.com/services/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";
            string text = string.Format("Here is my My Last IP Adresses: {0} {1} {0} Delivered On: {2} ", Environment.NewLine, ip, DateTime.UtcNow.ToString("R"));
            string channelName = "#notification-log";
            Slack.Net.Message message = new Slack.Net.Message(webhookUrl, text, channelName);
            //message.Send();
            Console.WriteLine(text);
            Console.ReadKey();
            //Thread.Sleep(1000);
        }
    }
}
