using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using NakaEngine.Audio;
using NakaEngine.Entities;
using NakaEngine.Graphics;
using NakaEngine.Input;
using NakaEngine.Loaders;
using System;
using System.Reflection;

namespace NakaEngine
{
    public sealed class NakaEngine : Game
    {
        /*===============================================================================   
         *   Major priorities
         *   
         * - Animated renderers, animations are not mandatory but definitely important.
         * 
         * - Scenes and tiles, cant play if there's no map.
         * 
         * - As much as its private use, documentation would be nice.
         ===============================================================================*/

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

        [ThreadStatic] 
        private static Random _random;

        public static Random Random => _random ??= new();

        public static Assembly Assembly => Assembly.GetExecutingAssembly();

        public NakaEngine() : base()
		{
			Instance = this;

            Graphics = new GraphicsDeviceManager(Instance);

            Content.RootDirectory = "Assets";

            IsMouseVisible = true;
		}

        protected override void LoadContent()
        {
            LoadableLoader.Load();

            SpriteBatch = new SpriteBatch(Graphics.GraphicsDevice);
            MainCamera = new Camera();

            LoadAssets();

            base.LoadContent();
		}

        protected override void UnloadContent()
        {
            LoadableLoader.Unload();
            Content.Unload();

            Instance = null;

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            InputSystem.Update();
            KeybindSystem.Update(ref InputSystem.CurrentKeyboardState, ref InputSystem.OldKeyboardState);

            ComponentSystem.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            RenderSystem.Render(SpriteBatch);

            base.Draw(gameTime); 
        }

        private void LoadAssets()
        {
            new AssetLoader<Texture2D>(".png").Load(Content.RootDirectory);
            new AssetLoader<Effect>(".xnb").Load(Content.RootDirectory);

            new AssetLoader<SoundEffect>(".wav").Load(Content.RootDirectory);
        }
    }
}
