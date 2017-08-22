using System.Linq;
using System.Text.RegularExpressions;
using lib12.Data.Random;
using Should;
using Xunit;

namespace lib12.Test.Data.Random
{
    public class RandTests
    {
        [Fact]
        public void NextFullName_test()
        {
            var result = Rand.NextFullName();
            result.ShouldNotBeEmpty();
            var names = result.Split(' ');
            FakeData.MaleNames.Concat(FakeData.FemaleNames).ShouldContain(names[0]);
            FakeData.Surnames.ShouldContain(names[1]);
        }

        [Fact]
        public void NextCountry_test()
        {
            var result = Rand.NextCountry();
            result.ShouldNotBeEmpty();
            FakeData.Countries.ShouldContain(result);
        }

        [Fact]
        public void NextCity_test()
        {
            var result = Rand.NextCity();
            result.ShouldNotBeEmpty();
            FakeData.Cities.ShouldContain(result);
        }

        [Fact]
        public void NextZipCode_test()
        {
            var result = Rand.NextZipCode();
            var regex = new Regex("[0-9]{2}-[0-9]{3}");
            regex.IsMatch(result).ShouldBeTrue();
        }

        [Fact]
        public void NextStreet_test()
        {
            var result = Rand.NextStreet();
            result.ShouldNotBeEmpty();
            FakeData.Streets.ShouldContain(result);
        }

        [Fact]
        public void NextAddress_test()
        {
            var result = Rand.NextAddress();
            result.ShouldNotBeEmpty();
            var parts = result.Split(' ');
            FakeData.Streets.ShouldContain(parts[0]);
            Assert.DoesNotThrow(() => int.Parse(parts.Last()));
        }

        [Fact]
        public void NextCompany_test()
        {
            var result = Rand.NextCompany();
            result.ShouldNotBeEmpty();
            FakeData.Companies.ShouldContain(result);
        }
    }
}