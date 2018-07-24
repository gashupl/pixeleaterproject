using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyShock.Common.Screens
{
    public class ScreenManager : DrawableGameComponent
    {
        #region Private fields
        private List<GameScreen> gameScreens = new List<GameScreen>();
        private List<GameScreen> screensToUpdate = new List<GameScreen>();
        #endregion

        #region Public properties
        new public Game Game
        {
            get
            {
                return base.Game; 
            }
        }
        #endregion

        #region Constructor
        public ScreenManager(Game game, GraphicsDeviceManager graphicsDeviceManager): base(game)
        {

        }
        #endregion

        #region Public methods
        public void AddScreen(GameScreen screen)
        {
            screen.ScreenManager = this;
            screen.Initialize();
            this.gameScreens.Add(screen); 
        }

        public void RemoveScreen(GameScreen screen)
        {
            this.gameScreens.Remove(screen);
            this.screensToUpdate.Remove(screen); 
        }

        public List<GameScreen> GetScreens()
        {
            return this.gameScreens; 
        }
        #endregion

        #region DrawableGameComponent overriden methods
        protected override void LoadContent()
        {
            this.gameScreens.ForEach(screen =>
            {
                screen.UnloadContent();
            }); 
        }

        protected override void UnloadContent()
        {
            this.gameScreens.ForEach(screen =>
            {
                screen.UnloadContent();
            });
        }

        public override void Update(GameTime gameTime)
        {
            //TODO: Finish update method implementation
            this.screensToUpdate.Clear();
            this.gameScreens.ForEach(screen =>
            {
                this.screensToUpdate.Add(screen); 
            });

            bool anotherScreenHasFocus = !this.Game.IsActive;
            var coveredByAnotherScreen = false; 

            while(this.screensToUpdate.Count > 0)
            {
                var screen = this.screensToUpdate[this.screensToUpdate.Count];
                this.screensToUpdate.RemoveAt(this.screensToUpdate.Count - 1);
                screen.Update(gameTime, anotherScreenHasFocus, coveredByAnotherScreen); 
                if(screen.ScreenState == ScreenState.TransitionOn || screen.ScreenState == ScreenState.Active)
                {
                    if (!anotherScreenHasFocus)
                    {
                        //screen.HandleInput()
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach(var screen in this.gameScreens)
            {
                if (screen.ScreenState == ScreenState.Hidden)
                {
                    continue;
                }
                screen.Draw(gameTime);
            }
        }
        #endregion

    }
}
