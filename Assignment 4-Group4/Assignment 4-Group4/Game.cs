using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        // Call Player Class twice to create 2 Players
        Player playerOne = new Player();
        Player playerTwo = new Player();
        public void Setup()
        {
            Window.SetTitle("Plumber The Hedgehog");
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

            // Draw Players
            playerOne.Setup();
            playerTwo.Setup();
            CollisionDetection(); // Call Collision Detection function
        }
        public void CollisionDetection()
        {
            // Calculate Player Positions from each other + Sum of both Players' radius'
            float distanceBetweenPlayers = Vector2.Distance(playerOne.position, playerTwo.position);
            float sumOfPlayerRadius = playerOne.size + playerTwo.size;

            // Check distance between players based on the sum of their radius
            if (distanceBetweenPlayers < sumOfPlayerRadius)
            {
                // If colliding, set Player velocity to 0
                playerOne.velocity.X = 0;
                playerOne.velocity.Y = 0;
                playerTwo.velocity.X = 0;
                playerTwo.velocity.Y = 0;

                // If colliding, push Player positions away from each other to prevent getting stuck
                playerOne.position.X -= 5;
                playerOne.position.Y -= 5;
                playerTwo.position.X += 5;
                playerTwo.position.Y += 5;
            }
            else 
            {   
                // If NOT colliding, Call Player Controls & Gravity
                playerOne.PlayerControls();
                playerOne.PlayerGravity();

                playerTwo.PlayerControls();
                playerTwo.PlayerGravity();
            }
        }
    }
}