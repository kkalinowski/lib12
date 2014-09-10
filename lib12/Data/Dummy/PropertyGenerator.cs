using System;
using System.Linq.Expressions;
using lib12.Reflection;

namespace lib12.Data.Dummy
{
    public abstract class PropertyGenerator<T, T2> : PropertyGeneratorBase<T>
    {
        public Expression<Func<T, T2>> Selector { get; set; }

        public override string PropertyName
        {
            get { return Selector.GetName(); }
        }

        protected PropertyGenerator(Expression<Func<T, T2>> selector)
        {
            Selector = selector;
        }
    }
}
