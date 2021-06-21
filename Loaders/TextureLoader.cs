using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NakaEngine.Loaders
{
    public class TextureLoader : AssetLoader<Texture2D>, ILoadable
    {
        public override string FileExtension => ".png";

        public void Load()
        {
            Assets = new Dictionary<string, Texture2D>();

            LoadAllTextures(NakaEngine.Instance.Content.RootDirectory);

            string[] subDirectories = Directory.GetDirectories(NakaEngine.Instance.Content.RootDirectory);

            foreach (string subDirectory in subDirectories)
            {
                LoadAllTextures(subDirectory);
            }
        }

        public void Unload() => Assets.Clear();

        internal void LoadAllTextures(string path)
        {
            string[] files = Directory.GetFiles(path);

            foreach (string file in files.Where(x => x.EndsWith(FileExtension)))
            {
                LoadTexture(file, GetFileKey(file));
            }
        }

        internal static void LoadTexture(string path, string key)
        {
            Stream stream = TitleContainer.OpenStream(path);
            Texture2D texture = Texture2D.FromStream(NakaEngine.Instance.GraphicsDevice, stream);

            if (!Assets.ContainsKey(key))
            {
                Assets.Add(key, texture);
            }
        }
    }
}
