using System;
using System.Net;
using lib12.Utility;

namespace lib12.CountryGenerator
{
    class Program
    {
        private const string UrlToCountryFile = "https://github.com/mledoze/countries/raw/master/countries.json";
        private const string CountryFilename = "countries.json";

        static void Main(string[] args)
        {

            Console.WriteLine("lib12 country generator started");

            DownloadCountryFile();

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
    }
}
