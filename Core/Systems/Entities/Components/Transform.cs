using Microsoft.Xna.Framework;

namespace NakaEngine.Core.Systems.Entities.Components
{
    public class Transform : Component
    {
        public Vector2 Position;

        public Vector2 Scale;

        public float Rotation;

        public Transform(Vector2 position, Vector2? scale = null, float rotation = 0f)
        {
            Position = position;
            Scale = scale ?? Vector2.One;
            Rotation = rotation;

            TransformSystem.AddComponent(this);
        }
    }
}
