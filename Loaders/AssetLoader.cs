using NakaEngine.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NakaEngine.Loaders
{
    public sealed class AssetLoader<T> where T : class
    {
        private static Dictionary<string, T> assets = new();

        private readonly string[] fileExtensions;

        public AssetLoader(params string[] fileExtensions) => this.fileExtensions = fileExtensions;

        public void Load(string path)
        {
            LoadAssets(path);

            string[] subDirectories = path.GetAllDirectories();
            
            foreach (string subDirectory in subDirectories)
            {
                LoadAssets(subDirectory);
            }
        }

        private void LoadAssets(string path)
        {
            string[] files = Directory.GetFiles(path);

            foreach (string file in files.Where(file => fileExtensions.Any(element => file.EndsWith(element))))
            {
                string key = GetFileKey(file);

                T asset = NakaEngine.Instance.Content.Load<T>(key);

                if (!assets.ContainsKey(key))
                {
                    assets.Add(key, asset);

                    Console.WriteLine($"Asset loaded with key: {key} with type: {typeof(T).Name}");
                }
            }
        }

        public static T GetAsset(string path) => assets[path];

        private static string GetFileKey(string path)
        {
            string key = path[(path.IndexOf(Path.DirectorySeparatorChar) + 1)..];

            key = Path.ChangeExtension(key, null);
            key = key.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            return key;
        }
    }
}
