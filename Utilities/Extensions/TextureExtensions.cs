using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NakaEngine.Utilities.Extensions
{
    public static class TextureExtensions
    {
        public static Vector2 GetSize(this Texture2D texture) => new(texture.Width, texture.Height);

        public static Vector2 GetCenter(this Texture2D texture) => texture.GetSize() / 2f;

        public static Rectangle Frame(this Texture2D texture, int frameX = 0, int framesX = 1, int frameY = 0, int framesY = 1)
        {
            int width = texture.Width / framesX; 
            int height = texture.Height / framesY;

            return new(frameX * width, frameY * height, width, height);
        }
    }
}
