using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Core.Utilities;

namespace NakaEngine.Core.Systems.Entities.Components
{
     /*==================================================
     * TODO
     *
     * - Layering
     *      - Possible idea: SpriteSortMode.FrontToBack
     *      
     * - Animations
     ==================================================*/

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
            spriteBatch.Draw(Texture, GameObject.Transform.Position, Frame, Color, GameObject.Transform.Rotation, Texture.GetCenter(), GameObject.Transform.Scale, Effects, 0f);
        }
    }
}
