using System.Linq;

namespace lib12.FunctionalFlow
{
    public static class MaybeObjectParamsExtension
    {
        public static Maybe AllNull(params object[] toCheck)
        {
            return Maybe.Create(toCheck.All(x => x.Null()));
        }

        public static Maybe AllNotNull(params object[] toCheck)
        {
            return Maybe.Create(toCheck.All(x => x.NotNull()));
        }

        public static Maybe AnyNull(params object[] toCheck)
        {
            return Maybe.Create(toCheck.Any(x => x.Null()));
        }

        public static Maybe AnyNotNull(params object[] toCheck)
        {
            return Maybe.Create(toCheck.Any(x => x.NotNull()));
        }
    }
}