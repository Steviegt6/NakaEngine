using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Utilities;

namespace NakaEngine.Systems.Entities.Components
{
    public class Sprite : Component
    {
        public Texture2D Texture;

        public Rectangle Frame;

        public Color Color;

        public SpriteEffects Effects;
       
        public Sprite(Texture2D texture, Rectangle? frame = null, Color? color = null, SpriteEffects effects = SpriteEffects.None)
        {
            Texture = texture; 
            Frame = frame ?? texture.Bounds;
            Color = color ?? Color.White;
            Effects = effects;
        }

        public override void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(Texture, GameObject.Transform.Position, Frame, Color, GameObject.Transform.Rotation, Texture.GetCenter(), GameObject.Transform.Scale, Effects, 0f);
    }
}
