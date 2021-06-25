using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NakaEngine.Utilities
{
    public static class DrawUtils
    {
        public static int ScreenWidth => NakaEngine.Instance.GraphicsDevice.Viewport.Width;

        public static int ScreenHeight => NakaEngine.Instance.GraphicsDevice.Viewport.Height;

        public static Vector2 ScreenSize => new(ScreenWidth, ScreenHeight);

        public static Vector2 ScreenCenter => ScreenSize / 2f;

        public static Rectangle ScreenRectangle => new(0, 0, ScreenWidth, ScreenHeight);

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
