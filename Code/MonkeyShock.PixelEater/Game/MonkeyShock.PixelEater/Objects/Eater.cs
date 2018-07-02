using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonkeyShock.Common;

namespace MonkeyShock.PixelEater.Objects
{
    class Eater
    {
        public readonly int TextureSize = 10;

        private Vector2 initialPosition;
        public Vector2 InitialPosition
        {
            get
            {
                return this.initialPosition;
            }
            set
            {
                this.initialPosition = value;
            }
        }
        private Texture2D texture; 
        public Texture2D Texture {
            get
            {
                return this.texture;
            }
            set
            {
                this.texture = value;
            }
        }

        public Eater(Arena arena)
        {
            this.InitialPosition = new Vector2(arena.InitialPosition.X, arena.InitialPosition.Y);
        }

        public void Initialize(GraphicsDevice graphicsDevice, ColorDataFactory colorDataFactory)
        {
            this.Texture = new Texture2D(graphicsDevice, TextureSize, TextureSize);
            this.Texture.SetData<Color>(colorDataFactory.Get(TextureSize * TextureSize, Color.Red));
        }

        public void MoveX(float pixelCount)
        {
            this.initialPosition.X += pixelCount; 
        }

        public void MoveY(float pixelCount)
        {
            this.initialPosition.Y += pixelCount; 
        }

    }
}
