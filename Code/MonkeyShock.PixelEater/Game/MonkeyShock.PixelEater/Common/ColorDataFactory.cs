using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyShock.PixelEater.Common
{
    public class ColorDataFactory
    {
        public Color[] Get(int colorArraySize, Color color)
        {
            Color[] colorData = new Color[colorArraySize];
            for (int i = 0; i < colorArraySize; i++)
            {
                colorData[i] = color;
            }
            return colorData; 
        }
    }
}
