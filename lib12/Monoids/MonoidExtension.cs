namespace lib12.Monoids
{
    public static class MonoidExtension
    {
        /// <summary>
        /// Check if given object is null
        /// </summary>
        /// <param name="object">Object to check</param>
        /// <returns></returns>
        public static MonoidResult Null<TObject>(this TObject @object) where TObject : class
        {
            return MonoidResult.Create(@object == null);
        }

        ///// <summary>
        ///// Check if given object is not null
        ///// </summary>
        ///// <param name="@object"></param>
        ///// <returns></returns>
        public static MonoidResult NotNull<TObject>(this TObject @object) where TObject : class
        {
            return MonoidResult.Create(@object != null);
        }
    }
}