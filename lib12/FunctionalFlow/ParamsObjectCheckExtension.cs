using System.Linq;

namespace lib12.FunctionalFlow
{
    public static class ParamsObjectCheckExtension
    {
        public static bool AllNull(params object[] toCheck)
        {
            return toCheck.All(x => x.Null());
        }

        public static bool AllNotNull(params object[] toCheck)
        {
            return toCheck.All(x => x.NotNull());
        }

        public static bool AnyNull(params object[] toCheck)
        {
            return toCheck.Any(x => x.Null());
        }

        public static bool AnyNotNull(params object[] toCheck)
        {
            return toCheck.Any(x => x.NotNull());
        }
    }
}