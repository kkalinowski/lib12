using System;
using System.Collections.Generic;

namespace lib12.Collections
{
    public static class ListUtil
    {
        public static List<T> FillList<T>(int count, Func<T> func)
        {
            var res = new List<T>();

            for (int i = 0; i < count; i++)
            {
                res.Add(func());
            }

            return res;
        }
    }
}
