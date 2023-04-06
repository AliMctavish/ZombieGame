using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.EnemyFiles;
using ZombieGame.Managers;

namespace ZombieGame.Effects
{
    public class ExplosionEffect
    {
        Random rand = new Random();
        public Vector2 position;
        Vector2 randomPosition;
        Texture2D explosionTexture;
        Color[] pixels; 
        public static List<ExplosionEffect> fragments = new List<ExplosionEffect>();
        public void CreateExplotionEffect(float posX,float posY)
        {
            position.X = posX;
            position.Y = posY;
            randomPosition= new Vector2(rand.Next(-20,20), rand.Next(-20,20));
            explosionTexture = new Texture2D(Globals.graphics, 30, 30);
            pixels = new Color[30 * 30];
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = Color.Green;
            }
            explosionTexture.SetData(pixels);
            fragments.Add(this);
        }
        public void Update()
        {
            position = position + randomPosition;
            PhysicsManager.OnExplotionEffect();
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(explosionTexture, position, Color.White);
        }
    }
}
