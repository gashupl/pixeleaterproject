using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonkeyShock.PixelEater.Screens
{
    class GameOverScreen : GameScreenBase
    {
        private int score;

        private SpriteFont font;
        private Vector2 gameoverTextPosition;
        private Vector2 scoreTextPosition;

        public GameOverScreen(PixelEaterGame game) : base(game)
        {
   
            this.gameoverTextPosition = new Vector2(100, 100);
            this.scoreTextPosition = new Vector2(100, 140);
        }

        public void SetScore(int score)
        {
            this.score = score;
        }

        public override void Initialize()
        {
            this.graphicsDevice = this.game.GraphicsDevice;
        }

        public override void LoadContent()
        {
            this.font = this.game.Content.Load<SpriteFont>("Score");
        }

        public override void HandleKeyboardEvents()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                this.game.GameState = GameState.WelcomeScreen;
            }
        }

        public override void Draw()
        {
            this.game.SpriteBatch.Begin();

            this.game.SpriteBatch.DrawString(font, $"Game over!", gameoverTextPosition, Color.Red);
            this.game.SpriteBatch.DrawString(font, $"Your score: {this.score}", scoreTextPosition, Color.Red);
            this.game.SpriteBatch.End();
        }

    }
}
