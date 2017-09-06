using System;
using System.Linq.Expressions;
using lib12.Reflection;
using ConstrainCollection = System.Collections.Generic.Dictionary<string, lib12.Data.Random.RandDataConstrain>;

namespace lib12.Data.Random
{
    public class ConstrainFactory
    {
        public class ConstrainFactoryOf<TSource>
        {
            private readonly ConstrainCollection result = new ConstrainCollection();

            internal ConstrainFactoryOf()
            {

            }

            public ConstrainFactoryOf<TSource> AddValueSetConstrain<TKey>(Expression<Func<TSource, TKey>> selector,
                params TKey[] availableValues)
            {
                var propertyName = selector.GetName();
                result.Add(propertyName, new ValueSetConstrain { AvailableValues = availableValues });

                return this;
            }

            public ConstrainFactoryOf<TSource> AddIntConstrain(Expression<Func<TSource, int>> selector, int minValue, int maxValue)
            {
                var propertyName = selector.GetName();
                result.Add(propertyName, new IntConstrain { MinValue = minValue, MaxValue = maxValue });

                return this;
            }

            public ConstrainFactoryOf<TSource> AddDoubleConstrain(Expression<Func<TSource, double>> selector, double minValue, double maxValue)
            {
                var propertyName = selector.GetName();
                result.Add(propertyName, new DoubleConstrain { MinValue = minValue, MaxValue = maxValue });

                return this;
            }

            public ConstrainCollection Build()
            {
                return result;
            }
        }

        public static ConstrainFactoryOf<TSource> For<TSource>()
        {
            return new ConstrainFactoryOf<TSource>();
        }
    }
}