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
        float player1x = 100.0f;
        float player1y = 400.0f;
        float player2x = 850.0f;
        float player2y = 400.0f;
        float player1Speed = 4.0f;
        float player2Speed = 4.0f;

        //variables for graphics
        Texture2D sonic;
        Texture2D tails;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            //general config
            Window.SetTitle("Assignment 4 - Group 4");
            Window.SetSize(1200, 600);

            //load graphics
            sonic = Graphics.LoadTexture("../../../../../assets/graphics/sonic.png");
            tails = Graphics.LoadTexture("../../../../../assets/graphics/tails.png");
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            //player movement
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

            //draw sonic asset
            Graphics.Draw(sonic, player1x, player1y);
           
           //draw tails asset
            Graphics.Draw(tails, player2x, player2y);
        }
    }

}
