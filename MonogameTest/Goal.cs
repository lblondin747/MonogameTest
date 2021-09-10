using System;
using Microsoft.Xna.Framework;

namespace MonogameTest
{
    public class Goal
    {
        public Goal(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public float x { get; set; }
        public float y { get; set; }
        public static float width = 20;
        public static float height = 20;
        public static Color color = Color.Red;
    }
}
