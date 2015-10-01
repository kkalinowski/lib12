using System.Linq;

namespace lib12.FunctionalFlow
{
    public static class Maybe
    {
        public static MaybeResult AllNull(params object[] toCheck)
        {
            return MaybeResult.Create(toCheck.All(x => x.Null()));
        }

        public static MaybeResult AllNotNull(params object[] toCheck)
        {
            return MaybeResult.Create(toCheck.All(x => x.NotNull()));
        }

        public static MaybeResult AnyNull(params object[] toCheck)
        {
            return MaybeResult.Create(toCheck.Any(x => x.Null()));
        }

        public static MaybeResult AnyNotNull(params object[] toCheck)
        {
            return MaybeResult.Create(toCheck.Any(x => x.NotNull()));
        }
    }
}