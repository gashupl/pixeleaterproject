using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonkeyShock.PixelEater.Common
{
    abstract class GameStateBase
    {
        protected PixelEaterGame game; 
        public GameStateBase(PixelEaterGame game)
        {
            this.game = game; 
        }
        protected  GraphicsDevice graphicsDevice;

        public abstract void Initialize();

        public abstract void HandleKeyboardEvents();

        public abstract void Draw();

        public abstract void LoadContent(); 
    }
}
