using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public class FileManager
    {
        private List<string> tiles = new List<string>(4);
        public FileManager() 
        {
            for(int i = 0; i < tiles.Count; i++) 
            {
                tiles.Add($"Tiles/tile{i}");
            }
        }
    }
}
