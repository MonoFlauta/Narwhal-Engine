using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluteEngine
{
    class AnimationController
    {
        public int rows;
        public int columns;
        public float speed;
        public int currentRow;
        public int currentColumn;
        public int width;
        public int height;
        
        private float _currentIndex;

        /// <summary>
        /// Creates the animation controller
        /// </summary>
        /// <param name="width">Width of each cell</param>
        /// <param name="height">Height of each cell</param>
        /// <param name="rows">Total rows</param>
        /// <param name="columns">Total columns</param>
        /// <param name="speed">Animation speed</param>
        public AnimationController(int width, int height, int rows = 1, int columns = 1, int speed = 1)
        {
            this.width = width;
            this.height = height;
            this.rows = rows;
            this.columns = columns;
            this.speed = speed;
            currentColumn = 0;
            currentRow = 0;
        }

        /// <summary>
        /// Updates the animation controller
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            _currentIndex += deltaTime * speed;
            while(_currentIndex >= 1)
            {
                _currentIndex--;
                currentColumn++;
                if (currentColumn == columns)
                {
                    currentColumn = 0;
                    currentRow++;
                    if(currentRow == rows)
                    {
                        currentRow = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Returns the current sprite rectangle
        /// </summary>
        /// <returns>The rectangle</returns>
        public Rectangle GetCurrentRectangle()
        {
            return new Rectangle(
                currentColumn * width,
                currentRow * height,
                width,
                height);
        }
    }
}
