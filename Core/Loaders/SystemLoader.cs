using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Core.Interfaces;
using NakaEngine.Core.Systems;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace NakaEngine.Core.Loaders
{
    public sealed class SystemLoader : ILoadable // here or in a separate class ?
    {
        public static List<GameSystem> Systems = new(); 

        public void Load()
        {
            foreach (Type type in NakaEngine.Instance.Assembly.GetTypes())
            {
                if (!type.IsAbstract && type.IsSubclassOf(typeof(GameSystem)))
                {
                    GameSystem system = Activator.CreateInstance(type) as GameSystem;

                    Systems.Add(system);
                }
            }
        }

        public void Unload() => Systems.Clear();

        public static void UpdateSystems(GameTime gameTime)
        {
            foreach (GameSystem system in Systems)
            {
                system.Update(gameTime);
            }
        }

        public static void DrawSystems(SpriteBatch spriteBatch)
        {
            foreach (GameSystem system in Systems)
            {
                system.Draw(spriteBatch);
            }
        }

        public static GameSystem GetSystem<T>() where T : GameSystem => Systems.FirstOrDefault(s => s is T) as T;
    }

    static class Singletons
    {
        public static void Add(object singleton)
        {

        }
    }
    static class Singletons<T>
    {

    }
}
