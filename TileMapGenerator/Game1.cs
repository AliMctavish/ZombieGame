using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZombieGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteFont spriteFont;
        private Player player;

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
            player = new Player(_graphics.PreferredBackBufferWidth/2,_graphics.PreferredBackBufferHeight/2,GraphicsDevice);

            base.Initialize();

        }

        protected override void LoadContent()
        {
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("spriteFont");

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            Globals.Update(gameTime);
            InputManager.Update();
            player.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();
            player.Draw();
            Globals.spriteBatch.DrawString(spriteFont, $"the rotation of object {Mouse.GetState().Position}", new Vector2(50, 50), Color.White);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}