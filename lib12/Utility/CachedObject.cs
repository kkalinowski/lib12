using System;
using lib12.Extensions;

namespace lib12.Utility
{
    //internal, because I'm thinking about Memoization for next version

    /// <summary>
    /// Container for easier accessing cached values
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class CachedObject<T> where T : class
    {
        private readonly Action addToStore;
        private readonly Func<T> getFromStore;

        public CachedObject(Action addToStore, Func<T> getFromStore)
        {
            this.addToStore = addToStore;
            this.getFromStore = getFromStore;
        }

        /// <summary>
        /// Get object from store
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            var @object = getFromStore();
            if (@object.IsNull())
            {
                addToStore();
                @object = getFromStore();
            }

            return @object;
        }
    }
}