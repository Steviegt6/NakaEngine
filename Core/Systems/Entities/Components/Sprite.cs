using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Core.Utilities;

namespace NakaEngine.Core.Systems.Entities.Components
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

            SpriteSystem.AddComponent(this);
        }

        public override void Draw(SpriteBatch spriteBatch) 
        {
            /*==================================================
             * TODO
             *
             * - Layering
             *      - Possible idea: SpriteSortMode.FrontToBack
             *      
             * - Animations
             ==================================================*/

            spriteBatch.Draw(Texture, Transform.Position, Frame, Color, Transform.Rotation, Texture.GetCenter(), Transform.Scale, Effects, 0f);
        }
    }
}
