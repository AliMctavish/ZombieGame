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
    internal class DeadEffect
    {
        public Vector2 effectPos;
        public Random rand = new Random();
        public Texture2D effectTexture;
        public Color[] textureData;
        Vector2 randomPosition;
        public static List<DeadEffect> effects = new List<DeadEffect>();
        public void CreateDeadEffect(float posX, float posY)
        {
            effectPos.X = posX;
            effectPos.Y = posY;
            randomPosition = new Vector2(rand.Next(-8, 8), rand.Next(-8, 8));
            effectTexture = new Texture2D(Globals.graphics, 15, 15);
            textureData = new Color[15 * 15];
            for (int i = 0; i < textureData.Length; i++)
            {
                textureData[i] = Color.Red;
            }
            effectTexture.SetData(textureData);
            effects.Add(this);
        }
        public void Update()
        {
            effectPos = effectPos  + randomPosition;
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(effectTexture, effectPos, Color.White);
        }
    }
}
