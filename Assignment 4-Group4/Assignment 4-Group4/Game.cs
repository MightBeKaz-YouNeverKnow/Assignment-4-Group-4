using System;
using System.Numerics;
using Raylib_cs;

namespace MohawkGame2D
{
    public class Game
    {
        // Two players
        Player playerOne = new Player();
        Player playerTwo = new Player();

        // Moving Platforms
        MovingPlatform[] platforms = new MovingPlatform[1];

        // Graphics
        Texture2D sonic;
        Texture2D tails;
        Texture2D platform;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // Window configuration
            Window.SetTitle("Assignment 4 - Group 4");
            Window.SetSize(1200, 600);

            // Load graphics (paths are relative to executable; adjust if needed)
            sonic = Graphics.LoadTexture("../../../../../assets/graphics/sonic.png");
            tails = Graphics.LoadTexture("../../../../../assets/graphics/tails.png");
            platform = Graphics.LoadTexture("../../../../../assets/graphics/platform.png");

            // Initialize player one
            playerOne.playerColour = Color.Red;
            playerOne.position.X = 100;
            playerOne.position.Y = 500;
            playerOne.keyJump = KeyboardInput.W;
            playerOne.keyLeft = KeyboardInput.A;
            playerOne.keyRight = KeyboardInput.D;

            // Initialize player two
            playerTwo.playerColour = Color.Green;
            playerTwo.position.X = 1100;
            playerTwo.position.Y = 500;
            playerTwo.keyJump = KeyboardInput.Up;
            playerTwo.keyLeft = KeyboardInput.Left;
            playerTwo.keyRight = KeyboardInput.Right;

            // Draw moving platforms
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i] = new MovingPlatform();
                
                // All of the Random values determine the XY coord spawn, speed, and size of the moving platform
                platforms[i].Setup(Random.Integer(100, 1100), Random.Integer(100, 500), Random.Integer(5, 10), Random.Integer(75, 175));
            }
        }

        public void Update()
        {
            // Clear background
            Window.ClearBackground(Color.OffWhite);

            // Run controls and physics for both players
            playerOne.PlayerControls();
            playerOne.PlayerGravity();

            playerTwo.PlayerControls();
            playerTwo.PlayerGravity();

            // Handle collisions between players
            CollisionDetection();

            // Draw assets
           
             Graphics.Draw(sonic, playerOne.position);
            
             Graphics.Draw(tails, playerTwo.position);

            // Draw a platform at a fixed position
            
            
                Graphics.Draw(platform, 600, 300);
            
            // Draw players (circles)
            playerOne.Setup();
            playerTwo.Setup();

            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].Update();
            }
        }

        private void CollisionDetection()
        {
            float distanceBetweenPlayers = Vector2.Distance(playerOne.position, playerTwo.position);
            float sumOfPlayerRadius = playerOne.size + playerTwo.size;

            if (distanceBetweenPlayers <= 0f)
            {
                // Prevent divide by zero; nudge players apart
                playerOne.position.X -= 1;
                playerTwo.position.X += 1;
                playerOne.velocity = Vector2.Zero;
                playerTwo.velocity = Vector2.Zero;
                return;
            }

            if (distanceBetweenPlayers < sumOfPlayerRadius)
            {
                // Compute overlap and separate players along the collision normal
                float overlap = sumOfPlayerRadius - distanceBetweenPlayers;
                Vector2 direction = Vector2.Normalize(playerOne.position - playerTwo.position);

                // Move each player half the overlap in opposite directions
                playerOne.position += direction * (overlap * 0.5f);
                playerTwo.position -= direction * (overlap * 0.5f);

                // Zero their velocities to stop them from sticking
                playerOne.velocity = Vector2.Zero;
                playerTwo.velocity = Vector2.Zero;
            }
        }
    }
}