using System;

namespace lib12.FunctionalFlow
{
    public class Maybe
    {
        public bool Result { get; private set; }

        public static Maybe Create(bool result)
        {
            return new Maybe {Result = result};
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

        public static implicit operator bool(Maybe result)
        {
            return result.Result;
        }
    }
}