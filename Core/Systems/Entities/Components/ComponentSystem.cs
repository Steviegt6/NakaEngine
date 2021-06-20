using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace NakaEngine.Core.Systems.Entities.Components
{
    public abstract class ComponentSystem<T> where T : Component
    {
        public static List<T> Components = new();

        public static T AddComponent(T component)
        {
            Components.Add(component);

            return component;
        }

        public static void UpdateComponents(GameTime gameTime)
        {
            foreach (T component in Components)
            {
                component.Update(gameTime);
            }
        }

        public static void DrawComponents(SpriteBatch spriteBatch)
        {
            foreach (T component in Components)
            {
                component.Draw(spriteBatch);
            }
        }
    }

    public class TransformSystem : ComponentSystem<Transform> { } 

    public class SpriteSystem : ComponentSystem<Sprite> { }

    public class BehaviourSystem : ComponentSystem<Behaviour> { }
}
