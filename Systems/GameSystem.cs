using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NakaEngine.Systems
{
    public abstract class GameSystem
    {
        public GameSystem() => Initialize();

        public virtual void Initialize() { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
