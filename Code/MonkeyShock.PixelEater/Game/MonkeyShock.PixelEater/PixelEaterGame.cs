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

        private WelcomeScreen welcomeScreen; 
        private Gameplay gameplay; 

        public static GameState GameState; 

        public PixelEaterGame()
        {
            this.Window.Title = "Pixel Eater Project";
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            GameState = GameState.WelcomeScreen; 
            this.welcomeScreen = new WelcomeScreen(); 
            this.gameplay = new Gameplay();
        }

        protected override void Initialize()
        {
            this.welcomeScreen.Initialize(this.GraphicsDevice); 
            this.gameplay.Initialize(this.GraphicsDevice); 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.welcomeScreen.LoadContent(this.Content); 
            this.gameplay.LoadContent(this.Content); 
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if(GameState == GameState.WelcomeScreen)
            {
                this.welcomeScreen.HandleKeyboardEvents(); 
            }
            else if(GameState == GameState.Gameplay)
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

            if (GameState == GameState.WelcomeScreen)
            {
                this.welcomeScreen.Draw(this.spriteBatch); 
            }
            else if(GameState == GameState.Gameplay)
            {
                this.gameplay.Draw(this.spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}
