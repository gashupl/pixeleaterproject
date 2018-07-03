using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonkeyShock.Common;

namespace MonkeyShock.PixelEater.Objects
{
    class Food : GameObjectBase
    {
        public readonly int TextureSize = 10;

        public Food(Vector2 position)
        {
            this.position = position; 
        }
        public override void Initialize(GraphicsDevice graphicsDevice, ColorDataFactory colorDataFactory)
        {
            this.Texture = new Texture2D(graphicsDevice, TextureSize, TextureSize);
            this.Texture.SetData<Color>(colorDataFactory.Get(TextureSize * TextureSize, Color.Red));
        }
    }
}
