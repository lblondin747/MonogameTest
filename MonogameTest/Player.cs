using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace MonogameTest
{
    public class Player : Entity
    {
        public Player(float radius, Vector2 position, Color color,float density,float bounce,bool goal)
            : base(radius,position,color,density,bounce,goal)
        {
            this.area = MathHelper.Pi * this.radius * this.radius;
            this.mass = this.area * this.density;
            this.invMass = 1 / mass;

        }

        public void ApplyForce(float amount,int dir)
        {
            if (dir == 1)
                this.velocity.X += amount;
            else if (dir == 2)
                this.velocity.X -= amount;
            else if (dir == 3)
                this.velocity.Y += amount * 30;
        }

        
    }

}
