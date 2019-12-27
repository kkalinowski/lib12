using System;
using System.Collections.Generic;
using System.Text;

namespace lib12.Data.Geopolitical
{
    public class Country
    {
        public string Name { get; }
        public string OfficialName { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public string TopLevelDomainCode { get; }
        public string Capital { get; }
        public string Region { get; }
        public string Subregion { get; }
        public string[] Languages { get; }
        public string NameOfResidents { get; }
        public string EmojiFlag { get; }
        public string IsoAlfa2Code { get; }
        public string IsoAlfa3Code { get; }
        public string IsoNumeric { get; }
        public string[] Currencies { get; }
        public string[] DialingPrefix { get; }

        public Country(string name, string officialName, double latitude, double longitude, string topLevelDomainCode, string capital, string region, string subregion, string[] languages, string nameOfResidents, string emojiFlag, string isoAlfa2Code, string isoAlfa3Code, string isoNumeric, string[] currencies, string[] dialingPrefix)
        {
            Name = name;
            OfficialName = officialName;
            Latitude = latitude;
            Longitude = longitude;
            TopLevelDomainCode = topLevelDomainCode;
            Capital = capital;
            Region = region;
            Subregion = subregion;
            Languages = languages;
            NameOfResidents = nameOfResidents;
            EmojiFlag = emojiFlag;
            IsoAlfa2Code = isoAlfa2Code;
            IsoAlfa3Code = isoAlfa3Code;
            IsoNumeric = isoNumeric;
            Currencies = currencies;
            DialingPrefix = dialingPrefix;
        }
    }
}
