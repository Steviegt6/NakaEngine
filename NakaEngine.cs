using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Core.Interfaces;
using NakaEngine.Core.Loaders;
using NakaEngine.Core.Systems.Entities;
using NakaEngine.Core.Systems.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NakaEngine
{
    public sealed class NakaEngine : Game
    {
        public Assembly Assembly => Assembly.GetExecutingAssembly();

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

            new TestEntity();

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
            GameSystemLoader.UpdateSystems(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin();

            GameSystemLoader.DrawSystems(SpriteBatch);
            
            SpriteBatch.End();

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

            loadCache.Sort((x, y) => x.Priority.CompareTo(y.Priority));

            foreach (ILoadable loadable in loadCache)
            {
                loadable.Load();
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

    public class TestEntity : Entity
    {
        public TestEntity()
        {
            Transform transform = new(new Vector2(200));
            AddComponent(transform);

            Sprite sprite = new(TextureLoader.GetAsset("Miscellaneous/MissingTexture"));
            AddComponent(sprite);

            TestEntityBehaviour behaviour = new();
            AddComponent(behaviour);
        }
    }

    public class TestEntityBehaviour : Behaviour 
    {
        private float progress;

        public override void Update(GameTime gametime)
        {
            progress++;

            float cos = MathF.Cos(progress / 20f);
            float sin = MathF.Sin(progress / 20f);

            Transform.Position.X += cos;
            Transform.Position.Y += sin;
        }
    }
}
