using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonkeyShock.PixelEater.Common
{
    class Gameplay : GameStateBase
    { 
        private Vector2 position = new Vector2(10, 30);
        private Texture2D squareTexture;
        private SpriteFont font;
        private Vector2 scoreTextPosition = new Vector2(10, 10); 
        private int score = 0;
        private int squareTextureSize = 10;
        private int movePixelNumber = 3;

        public Texture2D SquareTexture {
            get { return this.squareTexture; }
            set { this.squareTexture = value; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public override void Initialize(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice; 
            this.SquareTexture = new Texture2D(this.graphicsDevice, squareTextureSize, squareTextureSize);

            var colorArraySize = squareTextureSize * squareTextureSize;
            Color[] colorData = new Color[colorArraySize];
            for (int i = 0; i < colorArraySize; i++)
            {
                colorData[i] = Color.Red;
            }

            this.squareTexture.SetData<Color>(colorData);
        }

        public override void HandleKeyboardEvents()
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

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                PixelEaterGame.GameState = GameState.WelcomeScreen; 
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(squareTexture, position, Color.Yellow);
            spriteBatch.DrawString(font, $"Score: {this.score}", scoreTextPosition, Color.Red);
            spriteBatch.End();
        }

        public override void LoadContent(ContentManager content)
        {
            this.font = content.Load<SpriteFont>("Score");
        }
    }
}
