using Microsoft.Xna.Framework;

namespace NakaEngine.Entities
{
    public class Collider : Component  
    {
        // TODO - Implement actual collision.

        public Rectangle Hitbox;

        public int Width;

        public int Height;

        public Collider(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override void Update(GameTime gameTime) => Hitbox = new Rectangle((int)GameObject.Transform.Position.X - Width / 2, (int)GameObject.Transform.Position.Y - Height / 2, Width, Height);
    }
}
