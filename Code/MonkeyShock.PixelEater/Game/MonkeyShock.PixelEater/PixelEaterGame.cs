using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonkeyShock.PixelEater.Common;

namespace MonkeyShock.PixelEater
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class PixelEaterGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Gameplay gameplay; 


        private GameState gameState; 

        public PixelEaterGame()
        {
            this.gameState = GameState.Gameplay; 
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.gameplay = new Gameplay();
            this.gameplay.Initialize(this.GraphicsDevice); 
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
            if(this.gameState == GameState.Gameplay)
            {
                this.gameplay.HandleKeyboardEvents(); 
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (this.gameState == GameState.Gameplay)
            {
                this.gameplay.Draw(this.spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}
