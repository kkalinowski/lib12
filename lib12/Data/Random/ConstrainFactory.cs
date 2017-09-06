using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using lib12.Reflection;

namespace lib12.Data.Random
{
    public class ConstrainFactory<TSource>
    {
        private readonly Dictionary<string, RandDataConstrain> constrainsDictionary = new Dictionary<string, RandDataConstrain>();

        private ConstrainFactory()
        {
            
        }

        public static ConstrainFactory<TSource> Create()
        {
            return new ConstrainFactory<TSource>();
        }

        public ConstrainFactory<TSource> AddValueSetConstrain<TKey>(Expression<Func<TSource, TKey>> selector,
            params TKey[] availableValues)
        {
            var propertyName = selector.GetName();
            constrainsDictionary.Add(propertyName, new ValueSetConstrain<TKey> { AvailableValues = availableValues });

            return this;
        }

        public ConstrainFactory<TSource> AddIntConstrain(Expression<Func<TSource, int>> selector, int minValue, int maxValue)
        {
            var propertyName = selector.GetName();
            constrainsDictionary.Add(propertyName, new IntConstrain{ MinValue = minValue, MaxValue = maxValue});

            return this;
        }

        public ConstrainFactory<TSource> AddDoubleConstrain(Expression<Func<TSource, int>> selector, double minValue, double maxValue)
        {
            var propertyName = selector.GetName();
            constrainsDictionary.Add(propertyName, new DoubleConstrain { MinValue = minValue, MaxValue = maxValue });

            return this;
        }
    }
}