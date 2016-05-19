using System;
using System.Linq.Expressions;
using lib12.Reflection;

namespace lib12.Data.Random
{
    public abstract class PropertyGenerator<T, TProp> : PropertyGeneratorBase<T>
    {
        public Expression<Func<T, TProp>> Selector { get; set; }

        public override string PropertyName
        {
            get { return Selector.GetName(); }
        }

        protected PropertyGenerator(Expression<Func<T, TProp>> selector)
        {
            Selector = selector;
        }
    }
}
