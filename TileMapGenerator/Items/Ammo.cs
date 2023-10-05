using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using ZombieGame.Managers;

namespace ZombieGame.Items
{
    public class Ammo
    {
        private Texture2D _texutre;
        private Vector2 _position;
        private float _size = 0.1f;

        /// <summary>
        /// STATIC FIELDS
        /// </summary>  
        /// 
        private static int counter = 0;
        public static List<Ammo> Ammos = new List<Ammo>();
        public Ammo(int posX , int posY)
        {
            _texutre = Globals.content.Load<Texture2D>("bullets");
            _position = new Vector2(posX, posY);
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
            Ammo ammo = new Ammo(20,20 + counter);
            counter++;
            Ammos.Add(ammo);
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(_texutre, _position, null, Color.White, 0, _position / 2, _size, SpriteEffects.FlipHorizontally, 0f);
        }
    }
}
