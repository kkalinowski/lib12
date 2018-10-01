using System;
using System.Linq.Expressions;
using lib12.Extensions;
using lib12.Reflection;
using ConstrainCollection = System.Collections.Generic.Dictionary<string, lib12.Data.Random.RandDataConstrain>;

namespace lib12.Data.Random
{
    /// <summary>
    /// Factory for creating constrains for random data creation
    /// </summary>
    public static class ConstrainFactory
    {
        /// <summary>
        /// Starts creating constrain for given type
        /// </summary>
        /// <typeparam name="TSource">The type of the to be generated.</typeparam>
        /// <returns></returns>
        public static ConstrainFactoryOf<TSource> For<TSource>()
        {
            return new ConstrainFactoryOf<TSource>();
        }

        /// <summary>
        /// Constrain factory subclass
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        public class ConstrainFactoryOf<TSource>
        {
            private readonly ConstrainCollection result = new ConstrainCollection();

            internal ConstrainFactoryOf()
            {

            }

            /// <summary>
            /// Adds constrain with set of possible values for property
            /// </summary>
            /// <typeparam name="TKey">The type of property</typeparam>
            /// <param name="selector">The selector for property</param>
            /// <param name="availableValues">The available values for property</param>
            /// <returns></returns>
            public ConstrainFactoryOf<TSource> AddValuesConstrain<TKey>(Expression<Func<TSource, TKey>> selector,
                params TKey[] availableValues)
            {
                var propertyName = selector.GetName();
                result.Add(propertyName, new ValueSetConstrain { AvailableValues = availableValues });

                return this;
            }

            /// <summary>
            /// Adds the constrain for int property.
            /// </summary>
            /// <param name="selector">The selector for property</param>
            /// <param name="minValue">The minimum value of property</param>
            /// <param name="maxValue">The maximum value of property</param>
            /// <returns></returns>
            public ConstrainFactoryOf<TSource> AddNumericConstrain(Expression<Func<TSource, int>> selector, int minValue, int maxValue)
            {
                var propertyName = selector.GetName();
                result.Add(propertyName, new IntConstrain { MinValue = minValue, MaxValue = maxValue });

                return this;
            }

            /// <summary>
            /// Adds the constrain for double property.
            /// </summary>
            /// <param name="selector">The selector for property</param>
            /// <param name="minValue">The minimum value of property</param>
            /// <param name="maxValue">The maximum value of property</param>
            /// <returns></returns>
            public ConstrainFactoryOf<TSource> AddNumericConstrain(Expression<Func<TSource, double>> selector, double minValue, double maxValue)
            {
                var propertyName = selector.GetName();
                result.Add(propertyName, new DoubleConstrain { MinValue = minValue, MaxValue = maxValue });

                return this;
            }

            /// <summary>
            /// Adds the constrain with the factory method, where you can easily create custom values for property
            /// </summary>
            /// <typeparam name="TValue">The type of the property</typeparam>
            /// <param name="selector">The selector for property</param>
            /// <param name="factoryMethod">The factory method to construct new values</param>
            /// <returns></returns>
            public ConstrainFactoryOf<TSource> AddFactoryMethodConstrain<TValue>(Expression<Func<TSource, TValue>> selector, Func<TValue> factoryMethod)
            {
                var propertyName = selector.GetName();
                result.Add(propertyName, new FactoryMethodConstrain{ FactoryMethod = factoryMethod.ConvertToNonGeneric() });

                return this;
            }

            /// <summary>
            /// Creates constrain set to use
            /// </summary>
            /// <returns></returns>
            public ConstrainCollection Build()
            {
                return result;
            }
        }
    }
}