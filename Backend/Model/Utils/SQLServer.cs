using System.Text.RegularExpressions;

namespace Model.Utils
{
    public class SQLServer
    {
        public static string MySQLEscape(string str)
        {
            return Regex.Replace(str, @"[\x00'""\b\n\r\t\cZ\\%_]",
                delegate (Match match)
                {
                    string v = match.Value;
                    switch (v)
                    {
                        case "\x00":
                            return "\\0";
                        case "\b":
                            return "\\b";
                        case "\n":
                            return "\\n";
                        case "\r":
                            return "\\t";
                        case "\u001A":
                            return "\\Z";
                        default:
                            return "\\" + v;
                    }
                });
        }
    }
}