using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class PlayerOne
    {
        public Vector2 position = new Vector2();
        Vector2 velocity;
        public int size;
        public void Setup()
        {
            // Setup random XY coords for Player spawn position
            position = new Vector2(100, 500);

            // Hard code size variable
            size = 25;

            // Draw Player 1
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
            Draw.Circle(position.X, position.Y, size);
        }
    }
}
