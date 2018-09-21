namespace lib12.Mathematics
{
    /// <summary>
    /// Set of various math functions
    /// </summary>
    public static class Math2
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
        /// Determines whether the specified number is even.
        /// </summary>
        /// <param name="number">The number to check</param>
        /// <returns>
        ///   <c>true</c> if the specified number is even; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Determines whether the specified number is odd.
        /// </summary>
        /// <param name="number">The number to check</param>
        /// <returns>
        ///   <c>true</c> if the specified number is odd; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOdd(int number)
        {
            return !IsEven(number);
        }
    }
}