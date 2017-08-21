using Microsoft.Xna.Framework.Input;

namespace NarwhalEngine
{
    class InputManager
    {
        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;
        private MouseState _currentMouseState;
        private MouseState _previousMouseState;

        /// <summary>
        /// Creates the input manager
        /// </summary>
        /// <param name="e">Engine</param>
        public InputManager(Narwhal e)
        {
            _currentKeyboardState = Keyboard.GetState();
            _currentMouseState = Mouse.GetState();
            _previousKeyboardState = _currentKeyboardState;
            _previousMouseState = _currentMouseState;
            e.updateManager.AddCallBack(Update);
        }

        /// <summary>
        /// Update function to check keys
        /// </summary>
        /// <param name="deltaTime">Elapsed time</param>
        private void Update(float deltaTime)
        {
            _previousKeyboardState = _currentKeyboardState;
            _previousMouseState = _currentMouseState;

            _currentKeyboardState = Keyboard.GetState();
            _currentMouseState = Mouse.GetState();
        }

        /// <summary>
        /// Returns if a key is pressed
        /// </summary>
        /// <param name="k">Key to check</param>
        /// <returns>Returns true if key is pressed, false if not</returns>
        public bool GetKey(Keys k)
        {
            return _currentKeyboardState.IsKeyDown(k);
        }
        
        /// <summary>
        /// Returns if a key was just released
        /// </summary>
        /// <param name="k">Key to check</param>
        /// <returns>Returns true if key was just released, false if not</returns>
        public bool GetKeyReleased(Keys k)
        {
            return !_currentKeyboardState.IsKeyDown(k) && _previousKeyboardState.IsKeyDown(k);
        }
    }
}
