using System;
using System.Linq.Expressions;
using lib12.Reflection;

namespace lib12.Data.Random
{
    public class IntGenerator<T> : PropertyGenerator<T, int>
    {
        public int Min { get; set; }

        public int Max { get; set; }

        public IntGenerator(Expression<Func<T, int>> selector, int min = 0, int max = int.MaxValue)
            : base(selector)
        {
            Min = min;
            Max = max;
        }

        public override void GenerateProperty(T item, System.Random random)
        {
            Selector.SetValue(item, random.Next(Min, Max));
        }
    }
}