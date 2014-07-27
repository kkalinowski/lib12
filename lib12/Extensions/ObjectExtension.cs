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
        /// Safely get value from object
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="object">The object.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static TValue SafeGet<TObject, TValue>(this TObject @object, Expression<Func<TObject, TValue>> expression, TValue defaultValue = default(TValue)) where TObject : class
        {
            if (@object.NotNull())
                return expression.Compile().Invoke(@object);
            else
                return defaultValue;
        }

        /// <summary>
        /// Throw exception if checked object is null
        /// </summary>
        public static void ThrowExceptionIfNull<TObject>(this TObject @object) where @TObject : class
        {
            if (@object.Null())
                throw new NullReferenceException();
        }

        /// <summary>
        /// Throw exception if checked object is null
        /// </summary>
        /// <param name="object">Object to check</param>
        /// <param name="ex">Exception to throw</param>
        public static void ThrowExceptionIfNull<TObject>(this TObject @object, Exception ex) where @TObject : class
        {
            if (@object.Null())
                throw ex;
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