using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZombieGame.Managers;

namespace ZombieGame
{
    internal class Projectile
    {
        public Vector2 position;
        public float velocity = 200f;
        private Color[] textureData;
        private Texture2D projectileTexure;
        private Player GetPlayer;
        float mousePosX,mousePosY;
        
        public static List<Projectile> projectileList = new List<Projectile>();
        public Projectile(Player player , GraphicsDevice graphics)
        {
            GetPlayer = player;
            position= new Vector2(player.playerPos.X , player.playerPos.Y) ;
            textureData = new Color[20 * 20];
            projectileTexure = new Texture2D(graphics,20,20);
            
            for(int i = 0; i < textureData.Length; i++)
            {
                textureData[i] = Color.Black;    
            }
            projectileTexure.SetData(textureData);

            mousePosX = Mouse.GetState().X;
            mousePosY = Mouse.GetState().Y;

        }
        public void Update()
        {
            shooting();
        }
        public void shooting()
        {

            MouseState mouseState = Mouse.GetState();
         
            Vector2 mousePos = new Vector2(mousePosX, mousePosY);
            Vector2 movDir = this.position - mousePos ;
            movDir.Normalize();
            this.position -= movDir* 12;
            velocity += 1;
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(projectileTexure, position, Color.White);
        }
    }
}
