using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NakaEngine.Entities
{
    public sealed class ComponentSystem 
    {
        public static List<Component> Components
        {
            get;
            private set;
        } = new();

        internal static void Update(GameTime gameTime)
        {
            foreach (Component component in Components.Where(component => component.Active))
            {
                component.Update(gameTime);
            }
        }
    }
}
