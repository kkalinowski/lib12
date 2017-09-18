using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lib12.Extensions;

namespace lib12.Collections
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Determines whether the specified enumerable is empty.
        /// </summary>
        /// <param name="source">The source to check</param>
        /// <returns>True if enumerable is empty</returns>
        public static bool IsEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return !source.Any();
        }

        /// <summary>
        /// Determines whether enumerable is null or empty
        /// </summary>
        /// <param name="source">The source to check</param>
        /// <returns>True if enumerable is null or empty</returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return source == null || !source.Any();
        }

        /// <summary>
        /// Determines whether enumerable is not empty
        /// </summary>
        /// <param name="source">The source to check</param>
        /// <returns>True if enumerable is not empty</returns>
        public static bool IsNotEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return source.Any();
        }

        /// <summary>
        /// Determines whether enumerable is not null and not empty
        /// </summary>
        /// <param name="source">The source to check</param>
        /// <returns>True if enumerable is not null and not empty</returns>
        public static bool IsNotNullAndNotEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return source != null && source.Any();
        }

        /// <summary>
        /// Invoke action for each element in enumerable
        /// </summary>
        /// <param name="source">The enumeration of items to invoke action on</param>
        /// <param name="action">The action to invoke</param>
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (TSource item in source)
                action(item);

            return source;
        }

        /// <summary>
        /// Converterts enumerable to delimited string
        /// </summary>
        /// <param name="source">The enumerable to convert</param>
        /// <param name="delimiter">The delimiter to use</param>
        /// <returns>Delimited string</returns>
        public static string ToDelimitedString<TSource>(this IEnumerable<TSource> source, string delimiter)
        {
            if (source.IsEmpty())
                return string.Empty;

            var sbuilder = new StringBuilder();
            foreach (var item in source)
            {
                sbuilder.AppendFormat("{0}{1}", item, delimiter);
            }

            sbuilder.Remove(sbuilder.Length - delimiter.Length, delimiter.Length);
            return sbuilder.ToString();
        }

        /// <summary>
        /// Determines if two collections have the same content, but not necessary in the same order
        /// </summary>
        /// <param name="first">The first collection.</param>
        /// <param name="second">The second collection.</param>
        /// <returns>True if both collections have the same content, false otherwise.</returns>
        public static bool SequenceContentEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            //based on http://stackoverflow.com/questions/50098/comparing-two-collections-for-equality

            // Declare a dictionary to count the occurence of the items in the collection
            var itemCounts = new Dictionary<TSource, int>();

            // Increase the count for each occurence of the item in the first collection
            foreach (TSource item in first)
            {
                if (itemCounts.ContainsKey(item))
                {
                    itemCounts[item]++;
                }
                else
                {
                    itemCounts[item] = 1;
                }
            }

            // Wrap the keys in a searchable list
            var keys = new List<TSource>(itemCounts.Keys);

            // Decrease the count for each occurence of the item in the second collection
            foreach (var item in second)
            {
                // Try to find a key for the item
                // The keys of a dictionary are compared by reference, so we have to
                // find the original key that is equivalent to the "item"
                // You may want to override ".Equals" to define what it means for
                // two "T" objects to be equal
                var key = keys.Find(
                    delegate (TSource listKey)
                    {
                        return listKey.Equals(item);
                    });

                // Check if a key was found
                if (key != null)
                {
                    itemCounts[key]--;
                }
                else
                {
                    // There was no occurence of this item in the first collection, thus the collections are not equal
                    return false;
                }
            }

            // The count of each item should be 0 if the contents of the collections are equal
            foreach (int value in itemCounts.Values)
            {
                if (value != 0)
                {
                    return false;
                }
            }

            // The collections are equal
            return true;
        }

        /// <summary>
        /// Determines whether collection contains exactly one element
        /// </summary>
        /// <param name="source">Collection to check</param>
        public static bool ContainsOneElement<TSource>(this IEnumerable<TSource> source)
        {
            return source.IsNotNullAndNotEmpty() && source.Recover().Skip(1).IsEmpty();
        }

        /// <summary>
        /// Determines whether collection contains more than one element
        /// </summary>
        /// <param name="source">Collection to check</param>
        public static bool ContainsMultipleElements<TSource>(this IEnumerable<TSource> source)
        {
            return source != null && source.Skip(1).IsNotEmpty();
        }

        /// <summary>
        /// Gets the next element after given or default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The enumerable to search</param>
        /// <param name="currentElement">The current element</param>
        /// <returns></returns>
        public static TSource GetNextElementOrDefault<TSource>(this IEnumerable<TSource> source, TSource currentElement)
        {
            var returnNextElement = false;
            foreach (var item in source)
            {
                if (item.Equals(currentElement))
                {
                    returnNextElement = true;
                    continue;
                }
                else if (returnNextElement)
                {
                    return item;
                }
            }

            return default(TSource);
        }

        /// <summary>
        /// Gets the previous element before given or default
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">The enumerable to search</param>
        /// <param name="currentElement">The current element</param>
        /// <returns></returns>
        public static TSource GetPreviousElementOrDefault<TSource>(this IEnumerable<TSource> source, TSource currentElement)
        {
            var prevoiusElement = default(TSource);
            foreach (var item in source)
            {
                if (item.Equals(currentElement))
                    return prevoiusElement;
            }

            return default(TSource);
        }

        /// <summary>
        /// Takes last X elements
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">The enumerable to take elements from</param>
        /// <param name="count">The count to take</param>
        /// <returns></returns>
        public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int count)
        {
            return source.Recover().Skip(Math.Max(0, source.Count() - count));
        }

        /// <summary>
        /// If enumerable is null convert it into empty collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The enumerable to recover</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Recover<TSource>(this IEnumerable<TSource> source)
        {
            return source ?? Enumerable.Empty<TSource>();
        }

        /// <summary>
        /// Get item with maximum value of given property
        /// </summary>
        /// <typeparam name="TSource">The type of the item.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector to get value by which maximum is searched</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// source
        /// or
        /// selector
        /// </exception>
        /// <exception cref="InvalidOperationException">Sequence contains no elements</exception>
        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector) where TKey : IComparable
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    throw new InvalidOperationException("Sequence contains no elements");

                var maxKey = enumerator.Current;
                var maxValue = selector(maxKey);
                while (enumerator.MoveNext())
                {
                    var currentValue = selector(enumerator.Current);
                    if (maxValue.CompareTo(currentValue) < 0)
                    {
                        maxValue = currentValue;
                        maxKey = enumerator.Current;
                    }
                }
                return maxKey;
            }
        }

        /// <summary>
        /// Get item with minimum value of given property
        /// </summary>
        /// <typeparam name="TSource">The type of the item.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector to get value by which minimum is searched</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// source
        /// or
        /// selector
        /// </exception>
        /// <exception cref="InvalidOperationException">Sequence contains no elements</exception>
        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector) where TKey : IComparable
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    throw new InvalidOperationException("Sequence contains no elements");

                var minKey = enumerator.Current;
                var minValue = selector(minKey);
                while (enumerator.MoveNext())
                {
                    var currentValue = selector(enumerator.Current);
                    if (minValue.CompareTo(currentValue) > 0)
                    {
                        minValue = currentValue;
                        minKey = enumerator.Current;
                    }
                }
                return minKey;
            }
        }

        /// <summary>
        /// Computes the collection of distinct elements by specific property
        /// </summary>
        /// <typeparam name="TSource">The type of the item.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// source
        /// or
        /// selector
        /// </exception>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            var set = new HashSet<TKey>();
            foreach (var item in source.Recover())
            {
                var value = selector(item);
                if (set.Add(value))
                    yield return item;
            }
        }

        /// <summary>
        /// Finds the index using predicate
        /// </summary>
        /// <typeparam name="TSource">The type of the item.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// source
        /// or
        /// predicate
        /// </exception>
        public static int FindIndex<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var index = 0;
            using (var enumerator = source.Recover().GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return -1;

                do
                {
                    if (predicate(enumerator.Current))
                        return index;
                    else
                        index++;
                } while (enumerator.MoveNext());

                return -1;
            }
        }

        /// <summary>
        /// Splits collection into two collections based on whether or not they pass the condition provided
        /// </summary>
        /// <typeparam name="TSource">The type of the item.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">predicate</exception>
        public static (List<TSource> True, List<TSource> False) Partition<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var trueList = new List<TSource>();
            var falseList = new List<TSource>();
            using (var enumerator = source.Recover().GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return (trueList, falseList);

                do
                {
                    if (predicate(enumerator.Current))
                        trueList.Add(enumerator.Current);
                    else
                        falseList.Add(enumerator.Current);
                } while (enumerator.MoveNext());

                return (trueList, falseList);
            }
        }

        /// <summary>
        /// Returns items from source batched in arrays with given size
        /// </summary>
        /// <typeparam name="TSource">The type of the item.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="size">The size of batch</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">size - The batch must have at least 1 length</exception>
        public static IEnumerable<TSource[]> Batch<TSource>(this IEnumerable<TSource> source, int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size), "The batch must have at least 1 length");

            var count = 0;
            TSource[] batch = null;
            foreach (var item in source.Recover())
            {
                if (batch == null)
                    batch = new TSource[size];

                batch[count++] = item;
                if (count == size)
                {
                    yield return batch;

                    batch = null;
                    count = 0;
                }
            }

            if (batch != null && count > 0)
            {
                Array.Resize(ref batch, count);
                yield return batch;
            }
        }

        /// <summary>
        /// Returns items existing both in first and in second collection. Using selectors to get property by which to compare, so you can compare collections of different types.
        /// </summary>
        /// <typeparam name="TFirst">The type of the items in first collection</typeparam>
        /// <typeparam name="TSecond">The type of the items in second collection</typeparam>
        /// <typeparam name="TKey">The type of key by which compare occurs</typeparam>
        /// <param name="first">The source collection</param>
        /// <param name="second">Collection to intersect with</param>
        /// <param name="firstSelector">The selector for first collection</param>
        /// <param name="secondSelector">The selector for second collection</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TFirst> IntersectBy<TFirst, TSecond, TKey>(this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second, Func<TFirst, TKey> firstSelector, Func<TSecond, TKey> secondSelector)
        {
            if (firstSelector == null)
                throw new ArgumentNullException(nameof(firstSelector));
            if (secondSelector == null)
                throw new ArgumentNullException(nameof(secondSelector));

            return first.Recover().Join(second.Recover(), firstSelector, secondSelector, (s, i) => s);
        }

        /// <summary>
        /// Returns items existing in first sequence but not in second sequence. Using selectors to get property by which to compare, so you can compare collections of different types.
        /// </summary>
        /// <typeparam name="TFirst">The type of the items in first collection</typeparam>
        /// <typeparam name="TSecond">The type of the items in second collection</typeparam>
        /// <typeparam name="TKey">The type of key by which compare occurs</typeparam>
        /// <param name="first">The source collection</param>
        /// <param name="second">Collection to compare with</param>
        /// <param name="firstSelector">The selector for first collection</param>
        /// <param name="secondSelector">The selector for second collection</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TFirst> ExceptBy<TFirst, TSecond, TKey>(this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second, Func<TFirst, TKey> firstSelector, Func<TSecond, TKey> secondSelector)
        {
            if (firstSelector == null)
                throw new ArgumentNullException(nameof(firstSelector));
            if (secondSelector == null)
                throw new ArgumentNullException(nameof(secondSelector));

            var keys = new HashSet<TKey>(second.Recover().Select(secondSelector));
            foreach (var element in first.Recover())
            {
                var key = firstSelector(element);
                if (keys.Contains(key))
                    continue;

                yield return element;
                keys.Add(key);
            }
        }

        /// <summary>
        /// Do left join with another collection. If the isn't a item to join with, default value is returned.
        /// </summary>
        /// <typeparam name="TFirst">The type of the items in first collection</typeparam>
        /// <typeparam name="TSecond">The type of the items in second collection</typeparam>
        /// <typeparam name="TKey">The type of key by which compare occurs</typeparam>
        /// <typeparam name="TResult">The result of join</typeparam>
        /// <param name="first">The source collection</param>
        /// <param name="second">Collection to join</param>
        /// <param name="firstSelector">The selector for first collection</param>
        /// <param name="secondSelector">The selector for second collection</param>
        /// <param name="resultSelector">The selector of colection join</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TResult> LeftJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second, Func<TFirst, TKey> firstSelector, Func<TSecond, TKey> secondSelector,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            //from https://stackoverflow.com/a/584840

            if (firstSelector == null)
                throw new ArgumentNullException(nameof(firstSelector));
            if (secondSelector == null)
                throw new ArgumentNullException(nameof(secondSelector));
            if (resultSelector == null)
                throw new ArgumentNullException(nameof(resultSelector));

            return first.Recover()
                .GroupJoin(second.Recover(), firstSelector, secondSelector, (f, s) => new { First = f, Second = s })
                .SelectMany(x => x.Second.DefaultIfEmpty(), (f, s) => resultSelector(f.First, s));
        }
    }
}
