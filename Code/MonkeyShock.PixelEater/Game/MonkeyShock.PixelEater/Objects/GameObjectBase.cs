using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonkeyShock.Common;

namespace MonkeyShock.PixelEater.Objects
{
    abstract class GameObjectBase
    {
        protected Vector2 position;
        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }
        protected Texture2D texture;
        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }
            set
            {
                this.texture = value;
            }
        }

        public abstract void Initialize(GraphicsDevice graphicsDevice, ColorDataFactory colorDataFactory); 
    }
}
