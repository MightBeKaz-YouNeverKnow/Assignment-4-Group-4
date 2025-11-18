using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class PlayerCollision
    {
        public void CollisionDetection(Player playerOne, PlayerTwo playerTwo)
        {
            // Player 1 Sides
            float playerOneLeft = playerOne.position.X - 25;
            float playerOneRight = playerOne.position.X + 25;
            float playerOneTop = playerOne.position.Y - 25;
            float playerOneBottom = playerOne.position.Y + 25;

            // Player 2 Sides
            float playerTwoLeft = playerTwo.position.X - 25;
            float playerTwoRight = playerTwo.position.X + 25;
            float playerTwoTop = playerTwo.position.Y - 25;
            float playerTwoBottom = playerTwo.position.Y + 25;

            // Bounce Players away from each other (Left & Right)
            if (playerOneLeft <= playerTwoRight &&
                playerOneRight >= playerTwoLeft)
            {
                playerOne.velocity.X = -playerOne.velocity.X;
                playerTwo.velocity.X = -playerTwo.velocity.X;
            }
            // Bounce Players away from each other (Top & Bottom)
            if (playerOneTop <= playerTwoBottom &&
                playerOneBottom >= playerTwoTop)
            {
                //playerOne.velocity.Y = -playerOne.velocity.Y;
                //playerTwo.velocity.Y = -playerTwo.velocity.Y;
            }
        }
    }
}