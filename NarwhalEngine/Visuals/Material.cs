using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        /// Creates a material with one of the default shaders and default color
        /// </summary>
        /// <param name="shader">Shader to use</param>
        public Material(Shaders shader)
        {
            color = Color.White;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(shader.ToString());
        }

        /// <summary>
        /// Creates a material with one of the default shaders and a given color
        /// </summary>
        /// <param name="shader">Shader to use</param>
        /// <param name="color">Color to use</param>
        public Material(Shaders shader, Color color)
        {
            this.color = Color.White;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(shader.ToString());
        }

        /// <summary>
        /// Draws an object without a rectangle
        /// </summary>
        /// <param name="spriteBatch">Sprite batch</param>
        /// <param name="texture">Texture</param>
        /// <param name="transform">Transform</param>
        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Transform transform)
        {
            CameraManager.instance.CheckDrawMaterial(this);
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
            CameraManager.instance.CheckDrawMaterial(this);
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

        /// <summary>
        /// Default shaders that Narwhal Engine brings
        /// </summary>
        public enum Shaders
        {
            BlackAndWhite,
            DiffuseWithNormal,
            MaskedDiffuse
        }
    }
}
