using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 position = new Vector2(0, 0);
        public Vector2 velocity;
        public int size = 25;

        // Colour of Player
        public Color playerColour;

        // Keyboard Input Controls
        public KeyboardInput keyJump;
        public KeyboardInput keyLeft;
        public KeyboardInput keyRight;
        public void Setup()
        {
            // Draw Player
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = playerColour;
            Draw.Circle(position.X, position.Y, size);
        }
        public void PlayerControls()
        {
            // Player Jump
            if (velocity.Y == 0)
            {
                if (Input.IsKeyboardKeyPressed(keyJump))
                {
                    velocity.Y = -10;
                }
            }
            // Player Move Left
            if (Input.IsKeyboardKeyDown(keyLeft))
            {
                position.X -= 10;
            }
            // Player Move Right
            if (Input.IsKeyboardKeyDown(keyRight))
            {
                position.X += 10;
            }
        }
        public void PlayerGravity()
        {
            // Calculate Player Gravity
            velocity += new Vector2(0, 40) * Time.DeltaTime;
            position += velocity;

            // Ensures Player doesn't fall off map
            if (position.Y + size > Window.Height)
            {
                position.Y = Window.Height - size;
                velocity.Y = 0;
            }
        }
    }
}
