using MonkeyShock.PixelEater.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyShock.PixelEater.Helpers
{
    class FoodFactory
    {
        private Arena arena;
        private ArenaPositionRandomizer positionRandomizer; 
        public FoodFactory(Arena arena)
        {
            this.positionRandomizer = new ArenaPositionRandomizer(arena); 

        }

        public Food Get()
        {
            var randomPosition = this.positionRandomizer.GenerateRandomPosition(); 
            var food = new Food(randomPosition);
            return food; 
        }
    }
}
