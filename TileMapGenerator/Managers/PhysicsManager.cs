using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Managers;

namespace ZombieGame.EnemyFiles
{
    internal class PhysicsManager
    {
        public void enemyMovement(Player player)
        {
            foreach (Enemy enemy in Enemy.enemyList)
            {
                if (Vector2.Distance(player.playerPos, enemy.enemyPos) >= 50)
                {
                    Vector2 movDir = enemy.enemyPos - player.playerPos;
                    movDir.Normalize();
                    enemy.enemyPos -= movDir;
                }
            }
        }
    }
}
