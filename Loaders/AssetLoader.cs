using System.Collections.Generic;
using System.IO;

namespace NakaEngine.Loaders
{
    public abstract class AssetLoader<T> where T : class
    {
        public virtual string FileExtension => string.Empty;

        public static Dictionary<string, T> Assets
        {
            get;
            protected set;
        } = new();

        public string GetFileKey(string path)
        {
            string key = path[(path.IndexOf(Path.DirectorySeparatorChar) + 1)..];

            key = Path.ChangeExtension(key, null);
            key = key.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            return key;
        }
    }
}
