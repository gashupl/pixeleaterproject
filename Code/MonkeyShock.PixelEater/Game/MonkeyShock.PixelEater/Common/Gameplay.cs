﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonkeyShock.PixelEater.Common
{
    class Gameplay : GameStateBase
    {
        private int frameSize = 10;
        private int score = 0;
        private int arenaWidth = 1000;
        private int arenaHeigth = 700;
        private int squareTextureSize = 10;
        private int movePixelNumber = 3;

        private Vector2 eaterInitialPosition; 
        private Texture2D eaterTexture;
        private SpriteFont font;
        private Vector2 scoreTextPosition; 

        private Vector2 arenaInitialPosition; 
        private Texture2D arenaTexture;

        public Gameplay()
        {
           
            this.scoreTextPosition = new Vector2(this.frameSize, 10);
            this.arenaInitialPosition = new Vector2(
                PixelEaterGame.WindowWidth - arenaWidth - frameSize,
                PixelEaterGame.WindowHeigth - arenaHeigth - frameSize
                );
            this.eaterInitialPosition = new Vector2(this.arenaInitialPosition.X, this.arenaInitialPosition.Y);

        }
        public override void Initialize(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice; 
            this.eaterTexture = new Texture2D(this.graphicsDevice, squareTextureSize, squareTextureSize);
            this.arenaTexture = new Texture2D(this.graphicsDevice, this.arenaWidth, this.arenaHeigth);

            var colorDataFactory = new ColorDataFactory();

            this.eaterTexture.SetData<Color>(colorDataFactory.Get(this.squareTextureSize * this.squareTextureSize, Color.Red));
            this.arenaTexture.SetData<Color>(colorDataFactory.Get(this.arenaWidth * this.arenaHeigth, Color.White)); 
        }

        public override void HandleKeyboardEvents()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (this.eaterInitialPosition.Y > this.arenaInitialPosition.Y)
                {
                    this.eaterInitialPosition.Y -= movePixelNumber;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                var arenaDownCornerY = this.arenaInitialPosition.Y + arenaHeigth - this.squareTextureSize;
                if (eaterInitialPosition.Y < arenaDownCornerY)
                {
                    if ((arenaDownCornerY - this.eaterInitialPosition.Y) >= movePixelNumber)
                    {
                        this.eaterInitialPosition.Y += movePixelNumber;
                    }
                    else
                    {
                        this.eaterInitialPosition.Y += (arenaDownCornerY - this.eaterInitialPosition.Y);
                    }
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (eaterInitialPosition.X > this.arenaInitialPosition.X)
                {
                    this.eaterInitialPosition.X -= movePixelNumber;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                var arenaRightCornerX = this.arenaInitialPosition.X + this.arenaWidth - this.squareTextureSize; 
                if (eaterInitialPosition.X < arenaRightCornerX)
                {
                    if ((arenaRightCornerX - eaterInitialPosition.X) >= movePixelNumber)
                    {
                        this.eaterInitialPosition.X += movePixelNumber;
                    }
                    else
                    {
                        this.eaterInitialPosition.X += (arenaRightCornerX - eaterInitialPosition.X);
                    }

                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                PixelEaterGame.GameState = GameState.WelcomeScreen; 
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(arenaTexture, arenaInitialPosition, Color.White);
            spriteBatch.Draw(eaterTexture, eaterInitialPosition, Color.Yellow);     
            spriteBatch.DrawString(font, $"Score: {this.score}", scoreTextPosition, Color.Red);
            spriteBatch.End();
        }

        public override void LoadContent(ContentManager content)
        {
            this.font = content.Load<SpriteFont>("Score");
        }
    }
}
