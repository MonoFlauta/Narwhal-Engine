using System.Collections.Generic;
using NarwhalEngine.Managers.Complements;

namespace NarwhalEngine
{
    class ScreenManager
    {
        private Dictionary<string, IScreen> _screens;
        private IScreen _currentScreen;

        public ScreenManager()
        {
            _screens = new Dictionary<string, IScreen>();
        }

        /// <summary>
        /// Loads a new screen by its name
        /// </summary>
        /// <param name="name">Name of the screen</param>
        public void LoadNewScreen(string name)
        {
            if(_currentScreen!=null)
            {
                Narwhal.instance.updateManager.RemoveCallBack(_currentScreen.Update);
                _currentScreen.Exit();
            }
            _currentScreen = _screens[name];
            _currentScreen.Open();
            Narwhal.instance.updateManager.AddCallBack(_currentScreen.Update);
        }

        /// <summary>
        /// Registers a new screen, by its name, using a type
        /// </summary>
        /// <typeparam name="T">Type of the screen</typeparam>
        /// <param name="name">Name of the screen</param>
        public void RegisterScreen<T>(string name) where T : IScreen, new()
        {
            _screens.Add(name, new T());
        }

        /// <summary>
        /// Registers a new screen, by its name, with a new screen
        /// </summary>
        /// <param name="name">Name of the screen</param>
        /// <param name="screen">The screen</param>
        public void RegisterScreen(string name, IScreen screen)
        {
            _screens.Add(name, screen);
        }

        /// <summary>
        /// Registers a new screen, by its type name, with a new screen
        /// </summary>
        /// <param name="screen">The screen</param>
        public void RegisterScreen(IScreen screen)
        {
            _screens.Add(screen.GetType().ToString(), screen);
        }
    }
}
