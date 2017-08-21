using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NarwhalEngine.Visuals.DefaultMaterials
{
    class MaterialDiffuseWithNormal : Material
    {
        private Vector3 _lightDirection;
        private Vector3 _lightColor;

        /// <summary>
        /// Creates the material with a given normal texture and default values
        /// </summary>
        /// <param name="normalTexture">Normal texture to use</param>
        public MaterialDiffuseWithNormal(Texture2D normalTexture)
        {
            color = Color.White;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(Shaders.DiffuseWithNormal.ToString());
            LightDirection = Vector3.Zero;
            LightColor = Vector3.One;
            NormalTexture = normalTexture;
        }

        /// <summary>
        /// Creates the material with a given normal texture, a given color and default values
        /// </summary>
        /// <param name="normalTexture">Normal texture to use</param>
        /// <param name="color">Color to use</param>
        public MaterialDiffuseWithNormal(Texture2D normalTexture, Color color)
        {
            this.color = color;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(Shaders.DiffuseWithNormal.ToString());
            LightDirection = Vector3.Zero;
            LightColor = Vector3.One;
            NormalTexture = normalTexture;
        }

        /// <summary>
        /// Creates the material with a given normal texture, light direction, light color and default color
        /// </summary>
        /// <param name="normalTexture">Normal texture to use</param>
        /// <param name="lightDirection">Light direction</param>
        /// <param name="lightColor">Light color (Use white if you don't want to see any changes)</param>
        public MaterialDiffuseWithNormal(Texture2D normalTexture, Vector3 lightDirection, Vector3 lightColor)
        {
            this.color = Color.White;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(Shaders.DiffuseWithNormal.ToString());
            LightDirection = lightDirection;
            LightColor = lightColor;
            NormalTexture = normalTexture;
        }

        /// <summary>
        /// Creates the material with a given normal texture, light direction, light color and default color
        /// </summary>
        /// <param name="normalTexture">Normal texture to use</param>
        /// <param name="lightDirection">Light direction</param>
        /// <param name="lightColor">Light color (Use white if you don't want to see any changes)</param>
        /// <param name="color">Color to use</param>
        public MaterialDiffuseWithNormal(Texture2D normalTexture, Vector3 lightDirection, Vector3 lightColor, Vector3 ambientColor, Color color)
        {
            this.color = color;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(Shaders.DiffuseWithNormal.ToString());
            LightDirection = lightDirection;
            LightColor = lightColor;
            NormalTexture = normalTexture;
        }

        /// <summary>
        /// The light direction that applies over the texture
        /// </summary>
        public Vector3 LightDirection
        {
            set
            {
                _lightDirection = value;
                Parameters["LightDirection"].SetValue(value);
            }
            get
            {
                return _lightDirection;
            }
        }

        /// <summary>
        /// Light color to use
        /// </summary>
        public Vector3 LightColor
        {
            set
            {
                _lightColor = value;
                Parameters["LightColor"].SetValue(value);
            }
            get
            {
                return _lightColor;
            }
        }

        /// <summary>
        /// Normal texture of the material
        /// </summary>
        public Texture2D NormalTexture
        {
            set
            {
                Parameters["NormalTexture"].SetValue(value);
            }
        }
    }
}
