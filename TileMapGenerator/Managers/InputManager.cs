using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ZombieGame.Managers
{
    public static class InputManager
    {
        public static Vector2 move = new Vector2(50,50);
        public static MouseState mouseState = Mouse.GetState();
        public static bool playerIsJumping = false;
        public static bool isMoving = false;
        public static void Update()
        {
            var state = Keyboard.GetState();
            if (Player.Health > 0)
            {
                if (!playerIsJumping)
                {
                    if (state.IsKeyDown(Keys.D))
                    {
                       isMoving= true;
                       move.X++;
                    }
                    if (state.IsKeyDown(Keys.A))
                    {
                        isMoving = true;
                        move.X--;
                    }
                    if (state.IsKeyDown(Keys.W))
                    {
                        isMoving = true;
                        move.Y--;
                    }

                    if (state.IsKeyDown(Keys.S))
                    {
                        isMoving = true;
                        move.Y++;
                    }
                }
                if (state.IsKeyDown(Keys.Space)) playerIsJumping = true;
            }
        }
    }
}
