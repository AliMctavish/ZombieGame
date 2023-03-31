using Microsoft.Xna.Framework;
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
        float num = 0;
        private float speed = 300;
        private float rotationSpeed = 10;
        private Texture2D playerTexture { get; set; }
        public Vector2 playerPos { get; set; }
        private Vector2 origin { get; set; }
        public float rotation;
        float jumpTimer = 2;

        private Color[] texutreData;
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
            playerPos = InputManager.move * Globals.time * speed;
            rotation = (float)Math.Atan2(mouseState.Y - playerPos.Y, mouseState.X - playerPos.X);
            if(InputManager.playerIsJumping)
            {
                jumpTimer -= Globals.time;
                if(jumpTimer >1 )
                {
                playerPos = InputManager.move * Globals.time * speed * num;
                num+= 0.1f;
                }
                if (jumpTimer < 1)
                {
                    jumpTimer -= 2;
                    num -= 0.1f;
                    if(jumpTimer < 0)
                    {
                        jumpTimer= 2;
                    }
                    InputManager.playerIsJumping= false;
                }
            }
        }
 
        
        public void Draw()
        {
            Globals.spriteBatch.Draw(playerTexture, playerPos, null, Color.White, rotation , origin  , 1f, SpriteEffects.None , 0f);
        }
    }
}
