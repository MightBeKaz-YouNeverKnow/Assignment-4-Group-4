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

            playerOne.keyJump = KeyboardInput.W;
            playerTwo.keyJump = KeyboardInput.Up;
        }
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            playerOne.Setup();
            playerTwo.Setup();
            playerCollision.CollisionDetection(playerOne, playerTwo);
        }
    }
}