using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ZombieGame.Managers;
using ZombieGame.ProjectileFile;

namespace ZombieGame
{

    public class Player
    {
        private float speed = 300f;
        private Texture2D playerTexture;
        public Vector2 playerPos { get; set; }
        private bool hasThrownGrenade = false;
        float timer = 5;
        private Vector2 origin { get; set; }
        private readonly GraphicsDevice graphicsDevice;
        public static float Health = 100;
        public float rotation { get; set; }
        public Player(int posX, int posY, GraphicsDevice graphics)
        {
            playerPos = new Vector2(posX, posY);
            playerTexture = Globals.content.Load<Texture2D>("Drawing 49");
            origin = new Vector2(playerTexture.Width / 2, playerTexture.Height / 2);
            graphicsDevice = graphics;
        }
        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            rotation = (float)Math.Atan2(mouseState.Y - playerPos.Y, mouseState.X - playerPos.X);
            playerPos = InputManager.move * Globals.time * speed;

            if (InputManager.isMoving)
            {
                for (int i = 49; i <= 53; i++)
                {
                    playerTexture = Globals.content.Load<Texture2D>($"Drawing {i}");
                }
            }
        }
        public void PlayerControllers()
        {

            if (Player.Health > 0 && Projectile.Ammo > 0)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Projectile projectile = new Projectile(this, graphicsDevice);
                    Projectile.projectileList.Add(projectile);
                    Projectile.Ammo -= 1;
                }
                if (Mouse.GetState().RightButton == ButtonState.Pressed)
                {
                    Projectile shotGunProjectiles = new ShotGun(this, graphicsDevice);
                    Projectile.projectileList.Add(shotGunProjectiles);
                    Projectile.Ammo -= 1;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.G))
                {
                    if (timer == 5)
                    {
                        hasThrownGrenade = true;
                        Projectile grenade = new Grenade(this, graphicsDevice);
                        Projectile.projectileList.Add(grenade);
                    }
                }
             
                if (hasThrownGrenade)
                {
                    timer -= Globals.time;

                    if (timer < 0)
                    {
                        hasThrownGrenade = false;
                        timer = 5;
                        Projectile.Ammo -= 1;
                    }
                }
            }
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(playerTexture, playerPos, null, Color.White, rotation, origin, 2f, SpriteEffects.FlipHorizontally, 0f);
        }
    }
}
