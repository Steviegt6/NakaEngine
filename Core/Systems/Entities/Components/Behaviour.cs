using Microsoft.Xna.Framework;

namespace NakaEngine.Core.Systems.Entities.Components
{
    public class Behaviour : Component
    {
        public bool Active;

        public Behaviour(bool active = true)
        {
            Active = active;

            Initialize();

            BehaviourSystem.AddComponent(this);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Active)
            {
                return;
            }
        }

        public virtual void Initialize() { }
    }
}
