using System;

namespace lib12.FunctionalFlow
{
    public class MaybeResult
    {
        public bool Result { get; private set; }

        public static MaybeResult Create(bool result)
        {
            return new MaybeResult {Result = result};
        }

        public void Do(Action action)
        {
            if (Result)
                action();
        }

        public void ThrowIfFailure(Exception ex)
        {
            if (!Result)
                throw ex;
        }

        public static implicit operator bool(MaybeResult result)
        {
            return result.Result;
        }
    }
}