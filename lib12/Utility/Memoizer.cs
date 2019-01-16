using System;
using System.Collections.Generic;

namespace lib12.Utility
{
    public static class Memoizer
    {
        public static Func<TParam1, TResult> CreateForOneParameter<TParam1, TResult>(this Func<TParam1, TResult> func)
        {
            var map = new Dictionary<TParam1, TResult>();
            return param1 =>
            {
                if (map.TryGetValue(param1, out var value))
                    return value;

                value = func(param1);
                map.Add(param1, value);

                return value;
            };
        }
    }
}