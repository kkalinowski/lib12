using System;
using System.Collections.Generic;
using System.Linq;

namespace lib12.Extensions
{
    /// <summary>
    /// ExceptionExtension
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// Gets the most inner exception of given exception.
        /// If exception doesn't have InnerException returns source exception.
        /// </summary>
        /// <param name="exception">The source exception.</param>
        /// <returns></returns>
        public static Exception GetMostInnerException(this Exception exception)
        {
            if (exception.InnerException == null)
                return exception;

            return exception
                .GetInnerExceptions()
                .Last();
        }

        /// <summary>
        /// Gets list of inner exceptions from source exception
        /// </summary>
        /// <param name="exception">The source exception.</param>
        /// <returns></returns>
        public static IEnumerable<Exception> GetInnerExceptions(this Exception exception)
        {
            var ex = exception.InnerException;
            while (ex != null)
            {
                yield return ex;
                ex = ex.InnerException;
            }
        }
    }
}