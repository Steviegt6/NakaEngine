using NakaEngine.Core.Systems.Entities.Components;
using System.Collections.Generic;
using System.Linq;

namespace NakaEngine.Core.Systems.Entities
{
    public class GameObject
    {
        public List<Component> Components = new List<Component>();

        public T AddComponent<T>(T component) where T : Component 
        {  
            Components.Add(component); 
            component.GameObject = this; 

            return component;
        } 

        public T GetComponent<T>() where T : Component => Components.FirstOrDefault(component => component is T) as T;
    }
}
