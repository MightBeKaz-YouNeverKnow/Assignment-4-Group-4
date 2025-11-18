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
            Draw.FillColor = Color.Green;
            Draw.Circle(position.X, position.Y, 25);

            PlayerTwoControls();
        }
        public void PlayerTwoControls()
        {
            // Player 2 Jump
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Up))
            {
                position.Y -= 100;
            }
            // Player 2 Move Left
            if (Input.IsKeyboardKeyDown(KeyboardInput.Left))
            {
                position.X -= 10;
            }
            // Player 2 Move Right
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right))
            {
                position.X += 10;
            }
        }
    }
}