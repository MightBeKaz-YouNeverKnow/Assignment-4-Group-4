using System;
using System.Numerics;
using Raylib_cs;

namespace MohawkGame2D
{
    public class MovingPlatform
    {
        public Vector2 position;
        public Vector2 velocity;
        public int width;
        public int height;
        Color color;
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
        }

        /// <summary>
        /// Resolve collision between this rectangular platform and a circular player.
        /// - If player lands on top (previous Y + size was <= platform top) then place player on top and zero Y velocity.
        /// - If collision happens from the side or bottom, push player out along the collision vector.
        /// Carries player horizontally by platform velocity when landed.
        /// </summary>
        public void ResolveCollision(Player player)
        {
            // Nearest point on the rectangle to the player's circle center
            float nearestX = Math.Clamp(player.position.X, position.X, position.X + width);
            float nearestY = Math.Clamp(player.position.Y, position.Y, position.Y + height);
            var nearest = new Vector2(nearestX, nearestY);

            float dist = Vector2.Distance(player.position, nearest);
            if (dist >= player.size) return; // no collision

            // Determine if the player was above the platform in the previous frame ( landing case )
            if (player.previousPosition.Y + player.size <= position.Y)
            {
                // Land on top of the platform
                player.position.Y = position.Y - player.size;
                player.velocity.Y = 0;
                player.onPlatform = true;

                // Carry horizontally with the platform (frame-based)
                player.position += new Vector2(velocity.X * Time.DeltaTime, 0);
                return;
            }

            // Otherwise handle a simple push-out along collision normal
            Vector2 pushDir = player.position - nearest;
            if (pushDir == Vector2.Zero)
            {
                // arbitrary push if exactly overlapped
                pushDir = new Vector2(0, -1);
            }
            pushDir = Vector2.Normalize(pushDir);
            float penetration = player.size - dist;
            player.position += pushDir * penetration;

            // If the collision had a large vertical component push, null Y velocity to avoid sticking
            if (Math.Abs(pushDir.Y) > Math.Abs(pushDir.X) * 0.5f)
            {
                player.velocity.Y = 0;
            }
        }
    }
}