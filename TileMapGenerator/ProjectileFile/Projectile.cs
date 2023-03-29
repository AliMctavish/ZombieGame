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
        private Vector2 origin;
        private Player GetPlayer;
        float mousePosX,mousePosY;
        Random rand= new Random();
        public static List<Projectile> projectileList = new List<Projectile>();
        List<Color> colors = new List<Color>() { Color.Red, Color.Blue, Color.BurlyWood, Color.Black };
        public Projectile(Player player , GraphicsDevice graphics)
        {
            GetPlayer = player;
            position= new Vector2(player.playerPos.X , player.playerPos.Y) ;
            textureData = new Color[20 * 20];
            projectileTexure = new Texture2D(graphics,20,20);
            Color randomColor = colors[rand.Next(0,3)];
            for(int i = 0; i < textureData.Length; i++)
            {
                textureData[i] = randomColor;    
            }
            projectileTexure.SetData(textureData);
            mousePosX = Mouse.GetState().X ;
            mousePosY = Mouse.GetState().Y ;
            origin = new Vector2(position.X, position.Y);
        }
        public void Update()
        {
            shooting();
        }
        public void shooting()
        {
            Vector2 mousePos = new Vector2(mousePosX,mousePosY);
            Vector2 movDir =  mousePos - origin ;
            movDir.Normalize();
            this.position += origin * movDir   * Globals.time ;
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(projectileTexure, position, Color.White);
        }
    }
}
