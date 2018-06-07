using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonkeyShock.PixelEater.Common
{
    abstract class GameStateBase
    {
        protected  GraphicsDevice graphicsDevice;

        public abstract void Initialize(GraphicsDevice graphicsDevice);

        public abstract void HandleKeyboardEvents();

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void LoadContent(ContentManager content); 
    }
}
