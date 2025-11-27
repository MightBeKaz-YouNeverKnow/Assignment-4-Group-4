using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 position = new Vector2(0, 0);
        public Vector2 velocity;
        public int size = 25;

        // Colour of Player + Transparent Hitbox
        public Color playerColour;
        Color transparent = new Color(0, 0, 0, 0);

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

            // Draw Transparent Square Hitbox on Player
            Draw.LineSize = 0;
            Draw.FillColor = transparent;
            Draw.Square(position.X - size, position.Y - size, size * 2);
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
            if (position.Y + size > Window.Height)
            {
                position.Y = Window.Height - size;
                velocity.Y = 0;
            }
        }
    }
}
