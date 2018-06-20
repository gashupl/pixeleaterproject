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
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private WelcomeScreen welcomeScreen; 
        private GameplayScreen gameplayScreen;
        private GameOverScreen gameoverScreen; 

        public static int WindowWidth = 1280; //HD resolution
        public static int WindowHeigth = 720; //HD resolution
        public static GameState GameState; 

        public PixelEaterGame()
        {
            this.Window.Title = "Pixel Eater Project";
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = PixelEaterGame.WindowWidth;
            this.graphics.PreferredBackBufferHeight = PixelEaterGame.WindowHeigth; 
            this.graphics.IsFullScreen = false;
            this.graphics.ApplyChanges();
            Content.RootDirectory = "Content";

            GameState = GameState.WelcomeScreen; 
            this.welcomeScreen = new WelcomeScreen(); 
            this.gameplayScreen = new GameplayScreen(this.ShowGameOverScreen);
            this.gameoverScreen = new GameOverScreen();
        }

        public void ShowGameOverScreen()
        {
            this.gameoverScreen.SetScore(GameplayScreen.Score);
            GameState = GameState.GameOver; 
        }

        protected override void Initialize()
        {
            this.welcomeScreen.Initialize(this.GraphicsDevice); 
            this.gameplayScreen.Initialize(this.GraphicsDevice);
            this.gameoverScreen.Initialize(this.GraphicsDevice); 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.welcomeScreen.LoadContent(this.Content);
            this.gameplayScreen.LoadContent(this.Content);
            this.gameoverScreen.LoadContent(this.Content); 
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
                this.gameplayScreen.HandleKeyboardEvents();
                this.gameplayScreen.Update(gameTime); 
            }
            else if (GameState == GameState.GameOver)
            {
                this.gameoverScreen.HandleKeyboardEvents();
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
                this.gameplayScreen.Draw(this.spriteBatch);
            }
            else if (GameState == GameState.GameOver)
            {
                this.gameoverScreen.Draw(this.spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}
