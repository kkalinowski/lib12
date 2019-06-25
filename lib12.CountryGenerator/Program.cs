using System;
using System.IO;
using System.Net;
using System.Text;
using lib12.Utility;
using Newtonsoft.Json.Linq;
using Console = System.Console;

namespace lib12.CountryGenerator
{
    class Program
    {
        private const string UrlToCountryFile = "https://github.com/mledoze/countries/raw/master/countries.json";
        private const string CountryFilename = "countries.json";
        private const string CountryRepositoryFilename = @"..\..\..\..\lib12\Data\Geopolitical\CountryRepository.cs";
        private const string CountryClassText = "         public Country {0} {{ get; }} = new Country {{\r\n            Name = \"{0}\"\r\n        }};";

        static void Main(string[] args)
        {

            Console.WriteLine("lib12 country generator started");

            DownloadCountryFile();
            var countryData = LoadCountryData();
            ParseCountryData(countryData);

            Console.WriteLine("lib12 country generator finished working");
        }

        private static void DownloadCountryFile()
        {
            IoHelper.DeleteIfExists(CountryFilename);

            using (var webClient = new WebClient())
            {
                Console.WriteLine("Downloading country file");
                webClient.DownloadFile(UrlToCountryFile, CountryFilename);
                Console.WriteLine("Country file downloaded");
            }
        }

        private static dynamic LoadCountryData()
        {
            var json = File.ReadAllText(CountryFilename);
            var countryData = JArray.Parse(json);

            Console.WriteLine("Loaded country data");
            return countryData;
        }

        private static void ParseCountryData(dynamic countryData)
        {
            Console.WriteLine("Started parsing country data");
            var countryRepositoryBuilder = new StringBuilder();
            countryRepositoryBuilder.Append("namespace lib12.Data.Geopolitical\r\n{\r\n    public class CountryRepository\r\n    {");

            foreach (var country in countryData)
            {
                Console.WriteLine($"Saving {country.name.common}");
                var countryName = country.name.common.ToString().Replace(" ", "");
                countryRepositoryBuilder.AppendFormat(CountryClassText, countryName);
                countryRepositoryBuilder.AppendLine();
            }

            countryRepositoryBuilder.Append("     }\r\n}");
            File.WriteAllText(CountryRepositoryFilename,countryRepositoryBuilder.ToString());

            Console.WriteLine("Country data parsed");
        }
    }
}
