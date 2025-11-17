using Raylib_cs;
using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        // Player 1 XY position
        float player1x = 0.0f;
        float player1y = 0.0f;

        // Player 2 XY position
        float player2x = 0.0f;
        float player2y = 0.0f;

        // Player Speed
        float player1Speed = 4.0f;
        float player2Speed = 4.0f;

        // Player Collision Variables
        bool playerOneLeftCollidePlayerTwoRight;
        bool playerOneRightCollidePlayerTwoLeft;
        bool playerOneBottomCollidePlayerTwoTop;
        bool playerOneTopCollidePlayerTwoBottom;
        public void Setup()
        {
            Window.SetTitle("Assignment 4 - Group 4");
            Window.SetSize(1200, 600);
        }
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
        void PlayerCollisionDetection()
        {
            // Check if Right side of Player 1 collides with Left side of Player 2
            if (player1x + 25 == player2x - 25)
            {
                playerOneLeftCollidePlayerTwoRight = true;
            }
            else
            {
                playerOneLeftCollidePlayerTwoRight = false;
            }
            // Check if Left side of Player 1 collides with Right side of Player 2
            if (player1x - 25 == player2x + 25)
            {
                playerOneRightCollidePlayerTwoLeft = true;
            }
            else
            {
                playerOneRightCollidePlayerTwoLeft = false;
            }
            // Check if Bottom of Player 1 collides with Top of Player 2
            if (player1y + 25 == player2y - 25)
            {
                playerOneBottomCollidePlayerTwoTop = true;
            }
            else
            {
                playerOneBottomCollidePlayerTwoTop = false;
            }
            // Check if Top of Player 1 collides with Bottom of Player 2
            if (player1y - 25 == player2y + 25)
            {
                playerOneTopCollidePlayerTwoBottom = true;
            }
            else
            {
                playerOneTopCollidePlayerTwoBottom = false;
            }

            /* 
                SEPERATOR
            */

            // Bounce Players away from each other (P1 = Left | P2 = Right)
            if (playerOneLeftCollidePlayerTwoRight == true)
            {
                player1x -= player1Speed * 2;
                player2x += player2Speed * 2;
            }
            // Bounce Players away from each other (P1 = Right | P2 = Left)
            if (playerOneRightCollidePlayerTwoLeft == true)
            {
                player1x += player1Speed * 2;
                player2x -= player1Speed * 2;
            }
            // Bounce Players away from each other (P1 = Bottom | P2 = Top)
            if (playerOneBottomCollidePlayerTwoTop == true)
            {
                player1y -= player1Speed * 2;
                player2y += player2Speed * 2;
            }
            // Bounce Players away from each other (P1 = Top | P2 = Bottom)
            if (playerOneTopCollidePlayerTwoBottom == true)
            {
                player1y += player1Speed * 2;
                player2y -= player1Speed * 2;
            }
        }
    }
}