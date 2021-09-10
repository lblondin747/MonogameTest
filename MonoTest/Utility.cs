using System;
using Microsoft.Xna.Framework;

namespace MonoTest
{
    public static class Utility
    {
        public static int Clamp(int value, int min, int max)
        {
            if(min>max)
            {
                throw new ArgumentOutOfRangeException("Min > Max");
            }
            if(value<min)
            {
                return min;
            }
            else if(value > max)
            {
                return max;
            }
            else
            {
                return value;
            }
        }
        public static float Clamp(float value, float min, float max)
        {
            if (min > max)
            {
                throw new ArgumentOutOfRangeException("Min > Max");
            }
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }
            else
            {
                return value;
            }
        }
        public static float Distance(Vector2 a, Vector2 b)
        {
            float dx = b.X - a.X;
            float dy = b.Y - a.Y;
            return MathF.Sqrt(dx * dx + dy * dy);

        }
        public static float DistanceSquared(Vector2 a, Vector2 b)
        {
            float dx = b.X - a.X;
            float dy = b.Y - a.Y;
            return dx * dx + dy * dy;

        }

        public static float Dot(Vector2 a, Vector2 b)
        {
            return a.X * b.X + a.Y * b.Y;
        }
        public static float yOut(float xIn, int type)
        {
            if (type == 1)
                return xIn * (xIn * .001f);
            else if (type == 2)
                return 0;
            else if (type == 3)
                return (xIn - 100f) * (xIn - 100f) * .003f;
            else if (type == 4)
                return (xIn - 200f) * (xIn - 200f) * .0035f;
            else if (type == 5)
                return (xIn - 100f) * (xIn - 100f) * .004f;
            else if (type == 6)
                return -((xIn - 100f) * (xIn - 100f) * .003f);
            return 0;
        }
    }
}
