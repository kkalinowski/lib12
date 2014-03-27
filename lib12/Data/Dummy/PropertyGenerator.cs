using System;
using System.Linq.Expressions;

namespace lib12.Data.Dummy
{
    public abstract class PropertyGenerator<T, T2> : PropertyGeneratorBase<T>
    {
        public Expression<Func<T, T2>> Selector { get; set; }

        protected PropertyGenerator(Expression<Func<T, T2>> selector)
        {
            Selector = selector;
        }
    }
}
