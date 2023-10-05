using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;
using ZombieGame.Managers;

namespace ZombieGame.Items
{
    public class Ammo
    {
        private Texture2D _texutre;
        private Vector2 _position;
        private float _size = 0.1f;
        private Random rand; 

        /// <summary>
        /// STATIC FIELDS
        /// </summary>  
        /// 
        private static float _spawnTimer = 5;
        public static List<Ammo> Ammos = new List<Ammo>();
        public Ammo()
        {
            rand = new Random();    
            _texutre = Globals.content.Load<Texture2D>("bullets");
            _position = new Vector2(rand.Next(1,1200), rand.Next(1,600));
            Ammos.Add(this);
        }

        public void Update(Player player)
        {
            if (Vector2.Distance(player.playerPos, _position) < 20)
            {
                Projectile.Ammo = 100;
                Ammos.Remove(this);
            }
        }
        public static void UpdateList()
        {
            _spawnTimer -= Globals.time;
            if (_spawnTimer < 0)
            {
                Ammo ammo = new Ammo();
                Ammos.Add(ammo);
                _spawnTimer = 5;
            }
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(_texutre, _position, null, Color.White, 0, _position / 2, _size, SpriteEffects.FlipHorizontally, 0f);
        }
    }
}
