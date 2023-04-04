using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame.ProjectileFile
{
    internal class Grenade : Projectile
    {

        public Grenade(Player player , GraphicsDevice graphics) : base (player , graphics)
        {

        }

        public override void shooting()
        {
            base.shooting();
        }
        public override void Update()
        {
            base.Update();
        }
    }
}
