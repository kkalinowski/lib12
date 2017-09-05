using System.Linq;
using lib12.Extensions;

namespace lib12.Misc
{
    public static class Check
    {
        public static bool AllAreNull(params object[] toCheck)
        {
            return toCheck.All(x => x.IsNull());
        }

        public static bool AllAreNotNull(params object[] toCheck)
        {
            return toCheck.All(x => x.IsNotNull());
        }

        public static bool AnyIsNull(params object[] toCheck)
        {
            return toCheck.Any(x => x.IsNull());
        }

        public static bool AnyIsNotNull(params object[] toCheck)
        {
            return toCheck.Any(x => x.IsNotNull());
        }
    }
}