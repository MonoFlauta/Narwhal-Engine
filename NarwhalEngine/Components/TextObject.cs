using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarwhalEngine
{
    class TextObject : ContainerObject
    {
        public string text;
        public Transform transform;
        public int scale;
        public SpriteFont font;
        public Material material;
        
        /// <summary>
        /// Creates a text object
        /// </summary>
        /// <param name="font">Font to use</param>
        /// <param name="scale">Scale to use</param>
        public TextObject(SpriteFont font, int scale = 1)
        {
            transform = new Transform();
            this.font = font;
            material = new Material();
            this.scale = scale;
        }

        /// <summary>
        /// Draws the text
        /// </summary>
        /// <param name="spriteBatch">Sprite Batch that uses</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, material.effect);
            spriteBatch.DrawString(font, text, transform.position, material.color, transform.rotation, transform.position, scale, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
