using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Loaders;
using NakaEngine.Utilities;
using NakaEngine.Utilities.Extensions;

namespace NakaEngine.Graphics
{
    public sealed class RenderLayer
    {
        public string Name
        {
            get;
            private set;
        }

        public RenderTarget2D RenderTarget
        {
            get;
            private set;
        }

        public SpriteSortMode SpriteSortMode
        {
            get;
            private set;
        }

        public BlendState BlendState 
        {
            get;
            private set;
        }

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public RenderLayer(string name, int width, int height)
        {
            Name = name;

            Width = width;
            Height = height;

            SpriteSortMode = SpriteSortMode.Deferred;
            BlendState = BlendState.AlphaBlend;

            RenderTarget = new RenderTarget2D(NakaEngine.Instance.GraphicsDevice, width, height);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = TextureLoader.GetTexture("Miscellaneous/MissingTexture");

            Vector2 offset = new(Name == "Tiles" ? 20f : 40f, 0f);
            Vector2 position = DrawUtils.ScreenCenter - texture.GetCenter();

            spriteBatch.Draw(texture, position + offset, Color.White);
        }
    }
}
