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
            Layers.Add(new RenderLayer("Tiles", DrawUtils.ScreenWidth, DrawUtils.ScreenHeight));
            Layers.Add(new RenderLayer("Entities", DrawUtils.ScreenWidth, DrawUtils.ScreenHeight));
        }

        public void Unload() => Layers.Clear();

        public static void Render(SpriteBatch spriteBatch)
        {
            GraphicsDevice device = NakaEngine.Instance.GraphicsDevice;

            RenderTargets(device, spriteBatch);
        }

        private static void RenderTargets(GraphicsDevice device, SpriteBatch spriteBatch)
        { 
            foreach (RenderLayer layer in Layers)
            {
                RenderLayers(device, spriteBatch, layer);

                spriteBatch.Begin();

                spriteBatch.Draw(layer.RenderTarget, DrawUtils.ScreenRectangle, Color.White);

                spriteBatch.End();
            }
        }

        private static void RenderLayers(GraphicsDevice device, SpriteBatch spriteBatch, RenderLayer layer)
        {
            device.SetRenderTarget(layer.RenderTarget);
            device.Clear(Color.Transparent);

            spriteBatch.Begin(layer.SpriteSortMode, layer.BlendState);

            layer.Draw(spriteBatch);

            spriteBatch.End();

            device.SetRenderTarget(null);
            device.Clear(Color.Transparent);
        }

        public static RenderLayer GetLayer(string name) => Layers.FirstOrDefault(layer => layer.Name == name);
    }
}
