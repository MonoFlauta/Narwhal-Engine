using Microsoft.Xna.Framework.Graphics;

namespace NarwhalEngine
{
    class AnimatedDisplayObject : ContainerObject
    {
        public Transform transform;
        public Texture2D texture;
        public Material material;
        public AnimationController currentAnimation;

        /// <summary>
        /// Creates an Animated Display Object
        /// </summary>
        /// <param name="tex">Texture of the display object</param>
        /// <param name="animationController">The animation controller</param>
        public AnimatedDisplayObject(Texture2D tex, AnimationController animationController)
        {
            texture = tex;
            transform = new Transform();
            currentAnimation = animationController;
            material = Narwhal.instance.defaultMaterial;
        }

        /// <summary>
        /// Creates an Animated Display Object with a given transform
        /// </summary>
        /// <param name="tex">Texture of the display object</param>
        /// <param name="transform">Transform of the display object</param>
        /// /// <param name="animationController">The animation controller</param>
        public AnimatedDisplayObject(Texture2D tex, Transform transform, AnimationController animationController)
        {
            texture = tex;
            this.transform = transform;
            currentAnimation = animationController;
            material = Narwhal.instance.defaultMaterial;
        }

        /// <summary>
        /// Draws the animated display object
        /// </summary>
        /// <param name="spriteBatch">Sprite Batch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            material.Draw(spriteBatch, texture, transform, currentAnimation.GetCurrentRectangle());
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
