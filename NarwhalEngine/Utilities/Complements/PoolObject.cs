namespace NarwhalEngine.Utilities.Complements
{
    class PoolObject<T>
    {
        private bool _isActive;
        private T _obj;
        public delegate void PoolCallback(T obj);
        private PoolCallback _initializationCallback;
        private PoolCallback _finalizationCallback;

        /// <summary>
        /// Creates a pool object
        /// </summary>
        /// <param name="obj">The object to be used</param>
        /// <param name="initialization">The initialize method</param>
        /// <param name="finalization">The finalize method</param>
        public PoolObject(T obj, PoolCallback initialization, PoolCallback finalization)
        {
            _obj = obj;
            _initializationCallback = initialization;
            _finalizationCallback = finalization;
            isActive = false;
        }

        /// <summary>
        /// Returns the object
        /// </summary>
        public T GetObj
        {
            get
            {
                return _obj;
            }
        }

        /// <summary>
        /// Returns if activated, on set it sets and initialize or finalize depending on the value
        /// </summary>
        public bool isActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                if (_isActive)
                    _initializationCallback?.Invoke(_obj);
                else
                    _finalizationCallback?.Invoke(_obj);
            }
        }
    }
}
