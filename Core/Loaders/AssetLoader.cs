using System.Collections.Generic;

namespace NakaEngine.Core.Loaders
{
    public abstract class AssetLoader<T> where T : class
    {
        public virtual string FileExtension => string.Empty;

        public static Dictionary<string, T> Assets;

        public static T GetAsset(string path) => Assets[path];
    }
}
