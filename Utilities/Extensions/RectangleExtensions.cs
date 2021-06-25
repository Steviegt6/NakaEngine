using Microsoft.Xna.Framework;

namespace NakaEngine.Utilities.Extensions
{
    public static class RectangleExtensions
    {
        /// <summary>
        /// Returns a <see cref="Vector2"/> with the width and height of a <see cref="Rectangle"/>.
        /// </summary>
        public static Vector2 GetSize(this Rectangle rectangle) => new(rectangle.Width, rectangle.Height);

        /// <summary>
        /// Returns a <see cref="Vector2"/> with the X and Y position of a <see cref="Rectangle"/>.
        /// </summary>
        public static Vector2 GetPosition(this Rectangle rectangle) => new(rectangle.X, rectangle.Y);

        /// <summary>
        /// Returns a <see cref="Vector2"/> with the center point of a <see cref="Rectangle"/>.
        /// </summary>
        public static Vector2 GetCenter(this Rectangle rectangle) => rectangle.GetSize() / 2f;
    }
}
