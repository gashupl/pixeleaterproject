using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonkeyShock.PixelEater.Screens;

namespace MonkeyShock.PixelEater
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class PixelEaterGame : Game
    {
        private GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;

        private WelcomeScreen welcomeScreen; 
        private GameplayScreen gameplayScreen;
        private GameOverScreen gameoverScreen; 

        public static int WindowWidth = 1280; //HD resolution
        public static int WindowHeigth = 720; //HD resolution

        private GameState gameState; 
        public GameState GameState {
            get
            {
                return gameState; 
            } 
            set
            {
                if(value == GameState.WelcomeScreen && this.gameplayScreen != null)
                {
                    this.gameplayScreen.ResetTimer(); 
                    this.gameplayScreen.ResetScore(); 
                }
                gameState = value; 
            }}

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
            this.welcomeScreen = new WelcomeScreen(this); 
            this.gameplayScreen = new GameplayScreen(this, this.ShowGameOverScreen);
            this.gameoverScreen = new GameOverScreen(this);
        }

        public void ShowGameOverScreen()
        {
            this.gameoverScreen.SetScore(GameplayScreen.Score);
            GameState = GameState.GameOver; 
        }

        protected override void Initialize()
        {
            this.welcomeScreen.Initialize(); 
            this.gameplayScreen.Initialize();
            this.gameoverScreen.Initialize(); 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.SpriteBatch = new SpriteBatch(GraphicsDevice);

            this.welcomeScreen.LoadContent();
            this.gameplayScreen.LoadContent();
            this.gameoverScreen.LoadContent(); 
        }

        protected override void UnloadContent()
        {

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
                this.welcomeScreen.Draw(); 
            }
            else if(GameState == GameState.Gameplay)
            {
                this.gameplayScreen.Draw();
            }
            else if (GameState == GameState.GameOver)
            {
                this.gameoverScreen.Draw();
            }

            base.Draw(gameTime);
        }
    }
}
