using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonkeyShock.Common;

namespace MonkeyShock.PixelEater.Objects
{
    class Arena
    {
        

        private readonly int frameSize;

        public int Width { get; set; } = 1000;
        public int Heigth { get; set; } = 700;
        public Vector2 InitialPosition { get; set; }
        public Texture2D Texture { get; set; }

        public Arena(int frameSize)
        {
            this.frameSize = frameSize; 
            this.InitialPosition = new Vector2(
                PixelEaterGame.WindowWidth - this.Width - frameSize,
                PixelEaterGame.WindowHeigth - this.Heigth - frameSize
                );
        }

        public void Initialize(GraphicsDevice graphicsDevice, ColorDataFactory colorDataFactory)
        {
            this.Texture = new Texture2D(graphicsDevice, this.Width, this.Heigth);
            this.Texture.SetData<Color>(colorDataFactory.Get(this.Width * this.Heigth, Color.White));
        }
    }
}
