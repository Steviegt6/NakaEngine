using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace NakaEngine.Core.Systems.Entities.Components
{
    public abstract class ComponentSystem<T> : GameSystem where T : Component
    {
        public static List<T> Components = new();

        public static T AddComponent(T component)
        {
            Components.Add(component);

            return component;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (T component in Components)
            {
                component.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
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
