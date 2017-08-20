using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NarwhalEngine
{
    class CameraManager : ContainerObject
    {
        /// <summary>
        /// Creates the Camera Manager
        /// </summary>
        public CameraManager()
        {
        }

        /// <summary>
        /// Draws the camera
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
