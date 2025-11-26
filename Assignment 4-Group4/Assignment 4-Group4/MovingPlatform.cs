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

            // Draw the platforms
            Draw.LineSize = 1;
            Draw.LineColor = color;
            Draw.FillColor = color;
            Draw.Rectangle(position.X, position.Y, width, height);
        }
    }
}