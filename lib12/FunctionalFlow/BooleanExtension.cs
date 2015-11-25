using System;

namespace lib12.FunctionalFlow
{
    public static class BooleanExtension
    {
        public static Maybe And(this bool @bool, bool secondArg)
        {
            return Maybe.Create(@bool && secondArg);
        }

        public static Maybe AndNot(this bool @bool, bool secondArg)
        {
            return Maybe.Create(@bool && !secondArg);
        }

        public static Maybe Or(this bool @bool, bool secondArg)
        {
            return Maybe.Create(@bool || secondArg);
        }

        public static Maybe OrNot(this bool @bool, bool secondArg)
        {
            return Maybe.Create(@bool || !secondArg);
        }

        public static void Do(this bool @bool, Action action)
        {
            if (@bool)
                action();
        }
    }
}