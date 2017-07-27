using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluteEngine
{
    class AssetManager
    {
        private Dictionary<string, object> _allContent;
        private Microsoft.Xna.Framework.Content.ContentManager cManager;

        /// <summary>
        /// Creates the AssetManager
        /// </summary>
        /// <param name="c">ContentManager</param>
        public AssetManager(Microsoft.Xna.Framework.Content.ContentManager c)
        {
            cManager = c;
            _allContent = new Dictionary<string, object>();
        }

        /// <summary>
        /// Loads a Content
        /// </summary>
        /// <typeparam name="T">Type of the content</typeparam>
        /// <param name="name">Name of the content</param>
        /// <param name="path">Path of the content</param>
        public void LoadContent<T>(string name, string path)
        {
            _allContent.Add(name, cManager.Load<T>(path));
        }

        /// <summary>
        /// Gets a content
        /// </summary>
        /// <typeparam name="T">Type of the content</typeparam>
        /// <param name="name">Name of the content</param>
        /// <returns>The content</returns>
        public T GetAsset<T>(string name)
        {
            return (T)_allContent[name];
        }
    }
}
