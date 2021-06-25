using Microsoft.Xna.Framework;
using System;

namespace NakaEngine.Utilities.Extensions
{
    public static class VectorExtensions
    {     
        public static Vector2 GetMiddleBetween(this Vector2 start, Vector2 end) => (start + end) / 2f;

        public static Vector3 ToVector3(this Vector2 vector) => new(vector.X, vector.Y, 0f); 
        
        public static Vector2 ToVector2(this Vector3 vector) => new(vector.X, vector.Y);

        public static float ToRotation(this Vector2 vector) => MathF.Atan2(vector.X, vector.Y);

        public static Vector2 ClampLength(this Vector2 vector, float max, float? min = null)
        {
            float length = vector.LengthSquared();

            if (length > max * max)
            {
                vector *= max / MathF.Sqrt(length);
                return vector;
            }
            else if (min != null && length < (float)min * (float)min)
            {
                vector *= (float)min / MathF.Sqrt(length);
            }

            return vector;
        }      
    }
}
