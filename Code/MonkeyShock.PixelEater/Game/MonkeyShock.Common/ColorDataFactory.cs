using Microsoft.Xna.Framework;

namespace MonkeyShock.Common
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
