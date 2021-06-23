using Microsoft.Xna.Framework;
using NakaEngine.Utilities.Extensions;

namespace NakaEngine.Graphics
{
    public sealed class Camera
    {
        public Matrix Transform
        {
            get
            {
                Matrix position = Matrix.CreateTranslation(Position.ToVector3());

                return position;
            }
        }

        public Vector2 Position;
    }
}
