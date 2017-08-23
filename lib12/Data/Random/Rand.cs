using System;
using System.Linq;
using System.Text;
using lib12.Misc;
using lib12.Extensions;

namespace lib12.Data.Random
{
    public static partial class Rand
    {
        private static readonly System.Random random;

        static Rand()
        {
            random = new System.Random();
        }

        /// <summary>
        /// Returns a random boolean value with setted percent for true
        /// </summary>
        /// <param name="percentForTrue">Percent for generating true value</param>
        /// <returns>Random boolean value</returns>
        public static bool NextBool(int percentForTrue = 50)
        {
            return random.Next(1, 101) < percentForTrue;
        }

        public static int NextInt()
        {
            return random.Next();
        }

        public static int NextInt(int max)
        {
            return random.Next(max);
        }

        public static int NextInt(int min, int max)
        {
            return random.Next(min, max);
        }

        /// <summary>
        /// Returns a double value between provided range
        /// </summary>
        /// <param name="start">Inclusive minimum value</param>
        /// <param name="end">Inclusive maximum value</param>
        /// <returns>Random double value between provided range</returns>
        public static double NextDouble(double start, double end)
        {
            return start + random.NextDouble() * (end - start);
        }

        /// <summary>
        /// Returns a lowercase letter
        /// </summary>
        /// <returns>Lowercase letter</returns>
        public static char NextLowercaseLetter()
        {
            return (char)((short)'a' + random.Next(26));
        }

        /// <summary>
        /// Returns a random string
        /// </summary>
        /// <returns>Random string</returns>
        public static string NextString()
        {
            return NextString(random.Next(4, 10));
        }

        /// <summary>
        /// Returns a random string with provided length
        /// </summary>
        /// <param name="length">Returned string length</param>
        /// <returns>Random string with provided length</returns>
        public static string NextString(int length)
        {
            var sbuilder = new StringBuilder();
            TimesLoop.Do(length, () => sbuilder.Append(NextLowercaseLetter()));
            return sbuilder.ToString();
        }

        /// <summary>
        /// Returns a random DateTime between provided range
        /// </summary>     
        /// <param name="from">Start date</param>
        /// <param name="to">End date</param>
        /// <returns>Random DateTime between provided range</returns>
        public static DateTime NextDateTime(DateTime from, DateTime to)
        {
            var days = (to - from).TotalDays;
            return from.AddDays(NextDouble(0, days));
        }

        public static string NextMaleName()
        {
            return FakeData.MaleNames.GetRandomItem();
        }

        public static string NextFemaleName()
        {
            return FakeData.FemaleNames.GetRandomItem();
        }

        public static string NextName()
        {
            return FakeData.MaleNames.Concat(FakeData.FemaleNames).GetRandomItem();
        }

        public static string NextSurname()
        {
            return FakeData.Surnames.GetRandomItem();
        }

        public static string NextFullName()
        {
            return $"{NextName()} {NextSurname()}";
        }

        public static string NextCountry()
        {
            return FakeData.Countries.GetRandomItem();
        }

        public static string NextCity()
        {
            return FakeData.Cities.GetRandomItem();
        }

        public static string NextZipCode()
        {
            return $"{NextInt(1, 99):00}-{NextInt(1, 999):000}";
        }

        public static string NextStreet()
        {
            return FakeData.Streets.GetRandomItem();
        }

        public static string NextAddress()
        {
            return $"{NextStreet()} {NextInt(1, 125)}";
        }

        public static string NextCompany()
        {
            return FakeData.Companies.GetRandomItem();
        }

        public static string NextEmail()
        {
            return $"{NextName()}@{NextCompany().Replace(" ", "_")}.com";
        }

        public static object NextEnum(Type enumType)
        {
            var values = Enum.GetValues(enumType);
            return values
                .Cast<object>()
                .GetRandomItem();
        }

        public static TEnum NextEnum<TEnum>()
        {
            return (TEnum) NextEnum(typeof (TEnum));
        }
    }
}