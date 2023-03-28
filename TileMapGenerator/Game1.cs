using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using ZombieGame.EnemyFiles;
using ZombieGame.Managers;
using Enemy = ZombieGame.EnemyFiles.Enemy;

namespace ZombieGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteFont spriteFont;
        private Player player;
        private Projectile projectile;
        private EnemyManager enemyManager;
        PhysicsManager physicsManager = new PhysicsManager();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth= 1200;
            _graphics.PreferredBackBufferHeight= 600;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            player = new Player(787,200, GraphicsDevice);
            Globals.graphics = GraphicsDevice;
            enemyManager = new EnemyManager();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("spriteFont");
            TileMap.tileGenerator(Content);
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                TileMap.tileList.Clear();
                TileMap.tileGenerator(Content);
            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Projectile projectile = new Projectile(player, GraphicsDevice);
                Projectile.projectileList.Add(projectile);
            }
            Globals.Update(gameTime);
            enemyManager.Update(gameTime);
            InputManager.Update();
            physicsManager.enemyMovement(player);
            player.Update();
            if(Projectile.projectileList.Count > 2000)
            {
                //Projectile.projectileList.Clear();
            }
            foreach(Enemy enemy in Enemy.enemyList)
            {
                enemy.Update(player);
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();
            TileMap.Draw();
            Globals.spriteBatch.DrawString(spriteFont, $"the rotation of object {Mouse.GetState().Position}", new Vector2(50, 50), Color.White);
            Globals.spriteBatch.DrawString(spriteFont, $"player coordinate {player.playerPos}", new Vector2(50, 100), Color.White);
            Globals.spriteBatch.DrawString(spriteFont, $"number of projectiles {Projectile.projectileList.Count}", new Vector2(50, 150), Color.White);
            enemyManager.Draw();
            player.Draw();
            foreach(Projectile projectile in Projectile.projectileList)
            {
                projectile.Update();
                projectile.Draw();
            }
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}