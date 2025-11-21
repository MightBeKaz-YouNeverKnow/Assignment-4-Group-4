using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        Player playerOne = new Player();
        Player playerTwo = new Player();
        PlayerCollision playerCollision = new PlayerCollision();
        public void Setup()
        {
            Window.SetTitle("Assignment 4 - Group 4");
            Window.SetSize(1200, 600);

            // Player 1 colour + spawn position
            playerOne.playerColour = Color.Red;
            playerOne.position.X = 100;
            playerOne.position.Y = 500;
            // Player 1 controls
            playerOne.keyJump = KeyboardInput.W;
            playerOne.keyLeft = KeyboardInput.A;
            playerOne.keyRight = KeyboardInput.D;

            // Player 2 colour + spawn position
            playerTwo.playerColour = Color.Green;
            playerTwo.position.X = 1100;
            playerTwo.position.Y = 500;
            // Player 2 controls
            playerTwo.keyJump = KeyboardInput.Up;
            playerTwo.keyLeft = KeyboardInput.Left;
            playerTwo.keyRight = KeyboardInput.Right;
        }
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            playerOne.Setup();
            playerTwo.Setup();
            CollisionDetection();
        }
        public void CollisionDetection()
        {
            // Calculate Player Positions from each other
            float distanceBetweenPlayers = Vector2.Distance(playerOne.position, playerTwo.position);
            float sumOfPlayerRadius = playerOne.size + playerTwo.size;

            if (distanceBetweenPlayers < sumOfPlayerRadius)
            {
                playerOne.velocity.X = 0;
                playerOne.velocity.Y = 0;

                playerTwo.velocity.X = 0;
                playerTwo.velocity.Y = 0;
            }
            else { }

            //// Calculate Player Positions from each other
            //Vector2 playerOnePosition = playerOne.position;
            //Vector2 playerTwoPosition = playerTwo.position;
            //Vector2 playerOneToPlayerTwo = playerTwoPosition - playerOnePosition;
            //float distanceBetweenPlayers = playerOneToPlayerTwo.Length();

            //// Check if colliding, stops players from moving
            //if (distanceBetweenPlayers < playerOne.size - playerTwo.size)
            //{
            //    playerOne.velocity.X = 0;
            //    playerTwo.velocity.Y = 0;

            //    playerTwo.velocity.X = 0;
            //    playerTwo.velocity.Y = 0;
            //}
            //else { }


            //// Player 1 Sides
            //float playerOneLeft = playerOne.position.X;
            //float playerOneRight = playerOne.position.X + playerOne.size * 2;
            //float playerOneTop = playerOne.position.Y;
            //float playerOneBottom = playerOne.position.Y + playerOne.size * 2;

            //// Player 2 Sides
            //float playerTwoLeft = playerTwo.position.X;
            //float playerTwoRight = playerTwo.position.X + playerTwo.size * 2;
            //float playerTwoTop = playerTwo.position.Y;
            //float playerTwoBottom = playerTwo.position.Y + playerTwo.size * 2;

            //// Bounce Players away from each other (Left & Right)
            //if (playerOneLeft <= playerTwoRight &&
            //    playerOneRight >= playerTwoLeft)
            //{
            //    playerOne.velocity.X = 0;
            //    playerTwo.velocity.X = 0;
            //}
            //// Bounce Players away from each other (Top & Bottom)
            //if (playerOneTop <= playerTwoBottom &&
            //    playerOneBottom >= playerTwoTop)
            //{
            //    // playerOne.velocity.Y = 0;
            //    // playerTwo.velocity.Y = 0;
            //}
        }

    }
}