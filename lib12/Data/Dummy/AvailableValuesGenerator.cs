using lib12.Reflection;
using System;
using System.Linq.Expressions;

namespace lib12.Data.Dummy
{
    public class AvailableValuesGenerator<T, TProp> : PropertyGenerator<T, TProp>
    {
        private readonly TProp[] availableValues;

        public AvailableValuesGenerator(Expression<Func<T, TProp>> selector, params TProp[] availableValues)
            : base(selector)
        {
            this.availableValues = availableValues;
        }

        public override void GenerateProperty(T item, Random random)
        {
            Selector.SetValue(item, availableValues.GetRandomItem(random));
        }
    }
}