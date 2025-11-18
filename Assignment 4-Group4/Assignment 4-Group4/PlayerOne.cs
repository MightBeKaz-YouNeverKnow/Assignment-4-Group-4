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
        public void PlayerOneGravity()
        {
            // Calculate Player 1 Gravity
            velocity += new Vector2(0, 40) * Time.DeltaTime;
            position += velocity;

            if (position.Y + 25 > Window.Height)
            {
                position.Y = Window.Height - 25;
                velocity.Y = 0;
            }
        }
    }
}
