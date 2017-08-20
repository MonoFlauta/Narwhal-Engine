using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarwhalEngine
{
    class Material
    {
        public Color color;
        public Effect effect;

        /// <summary>
        /// Creates a material with default values
        /// </summary>
        public Material()
        {
            color = Color.White;
        }

        /// <summary>
        /// Creates a material with a given color and default shader
        /// </summary>
        /// <param name="color">Color</param>
        public Material(Color color)
        {
            this.color = color;
        }

        /// <summary>
        /// Creates a material with a shader and default color
        /// </summary>
        /// <param name="effect">Shader</param>
        public Material(Effect effect)
        {
            this.effect = effect;
            color = Color.White;
        }

        /// <summary>
        /// Creates a material with a given shader and color
        /// </summary>
        /// <param name="effect">Shader</param>
        /// <param name="color">Color</param>
        public Material(Effect effect, Color color)
        {
            this.effect = effect;
            this.color = color;
        }

        /// <summary>
        /// Draws an object without a rectangle
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        /// <param name="texture">Texture</param>
        /// <param name="transform">Transform</param>
        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Transform transform)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, effect);
            spriteBatch.Draw(
                texture,
                transform.position,
                null,
                color,
                transform.rotation,
                transform.pivot,
                transform.scale,
                SpriteEffects.None,
                0);
            spriteBatch.End();
        }

        /// <summary>
        /// Draws an object with a rectangle
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        /// <param name="texture">Texture</param>
        /// <param name="transform">Transform</param>
        /// <param name="rectangle">Rectangle to use</param>
        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Transform transform, Rectangle rectangle)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, effect);
            spriteBatch.Draw(
                texture,
                transform.position,
                rectangle,
                color,
                transform.rotation,
                transform.pivot,
                transform.scale,
                SpriteEffects.None,
                0);
            spriteBatch.End();
        }

        /// <summary>
        /// Get of the Effect Parameter Collection
        /// </summary>
        public EffectParameterCollection Parameters
        {
            get
            {
                return effect.Parameters;
            }
        }
    }
}
