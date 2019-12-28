using lib12.Data.Geopolitical;
using Shouldly;
using Xunit;

namespace lib12.Tests.Data.Geopolitical
{
    public class CountryRepositoryTests
    {
        private static int CountryNumber = 249;
        
        [Fact]
        public void correct_number_of_countries_in_repository()
        {
            CountryRepository.AllCountries.Length.ShouldBe(CountryNumber);
            typeof(CountryRepository.SingleCountries).GetProperties().Length.ShouldBe(CountryNumber);
        }
        
        [Fact]
        public void correct_values_for_poland()
        {
            var poland = CountryRepository.SingleCountries.Poland;
            
            poland.Name.ShouldBe("Poland");
            poland.OfficialName.ShouldBe("Republic of Poland");
            poland.Capital.ShouldBe("Warsaw");
            poland.NameOfResidents.ShouldBe("Polish");
            poland.Currencies.Length.ShouldBe(1);
            poland.Currencies[0].ShouldBe("PLN");
            poland.Languages.Length.ShouldBe(1);
            poland.Languages[0].ShouldBe("Polish");
            poland.Latitude.ShouldBe(52);
            poland.Longitude.ShouldBe(20);
            poland.Region.ShouldBe("Europe");
            poland.Subregion.ShouldBe("Eastern Europe");
            poland.DialingPrefix.ShouldBe("+48");
            poland.EmojiFlag.ShouldBe("🇵🇱");
            poland.IsoNumeric.ShouldBe("616");
            poland.IsoAlfa2Code.ShouldBe("PL");
            poland.IsoAlfa3Code.ShouldBe("POL");
            poland.TopLevelDomainCode.ShouldBe(".pl");
        }
    }
}