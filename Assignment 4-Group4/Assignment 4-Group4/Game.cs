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
        MovingPlatform[] platforms = new MovingPlatform[5];

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
                
                // All of the Random values determine the XY coord spawn, speed, and width size of the moving platform
                platforms[i].Setup(Random.Integer(100, 1100), Random.Integer(100, 500), // XY Coords
                                   Random.Integer(100, 200), // Speed
                                   Random.Integer(75, 175)); // Width Size
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
            PlayerOnPlayerCollisionDetection();

            // Draw assets
           
             Graphics.Draw(sonic, playerOne.position);
            
             Graphics.Draw(tails, playerTwo.position);

            // Draw a platform at a fixed position
            
            
                Graphics.Draw(platform, 600, 300);
            
            // Draw players (circles)
            playerOne.Setup();
            playerTwo.Setup();

            // Ensures platforms are constantly moving
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].Update();
                // PlayerOnPlatformCollisionDetection(platforms[i]);
            }
        }

        private void PlayerOnPlayerCollisionDetection()
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
        //private void PlayerOnPlatformCollisionDetection(MovingPlatform platforms)
        //{
        //    float distanceBetweenPlayerOneAndPlatform = Vector2.Distance(playerOne.position, platforms.position);
        //    float distanceBetweenPlayerTwoAndPlatform = Vector2.Distance(playerTwo.position, platforms.position);

        //    float sumOfPlayerOneRadiusAndPlatformWidth = playerOne.size + platforms.width;
        //    float sumOfPlayerOneRadiusAndPlatformHeight = playerOne.size + platforms.height;

        //    float sumOfPlayerTwoRadiusAndPlatformWidth = playerTwo.size + platforms.width;
        //    float sumOfPlayerTwoRadiusAndPlatformHeight = playerTwo.size + platforms.height;

        //    if (distanceBetweenPlayerOneAndPlatform <= 0f)
        //    {
        //        // Prevent divide by zero; nudge players apart
        //        playerOne.position.X -= 1;
        //        playerOne.velocity = Vector2.Zero;
        //        return;
        //    }

        //    if (distanceBetweenPlayerTwoAndPlatform <= 0f)
        //    {
        //        // Prevent divide by zero; nudge players apart
        //        playerTwo.position.X -= 1;
        //        playerTwo.velocity = Vector2.Zero;
        //        return;
        //    }

        //    if (distanceBetweenPlayerOneAndPlatform < sumOfPlayerOneRadiusAndPlatformWidth &&
        //        distanceBetweenPlayerOneAndPlatform < sumOfPlayerOneRadiusAndPlatformHeight)
        //    {
        //        // Compute overlap and separate players along the collision normal
        //        float overlapWidth = sumOfPlayerOneRadiusAndPlatformWidth - distanceBetweenPlayerOneAndPlatform;
        //        float overlapHeight = sumOfPlayerOneRadiusAndPlatformHeight - distanceBetweenPlayerOneAndPlatform;
        //        Vector2 direction = Vector2.Normalize(playerOne.position - platforms.position);

        //        // Move each player half the overlap in opposite directions
        //        playerOne.position += direction * (overlapWidth * 0.5f);
        //        playerOne.position += direction * (overlapHeight * 0.5f);

        //        // Zero their velocities to stop them from sticking
        //        playerOne.velocity = Vector2.Zero;
        //    }

        //    if (distanceBetweenPlayerTwoAndPlatform < sumOfPlayerTwoRadiusAndPlatformWidth &&
        //        distanceBetweenPlayerTwoAndPlatform < sumOfPlayerTwoRadiusAndPlatformHeight)
        //    {
        //        // Compute overlap and separate players along the collision normal
        //        float overlapWidth = sumOfPlayerTwoRadiusAndPlatformWidth - distanceBetweenPlayerTwoAndPlatform;
        //        float overlapHeight = sumOfPlayerTwoRadiusAndPlatformHeight - distanceBetweenPlayerTwoAndPlatform;
        //        Vector2 direction = Vector2.Normalize(playerTwo.position - platforms.position);

        //        // Move each player half the overlap in opposite directions
        //        playerTwo.position += direction * (overlapWidth * 0.5f);
        //        playerTwo.position += direction * (overlapHeight * 0.5f);

        //        // Zero their velocities to stop them from sticking
        //        playerTwo.velocity = Vector2.Zero;
        //    }

            //float playerOneLeft = playerOne.position.X - playerOne.size;
            //float playerOneRight = playerOne.position.X + playerOne.size;
            //float playerOneTop = playerOne.position.Y - playerOne.size;
            //float playerOneBottom = playerOne.position.Y + playerOne.size;

            //float playerTwoLeft = playerTwo.position.X - playerTwo.size;
            //float playerTwoRight = playerTwo.position.X + playerTwo.size;
            //float playerTwoTop = playerTwo.position.Y - playerTwo.size;
            //float playerTwoBottom = playerTwo.position.Y + playerTwo.size;

            //float platformLeft = platforms.position.X;
            //float platformRight = platforms.position.X + platforms.width;
            //float platformTop = platforms.position.Y;
            //float platformBottom = platforms.position.Y + platforms.height;

            //// Player Left collides Platform Right
            //if (playerOneLeft <= platformRight)
            //{
            //    playerOne.position.X -= 1;
            //    playerOne.velocity.X = 0;
            //}
            //if (playerTwoLeft <= platformRight)
            //{
            //    playerTwo.position.X -= 1;
            //    playerTwo.velocity.X = 0;
            //}

            //// Player Right collides Platform Left
            //if (playerOneRight >= platformLeft)
            //{
            //    playerOne.position.X += 1;
            //    playerOne.velocity.X = 0;
            //}
            //if (playerTwoRight <= platformLeft)
            //{
            //    playerTwo.position.X += 1;
            //    playerTwo.velocity.X = 0;
            //}

            //// Player Top collides Platform Bottom
            //if (playerOneTop <= platformBottom)
            //{
            //    playerOne.position.Y -= 1;
            //    playerOne.velocity.Y = 0;
            //}
            //if (playerTwoTop <= platformBottom)
            //{
            //    playerTwo.position.Y -= 1;
            //    playerTwo.velocity.Y = 0;
            //}

            //// Player Bottom collides Platform Bottom
            //if (playerOneBottom >= platformTop)
            //{
            //    playerOne.position.Y += 1;
            //    playerOne.velocity.Y = 0;
            //}
            //if (playerTwoBottom >= platformTop)
            //{
            //    playerTwo.position.Y += 1;
            //    playerTwo.velocity.Y = 0;
            //}
        //}
    }
}