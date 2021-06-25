using Microsoft.Xna.Framework;

namespace NakaEngine.Entities
{
    public class Transform : Component
    {
        public Vector2 Position;

        public Vector2 Scale = Vector2.One;

        public float Rotation;

        public Transform(Vector2 position = default, Vector2? scale = null, float rotation = 0f) : base()
        {
            Position = position;
            Scale = scale ?? Vector2.One;
            Rotation = rotation;
        }
    }
}
