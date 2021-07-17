using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NakaEngine.Core.Systems.Input
{
    public class KeyboardInput : GameSystem
    {
        public static KeyboardState CurrentKeyboardState;

        public static KeyboardState OldKeyboardState;

        public static bool JustPressedKey(Keys key) => CurrentKeyboardState.IsKeyDown(key) && !OldKeyboardState.IsKeyDown(key);

        public static bool IsKeyDown(Keys key) => CurrentKeyboardState.IsKeyDown(key);

        public override void Update(GameTime gameTime)
        {
            OldKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
        }
    }
}
