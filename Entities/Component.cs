using Microsoft.Xna.Framework;

namespace NakaEngine.Entities
{
    public class Component
    {
        public bool Active;

        public GameObject GameObject;

        public Component()
        {
            Initialize();

            ComponentSystem.components.Add(this);
        }

        public virtual void Initialize() { }

        public virtual void Update(GameTime gameTime) { }
    }
}
