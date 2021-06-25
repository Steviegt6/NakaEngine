using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NakaEngine.Input
{
    public class InputSystem 
    {
        public static KeyboardState CurrentKeyboardState;

        public static KeyboardState OldKeyboardState;

        public static MouseState CurrentMouseState;

        public static MouseState OldMouseState;

        public static Vector2 OldMousePosition;

        public static Vector2 MousePosition;

        internal static void Update()
        {
            OldKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();

            OldMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();

            OldMousePosition = MousePosition;
            MousePosition = new Vector2(CurrentMouseState.X, CurrentMouseState.Y);

            KeybindSystem.Update(ref CurrentKeyboardState, ref OldKeyboardState);
        }

        public static bool JustLeftClicked => CurrentMouseState.LeftButton == ButtonState.Pressed && OldMouseState.LeftButton == ButtonState.Released;

        public static bool JustRightClicked => CurrentMouseState.RightButton == ButtonState.Pressed && OldMouseState.RightButton == ButtonState.Released;

        public static bool JustPressedKey(Keys key) => CurrentKeyboardState.IsKeyDown(key) && !OldKeyboardState.IsKeyDown(key);
    }
}
