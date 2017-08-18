using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarwhalEngine
{
    class DisplayObject : ContainerObject
    {
        public Transform transform;
        public Texture2D texture;
        public Color color;
        
        /// <summary>
        /// Creates a Display Object
        /// </summary>
        /// <param name="tex">Texture of the display object</param>
        public DisplayObject(Texture2D tex)
        {
            texture = tex;
            transform = new Transform();
            color = Color.White;
        }

        /// <summary>
        /// Creates a Display Object with a given color
        /// </summary>
        /// <param name="tex">Texture of the display object</param>
        /// <param name="color">Color of the model</param>
        public DisplayObject(Texture2D tex, Color color)
        {
            texture = tex;
            transform = new Transform();
            this.color = color;
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
            color = Color.White;
        }

        /// <summary>
        /// Creates a Display Object with a given transform and color
        /// </summary>
        /// <param name="tex">Texture of the display object</param>
        /// <param name="transform">Transform of the display object</param>
        /// /// <param name="color">Color of the model</param>
        public DisplayObject(Texture2D tex, Transform transform, Color color)
        {
            texture = tex;
            this.transform = transform;
            this.color = color;
        }

        /// <summary>
        /// Draws the display object
        /// </summary>
        /// <param name="spriteBatch">Sprite Batch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
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
