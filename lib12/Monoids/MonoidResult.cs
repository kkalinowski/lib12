using System;

namespace lib12.Monoids
{
    public class MonoidResult
    {
        public bool Result { get; private set; }

        public static MonoidResult Create(bool result)
        {
            return new MonoidResult {Result = result};
        }

        public void Do(Action action)
        {
            if (Result)
                action();
        }

        public static implicit operator bool(MonoidResult result)
        {
            return result.Result;
        }
    }
}