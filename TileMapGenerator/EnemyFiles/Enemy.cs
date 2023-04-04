using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
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
        private Vector2 origin;
        public static List<Enemy> enemyList = new List<Enemy>();
        public Enemy(int posX, int posY)
        {
            enemyPos = new Vector2(posX, posY);
            enemyTexture = new Texture2D(Globals.graphics, 50, 50);
            textureData = new Color[50 * 50];
            for (int i = 0; i < textureData.Length; i++)
            {
                textureData[i] = Color.Red;
            }
            enemyTexture.SetData(textureData);
            origin = new Vector2(enemyTexture.Width / 2, enemyTexture.Height / 2);
        }
      
        public void Update(int type , Player player , Projectile grenade)
        {
            if(type ==1)
            {
            rotation = (float)Math.Atan2(player.playerPos.Y - enemyPos.Y, player.playerPos.X - enemyPos.X);
            }
            if(type ==2)
            {
            rotation = (float)Math.Atan2(grenade.position.Y - enemyPos.Y, grenade.position.X - enemyPos.X);
            }
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(enemyTexture, enemyPos, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
