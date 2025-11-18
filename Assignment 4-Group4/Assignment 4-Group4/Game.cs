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
        float player1x = 0.0f;
        float player1y = 0.0f;
        float player2x = 0.0f;
        float player2y = 0.0f;
        float player1Speed = 4.0f;
        float player2Speed = 4.0f;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Plumber The Hedgehog");
            Window.SetSize(1200, 600);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                player1y -= player1Speed;
            }
            if (Raylib.IsKeyDown (KeyboardKey.A)) 
            {
             player1x -= player1Speed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                player1y += player1Speed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                player1x += player1Speed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {
                player2y -= player2Speed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                player2x -= player2Speed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.Down))
            {
                player2y += player2Speed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                player2x += player2Speed;
            }
            Draw.FillColor = (Color.Red);
            Draw.Circle(player1x, player1y, 25);
           
            Draw.FillColor = (Color.Green);
            Draw.Circle(player2x, player2y, 25);
        }
    }

}
