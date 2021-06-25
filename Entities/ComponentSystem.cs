using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NakaEngine.Entities
{
    public sealed class ComponentSystem 
    {
        private static List<Component> components = new();

        internal static void Update(GameTime gameTime)
        {
            foreach (Component component in components.Where(component => component.Active))
            {
                component.Update(gameTime);
            }
        }
    }
}
