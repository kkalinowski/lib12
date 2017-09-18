using System.Linq;

namespace lib12.Checking
{
    /// <summary>
    /// Check condition on set of objects
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Checks if all given objects are null
        /// </summary>
        /// <param name="toCheck">To collection with objects to check</param>
        /// <returns></returns>
        public static bool AllAreNull(params object[] toCheck)
        {
            return toCheck.All(x => x == null);
        }

        /// <summary>
        /// Checks if all given objects are not null
        /// </summary>
        /// <param name="toCheck">To collection with objects to check</param>
        /// <returns></returns>
        public static bool AllAreNotNull(params object[] toCheck)
        {
            return toCheck.All(x => x != null);
        }

        /// <summary>
        /// Checks if any of given objects is null
        /// </summary>
        /// <param name="toCheck">To collection with objects to check</param>
        /// <returns></returns>
        public static bool AnyIsNull(params object[] toCheck)
        {
            return toCheck.Any(x => x == null);
        }

        /// <summary>
        /// Checks if any of given objects is not null
        /// </summary>
        /// <param name="toCheck">To collection with objects to check</param>
        /// <returns></returns>
        public static bool AnyIsNotNull(params object[] toCheck)
        {
            return toCheck.Any(x => x != null);
        }
    }
}