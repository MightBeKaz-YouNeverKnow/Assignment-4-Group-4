using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 position = new Vector2(0, 0);
        public Vector2 velocity;

        // Transparent Hitbox
        Color hitbox = new Color(0, 0, 0, 30);

        // Keyboard Input Controls
        public KeyboardInput keyJump;
        public KeyboardInput keyLeft;
        public KeyboardInput keyRight;
        public void Setup()
        {
            // Draw Player 1
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
            Draw.Circle(position.X + 100, position.Y + 500, 25);
            // Player 1 Transparent Hitbox
            Draw.LineSize = 0;
            Draw.FillColor = hitbox;
            Draw.Square(position.X + 75, position.Y + 475, 25 * 2);

            // Draw Player 2
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Green;
            Draw.Circle(position.X + 1100, position.Y + 500, 25);
            // Player 2 Transparent Hitbox
            Draw.LineSize = 0;
            Draw.FillColor = hitbox;
            Draw.Square(position.X + 1075, position.Y + 475, 25 * 2);

            PlayerControls();
            PlayerGravity();
        }
        public void PlayerControls()
        {
            // Player Jump
            if (Input.IsKeyboardKeyPressed(keyJump))
            {
                position.Y -= 100;
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
            if (position.Y + 25 > Window.Height)
            {
                position.Y = Window.Height - 25;
                velocity.Y = 0;
            }
        }
    }
}
