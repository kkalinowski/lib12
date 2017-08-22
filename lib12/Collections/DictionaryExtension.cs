using System.Collections.Generic;

namespace lib12.Collections
{
    public static class DictionaryExtension
    {
        /// <summary>
        /// Gets the value for given key or default if key doesn't exist in dictionary
        /// </summary>
        /// <param name="dict">Dictionary</param>
        /// <param name="key">The key</param>
        /// <returns></returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            return dict.TryGetValue(key, out TValue result) ? result : default(TValue);
        }
    }
}
