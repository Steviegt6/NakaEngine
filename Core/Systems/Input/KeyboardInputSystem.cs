using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NakaEngine.Core.Systems.Input
{
    public class KeyboardInputSystem : GameSystem
    {
        public static KeyboardState CurrentKeyboardState;

        public static KeyboardState OldKeyboardState;

        public override void Update(GameTime gameTime)
        {
            CurrentKeyboardState = Keyboard.GetState();
            OldKeyboardState = CurrentKeyboardState;
        }
    }
}
