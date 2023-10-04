using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame.EnemyFiles
{
    /// <summary>
    /// THIS ENUM IS FOR THE ROTAION OF THE ZOMBIE 
    /// IDLE : ZOMBIE ROTATED TOWARD THE PLAYER LOCATION
    /// IF PLAYER THROW BOMB : ZOMBIE ROTAION TOWARD THE BOMB LOCATION
    /// </summary>
    public enum TargetType
    {
        None = 0,
        Player = 1,
        Bomb = 2,
    }
}
