using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NakaEngine.Core.Systems.Input
{
    public class MouseInput : GameSystem
    {
        public static Vector2 MousePosition;

        public static MouseState CurrentMouseState;

        public static MouseState OldMouseState;

        public static bool JustLeftClicked => CurrentMouseState.LeftButton == ButtonState.Pressed && OldMouseState.LeftButton == ButtonState.Released;

        public static bool JustRightClicked => CurrentMouseState.RightButton == ButtonState.Pressed && OldMouseState.RightButton == ButtonState.Released;

        public static bool LeftClickDown => CurrentMouseState.LeftButton == ButtonState.Pressed;

        public static bool RightClickDown => CurrentMouseState.RightButton == ButtonState.Pressed;

        public override void Update(GameTime gameTime)
        {
            OldMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();

            MousePosition = new(CurrentMouseState.X, CurrentMouseState.Y);
        }
    }
}
