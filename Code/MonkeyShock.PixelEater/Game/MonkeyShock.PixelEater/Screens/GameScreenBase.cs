using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonkeyShock.PixelEater.Screens
{
    abstract class GameScreenBase
    {
        protected PixelEaterGame game;
        protected KeyboardState oldKeyboardState;

        public GameScreenBase(PixelEaterGame game)
        {
            this.game = game; 
        }

        protected bool IsKeyPressed(KeyboardState keyboardState, Keys key)
        {
            bool isKeyPressed; 
            if (oldKeyboardState.IsKeyUp(key) && keyboardState.IsKeyDown(key))
            {
                isKeyPressed =  true; 
            }
            else
            {
                isKeyPressed =  false; 
            }
            this.oldKeyboardState = keyboardState;
            return isKeyPressed; 

        }
        protected  GraphicsDevice graphicsDevice;

        public abstract void Initialize();

        public abstract void HandleKeyboardEvents();

        public abstract void Draw();

        public abstract void LoadContent();

    }
}
