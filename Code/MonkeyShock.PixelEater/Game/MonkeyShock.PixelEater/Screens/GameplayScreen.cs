using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonkeyShock.Common;
using MonkeyShock.PixelEater.Objects;
using System;

namespace MonkeyShock.PixelEater.Screens
{
    class GameplayScreen : GameScreenBase
    {
        public static int Score = 0;

        private Eater eater;
        private Arena arena; 
        private readonly int frameSize = 10;
        private readonly int arenaWidth = 1000;
        private readonly int arenaHeigth = 700;

        private readonly int movePixelNumber = 3;
  
        private int initialSecondsNumber = 5; 
        private TimeCounter timeCounter; 

        private Vector2 eaterInitialPosition; 
        private Texture2D eaterTexture;
        private SpriteFont font;
        private Vector2 scoreTextPosition;
        private Vector2 timerTextPosition;

        private Vector2 arenaInitialPosition; 
        private Texture2D arenaTexture;

        private Action onTimesUpAction; 

        public GameplayScreen(PixelEaterGame game, Action onTimesUpAction) : base(game)
        {
            this.arena = new Arena(); 
            this.eater = new Eater(this.arena); 
            this.onTimesUpAction = onTimesUpAction; 
            this.scoreTextPosition = new Vector2(this.frameSize, 10);
            this.timerTextPosition = new Vector2(this.frameSize, 40);
            this.arenaInitialPosition = new Vector2(
                PixelEaterGame.WindowWidth - arenaWidth - frameSize,
                PixelEaterGame.WindowHeigth - arenaHeigth - frameSize
                );
            this.eaterInitialPosition = new Vector2(this.arenaInitialPosition.X, this.arenaInitialPosition.Y);
            this.timeCounter = new TimeCounter(this.initialSecondsNumber, onTimesUpAction); 

        }

        public override void Initialize()
        {
            this.graphicsDevice = this.game.GraphicsDevice; 
            this.eaterTexture = new Texture2D(this.graphicsDevice, eater.TextureSize, eater.TextureSize);
            this.arenaTexture = new Texture2D(this.graphicsDevice, this.arenaWidth, this.arenaHeigth);

            var colorDataFactory = new ColorDataFactory();

            this.eaterTexture.SetData<Color>(colorDataFactory.Get(this.eater.TextureSize * this.eater.TextureSize, Color.Red));
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
                var arenaDownCornerY = this.arenaInitialPosition.Y + arenaHeigth - this.eater.TextureSize;
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
                var arenaRightCornerX = this.arenaInitialPosition.X + this.arenaWidth - this.eater.TextureSize; 
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
                this.game.GameState = GameState.WelcomeScreen; 
            }
        }

        public void Update(GameTime gameTime)
        {
            this.timeCounter.Update(gameTime); 
        }

        public void ResetScore()
        {
            Score = 0; 
        }

        public void ResetTimer()
        {
            this.timeCounter = new TimeCounter(this.initialSecondsNumber, onTimesUpAction);
        }

        public override void Draw()
        {
            this.game.SpriteBatch.Begin();
            this.game.SpriteBatch.Draw(arenaTexture, arenaInitialPosition, Color.White);
            this.game.SpriteBatch.Draw(eaterTexture, eaterInitialPosition, Color.Yellow);
            this.game.SpriteBatch.DrawString(font, $"Score: {Score}", scoreTextPosition, Color.Red);
            this.game.SpriteBatch.DrawString(font, $"Remaining time: {this.timeCounter.RemainingTime}", timerTextPosition, Color.Red);
            this.game.SpriteBatch.End();
        }

        public override void LoadContent()
        {
            this.font = this.game.Content.Load<SpriteFont>("Score");
        }


    }
}
