using NakaEngine.Systems.Entities.Components;
using System.Collections.Generic;
using System.Linq;

namespace NakaEngine.Systems.Entities
{
    public class GameObject
    {
        public List<Component> Components = new(); 
        
        public Behaviour Behaviour => GetComponent<Behaviour>();

        public Transform Transform => GetComponent<Transform>();

        public Sprite Sprite => GetComponent<Sprite>();

        public T AddComponent<T>(T component) where T : Component 
        {  
            Components.Add(component); 
            component.GameObject = this; 

            return component;
        } 
        
        public T RemoveComponent<T>(T component) where T : Component
        {
            Components.Remove(component);

            return component;
        }

        public bool HasComponent<T>() where T : Component => Components.OfType<T>().Any();

        public T GetComponent<T>() where T : Component => Components.FirstOrDefault(component => component is T) as T;
    }
}
