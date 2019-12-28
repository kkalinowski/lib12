using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using lib12.Collections;
using lib12.Collections.Packing;
using lib12.Extensions;
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
        private const string CountryClassText = "            public static Country {0} {{ get; }} = new Country (\"{1}\", \"{2}\", {3}, {4}, \"{5}\", \"{6}\", \"{7}\",\"{8}\", {9}, \"{10}\", \"{11}\", \"{12}\", \"{13}\", \"{14}\", {15}, \"{16}\");\n";

        static void Main(string[] args)
        {
            Console.WriteLine("lib12 country generator started");
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

        private static void SaveHeaderOfFile(StringBuilder countryRepositoryBuilder)
        {
            countryRepositoryBuilder.Append("#pragma warning disable 1591\r\n\nnamespace lib12.Data.Geopolitical\r\n{\r\n    public static class CountryRepository\r\n    {\n        public static class SingleCountries\r\n        {\n");
        }

        private static void SaveCountry(dynamic country, StringBuilder countryRepositoryBuilder)
        {
            Console.Write($"Saving {country.name.common}");
            if (country.name.common == "Antarctica")
                return;
            
            var countryClassName = GetCountryClassName(country.name.common.ToString());
            var languages = ((JObject)country.languages).PropertyValues().Select(x=>x.Value<string>()).ToArray();
            var languagesText = ConvertArrayToString(languages);
            var currenciesText = GetCurrenciesAsText(country);
            var dialingPrefix = country.idd.root + country.idd.suffixes[0];

            countryRepositoryBuilder.AppendFormat(CultureInfo.InvariantCulture, CountryClassText, countryClassName, country.name.common, country.name.official,
                country.latlng?[0], country.latlng?[1], ((JArray)country.tld).ElementAtOrDefault(0), ((JArray)country.capital).ElementAtOrDefault(0),
                country.region, country.subregion, languagesText, country.demonym, country.flag, country.cca2, country.cca3, country.ccn3, currenciesText, dialingPrefix);
            countryRepositoryBuilder.AppendLine();
            
            Console.WriteLine(" - saved");
        }

        private static dynamic GetCountryClassName(string countryName)
        {
            var capitalizedAnd = countryName.Replace(" and ", " And ");
            var capitalizedOf = capitalizedAnd.Replace(" of ", " Of ");
            var capitalizedThe = capitalizedOf.Replace(" the ", " The ");
            var replacedSpecialCharacters = capitalizedThe.ReplaceAll(Pack.IntoEnumerable(" ", "(", ")", "-", ","), string.Empty);
            var withoutLanguageSpecificCharacters = replacedSpecialCharacters.RemoveDiacritics();

            return withoutLanguageSpecificCharacters;
        }

        private static string GetCurrenciesAsText(dynamic country)
        {
            if (country.currencies.GetType() == typeof(JArray))
                return "new string[0]";
            
            var currencies = ((JObject)country.currencies).PropertyValues()
                .Select(x => x.Parent)
                .Cast<JProperty>()
                .Select(x => x.Name)
                .ToArray();

            return ConvertArrayToString(currencies);
        }

        private static string ConvertArrayToString(string[] array)
        {
            if (array.IsNullOrEmpty())
                return "new string[0]";
            
            var sbuilder = new StringBuilder();
            sbuilder.Append("new []{");

            foreach (var text in array)
            {
                sbuilder.Append($"\"{text}\", ");
            }

            sbuilder.Remove(sbuilder.Length - 2, 2);
            sbuilder.Append("}");
            return sbuilder.ToString();
        }

        private static void SaveEndOfFile(StringBuilder countryRepositoryBuilder)
        {
            countryRepositoryBuilder.Remove(countryRepositoryBuilder.Length - 2, 2);
            countryRepositoryBuilder.Append("        }\r\n    }\r\n}");
        }
    }
}
