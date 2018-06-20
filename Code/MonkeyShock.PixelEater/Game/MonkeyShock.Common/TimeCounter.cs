﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyShock.Common
{
    public class TimeCounter
    {
        private int savedTotalGameTime = 0; // seconds
        private Action onTimesUpAction; 

        public int RemainingTime { get; private set; }

        public TimeCounter(int intialSecondsNumber, Action onTimesUpAction)
        {
            this.RemainingTime = intialSecondsNumber;
            this.onTimesUpAction = onTimesUpAction; 
        }

        public void Update(GameTime gameTime)
        {
            var currentGameTotalTime = (int)gameTime.TotalGameTime.TotalSeconds;

            if (this.savedTotalGameTime == 0)
            {
                this.savedTotalGameTime = currentGameTotalTime;
            }
            else
            {
                if (this.savedTotalGameTime < currentGameTotalTime && this.RemainingTime > 0)
                {
                    this.savedTotalGameTime = currentGameTotalTime;
                    this.RemainingTime--;
                }
            }

            if(RemainingTime == 0)
            {
                this.onTimesUpAction.Invoke();
            }
        }

    }
}
