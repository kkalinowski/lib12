using System;
using System.Collections.Generic;
using System.Linq;

namespace lib12.Extensions
{
    public static class ExceptionExtension
    {
        public static Exception GetMostInnerException(this Exception exception)
        {
            if (exception.InnerException == null)
                return exception;

            return exception
                .GetInnerExceptions()
                .Last();
        }

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