using System;
using Microsoft.Xna.Framework;
using MonoTest.Graphics;
using MonoTest;
namespace MonogameTest
{
    public class Ball : Entity
    {
        public Ball(Random rand, float x,float y,Screen screen, float density, float bounce,float radius,Color color,bool goal)
            : base(radius,Vector2.Zero,color,density,bounce,goal)
        {
            float py;
            float px;
            if (goal)
            {
                py = y;
                px = x;
            }
            else
            {
                px = rand.Next(1, screen.Width);
                py = rand.Next(1, screen.Height);
            }
            this.position = new Vector2(px, py);

            float minSpeed = 40f;
            float maxSpeed = 120f;

            float randAng = rand.Next();

            Vector2 velDir = new Vector2(MathF.Cos(randAng),MathF.Sin(randAng));
            float speed = rand.Next((int)minSpeed, (int)maxSpeed);

            this.velocity = velDir * speed;

            this.area = MathHelper.Pi * this.radius * this.radius;
            this.mass = this.area * this.density;
            this.invMass = 1 / mass;

        }
    }
}
