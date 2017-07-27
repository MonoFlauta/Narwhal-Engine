using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluteEngine
{
    class UpdateManager
    {
        public delegate void UpdateCallBack(float deltaTime);

        private UpdateCallBack _callBacks;

        /// <summary>
        /// Creates the Update Manager
        /// </summary>
        public UpdateManager()
        {
            _callBacks = (delta) => { };
        }

        /// <summary>
        /// Adds a call back
        /// </summary>
        /// <param name="callBack">Call back</param>
        public void AddCallBack(UpdateCallBack callBack)
        {
            _callBacks += callBack;
        }

        /// <summary>
        /// Removes a call back.
        /// </summary>
        /// <param name="callBack">Call back</param>
        public void RemoveCallBack(UpdateCallBack callBack)
        {
            _callBacks -= callBack;
        }

        /// <summary>
        /// Updates the update manager
        /// </summary>
        /// <param name="deltaTime">Elapsed time between frames in seconds</param>
        public void Update(float deltaTime)
        {
            _callBacks(deltaTime);
        }
    }
}
