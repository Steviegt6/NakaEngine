using Microsoft.Xna.Framework;

namespace NakaEngine.Entities
{
    public class Component
    {
        public bool Active
        {
            get;
            set;
        }

        public GameObject GameObject
        {
            get;
            set;
        }

        public Component()
        {
            Initialize();

            ComponentSystem.Components.Add(this);
        }

        public virtual void Initialize() { }

        public virtual void Update(GameTime gameTime) { }
    }
}
