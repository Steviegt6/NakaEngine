using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NakaEngine.Utilities
{
    public static class DrawUtils
    {
        /// <summary>
        /// Returns the width of the player's screen.
        /// </summary>
        public static int ScreenWidth => NakaEngine.Instance.GraphicsDevice.Viewport.Width;

        /// <summary>
        /// Returns the height of the player's screen.
        /// </summary>
        public static int ScreenHeight => NakaEngine.Instance.GraphicsDevice.Viewport.Height;

        /// <summary>
        /// Returns a <see cref="Vector2"/> with the width and height of the screen.
        /// </summary>
        public static Vector2 ScreenSize => new(ScreenWidth, ScreenHeight);

        /// <summary>
        /// The center of the player's screen.
        /// </summary>
        public static Vector2 ScreenCenter => ScreenSize / 2f;

        /// <summary>
        /// The full <see cref="Rectangle"/> of the player's screen.
        /// </summary>
        public static Rectangle ScreenRectangle => new(0, 0, ScreenWidth, ScreenHeight);
        
        /// <summary>
        /// Returns a <see cref="Texture2D"/> that is just a white 2x2 pixel.
        /// </summary>
        public static Texture2D WhitePixel
        {
            get
            {
                Texture2D texture = new(NakaEngine.Instance.GraphicsDevice, 2, 2);

                Color[] data = new Color[2 * 2];

                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = Color.White;
                }

                texture.SetData(data);

                return texture;
            }
        }
    }
}
