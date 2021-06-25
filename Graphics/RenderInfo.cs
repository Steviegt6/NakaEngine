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


        public RenderInfo(Texture2D texture, Vector2 position, Rectangle? sourceRectangle = null, Color? color = null, float rotation = 0f, Vector2 origin = default, Vector2? scale = null, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0f)
        {
            Texture = texture;
            Position = position;
            Origin = origin;
            Scale = scale ?? Vector2.One;
            Effects = effects;
            Color = color ?? Color.White;
            SourceRectangle = sourceRectangle ?? texture.Bounds;
            Rotation = rotation;
            LayerDepth = layerDepth; 
        } 
    }
}