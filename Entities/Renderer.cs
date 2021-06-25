using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Graphics;
using NakaEngine.Utilities.Extensions;

namespace NakaEngine.Entities
{
    public class Renderer : Component
    {
        // TODO - Implement animations (Both axis).

        public Texture2D Texture;

        public Rectangle SourceRectangle;

        public Color Color;

        public SpriteEffects Effects;

        public RenderInfo Info;

        public Renderer(Texture2D texture, Rectangle? sourceRectangle = null, Color? color = null, SpriteEffects effects = SpriteEffects.None)
        {
            Texture = texture;
            SourceRectangle = sourceRectangle ?? texture.Bounds; 
            Color = color ?? Color.White;
            Effects = effects;
        }

        public override void Update(GameTime gameTime)
        {
            Info = new RenderInfo(Texture, GameObject.Transform.Position, SourceRectangle, Color, GameObject.Transform.Rotation, SourceRectangle.GetCenter(), GameObject.Transform.Scale, Effects, 0f);

            RenderSystem.GetLayer("Entities").AddInfo(Info, default, default, default, default, default, default);
        }
    }
}
