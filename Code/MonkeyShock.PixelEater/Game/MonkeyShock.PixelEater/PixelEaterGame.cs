using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonkeyShock.PixelEater
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class PixelEaterGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D squareTexture;
        private Vector2 position;
        private int squareTextureSize = 100;
        private int movePixelNumber = 3; 

        public PixelEaterGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.squareTexture = new Texture2D(this.GraphicsDevice, squareTextureSize, squareTextureSize);

            var colorArraySize = squareTextureSize * squareTextureSize; 
            Color[] colorData = new Color[colorArraySize];
            for (int i = 0; i < colorArraySize; i++)
            {
                colorData[i] = Color.Red;
            }

            squareTexture.SetData<Color>(colorData);
            base.Initialize();

        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (position.Y > 0)
                {
                    this.position.Y -= movePixelNumber;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (position.Y <= this.GraphicsDevice.Viewport.Height - squareTextureSize)
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
                if(position.X <= this.GraphicsDevice.Viewport.Width - squareTextureSize)
                {
                    this.position.X += movePixelNumber;
                }
            }


            //this.position.X += 1;
            //if (position.X > this.GraphicsDevice.Viewport.Width)
            //{
            //    this.position.X = 0;
            //}


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();
            this.spriteBatch.Draw(squareTexture, position, Color.Yellow);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
