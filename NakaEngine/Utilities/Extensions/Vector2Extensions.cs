using Microsoft.Xna.Framework;

namespace NakaEngine.Utilities.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector3 ToVector3(this Vector2 vector) => new(vector.X, vector.Y, 0f);
    }
}
