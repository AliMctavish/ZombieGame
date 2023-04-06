using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieGame.EnemyFiles;

namespace ZombieGame.Managers
{
    internal class DeadEffect : Effect
    {
        public Vector2 effectPos;
        public Texture2D effectTexture;
        public Color[] textureData;
        public static List<DeadEffect> effects= new List<DeadEffect>();

        public void CreateDeadEffect(float posX, float posY)
        {
            effectPos.X = posX;
            effectPos.Y = posY;
            effectTexture = new Texture2D(Globals.graphics, 15, 15);
            textureData = new Color[15 * 15];
            for(int i = 0; i < textureData.Length; i++)
            {
                textureData[i] = Color.Orange;
            }
            effectTexture.SetData(textureData);
            effects.Add(this);
        }
        public void Draw()
        {
        Globals.spriteBatch.Draw(effectTexture, effectPos, Color.White);
        }
    }
}
