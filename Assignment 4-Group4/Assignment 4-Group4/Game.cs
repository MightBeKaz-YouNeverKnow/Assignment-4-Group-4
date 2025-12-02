using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace MohawkGame2D
{
    public class Game
    {
        // Two players & music
        Player playerOne = new Player();
        Player playerTwo = new Player();
        OST OST = new OST();

        // Graphics
        Texture2D ground;
        Texture2D plumber;
        Texture2D fausta;
        Texture2D platform;
        Texture2D ring;
        Texture2D iceFlower;
        Texture2D background;

        // Moving platforms
        List<MovingPlatform> movingPlatforms = new List<MovingPlatform>();

        // Coins
        List<Coin> coins = new List<Coin>();

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

            // Create moving platforms
            var mp1 = new MovingPlatform();
            mp1.Setup(200, 450, 60, 150);
            movingPlatforms.Add(mp1);

            var mp2 = new MovingPlatform();
            mp2.Setup(600, 350, 80, 120);
            movingPlatforms.Add(mp2);

            var mp3 = new MovingPlatform();
            mp3.Setup(900, 250, 50, 200);
            movingPlatforms.Add(mp3);

            // Create coins (positions are examples; adjust as desired)
            coins.Add(new Coin { respawnDelay = 5f }); coins[^1].Init(new Vector2(300, 450));
            coins.Add(new Coin { respawnDelay = 5f }); coins[^1].Init(new Vector2(500, 400));
            coins.Add(new Coin { respawnDelay = 5f }); coins[^1].Init(new Vector2(700, 350));
            coins.Add(new Coin { respawnDelay = 5f }); coins[^1].Init(new Vector2(900, 450));
            coins.Add(new Coin { respawnDelay = 5f }); coins[^1].Init(new Vector2(600, 250));

            //Music
            if (Raylib.GetRandomValue(0, 2) == 0)
            {
                Audio.Play(OST.FUN);
            }
            if (Raylib.GetRandomValue(0, 2) == 1)
            {
                Audio.Play(OST.TOKYO);
            }
        }  


        public void Update()
        {
            // Clear background
            Window.ClearBackground(Color.OffWhite);

            Graphics.Draw(background, 0, 0);
            Graphics.Draw(ground, 0, 600);

            // Prepare players for this frame (store previous position for collision logic)
            playerOne.BeginFrame();
            playerTwo.BeginFrame();

            // Run controls and physics for both players
            playerOne.PlayerControls();
            playerOne.PlayerGravity();

            playerTwo.PlayerControls();
            playerTwo.PlayerGravity();

            // Update moving platforms (they also draw themselves)
            foreach (var mp in movingPlatforms)
            {
                mp.Update();
            }

            // Resolve collisions between players and moving platforms
            foreach (var mp in movingPlatforms)
            {
                mp.ResolveCollision(playerOne);
                mp.ResolveCollision(playerTwo);
            }

            // Handle collisions between players
            CollisionDetection();

            Texture2D sonic = default;
            Texture2D tails = default;
            // Draw assets (player sprites)
            //Graphics.Draw(sonic, playerOne.position);
            //Graphics.Draw(tails, playerTwo.position);

            // Draw a platform texture at a fixed position (kept for compatibility)
            //Graphics.Draw(platform, 600, 300);

            // Update, draw coins and check for collection
            foreach (var coin in coins)
            {
                coin.Update();
                coin.Draw();

                if (coin.active)
                {
                    if (coin.CheckCollected(playerOne)) { }
                    else
                    {
                        coin.CheckCollected(playerTwo);
                    }
                }
            }

            // Draw players (circles)
            playerOne.Setup();
            playerTwo.Setup();

            // Draw player scores on screen
            Raylib.DrawText($"P1: {playerOne.score}", 10, 10, 20, Color.Black);
            Raylib.DrawText($"P2: {playerTwo.score}", Window.Width - 120, 10, 20, Color.Black);
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