﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarwhalEngine
{
    class AnimatedDisplayObject : ContainerObject
    {
        public Transform transform;
        public Texture2D texture;
        public Color color;
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
            color = new Color(255, 255, 255, 255);
            currentAnimation = animationController;
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
            color = new Color(255, 255, 255, 255);
            currentAnimation = animationController;
        }

        /// <summary>
        /// Draws the animated display object
        /// </summary>
        /// <param name="spriteBatch">Sprite Batch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                    texture,
                    transform.position,
                    currentAnimation.GetCurrentRectangle(),
                    color,
                    transform.rotation,
                    Vector2.Zero,
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