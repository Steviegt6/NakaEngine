using Microsoft.Xna.Framework;
using NakaEngine.Core.Interfaces;
using NakaEngine.Core.Systems;
using NakaEngine.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NakaEngine.Core.Loaders
{
    public class GameSystemLoader : ILoadable
    {
        private readonly List<GameSystem> systems = new();

        public void Load()
        {
            NakaEngine.Instance.Logger.Log("Loading systems...");

            foreach (Type type in NakaEngine.Assembly.GetTypesWithType<GameSystem>().Where(type => !type.IsAbstract))
            {
                GameSystem system = Activator.CreateInstance(type) as GameSystem;
                system.Load();
                systems.Add(system);

                InstanceManager.Register(system);

                NakaEngine.Instance.Logger.Log($"System loaded: {system.GetType().Name}");
            }

            NakaEngine.Instance.Logger.Log("All systems found have been loaded!");
        }

        public void Unload()
        {
            NakaEngine.Instance.Logger.Log("Unloading systems...");

            foreach (GameSystem system in systems)
            {
                system.Unload();

                NakaEngine.Instance.Logger.Log($"System unloaded: {system.GetType().Name}");
            }

            systems.Clear();

            NakaEngine.Instance.Logger.Log("All systems found have been unloaded!");
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
