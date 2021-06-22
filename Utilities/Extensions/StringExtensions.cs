using System.IO;

namespace NakaEngine.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string[] GetAllDirectories(this string path, string pattern = "*") => Directory.GetDirectories(path, pattern, SearchOption.AllDirectories);
    }
}
