using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZombieGame.Effects;
using System.Threading.Tasks;
using ZombieGame.Managers;
using ZombieGame.ProjectileFile;

namespace ZombieGame.EnemyFiles
{
    internal class PhysicsManager
    {
        Player player;
        public PhysicsManager(Player player)
        {
            this.player = player;
        }
        public void enemyMovement()
        {
            foreach (Enemy enemy in Enemy.enemyList.ToList())
            {
                if (Projectile.projectileList.Count == 0)
                {
                    enemy.Update(1, player, null);
                }
                if (Vector2.Distance(player.playerPos, enemy.enemyPos) >= 50)
                {
                    Vector2 movDir = enemy.enemyPos - player.playerPos;
                    movDir.Normalize();
                    enemy.enemyPos -= movDir;
                }
                foreach (Projectile projectile in Projectile.projectileList.ToList())
                {
                    if (Vector2.Distance(enemy.enemyPos, projectile.position) <= 30)
                    {
                        if (projectile.GetType() == typeof(Projectile))
                        {
                            Vector2 movDir = projectile.position - enemy.enemyPos;
                            movDir.Normalize();
                            enemy.enemyPos -= movDir;
                            Projectile.projectileList.Remove(projectile);
                        enemy.Health -= 1;
                        }
                        if (projectile.GetType() == typeof(ShotGun))
                        {
                            Vector2 movDir = projectile.position - enemy.enemyPos;
                            movDir.Normalize();
                            enemy.enemyPos -= movDir * 2;
                            Projectile.projectileList.Remove(projectile);
                            enemy.Health -= 5;
                        }
                        if (enemy.Health <= 0)
                        {
                            for (int i = 0; i < 20; i++)
                            {
                                var deadEffect = new DeadEffect();
                                deadEffect.CreateDeadEffect(enemy.enemyPos.X, enemy.enemyPos.Y);
                            }
                            Enemy.enemyList.Remove(enemy);
                        }
                    }
                    if (Projectile.projectileList.Count > 100)
                    {
                        if (projectile.GetType() != typeof(Grenade))
                        {
                            Projectile.projectileList.Remove(projectile);
                        }
                    }
                    if (projectile.GetType() == typeof(Grenade))
                    {
                        enemy.Update(2, player, projectile);
                        Vector2 movDir = enemy.enemyPos - projectile.position;
                        movDir.Normalize();
                        enemy.enemyPos -= movDir * 2;
                    }
                    else
                    {
                        enemy.Update(1, player, null);
                    }
                }
            }
        }
        public static void OnExplotionEffect(ExplosionEffect effect)
        {
            foreach (var enemy in Enemy.enemyList.ToList())
            {
                if (Vector2.Distance(effect.position, enemy.enemyPos) <= 50)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        var deadEffect = new DeadEffect();
                        deadEffect.CreateDeadEffect(enemy.enemyPos.X, enemy.enemyPos.Y);
                    }
                        Enemy.enemyList.Remove(enemy);
                }
            }
        }


    }
}
