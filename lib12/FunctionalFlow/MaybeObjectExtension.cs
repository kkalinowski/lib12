using System;

namespace lib12.FunctionalFlow
{
    public static class MaybeObjectExtension
    {
        /// <summary>
        /// Check if given object is null
        /// </summary>
        /// <param name="object">Object to check</param>
        /// <returns></returns>
        public static Maybe Null<TObject>(this TObject @object) where TObject : class
        {
            return Maybe.Create(@object == null);
        }

        ///// <summary>
        ///// Check if given object is not null
        ///// </summary>
        ///// <param name="@object"></param>
        ///// <returns></returns>
        public static Maybe NotNull<TObject>(this TObject @object) where TObject : class
        {
            return Maybe.Create(@object != null);
        }
    }
}