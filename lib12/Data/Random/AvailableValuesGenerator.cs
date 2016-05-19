using System;
using System.Linq.Expressions;
using lib12.Reflection;

namespace lib12.Data.Random
{
    public class AvailableValuesGenerator<T, TProp> : PropertyGenerator<T, TProp>
    {
        private readonly TProp[] availableValues;

        public AvailableValuesGenerator(Expression<Func<T, TProp>> selector, params TProp[] availableValues)
            : base(selector)
        {
            this.availableValues = availableValues;
        }

        public override void GenerateProperty(T item)
        {
            Selector.SetValue(item, availableValues.GetRandomItem());
        }
    }
}