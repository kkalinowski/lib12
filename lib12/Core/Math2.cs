
namespace lib12.Core
{
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
        /// Iverson notation - if condition is true returns 1, otherwise 0
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public static int Iv(bool condition)
        {
            return condition ? 1 : 0;
        }
    }
}
