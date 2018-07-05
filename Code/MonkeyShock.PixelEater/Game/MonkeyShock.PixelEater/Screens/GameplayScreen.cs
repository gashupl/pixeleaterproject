using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonkeyShock.Common;
using MonkeyShock.PixelEater.Helpers;
using MonkeyShock.PixelEater.Objects;
using System;
using System.Collections.Generic;

namespace MonkeyShock.PixelEater.Screens
{
    class GameplayScreen : GameScreenBase
    {
        public static int Score = 0;

        private Eater eater;
        private Arena arena;
        private List<Food> availableFood;

        private readonly int frameSize = 10;
        private readonly int movePixelNumber = 3;
  
        private int initialSecondsNumber = 60; 
        private TimeCounter timeCounter; 

        private SpriteFont font;
        private Vector2 scoreTextPosition;
        private Vector2 timerTextPosition;

        private FoodFactory foodFactory;
        
        private Action onTimesUpAction; 

        public GameplayScreen(PixelEaterGame game, Action onTimesUpAction) : base(game)
        {

            this.onTimesUpAction = onTimesUpAction; 
            this.scoreTextPosition = new Vector2(this.frameSize, 10);
            this.timerTextPosition = new Vector2(this.frameSize, 40);

            this.arena = new Arena(frameSize);
            this.eater = new Eater(this.arena);
            this.timeCounter = new TimeCounter(this.initialSecondsNumber, onTimesUpAction);
            this.foodFactory = new FoodFactory(this.arena);
            this.availableFood = new List<Food>(); 

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
                if (this.eater.Position.Y > this.arena.Position.Y)
                {
                    this.eater.MoveY(-movePixelNumber); 
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                var arenaDownCornerY = this.arena.Position.Y + arena.Heigth - this.eater.TextureSize;
                if (eater.Position.Y < arenaDownCornerY)
                {
                    if ((arenaDownCornerY - this.eater.Position.Y) >= movePixelNumber)
                    {
                        this.eater.MoveY(movePixelNumber); 
                    }
                    else
                    {
                        this.eater.MoveY((arenaDownCornerY - this.eater.Position.Y));
                    }
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (eater.Position.X > this.arena.Position.X)
                {
                    this.eater.MoveX(-movePixelNumber); 
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                var arenaRightCornerX = this.arena.Position.X + this.arena.Width - this.eater.TextureSize; 
                if (eater.Position.X < arenaRightCornerX)
                {
                    if ((arenaRightCornerX - eater.Position.X) >= movePixelNumber)
                    {
                        this.eater.MoveX(movePixelNumber); 
                    }
                    else
                    {
                        this.eater.MoveX((arenaRightCornerX - eater.Position.X));
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
            this.game.SpriteBatch.Draw(arena.Texture, arena.Position, Color.White);
            this.game.SpriteBatch.Draw(eater.Texture, eater.Position, Color.Yellow);
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
