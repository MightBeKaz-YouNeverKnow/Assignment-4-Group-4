using Raylib_cs;
using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        PlayerOne playerOne = new PlayerOne();
        PlayerTwo playerTwo = new PlayerTwo();
        public void Setup()
        {
            Window.SetTitle("Assignment 4 - Group 4");
            Window.SetSize(1200, 600);
        }
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            playerOne.Setup();
            playerTwo.Setup();
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