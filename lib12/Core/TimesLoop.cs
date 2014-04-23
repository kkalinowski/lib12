using System;

namespace lib12.Core
{
    /// <summary>
    /// Times loop - calls given function X times
    /// </summary>
    public static class TimesLoop
    {
        public static void Do(int times, Action action)
        {
            for (int i = 0; i < times; i++)
            {
                action();
            }
        }

        public static void Do<T>(int times, Action<T> action, T parameter)
        {
            for (int i = 0; i < times; i++)
            {
                action(parameter);
            }
        }

        public static void Do<T1, T2>(int times, Action<T1, T2> action, T1 parameter1, T2 parameter2)
        {
            for (int i = 0; i < times; i++)
            {
                action(parameter1, parameter2);
            }
        }

        public static void DoFunc<TRes>(int times, Func<TRes> func)
        {
            for (int i = 0; i < times; i++)
            {
                func();
            }
        }

        public static void DoFunc<T, TRes>(int times, Func<T, TRes> func, T parameter)
        {
            for (int i = 0; i < times; i++)
            {
                func(parameter);
            }
        }

        public static void DoFunc<T1, T2, TRes>(int times, Func<T1, T2, TRes> func, T1 parameter1, T2 parameter2)
        {
            for (int i = 0; i < times; i++)
            {
                func(parameter1, parameter2);
            }
        }
    }
}
