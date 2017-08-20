using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarwhalEngine;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
        public Material defaultMaterial;

        /// <summary>
        /// Starts the engine
        /// </summary>
        /// <param name="c">The content manager</param>
        /// <param name="includeShaders">If it should include shaders</param>
        public void StartEngine(ContentManager c, bool includeShaders = true)
        {
            _instance = this;
            defaultMaterial = new Material();
            cameraManager = new CameraManager();
            assetManager = new AssetManager(c);

            if(includeShaders)
            {
                assetManager.LoadContent<Effect>("DiffuseWithNormal", "Shaders/DiffuseWithNormal");
            }

            updateManager = new UpdateManager();
            inputManager = new InputManager(this);
            screenManager = new ScreenManager();
        }
    }
}
