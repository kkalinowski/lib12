using System.Linq;

namespace lib12.Monoids
{
    public static class Monoid
    {
        public static MonoidResult AllNull(params object[] toCheck)
        {
            return MonoidResult.Create(toCheck.All(x => x.Null()));
        }

        public static MonoidResult AllNotNull(params object[] toCheck)
        {
            return MonoidResult.Create(toCheck.All(x => x.NotNull()));
        }

        public static MonoidResult AnyNull(params object[] toCheck)
        {
            return MonoidResult.Create(toCheck.Any(x => x.Null()));
        }

        public static MonoidResult AnyNotNull(params object[] toCheck)
        {
            return MonoidResult.Create(toCheck.Any(x => x.NotNull()));
        }
    }
}