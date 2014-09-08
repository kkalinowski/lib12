using System;
using System.Linq;
using lib12.Data.Dummy;
using Should;
using Xunit;

namespace lib12.Test.DummyDataTests
{
    public class RandomDataExtensionTests
    {
        private readonly Random random = new Random();

        [Fact]
        public void NextFullName_test()
        {
            var result = random.NextFullName();
            result.ShouldNotBeEmpty();
            var names = result.Split(' ');
            DummyData.MaleNames.Concat(DummyData.FemaleNames).ShouldContain(names[0]);
            DummyData.Surnames.ShouldContain(names[1]);
        }

        [Fact]
        public void NextCountry_test()
        {
            var result = random.NextCountry();
            result.ShouldNotBeEmpty();
            DummyData.Countries.ShouldContain(result);
        }

        [Fact]
        public void NextCity_test()
        {
            var result = random.NextCity();
            result.ShouldNotBeEmpty();
            DummyData.Cities.ShouldContain(result);
        }

        [Fact]
        public void NextCompany_test()
        {
            var result = random.NextCompany();
            result.ShouldNotBeEmpty();
            DummyData.Companies.ShouldContain(result);
        }
    }
}