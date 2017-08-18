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
        public Vector2 pivot;
        public Vector2 scale;
        public float rotation;

        /// <summary>
        /// Creates the transform
        /// </summary>
        public Transform()
        {
            position = Vector2.Zero;
            pivot = Vector2.Zero;
            scale = new Vector2(1, 1);
            rotation = 0;
        }

        /// <summary>
        /// Creates the transform using the given values
        /// </summary>
        /// <param name="position">Position of the transform</param>
        /// <param name="pivot">Pivot of the transform</param>
        /// <param name="scale">Scale of the transform</param>
        /// <param name="rotation">Rotation of the transform</param>
        public Transform(Vector2 position, Vector2 pivot, Vector2 scale, float rotation)
        {
            this.position = position;
            this.pivot = pivot;
            this.scale = scale;
            this.rotation = rotation;
        }
    }
}
