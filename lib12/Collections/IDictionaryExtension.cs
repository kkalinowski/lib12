using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace lib12.Collections
{
    /// <summary>
    /// IDictionaryExtension
    /// </summary>
    public static class IDictionaryExtension
    {
        /// <summary>
        /// Gets the value for given key or default if key doesn't exist in dictionary
        /// </summary>
        /// <param name="dict">Dictionary</param>
        /// <param name="key">The key</param>
        /// <param name="defaultValue">Default value, when key is not present in dictionary</param>
        /// <returns></returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
        {
            return dict.TryGetValue(key, out TValue result) ? result : defaultValue;
        }

        /// <summary>
        /// Returns ReadOnlyDictionary with the same values as given dictionary
        /// </summary>
        /// <param name="dict">Source dictionary</param>
        /// <returns></returns>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dict)
        {
            if (dict == null)
                return Empty.ReadOnlyDictionary<TKey, TValue>();

            return new ReadOnlyDictionary<TKey, TValue>(dict);
        }

        /// <summary>
        /// If dictionary is null converts it into empty dictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict">Source dictionary</param>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> Recover<TKey, TValue>(this IDictionary<TKey, TValue> dict)
        {
            if (dict == null)
                return Empty.Dictionary<TKey, TValue>();

            return new ReadOnlyDictionary<TKey, TValue>(dict);
        }

        /// <summary>
        /// Concatenates two dictionaries
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict">Source dictionary</param>
        /// <param name="secondDict">Second dictionary to concat to source dictionary</param>
        /// <exception cref="ArgumentException">Thrown when encounters duplicates</exception>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> Concat<TKey, TValue>(this IDictionary<TKey, TValue> dict, IDictionary<TKey, TValue> secondDict)
        {
            var result = new Dictionary<TKey, TValue>();

            dict.Recover().ForEach(x => result.Add(x.Key, x.Value));
            secondDict.Recover().ForEach(x => result.Add(x.Key, x.Value));

            return result;
        }
    }
}
