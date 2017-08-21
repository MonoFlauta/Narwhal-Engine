using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NarwhalEngine.Visuals.DefaultMaterials
{
    class MaterialMaskedDiffuse : Material
    {
        /// <summary>
        /// Creates a masked material with a default color
        /// </summary>
        /// <param name="mask">Mask of the material</param>
        public MaterialMaskedDiffuse(Texture2D mask)
        {
            color = Color.White;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(Shaders.DiffuseWithNormal.ToString());
            Mask = mask;
        }

        /// <summary>
        /// Creates a masked material with a given color
        /// </summary>
        /// <param name="mask">Mask of the material</param>
        /// <param name="color">Color to use</param>
        public MaterialMaskedDiffuse(Texture2D mask, Color color)
        {
            this.color = color;
            effect = Narwhal.instance.assetManager.GetAsset<Effect>(Shaders.DiffuseWithNormal.ToString());
            Mask = mask;
        }

        /// <summary>
        /// Mask of the texture
        /// </summary>
        public Texture2D Mask
        {
            set
            {
                Parameters["Mask"].SetValue(value);
            }
        }
    }
}
