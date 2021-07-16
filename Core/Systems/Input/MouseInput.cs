using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NakaEngine.Core.Systems.Input
{
    public class MouseInput : GameSystem
    {
        public static Vector2 MousePosition;

        public static MouseState CurrentMouseState;

        public static MouseState OldMouseState;

        public override void Update(GameTime gameTime)
        {
            CurrentMouseState = Mouse.GetState();
            OldMouseState = CurrentMouseState;

            MousePosition = new(CurrentMouseState.X, CurrentMouseState.Y);
        }
    }
}
