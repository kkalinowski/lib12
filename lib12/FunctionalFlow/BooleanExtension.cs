using System;

namespace lib12.FunctionalFlow
{
    public static class BooleanExtension
    {
        public static MaybeResult And(this bool @bool, bool secondArg)
        {
            return MaybeResult.Create(@bool && secondArg);
        }

        public static MaybeResult AndNot(this bool @bool, bool secondArg)
        {
            return MaybeResult.Create(@bool && !secondArg);
        }

        public static MaybeResult Or(this bool @bool, bool secondArg)
        {
            return MaybeResult.Create(@bool || secondArg);
        }

        public static MaybeResult OrNot(this bool @bool, bool secondArg)
        {
            return MaybeResult.Create(@bool || !secondArg);
        }

        public static void Do(this bool @bool, Action action)
        {
            if (@bool)
                action();
        }
    }
}