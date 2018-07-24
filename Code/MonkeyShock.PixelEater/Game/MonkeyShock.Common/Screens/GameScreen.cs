using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonkeyShock.Common.Screens
{
    //TODO: Finish implementation of GameScreen
    public abstract class GameScreen
    {
        protected bool anotherScreenHasFocus;

        #region Public properties
        public ScreenManager ScreenManager { get; internal set; }
        public ScreenState ScreenState { get; protected set; } = ScreenState.TransitionOn; 

        public bool IsPopup { get; protected set; } = false; 
        public TimeSpan TransitionOnTime { get; protected set; } = TimeSpan.Zero; 
        public TimeSpan TransitionOffTime { get; protected set; } = TimeSpan.Zero; 
        public float TransitionPosition { get; protected set; } = 1; 
        public byte TransitionAlpha { get { return (byte)(255 - TransitionPosition * 255); } }
        public bool IsExisting { get; protected set; } = false;
        public bool IsActive {
            get {
                return !this.anotherScreenHasFocus
                    && (this.ScreenState == ScreenState.TransitionOn || this.ScreenState == ScreenState.Active);
                }
        }
        #endregion

        public virtual void LoadContent() { }
        public virtual void UnloadContent() { }

        public virtual void Initialize() {}

        internal void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        internal void Update(GameTime gameTime, bool anotherScreenHasFocus, bool coveredByAnotherScreen)
        {
            this.anotherScreenHasFocus = anotherScreenHasFocus;
            if (this.IsExisting)
            {
                this.ScreenState = ScreenState.TransitionOff; 
                //TODO: Finish implementation
            }
        }
    }
}
