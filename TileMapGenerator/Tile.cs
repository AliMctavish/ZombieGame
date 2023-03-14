using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    internal class Tile
    {
        public Texture2D tileTexture;
        public Vector2 tilePos; 
        public Tile(int tileIndex, Vector2 tilePos , ContentManager content )
        {
            tileTexture = content.Load<Texture2D>($"Tiles/tile{tileIndex}");
            this.tilePos = tilePos;
        }
    }
}
