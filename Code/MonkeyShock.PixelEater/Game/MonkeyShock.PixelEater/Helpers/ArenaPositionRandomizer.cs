using Microsoft.Xna.Framework;
using MonkeyShock.PixelEater.Objects;
using System;

namespace MonkeyShock.PixelEater.Helpers
{
    class ArenaPositionRandomizer
    {
        private Arena arena;
        private int objectTextureSize; 
        public ArenaPositionRandomizer(Arena arena, int objectTextureSize)
        {
            this.arena = arena;
            this.objectTextureSize = objectTextureSize; 
        }

        public Vector2 GenerateRandomPosition()
        {
            var maxX = this.arena.Width - objectTextureSize;
            var maxY = this.arena.Heigth - objectTextureSize;

            var randomizer = new Random();
            var x = randomizer.Next(0, maxX);
            var y = randomizer.Next(0, maxY);

            return new Vector2(x + arena.Position.X, y + arena.Position.Y); 
        }
    }
}
