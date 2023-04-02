using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Managers;

namespace ZombieGame.ProjectileFile
{
    class ShotGun : Projectile
    {
       
        public ShotGun(Player player , GraphicsDevice graphics) : base(player , graphics)
        {
            origin = new Vector2(position.X, position.Y);
        }

        public override void Update()
        {
            shooting();
        }

        public override void shooting()
        { 
            GetPlayer.playerPos = origin;
            Vector2 mousePos = new Vector2(mousePosX, mousePosY);
            Vector2 movDir = mousePos - origin ;

            float num =  1f  /  MathF.Sqrt(movDir.X * movDir.X   +  movDir.Y * movDir.Y);

            Vector2 vect = new Vector2(movDir.X, movDir.Y);

            vect *= num;

            position += vect * Globals.time * velocity * 2;
        }

        public override void Draw()
        {
            Globals.spriteBatch.Draw(projectileTexure, position, Color.Black);
        }


    }
}
