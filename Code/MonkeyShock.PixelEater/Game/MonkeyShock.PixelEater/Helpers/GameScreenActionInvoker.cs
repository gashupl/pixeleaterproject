using MonkeyShock.Common;
using MonkeyShock.PixelEater.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyShock.PixelEater.Helpers
{
    class GameScreenActionInvoker
    {
        private Action<List<Food>> generateFoodAction;
        private List<Food> food; 
        private TimeCounter timeCounter;
        private int lastRemainingTime;
        private int invokeFrequencySeconds; 

        public GameScreenActionInvoker(TimeCounter timeCounter)
        {
            this.timeCounter = timeCounter;
            this.lastRemainingTime = this.timeCounter.InitialTime; 
        }

        public void AddGenerateFoodAction(Action<List<Food>> generateFoodAction, List<Food> food, int invokeFrequencySeconds)
        {
            this.generateFoodAction = generateFoodAction;
            this.food = food; 
            this.invokeFrequencySeconds = invokeFrequencySeconds; 
        }

        public void Update()
        {
            var timeDifference = lastRemainingTime - timeCounter.RemainingTime; 
            if(timeDifference == invokeFrequencySeconds)
            {
                this.generateFoodAction.Invoke(food);
                lastRemainingTime = timeCounter.RemainingTime; 
            }
        }
    }
}
