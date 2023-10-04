using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using ZombieGame.Effects;
using ZombieGame.EnemyFiles;
using ZombieGame.Managers;
using ZombieGame.ProjectileFile;
using Enemy = ZombieGame.EnemyFiles.Enemy;

namespace ZombieGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteFont spriteFont;
        private List<ExplosionEffect> explosionEffect = ExplosionEffect.fragments;
        private Player player;
        private Renderer renderer;
        private EnemyManager enemyManager;
        PhysicsManager physicsManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            Globals.content = Content;
            player = new Player(787, 200, GraphicsDevice);
            Globals.graphics = GraphicsDevice;
            physicsManager = new PhysicsManager(player);
            enemyManager = new EnemyManager();
            renderer = new Renderer();
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

            player.PlayerControllers();
            Globals.Update(gameTime);
            enemyManager.Update(gameTime);
            InputManager.Update();
            physicsManager.enemyMovement();
            AnimationManager.animateEnemy();
            player.Update();
            if (Projectile.projectileList.Count > 2000)
            {
                Projectile.projectileList.Clear();
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();
            TileMap.Draw();
            foreach (var effect in DeadEffect.effects.ToList())
            {
                effect.Draw();
                effect.Update();
            }
            if (DeadEffect.effects.Count > 1000)
                DeadEffect.effects.Clear();

            foreach (var effect in explosionEffect.ToList())
            {
                effect.Draw();
                effect.Update();
            }
            if (explosionEffect.Count > 200)
            {
                explosionEffect.Clear();
            }
            renderer.GuiDebugger(spriteFont, player);
            enemyManager.Draw();
            player.Draw();

            foreach (Projectile projectile in Projectile.projectileList.ToList())
            {
                projectile.Update();
                projectile.Draw();
            }

            Globals.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}