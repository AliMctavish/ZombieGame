using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Managers;

namespace ZombieGame.EnemyFiles
{
    internal class EnemyManager 
    {
        Random rnd = new Random();
        float spawnTime = 2f;
        float difficulityTimer = 10f;
        float spawnRate = 2f;
        public void Update(GameTime gameTime)
        {
            spawnTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            difficulityTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (spawnTime <= 0)
            {
                Enemy enemy = new Enemy(rnd.Next(0, 1200), rnd.Next(0, 600));
                Enemy.enemyList.Add(enemy);
                spawnTime = spawnRate;
            }
            if(difficulityTimer <= 0)
            {
                spawnRate -= 0.1f;
                difficulityTimer = 10f;
            }
        }
        public void Draw()
        {
            foreach (Enemy enemy in Enemy.enemyList)
            {
                enemy.Draw();
            }
        }
    }
}
