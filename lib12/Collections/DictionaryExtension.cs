using System.Collections.Generic;

namespace lib12.Collections
{
    /// <summary>
    /// DictionaryExtension
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// Gets the value for given key or default if key doesn't exist in dictionary
        /// </summary>
        /// <param name="dict">Dictionary</param>
        /// <param name="key">The key</param>
        /// <param name="defaultValue">Default value, when key is not present in dictionary</param>
        /// <returns></returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
        {
            return dict.TryGetValue(key, out TValue result) ? result : defaultValue;
        }
    }
}
