using System;

namespace lib12.Monoids
{
    public static class BooleanExtension
    {
        public static MonoidResult And(this bool @bool, bool secondArg)
        {
            return MonoidResult.Create(@bool && secondArg);
        }

        public static MonoidResult AndNot(this bool @bool, bool secondArg)
        {
            return MonoidResult.Create(@bool && !secondArg);
        }

        public static MonoidResult Or(this bool @bool, bool secondArg)
        {
            return MonoidResult.Create(@bool || secondArg);
        }

        public static MonoidResult OrNot(this bool @bool, bool secondArg)
        {
            return MonoidResult.Create(@bool || !secondArg);
        }

        public static void Do(this bool @bool, Action action)
        {
            if (@bool)
                action();
        }
    }
}