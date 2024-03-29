﻿using Microsoft.Xna.Framework;
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
    public class Projectile
    {
        //global statics
        public static int Ammo = 100;
        public static List<Projectile> projectileList = new List<Projectile>();

        /// <summary>
        /// PUBLIC MODIFYERS FOR THE PROJECTILE
        /// </summary>
        public Vector2 position;
        public float velocity = 1000f;
        public Color[] textureData;
        public Texture2D projectileTexure;
        public Vector2 origin;
        public Player GetPlayer;
        public float mousePosX, mousePosY;
        Random rand = new Random();
        List<Color> colors = new List<Color>() { Color.Red, Color.Blue, Color.Yellow, Color.Black };

        /// <summary>
        /// //
        /// </summary>
        /// <param name="player"></param>
        /// <param name="graphics"></param>
        public Projectile(Player player, GraphicsDevice graphics)
        {
            GetPlayer = player;
            position = new Vector2(player.playerPos.X, player.playerPos.Y);
            textureData = new Color[10 * 10];
            projectileTexure = new Texture2D(graphics, 10, 10);
            Color randomColor = colors[rand.Next(0, 3)];
            for (int i = 0; i < textureData.Length; i++)
            {
                textureData[i] = randomColor;
            }
            projectileTexure.SetData(textureData);
            mousePosX = Mouse.GetState().X;
            mousePosY = Mouse.GetState().Y;
            origin = new Vector2(position.X, position.Y);
        }
        public virtual void Update()
        {
            shooting();
        }

        public virtual void shooting()
        {
            Vector2 mousePos = new Vector2(mousePosX, mousePosY);
            Vector2 movDir = mousePos - origin;
            movDir.Normalize();
            this.position += movDir * Globals.time * velocity;
        }
        public virtual void Draw()
        {
            Globals.spriteBatch.Draw(projectileTexure, position, Color.White);

        }
    }
}
