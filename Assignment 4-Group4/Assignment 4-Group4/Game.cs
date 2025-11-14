// Include the namespaces (code libraries) you need below.
using Raylib_cs;
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        float player1x = 100f;
        float player1y = 100f;
        float player2x = 1100f;
        float player2y = 100f;
        float player1Speed = 4.0f;
        float player2Speed = 4.0f;

        // Separate vertical velocities for each player
        float velocityY1 = 0f;
        float velocityY2 = 0f;

        // Physics (values are in pixels per second and pixels per second^2)
        float gravity = 500f;
        float jumpSpeed = 250f;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Assignment 4 - Group 4");
            Window.SetSize(1200, 600);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            // frame time
            float dt = Raylib.GetFrameTime();

            // Player 1 Controls
            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                player1y -= player1Speed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                player1x -= player1Speed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                player1x += player1Speed;
            }

            // Player 2 Controls
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {
                player2y -= player2Speed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                player2x -= player2Speed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                player2x += player2Speed;
            }

            float radius = 25f;
            float groundY = Raylib.GetScreenHeight() - radius;

            // Player 1 jumping and gravity
            bool onGround1 = player1y >= groundY;
            if (Raylib.IsKeyPressed(KeyboardKey.W))
            {
                if (onGround1)
                {
                    velocityY1= -jumpSpeed;
                }
            }

            // Apply gravity and integrate for player 1
            velocityY1 += gravity * dt;
            player1y += velocityY1 * dt;

            // Ground collision: stop falling and snap to ground for player 1
            if (player1y >= groundY)
            {
                player1y = groundY;
                velocityY1 = 0f;
            }

            // Clamp horizontal position so the circle stays visible for player 1
            player1x = Math.Clamp(player1x, radius, Raylib.GetScreenWidth() - radius);

            // Player 2 jumping and gravity
            bool onGround2 = player2y >= groundY;
            if (Raylib.IsKeyPressed(KeyboardKey.Up))
            {
                if (onGround2)
                {
                    velocityY2 = -jumpSpeed;
                }
            }

            // Apply gravity and integrate for player 2
            velocityY2 += gravity * dt;
            player2y += velocityY2 * dt;

            // Ground collision: stop falling and snap to ground for player 2
            if (player2y >= groundY)
            {
                player2y = groundY;
                velocityY2 = 0f;
            }

            // Clamp horizontal position so the circle stays visible for player 2
            player2x = Math.Clamp(player2x, radius, Raylib.GetScreenWidth() - radius);

            // Draw Player 1
            Draw.FillColor = (Color.Red);
            Draw.Circle(player1x, player1y, 25);

            // Draw Player 2
            Draw.FillColor = (Color.Green);
            Draw.Circle(player2x, player2y, 25);
        }
    }
}
