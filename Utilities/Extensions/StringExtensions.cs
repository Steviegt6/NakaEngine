using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace NakaEngine.Utilities.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex SplitPattern = new("(?<!^)(?=[A-Z])", RegexOptions.Compiled);

        /// <summary>
        /// Splits a string with a upper case letter pattern, PascalCase to Pascal Case.
        /// </summary>
        public static string SplitPascalCase(this string input) => input.Any(char.IsUpper) ? string.Join(" ", SplitPattern) : input;

        /// <summary>
        /// Returns an array of all directories inside a directory.
        /// </summary>
        public static string[] GetAllDirectories(this string path, string pattern = "*") => Directory.GetDirectories(path, pattern, SearchOption.AllDirectories);
    }
}
