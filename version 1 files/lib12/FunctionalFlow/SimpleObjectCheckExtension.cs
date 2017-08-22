namespace lib12.FunctionalFlow
{
    public static class SimpleObjectCheckExtension
    {
        /// <summary>
        /// Check if given object is null
        /// </summary>
        /// <returns></returns>
        public static bool Null<TSource>(this TSource source) where TSource : class
        {
            return source == null;
        }

        ///// <summary>
        ///// Check if given object is not null
        ///// </summary>
        ///// <param name="source"></param>
        ///// <returns></returns>
        public static bool NotNull<TSource>(this TSource source) where TSource : class
        {
            return source != null;
        }
    }
}