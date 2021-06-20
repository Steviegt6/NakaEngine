using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NakaEngine
{
    public sealed class NakaEngine : Game
	{
        public static Assembly Assembly => Assembly.GetExecutingAssembly();

		public static NakaEngine Instance;

		public GraphicsDeviceManager Graphics;

		public SpriteBatch SpriteBatch;

        private List<ILoadable> loadCache;

        public NakaEngine() : base()
		{
			Instance = this;

			Graphics = new GraphicsDeviceManager(Instance);

			Content.RootDirectory = "Assets";
		}

        protected override void LoadContent()
		{
			SpriteBatch = new SpriteBatch(Graphics.GraphicsDevice);

            LoadCache();

			base.LoadContent();
		}

        protected override void UnloadContent()
        {
			Instance = null;

            base.UnloadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }

        private void LoadCache()
        {
            loadCache = new List<ILoadable>();

            foreach (Type type in Assembly.GetTypes())
            {
                if (!type.IsAbstract && type.GetInterfaces().Contains(typeof(ILoadable)))
                {
                    var loadable = Activator.CreateInstance(type) as ILoadable;

                    loadCache.Add(loadable);
                }
            }

            loadCache.Sort((x, y) => x.Priority > y.Priority ? 1 : -1);

            foreach (ILoadable loadable in loadCache)
            {
                loadable.Load();

                Console.WriteLine($"Loadable loaded: {loadable.GetType().Name}");
            }
        }
    }
}
