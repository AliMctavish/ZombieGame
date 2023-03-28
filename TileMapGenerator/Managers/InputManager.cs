using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame.Managers
{
    public static class InputManager
    {
        public static Vector2 move = new Vector2(50,50);
        public static MouseState mouseState = Mouse.GetState();
        public static void Update()
        {
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A)) move.X--;
            if (state.IsKeyDown(Keys.D)) move.X++;
            if (state.IsKeyDown(Keys.W)) move.Y--;
            if (state.IsKeyDown(Keys.S)) move.Y++;
        }
    }
}
