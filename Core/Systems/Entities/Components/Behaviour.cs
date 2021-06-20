namespace NakaEngine.Core.Systems.Entities.Components
{
    public class Behaviour : Component
    {
        public Behaviour()
        {
            Initialize();

            BehaviourSystem.AddComponent(this);
        }

        public virtual void Initialize() { }
    }
}
