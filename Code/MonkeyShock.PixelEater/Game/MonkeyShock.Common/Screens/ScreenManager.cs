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

    }
}
