using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyShock.PixelEater.Common
{
    class Gameplay
    { 
        private Vector2 position;
        private Texture2D squareTexture; 
        private int squareTextureSize = 10;
        private int movePixelNumber = 3;
        private GraphicsDevice graphicsDevice; 

        public Texture2D SquareTexture {
            get { return this.squareTexture; }
            set { this.squareTexture = value; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }


        public void Initialize(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice; 
            this.SquareTexture = new Texture2D(this.graphicsDevice, squareTextureSize, squareTextureSize);

            var colorArraySize = squareTextureSize * squareTextureSize;
            Color[] colorData = new Color[colorArraySize];
            for (int i = 0; i < colorArraySize; i++)
            {
                colorData[i] = Color.Red;
            }

            SquareTexture.SetData<Color>(colorData);
        }

        public void HandleKeyboardEvents()
        {


            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (Position.Y > 0)
                {
                    this.position.Y -= movePixelNumber;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (position.Y <= this.graphicsDevice.Viewport.Height - squareTextureSize)
                {
                    this.position.Y += movePixelNumber;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (position.X > 0)
                {
                    this.position.X -= movePixelNumber;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (position.X <= this.graphicsDevice.Viewport.Width - squareTextureSize)
                {
                    this.position.X += movePixelNumber;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(squareTexture, position, Color.Yellow);
            spriteBatch.End();
        }
    }
}
