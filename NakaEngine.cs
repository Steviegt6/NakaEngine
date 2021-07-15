using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Core;
using NakaEngine.Core.Interfaces;
using NakaEngine.Core.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NakaEngine
{
    public sealed class NakaEngine : Game
    { 
        public static Assembly Assembly => Assembly.GetExecutingAssembly();

        public GraphicsDeviceManager Graphics;

        public SpriteBatch SpriteBatch;

        private readonly List<ILoadable> loadables = new();

        public NakaEngine() : base()
        {
            Graphics = new(this);

            Content.RootDirectory = "Assets";

            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            SpriteBatch = new(GraphicsDevice);

            LoadLoadables();

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            UnloadLoadables();

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            SingletonManager.GetSingleton<GameSystemLoader>().Update(gameTime);

            base.Update(gameTime);
        }

        private void LoadLoadables()
        {
            foreach (Type type in Assembly.GetTypes())
            {
                if (!type.IsAbstract && type.GetInterfaces().Contains(typeof(ILoadable)))
                {
                    ILoadable loadable = Activator.CreateInstance(type) as ILoadable;
                    loadable.Load();

                    loadables.Add(loadable);

                    SingletonManager.Register(loadable);
                }
            }
        }

        private void UnloadLoadables()
        {
            foreach (ILoadable loadable in loadables)
            {
                loadable.Unload();
            }

            loadables.Clear();
        }
    }
}
