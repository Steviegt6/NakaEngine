using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NakaEngine.Utilities.Extensions
{
    public static class TextureExtensions
    {
        public static Vector2 GetSize(this Texture2D texture) => new(texture.Width, texture.Height);

        public static Vector2 GetCenter(this Texture2D texture) => texture.GetSize() / 2f;
    }
}
