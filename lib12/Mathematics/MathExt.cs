
namespace lib12.Mathematics
{
    /// <summary>
    /// Set of various math functions
    /// </summary>
    public static class MathExt
    {
        /// <summary>
        /// Returns next number from specified set
        /// </summary>
        /// <param name="number">Current number</param>
        /// <param name="limit">Limit</param>
        public static int Next(int number, int limit)
        {
            return ++number < limit ? number : 0;
        }

        /// <summary>
        /// Returns previous number from specified set
        /// </summary>
        /// <param name="number">Current number</param>
        /// <param name="limit">Limit</param>
        public static int Prev(int number, int limit)
        {
            return --number < 0 ? limit : number;
        }

        /// <summary>
        /// Try to divide two numbers, if impossible returns 0
        /// </summary>
        /// <param name="a">Number to divide</param>
        /// <param name="b">Number to divide by</param>
        /// <returns></returns>
        public static double DivWithZero(double a, double b)
        {
            return b != 0 ? a / b : 0;
        }

        /// <summary>
        /// Iverson notation - if condition is true returns 1, otherwise 0
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public static int Iv(bool condition)
        {
            return condition ? 1 : 0;
        }

        /// <summary>
        /// Computes factorial for given number
        /// </summary>
        /// <param name="number">The number to compute factorial</param>
        /// <returns></returns>
        public static int Factorial(int number)
        {
            if (number < 0)
                throw new MathException("Factorial cannot be computed for negative numbers");

            var result = 1;
            for (int i = 2; i <= number; i++)
                result *= i;

            return result;
        }

        /// <summary>
        /// Computes factorial for given number
        /// </summary>
        /// <param name="number">The number to compute factorial</param>
        /// <returns></returns>
        public static uint Factorial(uint number)
        {
            var result = (uint)1;
            for (uint i = 2; i <= number; i++)
                result *= i;

            return result;
        }

        /// <summary>
        /// Computes factorial for given number
        /// </summary>
        /// <param name="number">The number to compute factorial</param>
        /// <returns></returns>
        public static long Factorial(long number)
        {
            if (number < 0)
                throw new MathException("Factorial cannot be computed for negative numbers");

            var result = (long)1;
            for (long i = 2; i <= number; i++)
                result *= i;

            return result;
        }

        /// <summary>
        /// Computes factorial for given number
        /// </summary>
        /// <param name="number">The number to compute factorial</param>
        /// <returns></returns>
        public static ulong Factorial(ulong number)
        {
            var result = (ulong)1;
            for (ulong i = 2; i <= number; i++)
                result *= i;

            return result;
        }
    }
}
