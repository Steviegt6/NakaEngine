using System.Collections.Generic;
using System.Linq;

namespace NakaEngine.Entities
{
    public sealed class GameObject
    {
        private List<Component> Components
        {
            get;
            set;
        } = new();

        public Transform Transform => GetComponent<Transform>();

        public Renderer Renderer => GetComponent<Renderer>();

        public Collider Collider => GetComponent<Collider>();

        public void AddComponent<T>(T component) where T : Component
        {
            Components.Add(component);

            component.GameObject = this;
            component.Active = true;
        }

        public void RemoveComponent<T>(T component) where T : Component
        {
            Components.Remove(component);

            if (ReferenceEquals(component.GameObject, this))
            {
                component.GameObject = null;
            }

            component.Active = false;
        }

        public T GetComponent<T>() where T : Component => Components.FirstOrDefault(component => component.GetType() == typeof(T)) as T;

        public bool HasComponent<T>() where T : Component => Components.OfType<T>().Any();
    }
}
