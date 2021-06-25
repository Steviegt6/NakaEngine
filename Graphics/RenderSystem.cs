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
        private static readonly List<RenderLayer> layers = new();

        public void Load()
        {
            layers.Add(new RenderLayer("Entities", DrawUtils.ScreenWidth, DrawUtils.ScreenHeight));
            layers.Add(new RenderLayer("UserInterface", DrawUtils.ScreenWidth, DrawUtils.ScreenHeight));
        }

        public void Unload() => layers.Clear();

        internal static void Render(SpriteBatch spriteBatch)
        {
            foreach (RenderLayer layer in layers) 
            {
                layer.Draw(spriteBatch.GraphicsDevice, spriteBatch);
            }

            spriteBatch.GraphicsDevice.SetRenderTarget(null);

            foreach (RenderLayer layer in layers) 
            {
                spriteBatch.Begin();

                spriteBatch.Draw(layer.RenderTarget, Vector2.Zero, Color.White);

                spriteBatch.End();
            }
        }

        internal static void Reset()
        {
            foreach (RenderLayer layer in layers)
            {
                layer.ResetRenderTarget();
            }
        }

        public static RenderLayer GetLayer(string name) => layers.FirstOrDefault(layer => layer.Name == name);
    }
}
