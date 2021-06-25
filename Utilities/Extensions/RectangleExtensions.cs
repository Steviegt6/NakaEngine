using Microsoft.Xna.Framework;

namespace NakaEngine.Utilities.Extensions
{
    public static class RectangleExtensions
    {
        public static Vector2 GetSize(this Rectangle rectangle) => new(rectangle.Width, rectangle.Height);

        public static Vector2 GetPosition(this Rectangle rectangle) => new(rectangle.X, rectangle.Y);

        public static Vector2 GetCenter(this Rectangle rectangle) => rectangle.GetSize() / 2f;
    }
}
