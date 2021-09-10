using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace MonoTest.Input
{
    public class KeyInput
    {
        private static readonly Lazy<KeyInput> Lazy = new Lazy<KeyInput>(() => new KeyInput());

        public static KeyInput Instance
        {
            get { return Lazy.Value; }
        }

        private KeyboardState prevKeyboardState;
        private KeyboardState currKeyboardState;

        public KeyInput()
        {
            this.prevKeyboardState = Keyboard.GetState();
            this.currKeyboardState = prevKeyboardState;

        }

        public void Update()
        {
            this.prevKeyboardState = this.currKeyboardState;
            this.currKeyboardState = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            return this.currKeyboardState.IsKeyDown(key);
        }
        public bool IsKeyClicked(Keys key)
        {
            return this.currKeyboardState.IsKeyDown(key) && !this.prevKeyboardState.IsKeyDown(key);
        }
    }
}
