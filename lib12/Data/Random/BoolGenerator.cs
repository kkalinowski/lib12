using System;
using System.Linq.Expressions;
using lib12.Extensions;
using lib12.Reflection;

namespace lib12.Data.Random
{
    public class BoolGenerator<T> : PropertyGenerator<T, bool>
    {

        public BoolGenerator(Expression<Func<T, bool>> selector)
            : base(selector)
        {

        }

        public override void GenerateProperty(T item, System.Random random)
        {
            Selector.SetValue(item, Rand.NextBool());
        }
    }
}