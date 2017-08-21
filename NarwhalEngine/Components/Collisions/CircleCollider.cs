using Microsoft.Xna.Framework;
using System;

namespace NarwhalEngine
{
    class CircleCollider : Collider
    {
        public int radius;

        /// <summary>
        /// Creates a circle collider with a new transform and default radius
        /// </summary>
        public CircleCollider()
        {
            radius = 0;
            transform = new Transform();
        }

        /// <summary>
        /// Creates a circle collider with a new transform and defined radius
        /// </summary>
        /// <param name="radius">The radius</param>
        public CircleCollider(int radius)
        {
            this.radius = radius;
            transform = new Transform();
        }

        /// <summary>
        /// Creates a circle collider with a given transform and default radius
        /// </summary>
        /// <param name="transform">The transform</param>
        public CircleCollider(Transform transform)
        {
            radius = 0;
            this.transform = transform;
        }

        /// <summary>
        /// Creates a circle collider with a given transform and defined radius
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="radius">The radius</param>
        public CircleCollider(Transform transform, int radius)
        {
            this.radius = radius;
            this.transform = transform;
        }
        
        /// <summary>
        /// Checks collision with a BoxCollider
        /// </summary>
        /// <param name="boxCollider">Box collider to check collision</param>
        /// <returns>If the collision is made</returns>
        public override bool HitTest(BoxCollider boxCollider)
        {
            var realPosition = transform.position - transform.pivot;

            var thisRect = new Rectangle(
                (int)realPosition.X,
                (int)realPosition.Y,
                radius,
                radius);

            var otherRect = new Rectangle(
                (int)(boxCollider.transform.position.X - boxCollider.transform.pivot.X),
                (int)(boxCollider.transform.position.Y - boxCollider.transform.pivot.Y),
                (int)(boxCollider.width * boxCollider.transform.scale.X),
                (int)(boxCollider.height * boxCollider.transform.scale.Y));

            if (!thisRect.Intersects(otherRect)) return false;

            if (Vector2.Distance(realPosition, new Vector2(otherRect.Left, otherRect.Top)) < radius
                || Vector2.Distance(realPosition, new Vector2(otherRect.Left, otherRect.Bottom)) < radius
                || Vector2.Distance(realPosition, new Vector2(otherRect.Right, otherRect.Top)) < radius
                || Vector2.Distance(realPosition, new Vector2(otherRect.Right, otherRect.Bottom)) < radius)
                return true;

            thisRect.Size = new Point((int)(thisRect.Size.X / (Math.PI / 2)),
                (int)(thisRect.Size.Y / (Math.PI / 2)));

            return thisRect.Intersects(otherRect);
        }

        /// <summary>
        /// Checks collision with a CircleCollider
        /// </summary>
        /// <param name="circleCollider">Circle collider to check collision</param>
        /// <returns>If the collision is made</returns>
        public override bool HitTest(CircleCollider circleCollider)
        {
            return Vector2.Distance(transform.position - transform.pivot,
                circleCollider.transform.position - circleCollider.transform.pivot)
                < radius + circleCollider.radius;
        }
    }
}
