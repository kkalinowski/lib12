using System;

namespace lib12.FunctionalFlow
{
    public static class ResultObjectExtension
    {
        public static TResult With<TSource, TResult>(this TSource source, Func<TSource, TResult> evaluator, TResult defaultValue = default (TResult))
          where TSource : class
        {
            return source == null ? defaultValue : evaluator(source);
        }
    }
}