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
       

        //variables for graphics
        Texture2D sonic;
        Texture2D tails;
        Texture2D platform;

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
            platform = Graphics.LoadTexture("../../../../../assets/graphics/platform.png");
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

          

            //draw sonic asset
             Graphics.Draw(sonic, player1x, player1y);
           
            //draw tails asset
             Graphics.Draw(tails, player2x, player2y);

            //draw platforms
             Graphics.Draw(platform, 600, 300);
        }
    }

}
