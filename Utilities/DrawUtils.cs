using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace NakaEngine.Utilities
{
    public static class DrawUtils
    {
        public static float ScreenWidth => NakaEngine.Instance.GraphicsDevice.Viewport.Width;

        public static float ScreenHeight => NakaEngine.Instance.GraphicsDevice.Viewport.Height;

        public static Vector2 ScreenSize => new(ScreenWidth, ScreenHeight);

        public static Vector2 ScreenCenter => ScreenSize / 2f;

        public static Vector2 GetMiddleBetween(this Vector2 start, Vector2 end) => (start + end) / 2f;

        public static Vector2 GetSize(this Texture2D texture) => new(texture.Width, texture.Height);

        public static Vector2 GetCenter(this Texture2D texture) => texture.GetSize() / 2f; 
        
        public static Vector2 ToVector2(this Vector3 vector) => new(vector.X, vector.Y);

        public static Vector3 ToVector3(this Vector2 vector) => new(vector.X, vector.Y, 0f);

        public static float ToRotation(this Vector2 vector) => MathF.Atan2(vector.Y, vector.Y);

        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color, Texture2D texture, int width = 2)
        {
            Vector2 dist = end - start;

            float rotation = dist.ToRotation();

            var destRect = new Rectangle((int)start.X, (int)start.Y, (int)dist.Length(), width);

            spriteBatch.Draw(texture, destRect, null, color, rotation, default, SpriteEffects.None, 0);
        }
    }
}
