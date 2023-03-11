using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    internal class Tile
    {
        private Texture2D tileTexture;
        private Vector2 tilePos; 
        
        public Tile(string tileFilePath, Vector2 tilePos )
        {
            tileTexture = Globals.content.Load<Texture2D>(tileFilePath);
        }





    }
}
