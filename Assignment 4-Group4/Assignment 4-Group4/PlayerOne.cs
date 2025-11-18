using Raylib_cs;
using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class PlayerOne
    {
        public Vector2 position = new Vector2(100, 500);
        public Vector2 velocity;
        public void Setup()
        {
            // Draw Player 1
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
            Draw.Circle(position.X, position.Y, 25);

            PlayerOneControls();
            PlayerOneGravity();
        }
        public void PlayerOneControls()
        {
            // Player 1 Jump
            if (Input.IsKeyboardKeyPressed(KeyboardInput.W))
            {
                position.Y -= 100;
            }
            // Player 1 Move Left
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                position.X -= 10;
            }
            // Player 1 Move Right
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                position.X += 10;
            }
        }
    }
}
