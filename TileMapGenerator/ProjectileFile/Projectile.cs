using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZombieGame.Managers;

namespace ZombieGame
{
    internal class Projectile
    {
        public Vector2 position;
        public Vector2 velocity;
        private Color[] textureData;
        private Texture2D projectileTexure;
        public static List<Projectile> projectileList = new List<Projectile>();
        public Projectile(Player player , GraphicsDevice graphics)
        {
            position= new Vector2(player.playerPos.X , player.playerPos.Y) ;
            textureData = new Color[20 * 20];
            projectileTexure = new Texture2D(graphics,20,20);
            
            for(int i = 0; i < textureData.Length; i++)
            {
                textureData[i] = Color.Black;    
            }
            projectileTexure.SetData(textureData);
        }
        public void Update()
        {

        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(projectileTexure, position, Color.White);
        }
    }
}
