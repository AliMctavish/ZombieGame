using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Managers;

namespace ZombieGame
{
    static class TileMap 
    {
        public static List<Tile> tileList = new List<Tile>();
        static Random rnd = new Random();
        static public void tileGenerator(ContentManager content)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Tile tile = new Tile();
                    tile = tile.TileTexture(rnd.Next(1, 2), new Vector2(j * 300, i * 300) , content);
                    tileList.Add(tile);
                }
            }
        }
        static public void Draw()
        {
           foreach(var tiles in tileList)
           {
            Globals.spriteBatch.Draw(tiles.tileTexture, tiles.tilePos, Color.White);
           }
        }
            
    }
}
