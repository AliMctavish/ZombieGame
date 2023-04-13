﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ZombieGame.Managers
{
    public static class InputManager
    {
        public static Vector2 move = new Vector2(50,50);
        public static MouseState mouseState = Mouse.GetState();
        public static bool playerIsJumping = false;
        public static void Update()
        {
            var state = Keyboard.GetState();
            if (Player.Health > 0)
            {
                if (!playerIsJumping)
                {
                    if (state.IsKeyDown(Keys.D)) move.X++;
                    if (state.IsKeyDown(Keys.A)) move.X--;
                    if (state.IsKeyDown(Keys.W)) move.Y--;
                    if (state.IsKeyDown(Keys.S)) move.Y++;
                }
                if (state.IsKeyDown(Keys.Space)) playerIsJumping = true;
            }
        }
    }
}
