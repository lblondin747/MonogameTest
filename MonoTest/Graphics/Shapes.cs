using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoTest.Graphics
{
    public sealed class Shapes : IDisposable
    {
        public static readonly float MinLineThickness = 2f;
        public static readonly float MaxLineThickness = 20f;

        private bool isDisposed;
        private Game game;
        private BasicEffect effect;

        private VertexPositionColor[] vertices;
        private int[] indices;

        private int vertexCount;
        private int indexCount;
        private int shapeCount;

        private bool isStarted;

        public Shapes(Game game)
        {
            this.isDisposed = false;
            this.game = game ?? throw new ArgumentNullException("game");

            this.effect = new BasicEffect(this.game.GraphicsDevice);
            this.effect.TextureEnabled = false;
            this.effect.FogEnabled = false;
            this.effect.LightingEnabled = false;
            this.effect.VertexColorEnabled = true;
            this.effect.World = Matrix.Identity;
            this.effect.View = Matrix.Identity;
            this.effect.Projection = Matrix.Identity;
            

            const int MaxVertexCount = 1024;
            const int MaxIndexCount = MaxVertexCount * 3;

            this.vertices = new VertexPositionColor[MaxVertexCount];
            this.indices = new int[MaxIndexCount];

            this.shapeCount = 0;
            this.vertexCount = 0;
            this.indexCount = 0;

            this.isStarted = false;
        }
        public void Dispose()
        {
            if(this.isDisposed)
            {
                return;
            }

            this.effect?.Dispose();
            this.isDisposed = true;
        }
        public void Begin()
        {
            if(this.isStarted)
            {
                throw new Exception("batching already started");
            }

            Viewport vp = this.game.GraphicsDevice.Viewport;
            this.effect.Projection = Matrix.CreateOrthographicOffCenter(0, vp.Width, 0, vp.Height, 0f, 1f);
            

            this.isStarted = true;
        }
        public void End()
        {
            this.Flush();
            this.isStarted = false;
        }
        public void Flush()
        {
            if (this.shapeCount == 0)
            {
                return;
            }



            this.EnsureStarted();

            foreach(EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                this.game.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                    PrimitiveType.TriangleList,
                    this.vertices,
                    0,
                    this.vertexCount,
                    this.indices,
                    0,
                    this.indexCount/3
                    );
            }

            this.shapeCount = 0;
            this.indexCount = 0;
            this.vertexCount = 0;
        }
        public void EnsureSpace(int shapeVertexCount, int shapeIndexCount)
        {
            if (shapeVertexCount > this.vertices.Length)
            {
                throw new Exception("over max shape vertex count");
            }
                if(shapeIndexCount > this.indices.Length)
                {
                    throw new Exception("over max shape vertex count");

                }

                if (this.vertexCount + shapeVertexCount > this.vertices.Length || this.indexCount + shapeIndexCount > this.indices.Length)
            {
                Flush();
            }
            
        }
        public void EnsureStarted()
        {
            if (!this.isStarted)
            {
                throw new Exception("batching never started");
            }
        }

        public void DrawRectangle(float x, float y, float width, float height, Color color)
        {
            this.EnsureStarted();
            const int shapeVertexCount = 4;
            const int shapeIndexCount = 6;

            this.EnsureSpace(shapeVertexCount, shapeIndexCount);

            float left = x;
            float right = x + width;
            float bottom = y;
            float top = y + height;

            Vector2 a = new Vector2(left, top);
            Vector2 b = new Vector2(right, top);
            Vector2 c = new Vector2(right, bottom);
            Vector2 d = new Vector2(bottom, left);

            this.indices[this.indexCount++] = 0 + this.vertexCount;
            this.indices[this.indexCount++] = 1 + this.vertexCount;
            this.indices[this.indexCount++] = 2 + this.vertexCount;
            this.indices[this.indexCount++] = 0 + this.vertexCount;
            this.indices[this.indexCount++] = 2 + this.vertexCount;
            this.indices[this.indexCount++] = 3 + this.vertexCount;

            this.vertices[this.vertexCount++] = new VertexPositionColor(new Vector3(a, 0f), color);
            this.vertices[this.vertexCount++] = new VertexPositionColor(new Vector3(b, 0f), color);
            this.vertices[this.vertexCount++] = new VertexPositionColor(new Vector3(c, 0f), color);
            this.vertices[this.vertexCount++] = new VertexPositionColor(new Vector3(d, 0f), color);

            this.shapeCount++;
        }
        public void DrawEquation(float x, float y, float length, float thickness, Color color,int type)
        {
            //const int minPoints = 3;
            //const int maxPoints = 256;

            //points = Utility.Clamp(points, minPoints, maxPoints);

            

            for (float ix = 0; ix < length; ix++)
            {
                
                float ax = ix + x;
                float ay = Utility.yOut(ix,type) + y;

                

                float bx = (ix + 1) + x;
                float by = Utility.yOut(ix + 1,type) + y;

                this.DrawLine(new Vector2(ax, ay), new Vector2(bx, by), thickness, color);
            }
        }

        public void DrawLine(Vector2 a, Vector2 b, float thickness,Color color)
        {
            this.EnsureStarted();

            const int shapeVertexCount = 4;
            const int shapeIndexCount = 6;

            this.EnsureSpace(shapeVertexCount,shapeIndexCount);

            thickness = Utility.Clamp(thickness, Shapes.MinLineThickness, Shapes.MaxLineThickness);

            //float halfThickness -thickness / 2f;

            Vector2 e1 = b - a;
            e1.Normalize();
            e1 *= thickness / 2;

            Vector2 e2 = -e1;
            Vector2 n1 = new Vector2(-e1.Y, e1.X);
            Vector2 n2 = -n1;

            Vector2 q1 = a + n1 + e2;
            Vector2 q2 = b + n1 + e1;
            Vector2 q3 = b + n2 + e1;
            Vector2 q4 = a + n2 + e2;

            this.indices[this.indexCount++] = 0 + this.vertexCount;
            this.indices[this.indexCount++] = 1 + this.vertexCount;
            this.indices[this.indexCount++] = 2 + this.vertexCount;
            this.indices[this.indexCount++] = 0 + this.vertexCount;
            this.indices[this.indexCount++] = 2 + this.vertexCount;
            this.indices[this.indexCount++] = 3 + this.vertexCount;

            this.vertices[this.vertexCount++] = new VertexPositionColor(new Vector3(q1, 0f), color);
            this.vertices[this.vertexCount++] = new VertexPositionColor(new Vector3(q2, 0f), color);
            this.vertices[this.vertexCount++] = new VertexPositionColor(new Vector3(q3, 0f), color);
            this.vertices[this.vertexCount++] = new VertexPositionColor(new Vector3(q4, 0f), color);

            shapeCount++;


        }
        public void DrawCircle(float x, float y, float radius, int points, float thickness, Color color)
        {
            const int minPoints = 3;
            const int maxPoints = 256;

            points = Utility.Clamp(points, minPoints, maxPoints);

            float deltaAngle = MathHelper.TwoPi / (float)points;
            float angle = 0f;

            for (int i = 0; i < points; i++)
            {
                float ax = MathF.Sin(angle) * radius + x;
                float ay = MathF.Cos(angle) * radius + y;

                angle += deltaAngle;

                float bx = MathF.Sin(angle) * radius + x;
                float by = MathF.Cos(angle) * radius + y;

                this.DrawLine(new Vector2(ax, ay),new Vector2(bx, by), thickness, color);
            }
        }

    }
}
