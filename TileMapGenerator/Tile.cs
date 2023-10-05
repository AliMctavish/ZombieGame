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
     
        //why i should return tile rather than void method ? 
         public Tile TileTexture(int tileIndex, Vector2 tilePos, ContentManager content)
        {
            tileTexture = content.Load<Texture2D>($"Grass_Ground_Texture{tileIndex}");
            this.tilePos = tilePos;
            return this;
        }
    }
}
