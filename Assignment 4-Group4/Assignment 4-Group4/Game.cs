using System;
using System.Numerics;
//using Raylib_cs;

namespace MohawkGame2D
{
    public class Game
    {
        // Two players
        Player playerOne = new Player();
        Player playerTwo = new Player();

        // Graphics
        Texture2D ground;
        Texture2D plumber;
        Texture2D fausta;
        Texture2D platform;
        Texture2D ring;
        Texture2D iceFlower;
        Texture2D background;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // Window configuration
            Window.SetTitle("Assignment 4 - Group 4");
            Window.SetSize(1200, 600);

            // Load graphics (paths are relative to executable; adjust if needed)
            ground = Graphics.LoadTexture("../../../../../assets/graphics/ground.png");
            plumber = Graphics.LoadTexture("../../../../../assets/graphics/plumberS.png");
            fausta = Graphics.LoadTexture("../../../../../assets/graphics/faustaS.png");
            platform = Graphics.LoadTexture("../../../../../assets/graphics/platformS.png");
            ring = Graphics.LoadTexture("../../../../../assets/graphics/ringS.png");
            iceFlower = Graphics.LoadTexture("../../../../../assets/graphics/ice flowerS.png");
            background = Graphics.LoadTexture("../../../../../assets/graphics/background.png");

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

            // Draw players (circles)
            playerOne.Setup();
            playerTwo.Setup();

            // Draw assets
             Graphics.Draw(background, 0, 0);

             Graphics.Draw(ground, 0, 560);

             Graphics.Draw(plumber, playerOne.position);
             Graphics.Draw(fausta, playerTwo.position);

             Graphics.Draw(ring, 300, 495);
             Graphics.Draw(iceFlower, 800, 500);

            // Draw a platform at a fixed position
            
                Graphics.Draw(platform, 600, 300);
            
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