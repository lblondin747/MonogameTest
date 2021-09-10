using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest;
using MonoTest.Graphics;

namespace MonogameTest
{
    public abstract class Entity
    {
        protected float radius;
        protected Vector2 position;
        protected Vector2 velocity;
        protected float angle;
        protected Color color;
        public Color CircleColor;
        public bool goal;
        //protected Circle collisionCircle;

        protected float mass;
        protected float invMass;
        protected float density;
        protected float bounce;
        protected float area;
        public Entity(float radius, Vector2 position, Color color, float density,float bounce,bool goal)
        {
            this.radius = radius;
            this.position = position;
            this.velocity = Vector2.Zero;
            this.angle = 0f;
            this.color = color;
            this.goal = goal;
            this.area = 0f;
            this.density = density;
            this.bounce = bounce;
            this.mass = 0f;
            this.invMass = 1f;

            //this.collisionCircle = Entity.CollisionCircle(radius);

        }
        public float InvMass
        {
            get { return this.invMass; }
        }
        public float Bounce
        {
            get { return this.bounce; }
        }
        public Vector2 Position
        {
            get { return this.position; }
        }

        public Vector2 Velocity
        {
            get { return this.velocity;  }
            set { this.velocity = value; }
        }

        public float Radius
        {
            get { return this.radius; }
        }
   
        public virtual void Update(GameTime gameTime,Screen screen)
        {
            if(!goal)
            this.position += this.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            float viewWidth = screen.Width;
            float viewHeight = screen.Height;

            this.velocity.Y -= 2f;
            
            if(this.position.X - this.radius < 0) { this.position.X = this.radius; this.velocity.X = -this.velocity.X * .8f; }
            if (this.position.X + this.radius > viewWidth) { this.position.X = viewWidth - this.radius; this.velocity.X = -this.velocity.X *.8f; }
            if (this.position.Y - this.radius < 0) { this.position.Y = this.radius; this.velocity.Y = -this.velocity.Y *.8f; }
            if (this.position.Y > viewHeight) { this.position.Y = viewHeight - this.radius; this.velocity.Y = -this.velocity.Y *.8f; }
            this.CircleColor = color;
        }

        public void Move(Vector2 amount)
        {
            this.position += amount;
        }

        public virtual void Draw(Shapes shapes)
        {
            shapes.DrawCircle(position.X,position.Y,radius,32,2f,this.color);
            shapes.DrawCircle(this.position.X, this.position.Y, radius, 32, 2f, this.CircleColor);
        }

        protected static Circle CollisionCircle(float radius)
        {
            float circleRadius = radius;
            return new Circle(0f, 0f, circleRadius);
        }
    }
}
