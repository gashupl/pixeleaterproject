using Microsoft.Xna.Framework.Graphics;
using MonkeyShock.Common;
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
            this.positionRandomizer = new ArenaPositionRandomizer(arena, Food.TextureSize); 

        }

        public Food Get(GraphicsDevice graphicsDevice, ColorDataFactory colorDataFactory)
        {
            var randomPosition = this.positionRandomizer.GenerateRandomPosition(); 
            var food = new Food(randomPosition);
            food.Initialize(graphicsDevice, colorDataFactory); 
            return food; 
        }
    }
}
