using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Utilities;
using System.Collections.Specialized;

namespace NakaEngine.Graphics
{
    public sealed class RenderSystem 
    {
        public static OrderedDictionary Layers = new();

        public static void DrawLayers(SpriteBatch spriteBatch)
        { 
            GraphicsDevice device = NakaEngine.Instance.GraphicsDevice;

            foreach (RenderLayer layer in Layers.Values) 
            {
                device.SetRenderTarget(layer.RenderTarget);
                device.Clear(Color.Transparent);

                spriteBatch.Begin(layer.SpriteSortMode, layer.BlendState);

                layer.Draw(spriteBatch);

                spriteBatch.End();

                device.SetRenderTarget(null); 

                spriteBatch.Begin();

                spriteBatch.Draw(layer.RenderTarget, DrawUtils.ScreenRectangle, Color.White);

                spriteBatch.End();
            }
        }
            
        public static void AddLayer(RenderLayer layer) => Layers.Add(layer.Name, layer);
    }
}
