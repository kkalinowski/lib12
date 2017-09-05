using System.Linq;
using lib12.FunctionalFlow;

namespace lib12.Misc
{
    public static class Check
    {
        public static bool AllAreNull(params object[] toCheck)
        {
            return toCheck.All(x => x.Null());
        }

        public static bool AllAreNotNull(params object[] toCheck)
        {
            return toCheck.All(x => x.NotNull());
        }

        public static bool AnyIsNull(params object[] toCheck)
        {
            return toCheck.Any(x => x.Null());
        }

        public static bool AnyIsNotNull(params object[] toCheck)
        {
            return toCheck.Any(x => x.NotNull());
        }
    }
}