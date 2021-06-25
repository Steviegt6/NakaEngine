using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace NakaEngine.Graphics
{
    public sealed class RenderLayer
    {
        public string Name;

        public RenderTarget2D RenderTarget;

        public SpriteSortMode SpriteSortMode;

        public BlendState BlendState;

        public SamplerState SamplerState;

        public DepthStencilState DepthStencilState;

        public RasterizerState RasterizerState;

        public Effect Effect;

        public int Width;

        public int Height;

        private readonly List<RenderInfo> renderInfo = new();

        public RenderLayer(string name, int width, int height)
        {
            Name = name;

            Width = width;
            Height = height;

            SpriteSortMode = SpriteSortMode.Deferred;
            BlendState = BlendState.AlphaBlend;

            RenderTarget = new RenderTarget2D(NakaEngine.Instance.GraphicsDevice, width, height);
        }

        public RenderInfo AddInfo(RenderInfo info, SpriteSortMode spriteSortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect)
        {
            renderInfo.Add(info);

            SpriteSortMode = spriteSortMode;
            BlendState = blendState;
            SamplerState = samplerState;
            DepthStencilState = depthStencilState;
            RasterizerState = rasterizerState;
            Effect = effect;

            return info; 
        }

        public void Draw(GraphicsDevice device, SpriteBatch spriteBatch)
        {
            device.SetRenderTarget(RenderTarget);
            device.Clear(Color.Transparent);
            
            spriteBatch.Begin(SpriteSortMode, BlendState, SamplerState, DepthStencilState, RasterizerState, Effect, NakaEngine.Instance.MainCamera.Transform);

            foreach (RenderInfo info in renderInfo)
            {
                spriteBatch.Draw(info.Texture, info.Position, info.SourceRectangle, info.Color, info.Rotation, info.Origin, info.Scale, info.Effects, info.LayerDepth);
            }

            spriteBatch.End();

            renderInfo.Clear();
        }

        public void ResetRenderTarget()
        {
            RenderTarget?.Dispose();

            RenderTarget = new RenderTarget2D(NakaEngine.Instance.GraphicsDevice, Width, Height);
        }
    }
}
