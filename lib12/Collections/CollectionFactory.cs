using System;
using System.Collections.Generic;
using System.Linq;

namespace lib12.Collections
{
    /// <summary>
    /// Creates collections from init functions
    /// </summary>
    public static class CollectionFactory
    {
        /// <summary>
        /// Creates enumerable of given size using provided function
        /// </summary>
        /// <typeparam name="TResult">Type of enumerable to create</typeparam>
        /// <param name="size">Size of enumerable to create</param>
        /// <param name="createFunc">Create function</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">size - The batch must have at least 1 length</exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TResult> CreateEnumerable<TResult>(int size, Func<int, TResult> createFunc)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("Cannot create collection with negative size");
            if(createFunc == null)
                throw new ArgumentNullException(nameof(createFunc));

            for (var i = 0; i < size; i++)
                yield return createFunc(i);
        }

        /// <summary>
        /// Creates array of given size using provided function
        /// </summary>
        /// <typeparam name="TResult">Type of enumerable to create</typeparam>
        /// <param name="size">Size of array to create</param>
        /// <param name="createFunc">Create function</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">size - The batch must have at least 1 length</exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static TResult[] CreateArray<TResult>(int size, Func<int, TResult> createFunc)
        {
            return CreateEnumerable(size, createFunc).ToArray();
        }

        /// <summary>
        /// Creates list of given size using provided function
        /// </summary>
        /// <typeparam name="TResult">Type of enumerable to create</typeparam>
        /// <param name="size">Size of list to create</param>
        /// <param name="createFunc">Create function</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">size - The batch must have at least 1 length</exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static List<TResult> CreateList<TResult>(int size, Func<int, TResult> createFunc)
        {
            return CreateEnumerable(size, createFunc).ToList();
        }
    }
}