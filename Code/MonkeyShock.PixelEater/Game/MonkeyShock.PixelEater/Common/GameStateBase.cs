using Microsoft.Xna.Framework.Graphics;

namespace MonkeyShock.PixelEater.Common
{
    abstract class GameStateBase
    {
        protected  GraphicsDevice graphicsDevice;

        public abstract void Initialize(GraphicsDevice graphicsDevice);

        public abstract void HandleKeyboardEvents();

        public abstract void Draw(SpriteBatch spriteBatch); 
    }
}
