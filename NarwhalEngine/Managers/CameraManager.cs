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
        //private Dictionary<string, Tuple<Effect, List<ContainerObject>>> _allChildsWithEffects;
        private Dictionary<Effect, List<ContainerObject>> _allChildsWithEffects;

        /// <summary>
        /// Creates the Camera Manager
        /// </summary>
        public CameraManager()
        {
            _allChildsWithEffects = new Dictionary<Effect, List<ContainerObject>>();
        }

        /// <summary>
        /// Draws the camera
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null);
            base.Draw(spriteBatch);
            spriteBatch.End();

            foreach(var item in _allChildsWithEffects)
            {
                spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, item.Key);
                for (int i = item.Value.Count - 1; i >= 0; i--)
                    item.Value[i].Draw(spriteBatch);
                spriteBatch.End();
            }
        }

        /// <summary>
        /// Adds a child with an effect
        /// </summary>
        /// <param name="child">Child to add</param>
        /// <param name="effect">Effect</param>
        public void AddChildWithEffect(ContainerObject child, Effect effect)
        {
            if(!_allChildsWithEffects.ContainsKey(effect))
            {
                _allChildsWithEffects.Add(
                    effect,
                    new List<ContainerObject>()
                    );
            }

            _allChildsWithEffects[effect].Add(child);
        }

        /// <summary>
        /// Removes a child with an effect
        /// </summary>
        /// <param name="child">Child to remove</param>
        /// <param name="effect">Effect</param>
        public void RemoveChildWithEffect(ContainerObject child, Effect effect)
        {
            _allChildsWithEffects[effect].Remove(child);
        }

        /// <summary>
        /// Adds an effect
        /// </summary>
        /// <param name="effect">Effect</param>
        public void AddEffect(Effect effect)
        {
            _allChildsWithEffects.Add(
                effect,
                new List<ContainerObject>()
                );
        }
    }
}
