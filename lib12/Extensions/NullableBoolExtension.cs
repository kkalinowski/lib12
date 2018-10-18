namespace lib12.Extensions
{
    public static class NullableBoolExtension
    {
        public static bool IsTrue(this bool? source)
        {
            return source.HasValue && source.Value;
        }

        public static bool IsFalse(this bool? source)
        {
            return source.HasValue && !source.Value;
        }

        public static bool IsNullOrFalse(this bool? source)
        {
            return !source.HasValue || (source.HasValue && !source.Value);
        }
    }
}