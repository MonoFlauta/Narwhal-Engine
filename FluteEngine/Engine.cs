using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluteEngine;
using Microsoft.Xna.Framework.Content;

namespace FluteEngine
{
    class Flute
    {
        public AssetManager assetManager;
        public InputManager inputManager;
        public UpdateManager updateManager;

        /// <summary>
        /// Starts the engine
        /// </summary>
        /// <param name="c">The content manager</param>
        public void StartEngine(ContentManager c)
        {
            assetManager = new AssetManager(c);
            updateManager = new UpdateManager();
            inputManager = new InputManager(this);
        }
    }
}
