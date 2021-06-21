using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NakaEngine.Systems.Entities.Components
{
    public class Component
    {
        public GameObject GameObject;

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch spriteBatch) { }

        public Component() => ComponentSystem.AddComponent(this);
    }
}
