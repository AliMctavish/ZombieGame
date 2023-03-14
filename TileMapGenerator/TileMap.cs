using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
     static class TileMap 
    {
        static Tile[,] tiles = new Tile[10,10];
        static Random rnd = new Random();
        static public void tileGenerator(ContentManager content)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tiles[i,j] = new Tile(rnd.Next(1, 4), new Vector2(j * 200, i * 200) , content);
                }
            }
        }
        static public void Draw()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (tiles[i,j] != null)
                    {
                    Globals.spriteBatch.Draw(tiles[i, j].tileTexture, tiles[i, j].tilePos, Color.White);
                    }
                }
            }
        }
    }
}
