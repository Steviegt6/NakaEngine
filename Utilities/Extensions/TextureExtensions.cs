using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NakaEngine.Utilities.Extensions
{
    public static class TextureExtensions
    {
        /// <summary>
        /// Returns a <see cref="Vector2"/> with the width and height of a <see cref="Texture2D"/>.
        /// </summary>
        public static Vector2 GetSize(this Texture2D texture) => new(texture.Width, texture.Height);

        /// <summary>
        /// Returns a <see cref="Vector2"/> with the center point of a <see cref="Texture2D"/>.
        /// </summary>
        public static Vector2 GetCenter(this Texture2D texture) => texture.GetSize() / 2f;
    }
}
