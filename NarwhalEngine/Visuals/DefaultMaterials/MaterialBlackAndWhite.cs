using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NarwhalEngine.Visuals.DefaultMaterials
{
    class MaterialBlackAndWhite : Material
    {
        private float _intensity;

        /// <summary>
        /// Creates a black and white material with default values
        /// </summary>
        public MaterialBlackAndWhite()
        {
            color = Color.White;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(Shaders.BlackAndWhite.ToString());
            Intensity = 1;
        }

        /// <summary>
        /// Creates a black and white material with a given color and default intensity
        /// </summary>
        /// <param name="color">Color to use</param>
        public MaterialBlackAndWhite(Color color)
        {
            this.color = color;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(Shaders.BlackAndWhite.ToString());
            Intensity = 1;
        }

        /// <summary>
        /// Creates a black and white material with a given intensity and default color
        /// </summary>
        /// <param name="intensity">Intensity to use</param>
        public MaterialBlackAndWhite(float intensity)
        {
            this.color = Color.White;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(Shaders.BlackAndWhite.ToString());
            Intensity = intensity;
        }

        /// <summary>
        /// Creates a black and white material with a given intensity and color
        /// </summary>
        /// <param name="intensity">Intensity to use</param>
        /// <param name="color">Color to use</param>
        public MaterialBlackAndWhite(float intensity, Color color)
        {
            this.color = color;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(Shaders.BlackAndWhite.ToString());
            Intensity = intensity;
        }

        /// <summary>
        /// Intensity of the Black and White
        /// </summary>
        public float Intensity
        {
            set
            {
                _intensity = value;
                Parameters["Intensity"].SetValue(value);
            }
            get
            {
                return _intensity;
            }
        }
    }
}
