namespace lib12.Data.Random
{
    public abstract class PropertyGeneratorBase<T>
    {
        public abstract string PropertyName { get; }
        public abstract void GenerateProperty(T item);
    }
}