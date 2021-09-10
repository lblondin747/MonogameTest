using System;
using Microsoft.Xna.Framework;
namespace MonoTest
{
    public class Line
    {
        public int type { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float length { get; set; }
        public Color color { get; set; }
        public float thickness { get; set; }

        public Line(int type,float x, float y, float length, Color color, float thickness)
        {
            this.color = color;
            this.type = type;
            this.x = x;
            this.y = y;
            this.thickness = thickness;
            this.length = length;


        }
        
    }
}
