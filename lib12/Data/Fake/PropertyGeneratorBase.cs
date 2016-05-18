using System;

namespace lib12.Data.Dummy
{
    public abstract class PropertyGeneratorBase<T>
    {
        public abstract string PropertyName { get; }
        public abstract void GenerateProperty(T item, Random random);
    }
}