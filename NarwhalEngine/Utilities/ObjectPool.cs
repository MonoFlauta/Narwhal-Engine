using System.Collections.Generic;
using NarwhalEngine.Utilities.Complements;

namespace NarwhalEngine
{
    class ObjectPool<T>
    {
        private List<PoolObject<T>> _poolList;
        public delegate T CallbackFactory();

        private int _count;
        private bool _isDinamic = false;
        private PoolObject<T>.PoolCallback _init;
        private PoolObject<T>.PoolCallback _finalize;
        private CallbackFactory _factoryMethod;

        /// <summary>
        /// Creates an object pool
        /// </summary>
        /// <param name="initialStock">The initial stock to create</param>
        /// <param name="factoryMethod">The factory method that creates the object</param>
        /// <param name="initialize">The initialize method that inits the object</param>
        /// <param name="finalize">The finalize method that dispose the object</param>
        /// <param name="isDinamic">If the pool should or not be dynamic</param>
        public ObjectPool(int initialStock, CallbackFactory factoryMethod, PoolObject<T>.PoolCallback initialize, PoolObject<T>.PoolCallback finalize, bool isDinamic)
        {
            _poolList = new List<PoolObject<T>>();

            _factoryMethod = factoryMethod;
            _isDinamic = isDinamic;
            _count = initialStock;
            _init = initialize;
            _finalize = finalize;

            for (int i = 0; i < _count; i++)
            {
                _poolList.Add(new PoolObject<T>(_factoryMethod(), _init, _finalize));
            }
        }
        
        /// <summary>
        /// Gets an object from the pool
        /// </summary>
        /// <returns>The object initialized</returns>
        public T GetObjectFromPool()
        {
            for (int i = 0; i < _count; i++)
            {
                if (!_poolList[i].isActive)
                {
                    _poolList[i].isActive = true;
                    return _poolList[i].GetObj;
                }
            }

            if (_isDinamic)
            {
                PoolObject<T> po = new PoolObject<T>(_factoryMethod(), _init, _finalize);
                po.isActive = true;
                _poolList.Add(po);
                _count++;
                return po.GetObj;
            }
            return default(T);
        }

        /// <summary>
        /// Disables an object and returns it to the pool
        /// </summary>
        /// <param name="obj">The object to return</param>
        public void DisablePoolObject(T obj)
        {
            foreach (PoolObject<T> poolObj in _poolList)
            {
                if (poolObj.GetObj.Equals(obj))
                {
                    poolObj.isActive = false;
                    return;
                }
            }
        }
    }
}
