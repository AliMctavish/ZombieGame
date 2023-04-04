using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.Managers;

namespace ZombieGame.ProjectileFile
{
    internal class Grenade : Projectile
    {
        float grenadeVelocity = 150f;

        public Grenade(Player player , GraphicsDevice graphics) : base (player , graphics)
        {

        }
        public override void Update()
        {
            shooting();
        }

        public override void shooting()
        {
            Vector2 mousePos = new Vector2(mousePosX, mousePosY);

            Vector2 movDir = mousePos - origin;

            float lengthOfVector = MathF.Sqrt(movDir.X * movDir.X + movDir.Y * movDir.Y);

            float unitVectorValue = 1f / lengthOfVector;

            Vector2 vect = new Vector2(movDir.X, movDir.Y);

            vect *= unitVectorValue;

            position += vect * Globals.time * grenadeVelocity;

            if(Vector2.Distance(position , mousePos) <= 10)
            {
                position = mousePos;
            }

        }
    }
}
