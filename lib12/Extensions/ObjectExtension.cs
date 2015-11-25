using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace lib12.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Check if given object is null
        /// </summary>
        /// <param name="object">Object to check</param>
        /// <returns></returns>
        public static bool Null<TObject>(this TObject @object) where TObject : class
        {
            return @object == null;
        }

        ///// <summary>
        ///// Check if given object is not null
        ///// </summary>
        ///// <param name="@object"></param>
        ///// <returns></returns>
        public static bool NotNull<TObject>(this TObject @object) where TObject : class
        {
            return @object != null;
        }

        /// <summary>
        /// Packs given object into array.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public static TObject[] PackIntoArray<TObject>(this TObject @object)
        {
            return new[] { @object };
        }

        /// <summary>
        /// Packs given object into array.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public static List<TObject> PackIntoList<TObject>(this TObject @object)
        {
            return new List<TObject> { @object };
        }

        /// <summary>
        /// Checks if given collection contains this object
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="object">The object.</param>
        /// <param name="collection">The collection to check</param>
        /// <returns></returns>
        public static bool In<TObject>(this TObject @object, IEnumerable<TObject> collection)
        {
            return collection.Contains(@object);
        }

        /// <summary>
        /// Checks if given collection does not contains this object
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="object">The object.</param>
        /// <param name="collection">The collection to check</param>
        /// <returns></returns>
        public static bool NotIn<TObject>(this TObject @object, IEnumerable<TObject> collection)
        {
            return !collection.Contains(@object);
        }
    }
}