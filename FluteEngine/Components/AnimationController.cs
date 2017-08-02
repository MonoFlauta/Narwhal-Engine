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
        public string currentLabel;
        public int rows;
        public int columns;
        public float speed;
        public int currentRow;
        public int currentColumn;
        public int width;
        public int height;
        public delegate void Event();

        private Event[,] _events;
        private float _currentIndex;
        private Dictionary<string, Tuple<int, int>> _labels;

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
            _labels = new Dictionary<string, Tuple<int, int>>();
            currentLabel = "";
            this.width = width;
            this.height = height;
            this.rows = rows;
            this.columns = columns;
            this.speed = speed;
            _events = new Event[columns, rows];
            currentColumn = 0;
            currentRow = 0;
        }

        /// <summary>
        /// Adds an event to a cell
        /// </summary>
        /// <param name="column">Column of the cell</param>
        /// <param name="row">Row of the cell</param>
        /// <param name="theEvent">Event</param>
        public void AddEvent(int column, int row, Event theEvent)
        {
            _events[column, row] += theEvent;
        }

        /// <summary>
        /// Removes an event from a cell
        /// </summary>
        /// <param name="column">Column of the cell</param>
        /// <param name="row">Row of the cell</param>
        /// <param name="theEvent">Event</param>
        public void RemoveEvent(int column, int row, Event theEvent)
        {
            _events[column, row] -= theEvent;
        }
        
        /// <summary>
        /// Adds a label in a cell
        /// </summary>
        /// <param name="column">Column of the cell</param>
        /// <param name="row">Row of the cell</param>
        /// <param name="labelName">Name of the label</param>
        public void AddLabel(int column, int row, string labelName)
        {
            AddEvent(column, row, () => currentLabel = labelName);
            _labels[labelName] = new Tuple<int, int>(column, row);
        }

        /// <summary>
        /// Sends the animation to the label
        /// </summary>
        /// <param name="label">Label to go</param>
        /// <param name="forceGo">If forceGo is true, it will go even it is in that current label</param>
        public void GoToLabel(string label, bool forceGo = false)
        {
            if (forceGo || currentLabel != label)
            {
                currentColumn = _labels[label].Item1;
                currentRow = _labels[label].Item2;
                _currentIndex = 0;
                currentLabel = label;
            }
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
                _events[currentColumn, currentRow]?.Invoke();
                if (currentColumn == columns-1)
                {
                    currentColumn = 0;
                    currentRow++;
                    if(currentRow == rows-1)
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
