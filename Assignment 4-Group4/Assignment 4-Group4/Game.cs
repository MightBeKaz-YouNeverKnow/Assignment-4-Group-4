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
            Draw.Circle(player1x + 100, player1y + 100, 25);
           
            // Draw Player 2
            Draw.FillColor = (Color.Green);
            Draw.Circle(player2x + 1100, player2y + 100, 25);

            PlayerCollisionDetection();
        }
        public void PlayerCollisionDetection()
        {
            // Player 1 Sides
            float playerOneLeft = player1x - 25;
            float playerOneRight = player1x + 25;
            float playerOneTop = player1y - 25;
            float playerOneBottom = player1y + 25;

            // Player 2 Sides
            float playerTwoLeft = player2x - 25;
            float playerTwoRight = player2x + 25;
            float playerTwoTop = player2y - 25;
            float playerTwoBottom = player2y + 25;

            // Check Collision
            bool playerOneLeftCollidePlayerTwoRight = playerOneLeft <= playerTwoRight;
            bool playerOneRightCollidePlayerTwoLeft = playerOneRight >= playerTwoLeft;
            bool playerOneTopCollidePlayerTwoBottom = playerOneTop <= playerTwoBottom;
            bool playerOneBottomCollidePlayerTwoTop = playerOneBottom >= playerTwoTop;

            // Bounce Players away from each other (Left & Right)
            if (playerOneLeftCollidePlayerTwoRight &&
                playerOneRightCollidePlayerTwoLeft &&
                playerOneTopCollidePlayerTwoBottom &&
                playerOneBottomCollidePlayerTwoTop)
            {
                player1Speed = -player1Speed;
                player2Speed = -player2Speed;
            }
        }
    }
}