using Microsoft.Xna.Framework;
using NakaEngine.Core.Interfaces;
using NakaEngine.Core.Systems;
using System;
using System.Collections.Generic;

namespace NakaEngine.Core.Loaders
{
    public class GameSystemLoader : ILoadable
    {
        private readonly List<GameSystem> systems = new();

        public void Load()
        {
            foreach (Type type in NakaEngine.Assembly.GetTypes())
            {
                if (!type.IsAbstract && type.IsSubclassOf(typeof(GameSystem)))
                {
                    GameSystem system = Activator.CreateInstance(type) as GameSystem;
                    system.Load();

                    systems.Add(system);

                    SingletonManager.Register(system);
                }
            }
        }

        public void Unload()
        {
            foreach (GameSystem system in systems)
            {
                system.Unload();
            }

            systems.Clear();
        }

        public void Update(GameTime gameTime)
        {
            foreach (GameSystem system in systems)
            {
                system.Update(gameTime);
            }
        }
    }
}
