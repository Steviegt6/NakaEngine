using Microsoft.Xna.Framework;

namespace NakaEngine.Entities
{
    public class Component
    {
        public bool Active;

        public GameObject GameObject;

        public virtual void Update(GameTime gameTime) { }
    }
}
