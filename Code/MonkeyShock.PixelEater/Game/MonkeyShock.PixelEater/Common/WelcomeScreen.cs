using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonkeyShock.PixelEater.Common
{
    class WelcomeScreen : GameStateBase
    {
        private Vector2 initialPosition = new Vector2(50,50);
        private Texture2D[] titleTextures;
        private int singleSquareTextureSize = 30;
        private Texture2D[] textures;

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            this.titleTextures = new Texture2D[4]; 
            this.titleTextures[0] = new Texture2D(this.graphicsDevice, singleSquareTextureSize, singleSquareTextureSize * 6);
            this.titleTextures[1] = new Texture2D(this.graphicsDevice, singleSquareTextureSize * 3, singleSquareTextureSize);
            this.titleTextures[2] = new Texture2D(this.graphicsDevice, singleSquareTextureSize * 3, singleSquareTextureSize);
            this.titleTextures[3] = new Texture2D(this.graphicsDevice, singleSquareTextureSize, singleSquareTextureSize * 2);

            var colorDataFactory = new ColorDataFactory(); 

            this.titleTextures[0].SetData<Color>(colorDataFactory.Get(singleSquareTextureSize * singleSquareTextureSize * 6, Color.Yellow));
            this.titleTextures[1].SetData<Color>(colorDataFactory.Get(singleSquareTextureSize * 3 * singleSquareTextureSize, Color.Yellow));
            this.titleTextures[2].SetData<Color>(colorDataFactory.Get(singleSquareTextureSize * 3 * singleSquareTextureSize, Color.Yellow));
            this.titleTextures[3].SetData<Color>(colorDataFactory.Get(singleSquareTextureSize * singleSquareTextureSize * 2, Color.Yellow));
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
            spriteBatch.Draw(this.titleTextures[0], initialPosition, Color.Yellow);
            spriteBatch.Draw(this.titleTextures[1], new Vector2(initialPosition.X + singleSquareTextureSize, initialPosition.Y), Color.Yellow);
            spriteBatch.Draw(this.titleTextures[2], new Vector2(initialPosition.X + singleSquareTextureSize, initialPosition.Y + (singleSquareTextureSize * 3)), Color.Yellow);
            spriteBatch.Draw(this.titleTextures[3], new Vector2(initialPosition.X + (singleSquareTextureSize * 3), initialPosition.Y + singleSquareTextureSize), Color.Yellow);
            
            spriteBatch.End();
        }

    }
}
