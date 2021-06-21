using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Systems;
using NakaEngine.Interfaces;
using System;
using System.Collections.Generic;

namespace NakaEngine.Loaders
{
    public sealed class GameSystemLoader : ILoadable
    {
        public static List<GameSystem> Systems = new(); 

        public void Load()
        {
            foreach (Type type in NakaEngine.Assembly.GetTypes())
            {
                if (!type.IsAbstract && type.IsSubclassOf(typeof(GameSystem)))
                {
                    GameSystem system = Activator.CreateInstance(type) as GameSystem;

                    Singleton.Add(system);
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

        public static GameSystem GetSystem<T>() where T : GameSystem => Singleton<T>.Value;
    }
}
