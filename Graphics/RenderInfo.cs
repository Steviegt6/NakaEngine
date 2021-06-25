using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NakaEngine.Graphics
{
    public readonly struct RenderInfo
    {
        public readonly Texture2D Texture;

        public readonly Vector2 Position;

        public readonly Vector2 Origin;
        public readonly Vector2 Scale;

        public readonly SpriteEffects Effects;
        public readonly Color Color;

        public readonly Rectangle? SourceRectangle;

        public readonly float Rotation;
        public readonly float LayerDepth;


        public RenderInfo(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0f)
        {
            Texture = texture;
            Position = position;
            Origin = origin;
            Scale = scale;
            Effects = effects;
            Color = color;
            SourceRectangle = sourceRectangle;
            Rotation = rotation;
            LayerDepth = layerDepth; 
        } 
    }
}