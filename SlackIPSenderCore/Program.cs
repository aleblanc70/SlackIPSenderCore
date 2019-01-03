using System;
using System.Linq;
using System.Net;
using System.Threading;
using ServiceStack;
using ServiceStack.Logging;
using ServiceStack.Logging.Slack;
using ServiceStack.Text;

namespace SlackIPSenderCore
{
    class Program
    {
        private static ILogFactory logFactory;

        static void Main(string[] args)
        {

            InitLog();
            ILog log = LogManager.GetLogger(typeof(Program));

            string hostName = Dns.GetHostName(); // Retrive the Name of HOST

            // Get the IP
            var myIPs = Dns.GetHostEntry(hostName).AddressList;
            var json = myIPs.Select(ip => ip.ToString()).ToJson().IndentJson();
            log.InfoFormat("Here is my My Last IP Adresses: {0} {1} {0} Delivered On: {2} ", Environment.NewLine, json, DateTime.UtcNow.ToString("R"));
            Thread.Sleep(1000);
        }

        private static void InitLog()
        {
                                                          
            LogManager.LogFactory =  new SlackLogFactory("https://hooks.slack.com/services/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", debugEnabled: false)
            {
                //Alternate default channel than one specified when creating Incoming Webhook.
                DefaultChannel = "#notification-log",
                //Custom channel for Fatal logs. Warn, Info etc will fallback to DefaultChannel or 
                //channel specified when Incoming Webhook was created.
                //FatalChannel = "#fatal-log",
                //Custom bot username other than default
                //BotUsername = "Guybrush Threepwood",
                //Custom channel prefix can be provided to help filter logs from different users or environments. 
                ChannelPrefix = "RPi"
            };
        }
    }
}
