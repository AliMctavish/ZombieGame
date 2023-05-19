using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.EnemyFiles;

namespace ZombieGame.Managers
{
    public class AnimationManager
    {
        public static void animateEnemy()
        {
            foreach (var enemy in Enemy.enemyList)
            {
                enemy.animationCounter -= Globals.time;

                if (enemy.animationCounter < 0)
                {
                    enemy.enemyTexture = Globals.content.Load<Texture2D>($"zombie{enemy.counter}");
                    enemy.animationCounter = 0.2f;
                    enemy.counter--;
                }
                if (enemy.counter == 0) { enemy.counter = 5; }
            }
        }
    }
}
