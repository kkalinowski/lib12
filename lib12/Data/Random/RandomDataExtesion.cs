using System.Linq;
using lib12.Extensions;

namespace lib12.Data.Random
{
    public static class RandomDataExtesion
    {
        public static string NextMaleName(this System.Random random)
        {
            return FakeData.MaleNames.GetRandomItem(random);
        }

        public static string NextFemaleName(this System.Random random)
        {
            return FakeData.FemaleNames.GetRandomItem(random);
        }

        public static string NextName(this System.Random random)
        {
            return FakeData.MaleNames.Concat(FakeData.FemaleNames).GetRandomItem(random);
        }

        public static string NextSurname(this System.Random random)
        {
            return FakeData.Surnames.GetRandomItem(random);
        }

        public static string NextFullName(this System.Random random)
        {
            return "{0} {1}".FormatWith(NextName(random), NextSurname(random));
        }

        public static string NextCountry(this System.Random random)
        {
            return FakeData.Countries.GetRandomItem(random);
        }

        public static string NextCity(this System.Random random)
        {
            return FakeData.Cities.GetRandomItem(random);
        }

        public static string NextZipCode(this System.Random random)
        {
            return "{0:00}-{1:000}".FormatWith(random.Next(), random.Next());
        }

        public static string NextStreet(this System.Random random)
        {
            return FakeData.Streets.GetRandomItem(random);
        }

        public static string NextAddress(this System.Random random)
        {
            return "{0} {1}".FormatWith(random.NextStreet(), random.Next(1, 125));
        }

        public static string NextCompany(this System.Random random)
        {
            return FakeData.Companies.GetRandomItem(random);
        }

        public static string NextEmail(this System.Random random)
        {
            return "{0}@{1}.com".FormatWith(random.NextName(), random.NextCompany().Replace(" ", "_"));
        }
    }
}