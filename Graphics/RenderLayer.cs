using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

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

        public List<RenderInfo> Info
        {
            get;
            private set;
        } = new();

        public RenderLayer(string name, int width, int height)
        {
            Name = name;

            Width = width;
            Height = height;

            SpriteSortMode = SpriteSortMode.Deferred;
            BlendState = BlendState.AlphaBlend;

            RenderTarget = new RenderTarget2D(NakaEngine.Instance.GraphicsDevice, width, height);
        }

        public RenderInfo AddInfo(Texture2D texture, Vector2 position, Rectangle? sourceRectangle = null, Color? color = null, float rotation = 0f, Vector2 origin = default, Vector2? scale = null, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0f)
        {
            Color infoColor = color ?? Color.White;
            scale ??= Vector2.One;

            RenderInfo info = new(texture, position, sourceRectangle, infoColor, rotation, origin, scale ?? Vector2.One, effects, layerDepth);

            Info.Add(info);

            return info; 
        }

        public RenderInfo AddInfo(RenderInfo info)
        {
            Info.Add(info);

            return info;
        }

        public void Draw(GraphicsDevice device, SpriteBatch spriteBatch)
        {
            device.SetRenderTarget(RenderTarget);
            device.Clear(Color.Transparent);
            
            spriteBatch.Begin(SpriteSortMode, BlendState, default, default, default, default, NakaEngine.Instance.MainCamera.Transform);

            foreach (RenderInfo info in Info)
            {
                spriteBatch.Draw(info.Texture, info.Position, info.SourceRectangle, info.Color, info.Rotation, info.Origin, info.Scale, info.Effects, info.LayerDepth);
            }

            spriteBatch.End();

            Info.Clear();
        }

        public void ResetRenderTarget()
        {
            RenderTarget?.Dispose();

            RenderTarget = new RenderTarget2D(NakaEngine.Instance.GraphicsDevice, Width, Height);
        }
    }
}
