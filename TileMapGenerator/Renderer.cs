using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.EnemyFiles;
using ZombieGame.Managers;

namespace ZombieGame
{
    public class Renderer
    {
        public void GuiDebugger(SpriteFont spriteFont,Player player)
        {
            Globals.spriteBatch.DrawString(spriteFont, $"the rotation of object {Mouse.GetState().Position}", new Vector2(50, 50), Color.White);
            Globals.spriteBatch.DrawString(spriteFont, $"player coordinate {player.playerPos}", new Vector2(50, 100), Color.White);
            Globals.spriteBatch.DrawString(spriteFont, $"player Health : {Player.Health}", new Vector2(50, 10), Color.PapayaWhip);
            Globals.spriteBatch.DrawString(spriteFont, $"number of projectiles {Projectile.projectileList.Count}", new Vector2(50, 150), Color.White);
            Globals.spriteBatch.DrawString(spriteFont, $"enemy count :  {Enemy.enemyList.Count()}", new Vector2(50, 200), Color.White);
            Globals.spriteBatch.DrawString(spriteFont, $"ammo amount : {Projectile.Ammo}", new Vector2(50, 220), Color.White);
        }
    }
}
