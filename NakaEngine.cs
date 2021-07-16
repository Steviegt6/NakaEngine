using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Core;
using NakaEngine.Core.Interfaces;
using NakaEngine.Core.Loaders;
using NakaEngine.Core.Logging;
using NakaEngine.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NakaEngine
{
    public class NakaEngine : Game
    {
        public static Assembly Assembly => Assembly.GetExecutingAssembly();

        public static NakaEngine Instance;

        public GraphicsDeviceManager Graphics;

        public SpriteBatch SpriteBatch;

        public Logger Logger;

        private List<ILoadable> loadables;

        public NakaEngine() : base()
        {
            Instance = this;
            Graphics = new(Instance);

            Content.RootDirectory = "Assets";
        }

        protected override void LoadContent()
        {
            SpriteBatch = new(GraphicsDevice);

            Logger = new(@"Logs/engine-logs.txt");
            Logger.Configurate();

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
            InstanceManager.GetInstance<GameSystemLoader>().Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);

            base.Draw(gameTime);
        }

        private void LoadLoadables()
        {
            loadables = new();

            foreach (Type type in Assembly.GetTypesWithInterface<ILoadable>().Where(type => !type.IsAbstract))
            {
                ILoadable loadable = Activator.CreateInstance(type) as ILoadable;
                loadable.Load();
                loadables.Add(loadable);

                InstanceManager.Register(loadable);
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
