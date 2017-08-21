using Microsoft.Xna.Framework.Graphics;

namespace NarwhalEngine
{
    class DisplayObject : ContainerObject
    {
        public Transform transform;
        public Texture2D texture;
        public Material material;
        
        /// <summary>
        /// Creates a Display Object
        /// </summary>
        /// <param name="tex">Texture of the display object</param>
        public DisplayObject(Texture2D tex)
        {
            texture = tex;
            transform = new Transform();
            material = Narwhal.instance.defaultMaterial;
        }

        /// <summary>
        /// Creates a Display Object with a given transform
        /// </summary>
        /// <param name="tex">Texture of the display object</param>
        /// <param name="transform">Transform of the display object</param>
        public DisplayObject(Texture2D tex, Transform transform)
        {
            texture = tex;
            this.transform = transform;
            material = Narwhal.instance.defaultMaterial;
        }

        /// <summary>
        /// Draws the display object
        /// </summary>
        /// <param name="spriteBatch">Sprite Batch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            material.Draw(spriteBatch, texture, transform);
            base.Draw(spriteBatch);
        }
        
        /// <summary>
        /// Width of the object
        /// </summary>
        public int width
        {
            get
            {
                return texture.Width * (int)transform.scale.X;
            }
        }
        
        /// <summary>
        /// Height of the object
        /// </summary>
        public int height
        {
            get
            {
                return texture.Height * (int)transform.scale.Y;
            }
        }
    }
}
