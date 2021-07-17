using Microsoft.Xna.Framework;

namespace NakaEngine.Utilities
{
    public static class DrawUtilities
    {
        public static int ScreenWidth => NakaEngine.Instance.GraphicsDevice.Viewport.Width;

        public static int ScreenHeight => NakaEngine.Instance.GraphicsDevice.Viewport.Height;

        public static Vector2 ScreenSize => new(ScreenWidth, ScreenHeight);

        public static Vector2 ScreenCenter => ScreenSize / 2f;

        public static Rectangle ScreenRectangle => new(0, 0, ScreenWidth, ScreenHeight);
    }
}