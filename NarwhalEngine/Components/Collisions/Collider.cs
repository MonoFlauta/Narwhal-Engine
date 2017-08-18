using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarwhalEngine
{
    abstract class Collider
    {
        public Transform transform;

        /// <summary>
        /// Creates a collider with its own transform
        /// </summary>
        public Collider()
        {
            transform = new Transform();
        }

        /// <summary>
        /// Creates a collider using a transform
        /// </summary>
        /// <param name="t">Transform to use</param>
        public Collider(Transform t)
        {
            transform = t;
        }
        
        public abstract bool HitTest(BoxCollider boxCollider);
    }
}
