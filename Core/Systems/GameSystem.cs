using Microsoft.Xna.Framework;

namespace NakaEngine.Core.Systems
{
    public abstract class GameSystem
    {
        public virtual void Load() { }

        public virtual void Unload() { }

        public virtual void Update(GameTime gameTime) { }
    }
}
