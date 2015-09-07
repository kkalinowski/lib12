using System;

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

        ///// <summary>
        ///// If object is null recover to function flow with given object
        ///// </summary>
        ///// <param name="@object"></param>
        ///// <returns></returns>
        public static TObject Recover<TObject>(this TObject @object, TObject recoverWith) where TObject : class
        {
            return @object.NotNull() ? @object : recoverWith;
        }

        ///// <summary>
        ///// If object is null recover to function flow with default newly created object
        ///// </summary>
        ///// <param name="@object"></param>
        ///// <returns></returns>
        public static TObject RecoverWithDefault<TObject>(this TObject @object) where TObject : class
        {
            return @object.NotNull() ? @object : (TObject)Activator.CreateInstance(typeof(TObject));
        }
    }
}