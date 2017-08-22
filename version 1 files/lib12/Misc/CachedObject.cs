using System;
using lib12.FunctionalFlow;

namespace lib12.Misc
{
    /// <summary>
    /// Container for easier accessing cached values
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CachedObject<T> where T : class
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
            if (@object.Null())
            {
                addToStore();
                @object = getFromStore();
            }

            return @object;
        }
    }
}