using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class PlayerTwo
    {
        public Vector2 position = new Vector2(1100, 500);
        public Vector2 velocity;
        public void Setup()
        {
            // Draw Player 2
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
            Draw.Circle(position.X, position.Y, 25);
        }
    }
}