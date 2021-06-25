using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace NakaEngine.Input
{
    public static class KeybindSystem
    {
        private static List<Keybind> Keybinds
        {
            get;
            set;
        } = new();

        public static Keybind RegisterKeybind(Keybind keybind)
        {
            Keybinds.Add(keybind);

            return keybind;
        }

        public static Keybind RegisterKeybind(Keys key, Action onPress = null, Action onRelease = null, Action onKeyDown = null)
        {
            Keybind keybind = new(key);

            keybind.OnPress += onPress; 
            keybind.OnRelease += onRelease; 

            keybind.OnKeyDown += onKeyDown;

            return RegisterKeybind(keybind);
        }

        internal static void Update(ref KeyboardState currentState, ref KeyboardState oldState)
        {
            foreach (Keybind keybind in Keybinds)
            {
                keybind.Update(currentState.IsKeyDown(keybind.Key), oldState.IsKeyDown(keybind.Key));
            }
        }
    }
}
