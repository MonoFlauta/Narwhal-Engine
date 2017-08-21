using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace NarwhalEngine
{
    class ContainerObject
    {
        private List<ContainerObject> _childs;

        /// <summary>
        /// Creates a container object
        /// </summary>
        public ContainerObject()
        {
            _childs = new List<ContainerObject>();
        }

        /// <summary>
        /// Called in order to draw the objects
        /// </summary>
        /// <param name="spriteBatch">Sprite Batch</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = _childs.Count -1; i >= 0; i--)
                _childs[i].Draw(spriteBatch);
        }

        /// <summary>
        /// Adds a child to the object
        /// </summary>
        /// <param name="child">Child to add</param>
        public void AddChild(ContainerObject child)
        {
            _childs.Add(child);
        }

        /// <summary>
        /// Removes a child to the object
        /// </summary>
        /// <param name="child">Child to remove</param>
        public void RemoveChild(ContainerObject child)
        {
            _childs.Remove(child);
        }
    }
}
