using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Core.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NakaEngine.Core.Loaders
{
    public class AssetLoader : ILoadable
    {
        private static readonly Dictionary<string, object> assets = new();

        public void Load() 
        {
            NakaEngine.Instance.Logger.Log("Loading assets...");

            string path = NakaEngine.Instance.Content.RootDirectory;

            LoadAllAssets<Effect>(path, ".xnb");
            LoadAllAssets<Texture2D>(path, ".png");
            LoadAllAssets<SoundEffect>(path, ".wav");

            NakaEngine.Instance.Logger.Log($"All assets found have been loaded!"); 
        }

        private static void LoadAllAssets<T>(string path, params string[] extensions) where T : class
        {
            if (!Directory.Exists(path))
            {
                return;
            }

            string[] directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

            foreach (string directory in directories)
            {
                string[] files = Directory.GetFiles(directory);

                foreach (string file in files.Where(file => extensions.Any(element => file.EndsWith(element))))
                {
                    LoadAsset<T>(file);
                }
            }

            string[] rootFiles = Directory.GetFiles(path);

            foreach (string file in rootFiles.Where(file => extensions.Any(element => file.EndsWith(element))))
            {
                LoadAsset<T>(file);
            }
        }

        private static void LoadAsset<T>(string path) where T : class
        {
            string key = path[(path.IndexOf(Path.DirectorySeparatorChar) + 1)..]; 
            key = Path.ChangeExtension(key, null).Replace(Path.DirectorySeparatorChar, '/'); 

            if (!assets.ContainsKey(key))
            {
                T asset = NakaEngine.Instance.Content.Load<T>(key);

                assets.Add(key, asset);
                
                NakaEngine.Instance.Logger.Log($"Asset loaded: key: {key}, type: {typeof(T).Name}"); 
            }
        }

        public static T GetAsset<T>(string path) where T : class => assets[path] as T;
    }
}
