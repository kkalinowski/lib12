using System;
using System.Linq.Expressions;
using lib12.Extensions;
using lib12.Reflection;

namespace lib12.Data.Random
{
    public class DoubleGenerator<T> : PropertyGenerator<T, double>
    {
        public double Min { get; set; }

        public double Max { get; set; }

        public DoubleGenerator(Expression<Func<T, double>> selector, double min = 0, double max = double.MaxValue)
            : base(selector)
        {
            Min = min;
            Max = max;
        }

        public override void GenerateProperty(T item, System.Random random)
        {
            Selector.SetValue(item, Rand.NextDouble(Min, Max));
        }
    }
}