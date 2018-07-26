using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace NarwhalEngine
{
    class BoxCollider : Collider
    {
        public int width;
        public int height;

        /// <summary>
        /// Creates a box collider with a new transform and default values
        /// </summary>
        public BoxCollider()
        {
            width = 0;
            height = 0;
            transform = new Transform();
        }

        /// <summary>
        /// Creates a box collider with a new transform and defined values
        /// </summary>
        /// <param name="width">Width of the collider</param>
        /// <param name="height">Height of the collider</param>
        public BoxCollider(int width = 0, int height = 0)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Creates a box collider with a given transform and default values
        /// </summary>
        /// <param name="transform">Transform to set</param>
        public BoxCollider(Transform transform)
        {
            width = 0;
            height = 0;
            this.transform = transform;
        }

        /// <summary>
        /// Creates a box collider with a given transform and defined values
        /// </summary>
        /// <param name="transform">Transform to set</param>
        /// <param name="width">Width of the collider</param>
        /// <param name="height">Height of the collider</param>
        public BoxCollider(Transform transform, int width = 0, int height = 0)
        {
            this.transform = transform;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Creates a box collider with a default transform and uses a Texture2D for values
        /// </summary>
        /// <param name="texture">Texture for values</param>
        public BoxCollider(Texture2D texture)
        {
            transform = new Transform();
            width = texture.Width;
            height = texture.Height;
        }

        /// <summary>
        /// Creates a box collider with a given transform and uses a Texture2D for values
        /// </summary>
        /// <param name="texture">Texture for values</param>
        /// <param name="transform">Transform to use</param>
        public BoxCollider(Texture2D texture, Transform transform)
        {
            this.transform = transform;
            width = texture.Width;
            height = texture.Height;
        }

        /// <summary>
        /// Checks collision with a BoxCollider
        /// </summary>
        /// <param name="boxCollider">Box collider to check collision</param>
        /// <returns>If the collision is made</returns>
        public override bool HitTest(BoxCollider boxCollider)
        {
            var thisRect = new Rectangle(
                (int)(transform.position.X - transform.pivot.X), 
                (int)(transform.position.Y - transform.pivot.Y), 
                (int)(width * transform.scale.X), 
                (int)(height * transform.scale.Y));

            var otherRect = new Rectangle(
                (int)(boxCollider.transform.position.X - boxCollider.transform.pivot.X),
                (int)(boxCollider.transform.position.Y - boxCollider.transform.pivot.Y),
                (int)(boxCollider.width * boxCollider.transform.scale.X),
                (int)(boxCollider.height * boxCollider.transform.scale.Y));

            return thisRect.Intersects(otherRect);
        }

        /// <summary>
        /// Checks collision with a CircleCollider
        /// </summary>
        /// <param name="circleCollider">Circle collider to check collision</param>
        /// <returns>If the collision is made</returns>
        public override bool HitTest(CircleCollider circleCollider)
        {
            var thisRect = new Rectangle(
                (int)(transform.position.X - transform.pivot.X),
                (int)(transform.position.Y - transform.pivot.Y),
                (int)(width * transform.scale.X),
                (int)(height * transform.scale.Y));

            var otherRealPosition = circleCollider.transform.position - circleCollider.transform.pivot;
            var otherRect = new Rectangle(
                (int)otherRealPosition.X,
                (int)otherRealPosition.Y,
                circleCollider.radius,
                circleCollider.radius);

            if (!otherRect.Intersects(thisRect)) return false;

            if (Vector2.Distance(otherRealPosition, new Vector2(thisRect.Left, thisRect.Top)) < circleCollider.radius
                || Vector2.Distance(otherRealPosition, new Vector2(thisRect.Left, thisRect.Bottom)) < circleCollider.radius
                || Vector2.Distance(otherRealPosition, new Vector2(thisRect.Right, thisRect.Top)) < circleCollider.radius
                || Vector2.Distance(otherRealPosition, new Vector2(thisRect.Right, thisRect.Bottom)) < circleCollider.radius)
                return true;

            otherRect.Size = new Point((int)(otherRect.Size.X / (System.Math.PI / 2)),
                (int)(otherRect.Size.Y / (System.Math.PI / 2)));

            return otherRect.Intersects(thisRect);
        }
    }
}
