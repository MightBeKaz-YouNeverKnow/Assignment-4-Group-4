using System.Numerics;
using Raylib_cs;

namespace MohawkGame2D
{
    public class Coin
    {
        public Vector2 position = new Vector2(0, 0);
        public Vector2 originalPosition;
        public int size = 12;

        // Active = visible / collectable. When false, coin is waiting to respawn.
        public bool active = true;

        // Seconds to wait before respawning
        public float respawnDelay = 5f;
        float respawnTimer = 0f;

        // Call once after construction to remember the spawn position
        public void Init(Vector2 spawnPosition)
        {
            position = spawnPosition;
            originalPosition = spawnPosition;
            active = true;
            respawnTimer = 0f;
        }

        public void Update()
        {
            if (!active)
            {
                respawnTimer -= Time.DeltaTime;
                if (respawnTimer <= 0f)
                {
                    Respawn();
                }
            }
        }

        public void Draw()
        {
            if (!active) return;

            // Replace Draw.LineSize, Draw.LineColor, Draw.FillColor with Raylib drawing functions
            Raylib.DrawCircle((int)position.X, (int)position.Y, size, Color.Yellow);
            Raylib.DrawCircleLines((int)position.X, (int)position.Y, size, Color.Black);
        }

        /// <summary>
        /// Returns true when collected this frame (increments player score and starts respawn).
        /// </summary>
        public bool CheckCollected(Player player)
        {
            if (!active) return false;

            float distance = Vector2.Distance(position, player.position);
            if (distance < size + player.size)
            {
                active = false;
                respawnTimer = respawnDelay;
                player.score++;
                return true;
            }

            return false;
        }

        void Respawn()
        {
            position = originalPosition;
            active = true;
        }
    }
}