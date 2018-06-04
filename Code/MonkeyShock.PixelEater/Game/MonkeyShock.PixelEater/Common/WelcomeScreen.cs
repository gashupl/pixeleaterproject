using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonkeyShock.PixelEater.Common
{
    class WelcomeScreen : GameStateBase
    {
        private Vector2 initialPosition = new Vector2(50,50);
        private Texture2D squareTexture;
        private int squareTextureSize = 30;
        private Texture2D[] textures;

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            this.squareTexture = new Texture2D(this.graphicsDevice, squareTextureSize, squareTextureSize * 6);

            var colorArraySize = squareTextureSize * squareTextureSize * 6;
            Color[] colorData = new Color[colorArraySize];
            for (int i = 0; i < colorArraySize; i++)
            {
                colorData[i] = Color.Yellow;
            }

            this.squareTexture.SetData<Color>(colorData);
        }

        public override void HandleKeyboardEvents()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                PixelEaterGame.GameState = GameState.Gameplay; 
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(squareTexture, initialPosition, Color.Yellow);
            spriteBatch.End();
        }

    }
}
