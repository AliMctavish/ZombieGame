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
        public float velocity = 1000f;
        public Color[] textureData;
        public Texture2D projectileTexure;
        public Vector2 origin;
        public Player GetPlayer;
        public float mousePosX,mousePosY;
        Random rand= new Random();
        public static List<Projectile> projectileList = new List<Projectile>();
        List<Color> colors = new List<Color>() { Color.Red, Color.Blue, Color.Yellow, Color.Black };
        public Projectile(Player player , GraphicsDevice graphics)
        {
            GetPlayer = player;
            position= new Vector2(player.playerPos.X, player.playerPos.Y ) ;
            textureData = new Color[5 * 5];
            projectileTexure = new Texture2D(graphics,5,5);
            for(int i = 0; i < textureData.Length; i++)
            {
                textureData[i] = Color.Orange;    
            }
            projectileTexure.SetData(textureData);
            mousePosX = Mouse.GetState().X ;
            mousePosY = Mouse.GetState().Y ;
            origin = new Vector2(position.X, position.Y);
        }
        public virtual void Update()
        {
            shooting();
        }
        public virtual void shooting()
        {
            Vector2 mousePos = new Vector2(mousePosX,mousePosY);
            Vector2 movDir =  mousePos - origin ;
            movDir.Normalize();
            this.position += movDir * Globals.time * velocity ;
        }
        public virtual void Draw()
        {
            Globals.spriteBatch.Draw(projectileTexure, position, Color.White);
        }
    }
}
