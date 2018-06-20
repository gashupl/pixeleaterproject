using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonkeyShock.PixelEater.Common
{
    class GameOverScreen : GameStateBase
    {
        private int score;

        private SpriteFont font;
        private Vector2 gameoverTextPosition;
        private Vector2 scoreTextPosition;

        public GameOverScreen()
        {
   
            this.gameoverTextPosition = new Vector2(100, 100);
            this.scoreTextPosition = new Vector2(100, 140);
        }

        public void SetScore(int score)
        {
            this.score = score;
        }

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }

        public override void LoadContent(ContentManager content)
        {
            this.font = content.Load<SpriteFont>("Score");
        }

        public override void HandleKeyboardEvents()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                PixelEaterGame.GameState = GameState.WelcomeScreen;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
     
            spriteBatch.DrawString(font, $"Game over!", gameoverTextPosition, Color.Red);
            spriteBatch.DrawString(font, $"Your score: {this.score}", scoreTextPosition, Color.Red);
            spriteBatch.End();
        }
    }
}
