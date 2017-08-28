using System;
using System.Collections.Generic;

namespace lib12.Collections
{
    public static class CollectionFactory
    {
        public static IEnumerable<TResult> CreateEnumerable<TResult, TStep>(Func<TStep, TResult> func, Func<TStep, TStep> stepFunc, TStep initialStep)
        {
            var currentStep = initialStep;
            while (true)
            {
                yield return func(currentStep);
                currentStep = stepFunc(currentStep);
            }
        }
    }
}