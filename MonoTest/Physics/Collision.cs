﻿using System;
using Microsoft.Xna.Framework;

namespace MonoTest.Physics
{
    public static class Collision
    {
        public static bool IntersectCircles(Circle a, Circle b)
        {
            float distSq = Utility.DistanceSquared(a.Center, b.Center);
            float r2 = a.Radius + b.Radius;
            float radiusSq = r2 * r2;

            if (distSq >= radiusSq)
            {
                return false;
            }
            return true;
        }
        public static bool IntersectCircles(Circle a, Circle b, out float depth, out Vector2 normal)
        {
            depth = 0f;
            normal = Vector2.Zero;
            Vector2 n = b.Center - a.Center;
            float distSq = n.LengthSquared();
            float r2 = a.Radius + b.Radius;
            float radiusSq = r2 * r2;

            if (distSq >= radiusSq)
            {
                return false;
            }

            float dist = MathF.Sqrt(distSq);
            if (dist != 0)
            {
                depth = r2 - dist;
                normal = n / dist;
            }
            else
            {
                depth = r2;
                normal = new Vector2(1f, 0f);
            }
            return true;

        }
        public static bool IntersectLine(Circle a, Vector2 b, out float depth, out Vector2 normal)
        {
            depth = 0f;
            normal = Vector2.Zero;
            Vector2 n = b - a.Center;
            float distSq = n.LengthSquared();
            float r2 = a.Radius;
            float radiusSq = r2 * r2;

            if (distSq >= radiusSq)
            {
                return false;
            }

            float dist = MathF.Sqrt(distSq);
            if (dist != 0)
            {
                depth = r2 - dist;
                normal = n / dist;
            }
            else
            {
                depth = r2;
                normal = new Vector2(1f, 0f);
            }
            return true;

        }
        public static bool IntersectGoal(Circle a, Vector2 b)
        {
            Vector2 x = new Vector2(11f, 0f);
            Vector2 y = new Vector2(0f, 11f);
            Vector2 n = b - x - a.Center;
            float distSq = n.LengthSquared();
            float r2 = a.Radius;
            float radiusSq = r2 * r2;
            if (distSq < radiusSq)
            {
                return true;
            }
            n = b + x - a.Center;
            distSq = n.LengthSquared();
            if (distSq < radiusSq)
            {
                return true;
            }
            n = b + y - a.Center;
            distSq = n.LengthSquared();
            if (distSq < radiusSq)
            {
                return true;
            }
            n = b - y - a.Center;
            distSq = n.LengthSquared();
            if (distSq < radiusSq)
            {
                return true;
            }
            return false;



        }
    }
}