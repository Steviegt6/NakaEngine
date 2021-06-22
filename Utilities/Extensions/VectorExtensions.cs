using Microsoft.Xna.Framework;

namespace NakaEngine.Utilities.Extensions
{
    public static class VectorExtensions
    {     
        public static Vector2 GetMiddleBetween(this Vector2 start, Vector2 end) => (start + end) / 2f;

        public static Vector3 ToVector3(this Vector2 vector) => new(vector.X, vector.Y, 0f); 
        
        public static Vector2 ToVector2(this Vector3 vector) => new(vector.X, vector.Y);
    }
}
