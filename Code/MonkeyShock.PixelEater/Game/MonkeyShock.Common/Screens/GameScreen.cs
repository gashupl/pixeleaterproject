using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonkeyShock.Common.Screens
{
    public abstract class GameScreen
    {
        public ScreenManager ScreenManager { get; set; }
        public ScreenState ScreenState { get; internal set; }

        internal void Initialize()
        {
            throw new NotImplementedException();
        }

        internal void UnloadContent()
        {
            throw new NotImplementedException();
        }

        internal void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        internal void Update(GameTime gameTime, bool anotherScreenHasFocus, bool coveredByAnotherScreen)
        {
            throw new NotImplementedException();
        }
    }
}
