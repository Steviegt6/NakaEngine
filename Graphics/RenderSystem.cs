using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Interfaces;
using NakaEngine.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace NakaEngine.Graphics
{
    public sealed class RenderSystem : ILoadable
    {
        public static List<RenderLayer> Layers
        {
            get;
            private set;
        } = new();

        public void Load()
        {
            Layers.Add(new RenderLayer("Backgrounds", DrawUtils.ScreenWidth, DrawUtils.ScreenHeight));
            Layers.Add(new RenderLayer("Entities", DrawUtils.ScreenWidth, DrawUtils.ScreenHeight));
        }

        public void Unload() => Layers.Clear();

        internal static void Render(SpriteBatch spriteBatch)
        {
            foreach (RenderLayer layer in Layers) 
            {
                layer.Draw(spriteBatch.GraphicsDevice, spriteBatch);
            }

            spriteBatch.GraphicsDevice.SetRenderTarget(null);

            foreach (RenderLayer layer in Layers) 
            {
                spriteBatch.Begin();

                spriteBatch.Draw(layer.RenderTarget, Vector2.Zero, Color.White);

                spriteBatch.End();
            }
        }

        internal static void Reset()
        {
            foreach (RenderLayer layer in Layers)
            {
                layer.ResetRenderTarget();
            }
        }

        public static RenderLayer GetLayer(string name) => Layers.FirstOrDefault(layer => layer.Name == name);
    }
}
