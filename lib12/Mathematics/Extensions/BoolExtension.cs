namespace lib12.Mathematics.Extensions
{
    public static class BoolExtension
    {
        /// <summary>
        /// Converts bool to int
        /// </summary>
        /// <param name="source">The source bool</param>
        /// <returns>1 if true, 0 if false</returns>
        public static int ToInt(this bool source)
        {
            return source ? 1 : 0;
        }
    }
}