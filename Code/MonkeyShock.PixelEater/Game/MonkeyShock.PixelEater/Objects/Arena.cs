using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonkeyShock.Common;

namespace MonkeyShock.PixelEater.Objects
{
    class Arena : GameObjectBase
    {
        
        private readonly int frameSize;

        public int Width { get; set; } = 1000;
        public int Heigth { get; set; } = 700;

        public Arena(int frameSize)
        {
            this.frameSize = frameSize; 
            this.Position = new Vector2(
                PixelEaterGame.WindowWidth - this.Width - frameSize,
                PixelEaterGame.WindowHeigth - this.Heigth - frameSize
                );
        }

        public override void Initialize(GraphicsDevice graphicsDevice, ColorDataFactory colorDataFactory)
        {
            this.Texture = new Texture2D(graphicsDevice, this.Width, this.Heigth);
            this.Texture.SetData<Color>(colorDataFactory.Get(this.Width * this.Heigth, Color.White));
        }
    }
}
