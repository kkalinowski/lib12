namespace lib12.Data.Random
{
    public static class Rand
    {
        private static readonly System.Random random;

        static Rand()
        {
            random = new System.Random();
        }
    }
}