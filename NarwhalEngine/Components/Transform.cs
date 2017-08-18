using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarwhalEngine
{
    class Transform
    {
        public Vector2 position;
        public Vector2 scale;
        public float rotation;

        /// <summary>
        /// Creates the transform
        /// </summary>
        public Transform()
        {
            position = Vector2.Zero;
            scale = new Vector2(1, 1);
        }
    }
}
