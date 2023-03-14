using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public static class Globals
    {
        public static float time { get; set; } 
        public static SpriteBatch spriteBatch { get; set; }

        public static ContentManager content { get; set; } 


        public static void Update(GameTime gameTime)
        {
            time = (float)gameTime.ElapsedGameTime.TotalSeconds;  
        }

    }

}
