using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZombieGame.Managers;
using ZombieGame.ProjectileFile;

namespace ZombieGame.EnemyFiles
{
    internal class Enemy
    {
        public Vector2 enemyPos;
        public Texture2D enemyTexture;
        private Color[] textureData;
        public float rotation;
        public float Health = 100;
        public float animationCounter = 0.2f;
        private Vector2 origin;
        public int counter = 5;
        public static List<Enemy> enemyList = new List<Enemy>();
        public Enemy(int posX, int posY)
        {
            enemyPos = new Vector2(posX, posY);
            enemyTexture = Globals.content.Load<Texture2D>("zombie1");
            //enemyTexture = new Texture2D(Globals.graphics, 50, 50);
            //textureData = new Color[50 * 50];
            //for (int i = 0; i < textureData.Length; i++)
            //{
            //    textureData[i] = Color.Red;
            //}
            //enemyTexture.SetData(textureData);
            origin = new Vector2(enemyTexture.Width / 2, enemyTexture.Height / 2);
        }

        public void Update(int type, Player player, Projectile grenade)
        {

            if (type == 1)
            {
                rotation = (float)Math.Atan2(player.playerPos.Y - enemyPos.Y, player.playerPos.X - enemyPos.X);
            }
            if (type == 2)
            {
                rotation = (float)Math.Atan2(grenade.position.Y - enemyPos.Y, grenade.position.X - enemyPos.X);
            }

         


            foreach (Enemy enemy in enemyList)
            {
                if (this != enemy)
                {
                    if (Vector2.Distance(enemyPos, enemy.enemyPos) < 50)
                    {
                        Vector2 movDir = enemy.enemyPos - enemyPos;
                        movDir.Normalize();
                        enemy.enemyPos += movDir;
                    }
                }
            }
        }
       
        public void Draw()
        {
            Globals.spriteBatch.Draw(enemyTexture, enemyPos, null, Color.White, rotation, origin, 2f, SpriteEffects.FlipHorizontally, 0f);
        }
    }
}
