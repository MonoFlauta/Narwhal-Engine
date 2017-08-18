using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarwhalEngine;
using Microsoft.Xna.Framework.Content;

namespace NarwhalEngine
{
    class Narwhal
    {
        public static Narwhal instance
        {
            get
            {
                return _instance;
            }
        }

        private static Narwhal _instance;

        public CameraManager cameraManager;
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
            cameraManager = new CameraManager();
            assetManager = new AssetManager(c);
            updateManager = new UpdateManager();
            inputManager = new InputManager(this);
            screenManager = new ScreenManager();
        }
    }
}
