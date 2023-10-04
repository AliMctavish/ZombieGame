using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ZombieGame.Managers;

namespace ZombieGame.Items
{
    public class Ammo
    {
        private Texture2D _texutre;
        private Vector2 _position;
        private float _size = 0.1f;
        public static List<Ammo> Ammos = new List<Ammo>();
        public Ammo()
        {
            _texutre = Globals.content.Load<Texture2D>("bullets");
            _position = new Vector2(400, 400);
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


        public void Draw()
        {
            Globals.spriteBatch.Draw(_texutre, _position, null, Color.White, 0, _position / 2, _size, SpriteEffects.FlipHorizontally, 0f);
        }
    }
}
