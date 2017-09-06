using System;
using System.Collections.Generic;
using lib12.Reflection;

namespace lib12.Data.Random
{
    public class ConstrainFactory<TSource>
    {
        private Dictionary<string, RandConstrain> constrainsDictionary = new Dictionary<string, RandConstrain>();

        public ConstrainFactory<TSource> AddValueSetConstrain<TKey>(Func<TSource, TKey> selector,
            params TKey[] availableValues)
        {
            //var propertyName = selector.GetName();
            return null;
        }
    }
}