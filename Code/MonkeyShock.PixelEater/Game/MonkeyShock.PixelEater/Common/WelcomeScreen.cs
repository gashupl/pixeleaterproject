using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonkeyShock.PixelEater.Common
{
    class WelcomeScreen : GameScreenBase
    {
        private Vector2 initialPosition = new Vector2(50,50);
        private Vector2 initialMenuPosition = new Vector2(200, 100);
        private Texture2D[] titleTextures;
        private SpriteFont font;

        private int singleSquareTextureSize = 30;
        

        public WelcomeScreen(PixelEaterGame game) : base(game)
        {

        }

        public override void Initialize()
        {
            this.graphicsDevice = this.game.GraphicsDevice;
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
            if(this.IsKeyPressed(Keyboard.GetState(), Keys.Enter))
            {
                this.game.GameState = GameState.Gameplay;
            }
        }

        public override void Draw()
        {
            this.game.SpriteBatch.Begin();
            this.game.SpriteBatch.Draw(this.titleTextures[0], initialPosition, Color.Yellow);
            this.game.SpriteBatch.Draw(this.titleTextures[1], new Vector2(initialPosition.X + singleSquareTextureSize, initialPosition.Y), Color.Yellow);
            this.game.SpriteBatch.Draw(this.titleTextures[2], new Vector2(initialPosition.X + singleSquareTextureSize, initialPosition.Y + (singleSquareTextureSize * 3)), Color.Yellow);
            this.game.SpriteBatch.Draw(this.titleTextures[3], new Vector2(initialPosition.X + (singleSquareTextureSize * 3), initialPosition.Y + singleSquareTextureSize), Color.Yellow);

            this.game.SpriteBatch.DrawString(font, $"Start new game", new Vector2(this.initialMenuPosition.X, this.initialMenuPosition.Y), Color.Red);
            this.game.SpriteBatch.DrawString(font, $"High score", new Vector2(this.initialMenuPosition.X, this.initialMenuPosition.Y + 30), Color.Red);
            this.game.SpriteBatch.DrawString(font, $"Credits", new Vector2(this.initialMenuPosition.X, this.initialMenuPosition.Y + 60), Color.Red);
            this.game.SpriteBatch.End();
        }

        public override void LoadContent()
        {
            this.font = this.game.Content.Load<SpriteFont>("WelcomeScreen");
        }

    }
}
