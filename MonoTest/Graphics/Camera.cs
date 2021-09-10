using System;
using Microsoft.Xna.Framework;

namespace MonoTest.Graphics
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(float xPos)
        {

            var position = Matrix.CreateTranslation(xPos - (8f),0,0);

            var offset = Matrix.CreateTranslation(640, 1280, 0);

            Transform = position * offset;

        }
    }
}
