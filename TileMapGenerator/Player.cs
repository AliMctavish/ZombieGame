using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ZombieGame.Managers;

namespace ZombieGame
{
    internal class Player 
    {
        private float speed = 300f;
        private Texture2D playerTexture;
        public Vector2 playerPos { get; set; }
        private Vector2 origin { get; set; }
        public static float Health = 100;
        Color[] textureData;
        public float rotation { get; set; }
        public Player(int posX , int posY , GraphicsDevice graphics)
        {
            playerPos= new Vector2(posX, posY);
            playerTexture = new Texture2D(graphics, 50, 50);
            textureData = new Color[50 * 50];
            for (int i = 0; i < textureData.Length; i++)
            {
                textureData[i] = Color.White;
            }
            playerTexture.SetData(textureData);
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
            Globals.spriteBatch.Draw(playerTexture, playerPos, null, Color.White, rotation , origin  , 0.9f, SpriteEffects.None , 0f);
        }
    }
}
