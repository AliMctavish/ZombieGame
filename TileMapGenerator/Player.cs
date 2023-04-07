﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Managers;

namespace ZombieGame
{
    internal class Player 
    {
        private float speed = 300f;
        private Texture2D playerTexture { get; set; }
        public Vector2 playerPos { get; set; }
        private Vector2 origin { get; set; }
        public static float Health = 100;
        public float rotation { get; set; }
        private Color[] texutreData { get; set; }

        public Player(int posX , int posY , GraphicsDevice graphics)
        {
            playerPos= new Vector2(posX, posY);
            playerTexture = new Texture2D(graphics, 50, 50);
            texutreData = new Color[50 * 50];
            for(int i = 0; i < texutreData.Length; i++)
            {
                texutreData[i] = Color.White;
            }
            playerTexture.SetData(texutreData);
            origin = new Vector2(playerTexture.Width / 2, playerTexture.Height / 2);
        }
        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            rotation = (float)Math.Atan2(mouseState.Y - playerPos.Y, mouseState.X - playerPos.X);
            playerPos = InputManager.move * Globals.time * speed;
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(playerTexture, playerPos, null, Color.White, rotation , origin  , 1f, SpriteEffects.None , 0f);
        }
    }
}
