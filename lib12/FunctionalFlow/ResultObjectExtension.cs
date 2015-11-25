using System;

namespace lib12.FunctionalFlow
{
    //based on http://devtalk.net/2010/09/12/chained-null-checks-and-the-maybe-monad/

    public static class ResultObjectExtension
    {
        public static TResult With<TSource, TResult>(this TSource source, Func<TSource, TResult> evaluator, TResult defaultValue = default (TResult))
            where TSource : class
        {
            return source == null ? defaultValue : evaluator(source);
        }

        public static TSource If<TSource>(this TSource source, Predicate<TSource> predicate)
            where TSource : class
        {
            if (source == null)
                return null;

            return predicate(source) ? source : null;
        }

        public static TSource IfNot<TSource>(this TSource source, Predicate<TSource> predicate)
            where TSource : class
        {
            if (source == null)
                return null;

            return predicate(source) ? null : source;
        }

        public static TSource Do<TSource>(this TSource source, Action<TSource> action)
            where TSource : class
        {
            if (source == null)
                return null;

            action(source);
            return source;
        }

        public static TSource DoIfFailure<TSource>(this TSource source, Action action)
            where TSource : class
        {
            if (source == null)
                action();

            return source;
        }

        /// <summary>
        /// Throw exception if checked object is null
        /// </summary>
        public static void ThrowExceptionIfNull<TSource>(this TSource source) 
            where TSource : class
        {
            if (source == null)
                throw new NullReferenceException();
        }

        /// <summary>
        /// Throw exception if checked object is null
        /// </summary>
        public static void ThrowExceptionIfNull<TSource>(this TSource source, Exception ex) 
            where TSource : class
        {
            if (source == null)
                throw ex;
        }
    }
}