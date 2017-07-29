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
        public static Flute instance
        {
            get
            {
                return _instance;
            }
        }

        private static Flute _instance;

        public AssetManager assetManager;
        public InputManager inputManager;
        public UpdateManager updateManager;
        public ScreenManager screenManager;

        /// <summary>
        /// Starts the engine
        /// </summary>
        /// <param name="c">The content manager</param>
        public void StartEngine(ContentManager c)
        {
            _instance = this;
            assetManager = new AssetManager(c);
            updateManager = new UpdateManager();
            inputManager = new InputManager(this);
            screenManager = new ScreenManager();
        }
    }
}
