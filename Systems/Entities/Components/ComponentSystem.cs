using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace NakaEngine.Systems.Entities.Components
{
    public class ComponentSystem : GameSystem
    {
        public static List<Component> Components = new();

        public static Component AddComponent(Component component)
        {
            Components.Add(component);

            return component;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Component component in Components)
            {
                component.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component component in Components)
            {
                component.Draw(spriteBatch);
            }
        }
    }
}
