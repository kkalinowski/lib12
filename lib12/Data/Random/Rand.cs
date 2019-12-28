using System;
using System.Linq;
using lib12.Collections;
using lib12.Data.Geopolitical;

namespace lib12.Data.Random
{
    /// <summary>
    /// Generates random data
    /// </summary>
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

        /// <summary>
        /// Returns a random int value
        /// </summary>
        /// <returns></returns>
        public static int NextInt()
        {
            return random.Next();
        }

        /// <summary>
        /// Returns a random int value
        /// </summary>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static int NextInt(int max)
        {
            return random.Next(max);
        }

        /// <summary>
        /// Returns a random int value
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
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
            return new string(CollectionFactory.CreateArray(10, i => NextLowercaseLetter()));
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

        /// <summary>
        /// Returns a random Male Name
        /// </summary>
        /// <returns></returns>
        public static string NextMaleName()
        {
            return FakeData.MaleNames.GetRandomItem();
        }

        /// <summary>
        /// Returns a random Female Name
        /// </summary>
        /// <returns></returns>
        public static string NextFemaleName()
        {
            return FakeData.FemaleNames.GetRandomItem();
        }

        /// <summary>
        /// Returns a random Name
        /// </summary>
        /// <returns></returns>
        public static string NextName()
        {
            return FakeData.MaleNames.Concat(FakeData.FemaleNames).GetRandomItem();
        }

        /// <summary>
        /// Returns a random surname
        /// </summary>
        /// <returns></returns>
        public static string NextSurname()
        {
            return FakeData.Surnames.GetRandomItem();
        }

        /// <summary>
        /// Returns a random name and surname
        /// </summary>
        /// <returns></returns>
        public static string NextFullName()
        {
            return $"{NextName()} {NextSurname()}";
        }

        /// <summary>
        /// Returns a random country
        /// </summary>
        /// <returns></returns>
        public static string NextCountry()
        {
            return CountryRepository.AllCountries.GetRandomItem().Name;
        }

        /// <summary>
        /// Returns a random city
        /// </summary>
        /// <returns></returns>
        public static string NextCity()
        {
            return FakeData.Cities.GetRandomItem();
        }

        /// <summary>
        /// Returns a random zip code
        /// </summary>
        /// <returns></returns>
        public static string NextZipCode()
        {
            return $"{NextInt(1, 99):00}-{NextInt(1, 999):000}";
        }

        /// <summary>
        /// Returns a random street
        /// </summary>
        /// <returns></returns>
        public static string NextStreet()
        {
            return FakeData.Streets.GetRandomItem();
        }

        /// <summary>
        /// Returns a random adress - street with number
        /// </summary>
        /// <returns></returns>
        public static string NextAddress()
        {
            return $"{NextStreet()} {NextInt(1, 125)}";
        }

        /// <summary>
        /// Returns a random company
        /// </summary>
        /// <returns></returns>
        public static string NextCompany()
        {
            return FakeData.Companies.GetRandomItem();
        }

        /// <summary>
        /// Returns a random email
        /// </summary>
        /// <returns></returns>
        public static string NextEmail()
        {
            return $"{NextName()}@{NextCompany().Replace(" ", "_")}.com";
        }

        /// <summary>
        /// Returns a random enum of given type
        /// </summary>
        /// <returns></returns>
        public static object NextEnum(Type enumType)
        {
            var values = Enum.GetValues(enumType);
            return values
                .Cast<object>()
                .GetRandomItem();
        }

        /// <summary>
        /// Returns a random enum of given type
        /// </summary>
        /// <returns></returns>
        public static TEnum NextEnum<TEnum>()
        {
            return (TEnum)NextEnum(typeof(TEnum));
        }
    }
}