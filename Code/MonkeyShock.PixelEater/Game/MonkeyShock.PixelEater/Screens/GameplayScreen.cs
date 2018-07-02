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
        private readonly int movePixelNumber = 3;
  
        private int initialSecondsNumber = 60; 
        private TimeCounter timeCounter; 

        private SpriteFont font;
        private Vector2 scoreTextPosition;
        private Vector2 timerTextPosition;

        private Action onTimesUpAction; 

        public GameplayScreen(PixelEaterGame game, Action onTimesUpAction) : base(game)
        {

            this.onTimesUpAction = onTimesUpAction; 
            this.scoreTextPosition = new Vector2(this.frameSize, 10);
            this.timerTextPosition = new Vector2(this.frameSize, 40);

            this.arena = new Arena(frameSize);
            this.eater = new Eater(this.arena);
            this.timeCounter = new TimeCounter(this.initialSecondsNumber, onTimesUpAction); 

        }

        public override void Initialize()
        {
            this.graphicsDevice = this.game.GraphicsDevice;
            var colorDataFactory = new ColorDataFactory();

            this.arena.Initialize(this.graphicsDevice, colorDataFactory);
            this.eater.Initialize(this.graphicsDevice, colorDataFactory); 

        }

        public override void HandleKeyboardEvents()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (this.eater.InitialPosition.Y > this.arena.InitialPosition.Y)
                {
                    this.eater.MoveY(-movePixelNumber); 
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                var arenaDownCornerY = this.arena.InitialPosition.Y + arena.Heigth - this.eater.TextureSize;
                if (eater.InitialPosition.Y < arenaDownCornerY)
                {
                    if ((arenaDownCornerY - this.eater.InitialPosition.Y) >= movePixelNumber)
                    {
                        this.eater.MoveY(movePixelNumber); 
                    }
                    else
                    {
                        this.eater.MoveY((arenaDownCornerY - this.eater.InitialPosition.Y));
                    }
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (eater.InitialPosition.X > this.arena.InitialPosition.X)
                {
                    this.eater.MoveX(-movePixelNumber); 
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                var arenaRightCornerX = this.arena.InitialPosition.X + this.arena.Width - this.eater.TextureSize; 
                if (eater.InitialPosition.X < arenaRightCornerX)
                {
                    if ((arenaRightCornerX - eater.InitialPosition.X) >= movePixelNumber)
                    {
                        this.eater.MoveX(movePixelNumber); 
                    }
                    else
                    {
                        this.eater.MoveX((arenaRightCornerX - eater.InitialPosition.X));
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
            this.game.SpriteBatch.Draw(arena.Texture, arena.InitialPosition, Color.White);
            this.game.SpriteBatch.Draw(eater.Texture, eater.InitialPosition, Color.Yellow);
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
