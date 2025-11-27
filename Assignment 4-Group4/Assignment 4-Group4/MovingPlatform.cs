using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class MovingPlatform
    {
        public Vector2 position;
        Vector2 velocity;
        public int width;
        public int height;
        Color color;
        Color transparent = new Color(0, 0, 0, 0);
        public void Setup(int x, int y, int speed, int w)
        {
            // Spawn position of platforms
            position = new Vector2(x, y);

            // Random direction that platform moves towards
            Vector2 direction = new Vector2(Random.Integer(-1, 1), Random.Integer(-1, 1));
            velocity = direction * speed;

            // Platform size & colour
            width = w;
            height = 5;
            color = Color.Black;
        }
        public void Update()
        {
            // Movement of the platforms
            position += velocity * Time.DeltaTime;

            // Platform sides for game window collision
            float platformLeft = position.X;
            float platformRight = position.X + width;
            float platformTop = position.Y;
            float platformBottom = position.Y + height;

            // Constrains the platforms to the game window
            if (platformLeft <= 0) // If platform bumps the left side of the window, reverse velocity
            {
                position.X = 0;
                velocity.X = -velocity.X;
            }
            if (platformRight >= Window.Width) // If platform bumps the right side of the window, reverse velocity
            {
                position.X = Window.Width - width;
                velocity.X = -velocity.X;
            }
            if (platformTop <= 0) // If platform bumps the top of the window, reverse velocity
            {
                position.Y = 0;
                velocity.Y = -velocity.Y;
            }
            if (platformBottom >= Window.Height) // If platform bumps the bottom of the window, reverse velocity
            {
                position.Y = Window.Height - height;
                velocity.Y = -velocity.Y;
            }

            // Draw the platforms
            Draw.LineSize = 1;
            Draw.LineColor = color;
            Draw.FillColor = color;
            Draw.Rectangle(position.X, position.Y, width, height);

            // Draw ellipse shaped transparent hitbox
            Draw.LineSize = 0;
            Draw.FillColor = transparent;
            Draw.Ellipse(position.X + (width / 2), position.Y + (height / 2), width, height);
        }
    }
}