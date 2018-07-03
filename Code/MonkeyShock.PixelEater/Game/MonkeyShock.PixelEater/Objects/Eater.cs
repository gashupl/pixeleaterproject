using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonkeyShock.Common;

namespace MonkeyShock.PixelEater.Objects
{
    class Eater : GameObjectBase
    {
        public readonly int TextureSize = 10;

        public Eater(Arena arena)
        {
            this.Position = new Vector2(arena.Position.X, arena.Position.Y);
        }

        public override void Initialize(GraphicsDevice graphicsDevice, ColorDataFactory colorDataFactory)
        {
            this.Texture = new Texture2D(graphicsDevice, TextureSize, TextureSize);
            this.Texture.SetData<Color>(colorDataFactory.Get(TextureSize * TextureSize, Color.Red));
        }

        public void MoveX(float pixelCount)
        {
            this.position.X += pixelCount; 
        }

        public void MoveY(float pixelCount)
        {
            this.position.Y += pixelCount; 
        }

    }
}
