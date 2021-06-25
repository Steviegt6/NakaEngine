using Microsoft.Xna.Framework;

namespace NakaEngine.Entities
{
    ///<summary>Stores info for a GameObject.</summary>
    public class Component
    {
        public bool Active
        {
            get;
            set;
        }

        /// <summary>The GameObject this component is attatched to.</summary>
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
