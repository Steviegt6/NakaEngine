using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Graphics;
using NakaEngine.Interfaces;
using NakaEngine.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NakaEngine
{
    public sealed class NakaEngine : Game
    {
        public static Assembly Assembly => Assembly.GetExecutingAssembly();

        public static NakaEngine Instance
        {
            get;
            private set;
        }

        public GraphicsDeviceManager Graphics
        {
            get;
            private set;
        }

		public SpriteBatch SpriteBatch
        {
            get;
            private set;
        }

        public Camera MainCamera
        {
            get;
            private set;
        }

        private List<ILoadable> loadCache = new();

        public NakaEngine() : base()
		{
			Instance = this;

			Graphics = new GraphicsDeviceManager(Instance);

			Content.RootDirectory = "Assets";

            IsMouseVisible = true;
		} 

        protected override void LoadContent()
		{
			SpriteBatch = new SpriteBatch(Graphics.GraphicsDevice);
            MainCamera = new Camera();

            LoadCache();    
      
            base.LoadContent();
		}

        protected override void UnloadContent()
        {
            Instance = null;

            UnloadCache();

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            RenderSystem.Render(SpriteBatch);
            
            base.Draw(gameTime); 
        }

        private void LoadCache()
        {
            foreach (Type type in Assembly.GetTypes()) 
            {
                if (!type.IsAbstract && type.HasEmptyConstructor() && type.HasInterface(typeof(ILoadable)))
                { 
                    var loadable = Activator.CreateInstance(type) as ILoadable;
                    loadable.Load();

                    loadCache.Add(loadable);
                }
            }
        }

        private void UnloadCache()
        {
            foreach (ILoadable loadable in loadCache) 
            {
                loadable.Unload();
            }

            loadCache = null;
        }
    }
}
