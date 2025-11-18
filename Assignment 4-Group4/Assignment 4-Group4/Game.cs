using Raylib_cs;
using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        PlayerOne playerOne = new PlayerOne();
        PlayerTwo playerTwo = new PlayerTwo();
        PlayerCollision playerCollision = new PlayerCollision();
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
            playerCollision.CollisionDetection(playerOne, playerTwo);
        }
    }
}