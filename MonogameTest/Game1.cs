using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTest;
using MonoTest.Graphics;
using MonoTest.Input;
using System.Collections.Generic;
using MonoTest.Physics;


namespace MonogameTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;


        private Sprites sprites;
        private Texture2D texture;
        private Screen screen;
        private Shapes shapes;

        private Player player;
        private Camera camera;

        private List<Entity> entities;
        private List<Line> lines;

        private static bool jump;
        private static int? level;
        private int? levelBeat;
        private int? prevLevel;

        private Goal goal;
        private static bool win;

        private SpriteFont font;
        private SpriteFont title;
        private float time;
        private float transitionTime;
        private float nTime;

        private float[] starTime;
        private int starCount;


        private bool tut;
        private int tutScreen;
        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.SynchronizeWithVerticalRetrace = true;
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.IsFixedTimeStep = true;
        }

        protected override void Initialize()
        {
            nTime = 0f;
            this.graphics.PreferredBackBufferWidth = 1280;
            this.graphics.PreferredBackBufferHeight = 720;
            this.graphics.ApplyChanges();

            this.entities = new List<Entity>();
            this.lines = new List<Line>();

            this.sprites = new Sprites(this);
            this.screen = new Screen(this, 1280, 720);
            this.shapes = new Shapes(this);

            jump = true;

            Random rand = new Random(0);

            camera = new Camera();

            win = false;

            if (level is null)
            {
                level = 0;
                levelBeat = 0;
            }
            time = 0f;
            transitionTime = 0f;

            if (level == 0)
            {
                prevLevel = 0;
                tut = true;
                tutScreen = 0;
                starCount = 0;
                player = new Player(16, new Vector2(32f, 320f), Color.Blue, 6000, .3f, false);
                this.entities.Add(player);
                this.starTime = new float[1];
                this.starTime[0] = 1000f;
                goal = new Goal(1030, 30);                
                
                
            }
                if (level == 1)
            {
                starCount = 5;

                this.starTime = new float[6];
                this.starTime[0] = -10f;
                this.starTime[1] = 10f;
                this.starTime[2] = 13f;
                this.starTime[3] = 17f;
                this.starTime[4] = 20f;
                this.starTime[5] = 25f;
                player = new Player(16, new Vector2(200f, 220f), Color.Blue, 6000, .3f,false);
                this.entities.Add(player);
                Line line1 = new Line(5, 85, 30, 200, Color.White, 2f);
                this.lines.Add(line1);
                Line line2 = new Line(5, 800, 280, 200, Color.White, 2f);
                this.lines.Add(line2);

                Line line4 = new Line(5, 438, 155, 200, Color.White, 2f);
                this.lines.Add(line4);

                Line line5 = new Line(5, 438, 405, 200, Color.White, 2f);
                this.lines.Add(line5);

                Line line3 = new Line(5, 85, 500, 200, Color.White, 2f);
                this.lines.Add(line3);

                Line bottom = new Line(2, 0, 10, 1280, Color.White, 2f);
                this.lines.Add(bottom);

                goal = new Goal(30, 650);

                Line goalLine = new Line(1, goal.x, goal.y, 1, Color.Red, 20f);
                this.lines.Add(goalLine);

                


            }
                if(level == 2)
            {
                starCount = 5;

                this.starTime = new float[6];
                this.starTime[0] = -10f;
                this.starTime[1] = 6f;
                this.starTime[2] = 8f;
                this.starTime[3] = 10f;
                this.starTime[4] = 12f;
                this.starTime[5] = 15f;
                player = new Player(16, new Vector2(32f, 320f), Color.Blue, 6000, .3f, false);
                this.entities.Add(player);
                Line line1 = new Line(1, 100, 60, 300, Color.White, 2f);
                this.lines.Add(line1);
                Line line2 = new Line(3, 700, 300, 200, Color.White, 2f);
                this.lines.Add(line2);

                Line line3 = new Line(4, 100, 300, 200, Color.White, 2f);
                this.lines.Add(line3);

                Line bottom = new Line(2, 0, 10, 1280, Color.White, 2f);
                this.lines.Add(bottom);

                goal = new Goal(30, 650);

                Line goalLine = new Line(1, goal.x, goal.y, 1, Color.Red, 20f);
                this.lines.Add(goalLine);



                
            }
            if (level == 3)
            {
                
                starCount = 5;

                this.starTime = new float[6];
                this.starTime[0] = -10f;
                this.starTime[1] = 7f;
                this.starTime[2] = 10f;
                this.starTime[3] = 14f;
                this.starTime[4] = 16f;
                this.starTime[5] = 20f;
                player = new Player(16, new Vector2(300f, 120f), Color.Blue, 6000, .3f, false);
                this.entities.Add(player);
                Line line1 = new Line(5, 260, 30, 200, Color.White, 2f);
                this.lines.Add(line1);
                Line line2 = new Line(5, 820, 125, 200, Color.White, 2f);
                this.lines.Add(line2);

                Line line3 = new Line(5, 260, 230, 200, Color.White, 2f);
                this.lines.Add(line3);
                Line line4 = new Line(5, 820, 335, 200, Color.White, 2f);
                this.lines.Add(line4);
                Line line5 = new Line(5, 260, 440, 200, Color.White, 2f);
                this.lines.Add(line5);

                Line bottom = new Line(2, 0, 10, 1280, Color.White, 2f);
                this.lines.Add(bottom);

                goal = new Goal(30, 650);

                Line goalLine = new Line(1, goal.x, goal.y, 1, Color.Red, 20f);
                this.lines.Add(goalLine);




            }
            if (level == 4)
            {

                starCount = 5;

                this.starTime = new float[6];
                this.starTime[0] = -10f;
                this.starTime[1] = 7f;
                this.starTime[2] = 10f;
                this.starTime[3] = 15f;
                this.starTime[4] = 20f;
                this.starTime[5] = 25f;
                player = new Player(16, new Vector2(300f, 120f), Color.Blue, 6000, .3f, false);
                this.entities.Add(player);
                Line line1 = new Line(6, 260, 40, 200, Color.White, 2f);
                this.lines.Add(line1);
                Line line2 = new Line(6, 700, 100, 200, Color.White, 2f);
                this.lines.Add(line2);

                Line line3 = new Line(6, 380, 180, 200, Color.White, 2f);
                this.lines.Add(line3);
                Line line4 = new Line(6, 700, 260, 200, Color.White, 2f);
                this.lines.Add(line4);
                Line line6 = new Line(6, 380, 340, 200, Color.White, 2f);
                this.lines.Add(line6);
                Line line7 = new Line(6, 700, 420, 200, Color.White, 2f);
                this.lines.Add(line7);
                Line line5 = new Line(5, 260, 440, 200, Color.White, 2f);
                this.lines.Add(line5);
                Line line8 = new Line(2, 530, 455,50, Color.White, 2f);
                this.lines.Add(line8);

                Line bottom = new Line(2, 0, 10, 1280, Color.White, 2f);
                this.lines.Add(bottom);

                goal = new Goal(30, 650);

                Line goalLine = new Line(1, goal.x, goal.y, 1, Color.Red, 20f);
                this.lines.Add(goalLine);




            }







            //Line line3 = new Line(4, 700, 500, 200, Color.White, 2f);
            //this.lines.Add(line3);

            //int ballCt = 5;
            //for (int i = 0; i < ballCt; i++)
            //{
            //    Ball ball = new Ball(rand, screen, 12000, .99f, 16, Color.White);
            //    this.entities.Add(ball);
            //}

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Timer");
            title = Content.Load<SpriteFont>("File");
            this.texture = this.Content.Load<Texture2D>("star");
            
        }

        protected override void Update(GameTime gameTime)
        {
            if(nTime > 0)
                nTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            //player = (Player)this.entities[0]; 
            if (prevLevel != level)
                Initialize();
            prevLevel = level;
            KeyInput keyboard = KeyInput.Instance;
            keyboard.Update();
            float amount = 230f;
            if (keyboard.IsKeyClicked(Keys.Escape))
                this.Exit();
            if (keyboard.IsKeyClicked(Keys.N) && level != 0)
            {
                if (levelBeat >= level)
                    level++;
                else
                    nTime = 3f;
            }
            if(keyboard.IsKeyClicked(Keys.P))
            {
                if (level > 0)
                {
                    level--;
                }
            }
                
            if (keyboard.IsKeyClicked(Keys.R))
                Initialize();
            if (keyboard.IsKeyDown(Keys.Right))
            {
                player.ApplyForce(amount * (float)gameTime.ElapsedGameTime.TotalSeconds, 1);
            }
            if (keyboard.IsKeyClicked(Keys.Space) && jump && tutScreen > 0)
            {
                player.ApplyForce(amount * (float)gameTime.ElapsedGameTime.TotalSeconds, 3);
                jump = false;
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                player.ApplyForce(amount * (float)gameTime.ElapsedGameTime.TotalSeconds, 2);
            }
            if(tutScreen == 0)
            {
                if (keyboard.IsKeyClicked(Keys.Space))
                {
                    tutScreen++;
                    Line bottom = new Line(2, 0, 10, 1280, Color.White, 2f);
                    this.lines.Add(bottom);
                }
            }
            if (tutScreen == 2)
            {
                if (keyboard.IsKeyClicked(Keys.Space))
                {
                    tutScreen++;
                    Line goalLine = new Line(1, goal.x, goal.y, 1, Color.Red, 20f);
                    this.lines.Add(goalLine);
                }
            }
            if (tutScreen == 1)
            {
                if (keyboard.IsKeyClicked(Keys.Left) || (keyboard.IsKeyClicked(Keys.Right)))
                {
                    tutScreen++;
                }
            }
            if(tutScreen == 3)
            {
                if(Collision.IntersectGoal(new Circle(player.Position,player.Radius),new Vector2(goal.x,goal.y)))
                {
                    tutScreen++;

                }
            }
            if (tutScreen == 4)
            {
                transitionTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (transitionTime > 3)
                {
                    tutScreen++;
                    level++;
                    tut = false;
                    //Initialize();
                }
            }
            for (int i = 0; i < starTime.Length; i++)
            {
                if (time > starTime[i])
                {
                    starCount = 5 - i;
                }
            }
            if (!win)
            {
                time += (float)gameTime.ElapsedGameTime.TotalSeconds;

                player.Update(gameTime, screen);

                for (int i = 0; i < this.entities.Count; i++)
                {
                    this.entities[i].Update(gameTime, this.screen);
                }

                for (int i = 0; i < this.entities.Count; i++)
                {
                    Entity a = this.entities[i];
                    Circle ca = new Circle(a.Position, a.Radius);
                    if (Collision.IntersectGoal(ca, new Vector2(goal.x, goal.y)))
                    {
                        win = true;
                        if (starCount > 0)
                        {
                            if (level > levelBeat)
                                levelBeat = level;
                        }
                    }
                    for (int j = 0; j < this.entities.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        Entity b = this.entities[j];
                        Circle cb = new Circle(b.Position, b.Radius);

                        if (Collision.IntersectCircles(ca, cb, out float depth, out Vector2 normal))
                        {
                            Vector2 mtv = depth * normal;

                            Game1.SolveCollision(a, b, normal);

                            a.Move(-mtv / 2f);
                            b.Move(mtv / 2f);




                        }


                    }
                    //int lineCount = 0;
                    for (int j = 0; j < this.lines.Count; j++)
                    {
                        SolveCollision(a, lines[j]);
                        //float shortestDist = 1000f;
                        //float distHold = Utility.Distance(a.Position, new Vector2(lines[j].x, lines[j].y));
                        //if (distHold < shortestDist)
                        //{
                        //    shortestDist = distHold;
                        //    lineCount = j;
                        //}
                        //distHold = Utility.Distance(a.Position, new Vector2(lines[j].x + lines[j].length, Utility.yOut(lines[j].x + lines[j].length,1)));
                        //if (distHold < shortestDist)
                        //{
                        //    shortestDist = distHold;
                        //    lineCount = j;
                        //}

                    }



                }

                base.Update(gameTime);
            }
        }









        protected override void Draw(GameTime gameTime)
        {
            this.screen.Set();
            GraphicsDevice.Clear(Color.Black);

            Viewport vp = this.GraphicsDevice.Viewport;
            if (!tut)
            {
                this.sprites.Begin(false);
                for (int i = 0; i < starCount; i++)
                    this.sprites.Draw(texture, null, new Rectangle(625 + (i * 35), 648, 25, 25), Color.White);
                this.sprites.End();
            }

            this.shapes.Begin();
            if (tutScreen > 0)
            {
                for (int i = 0; i < this.entities.Count; i++)
                {
                    this.entities[i].Draw(this.shapes);
                }
            }
            
                for (int i = 0; i < this.lines.Count; i++)
                {
                    this.shapes.DrawEquation(lines[i].x, lines[i].y, lines[i].length, lines[i].thickness, lines[i].color, lines[i].type);

                }
            

            //this.shapes.DrawRectangle(goal.x, goal.y, Goal.width, Goal.height, Goal.color);
            //this.shapes.DrawRectangle(100, 100, 32, 32, Color.AliceBlue);
            //this.shapes.DrawLine(new Vector2(16, 16), new Vector2(640-16, 480-16), 2f, Color.Black);
            //this.shapes.DrawCircle(100, 32, 32, 48, 2f, Color.Black);
            this.shapes.End();
            spriteBatch.Begin();
            if(nTime > 0)
                spriteBatch.DrawString(font, $"Earn at least one star to advance levels", new Vector2(550, 250), Color.Gold);

            if (win && !tut)
            {
                if(starCount > 0)
                    spriteBatch.DrawString(font, $"Press N for next level, or R to restart", new Vector2(600, 200), Color.Gold);
                else
                    spriteBatch.DrawString(font, $"Press R to restart", new Vector2(600, 150), Color.Gold);

            }
            if (!tut)
            {
                spriteBatch.DrawString(font, $"{time:0.00}", new Vector2(500, 40), Color.Gold);
                spriteBatch.DrawString(font, $"{level}", new Vector2(1100, 40), Color.Gold);
            }
            else
            {
                if (tutScreen == 0)
                {
                    spriteBatch.DrawString(title, $"Hopper", new Vector2(540, 150), Color.Gold);
                    spriteBatch.DrawString(font, $"Press space to start", new Vector2(465, 300), Color.Gold);
                }
                else if (tutScreen == 1)
                {
                    spriteBatch.DrawString(font, $"Use the arrow keys to move left or right", new Vector2(310, 300), Color.Gold);

                }
                else if (tutScreen == 2)
                {
                    spriteBatch.DrawString(font, $"Press the spacebar to jump", new Vector2(440, 300), Color.Gold);

                }
                else if (tutScreen == 3)
                {
                    spriteBatch.DrawString(font, $"Collect the red square complete the level", new Vector2(310, 300), Color.Gold);

                }
                else if (tutScreen == 4)
                {
                    GraphicsDevice.Clear(Color.Black);

                    spriteBatch.DrawString(font, $"Tutorial Complete", new Vector2(500,300), Color.Gold);


                }
            }

            spriteBatch.End();
            this.screen.UnSet();
            this.screen.Present(this.sprites);

            base.Draw(gameTime);
        }













        public static void SolveCollision(Entity a, Entity b, Vector2 normal)
        {
            Vector2 relVel = b.Velocity - a.Velocity;

            if (Utility.Dot(relVel, normal) > 0f)
            {
                return;
            }

            float j = -(1f + a.Bounce) * Utility.Dot(relVel, normal);
            j /= a.InvMass + b.InvMass;

            Vector2 impulse = j * normal;

            a.Velocity -= a.InvMass * impulse;
            b.Velocity += b.InvMass * impulse;
        }
        public static void SolveCollision(Entity a, Line b)
        {
            Circle c = new Circle(a.Position, a.Radius);
            var overlap = new List<float>();
            float i = 0;
            for (; i < b.length; i++)
            {
                if(Utility.Distance(new Vector2(i+b.x,Utility.yOut(i,b.type)+b.y),a.Position) < a.Radius)
                {
                    overlap.Add(i);
                
                }
            }
            if(overlap.Count != 0)
            {
                jump = true;
                i = overlap[overlap.Count / 2];
                if (Collision.IntersectLine(c, new Vector2(i + b.x, Utility.yOut(i, b.type) + b.y), out float depth, out Vector2 normal))
                {
                    Vector2 mtv = depth * normal;
                    Vector2 relVel = -a.Velocity;
                    if (Utility.Dot(relVel, normal) > 0f)
                    {
                        return;
                    }

                    float j = -(1f + a.Bounce) * Utility.Dot(relVel, normal);
                    j /= a.InvMass;

                    Vector2 impulse = j * normal;

                    a.Velocity -= a.InvMass * impulse;
                    //b.Velocity += b.InvMass * impulse;

                    a.Move(-mtv / 2f);
                    return;





                }
            }
        }
    }
    
        
}
