using System;
using System.Collections;
using System.IO;
using System.Linq;
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
        private const string CountryClassText = "        public Country {0} {{ get; }} = new Country {{\r\n            Name = \"{1}\"\r\n        }};\n";

        static void Main(string[] args)
        {

            Console.WriteLine("lib12 country generator started");

            DownloadCountryFile();
            var countryData = LoadCountryData();
            ParseAndSaveCountryData(countryData);

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

        private static void ParseAndSaveCountryData(dynamic countryData)
        {
            Console.WriteLine("Started parsing and saving country data");
            var countryRepositoryBuilder = new StringBuilder();
            SaveHeaderOfFile(countryRepositoryBuilder);

            foreach (var country in ((IEnumerable)countryData).Cast<dynamic>().OrderBy(x => (string)x.name.common))
            {
                SaveCountry(country, countryRepositoryBuilder);
            }

            SaveEndOfFile(countryRepositoryBuilder);
            
            File.WriteAllText(CountryRepositoryFilename,countryRepositoryBuilder.ToString());
            Console.WriteLine("Country data parsed and saved");
        }

        private static void SaveCountry(dynamic country, StringBuilder countryRepositoryBuilder)
        {

            Console.WriteLine($"Saving {country.name.common}");
            var countryClassName = country.name.common.ToString().Replace(" ", "").Replace(",", "").Replace("(", "").Replace(")", "").Replace("-", "");
            countryRepositoryBuilder.AppendFormat(CountryClassText, countryClassName, country.name.common);
            countryRepositoryBuilder.AppendLine();
        }

        private static void SaveHeaderOfFile(StringBuilder countryRepositoryBuilder)
        {
            countryRepositoryBuilder.Append("namespace lib12.Data.Geopolitical\r\n{\r\n    public class CountryRepository\r\n    {\n");
        }

        private static void SaveEndOfFile(StringBuilder countryRepositoryBuilder)
        {

            countryRepositoryBuilder.Append("     }\r\n}");
        }

    }
}
