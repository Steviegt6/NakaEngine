using Microsoft.Xna.Framework;
using System;

namespace NakaEngine.Utilities.Extensions
{
    public static class VectorExtensions
    {     
        /// <summary>
        /// Gets the middle point between two <see cref="Vector2"/>s.
        /// </summary>
        public static Vector2 GetMiddleBetween(this Vector2 start, Vector2 end) => (start + end) / 2f;

        /// <summary>
        /// Converts a <see cref="Vector2"/> to a <see cref="Vector3"/>.
        /// </summary>
        public static Vector3 ToVector3(this Vector2 vector) => new(vector.X, vector.Y, 0f); 
        
        /// <summary>
        /// Converts a <see cref="Vector3"/> to a <see cref="Vector2"/>.
        /// </summary>
        public static Vector2 ToVector2(this Vector3 vector) => new(vector.X, vector.Y);

        /// <summary>
        /// Rotates a <see cref="Vector2"/> by an angle.
        /// </summary>
        public static Vector2 RotatedBy(this Vector2 vector, float radians, Vector2 center = default)
        {
            float cos = MathF.Cos(radians);
            float sin = MathF.Sin(radians);

            Vector2 dist = vector - center;
            Vector2 result = center;

            result.X += dist.X * cos - dist.Y * sin;
            result.Y += dist.X * sin + dist.Y * cos;

            return result;
        }

        /// <summary>
        /// Returns the rotation value of a <see cref="Vector2"/>.
        /// </summary>
        public static float ToRotation(this Vector2 vector) => MathF.Atan2(vector.X, vector.Y);

        /// <summary>
        /// Return the rotation value between two <see cref="Vector2"/>.
        /// </summary>
        public static float RotationTo(this Vector2 start, Vector2 end) => MathF.Atan2(end.Y - start.Y, end.X - start.X);
    }
}
