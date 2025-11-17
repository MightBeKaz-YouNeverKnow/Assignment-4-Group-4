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

        // Player 1 XY position
        float player1x = 0.0f;
        float player1y = 0.0f;

        // Player 2 XY position
        float player2x = 0.0f;
        float player2y = 0.0f;

        // Player Speed
        float player1Speed = 4.0f;
        float player2Speed = 4.0f;

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

            // Player 1 controls
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

            // Player 2 controls
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
            
            // Draw Player 1
            Draw.FillColor = (Color.Red);
            Draw.Circle(player1x, player1y, 25);
           
            // Draw Player 2
            Draw.FillColor = (Color.Green);
            Draw.Circle(player2x, player2y, 25);
        }
    }

}
