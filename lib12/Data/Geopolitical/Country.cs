using System;
using System.Collections.Generic;
using System.Text;

namespace lib12.Data.Geopolitical
{
    /// <summary>
    /// Represents country
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Country common name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Official country name
        /// </summary>
        public string OfficialName { get; }
        /// <summary>
        /// Country location's latitude
        /// </summary>
        public double Latitude { get; }
        /// <summary>
        /// Country location's longitude
        /// </summary>
        public double Longitude { get; }
        /// <summary>
        /// Country internet domain
        /// </summary>
        public string TopLevelDomainCode { get; }
        /// <summary>
        /// Country's capital
        /// </summary>
        public string Capital { get; }
        /// <summary>
        /// Geographical region country is located in
        /// </summary>
        public string Region { get; }
        /// <summary>
        /// Geographical subregion country is located in
        /// </summary>
        public string Subregion { get; }
        /// <summary>
        /// Official country languages
        /// </summary>
        public string[] Languages { get; }
        /// <summary>
        /// Name of country residents
        /// </summary>
        //public string NameOfResidents { get; } //removed for a while due to unstable data
        /// <summary>
        /// Unicode, emoji flag
        /// </summary>
        public string EmojiFlag { get; }
        /// <summary>
        /// Iso 2 letters country code
        /// </summary>
        public string IsoAlfa2Code { get; }
        /// <summary>
        /// Iso 3 letters country code
        /// </summary>
        public string IsoAlfa3Code { get; }
        /// <summary>
        /// Iso numeric country code
        /// </summary>
        public string IsoNumeric { get; }
        /// <summary>
        /// Country's official currencies
        /// </summary>
        public string[] Currencies { get; }
        /// <summary>
        /// Telephone dialing prefix
        /// </summary>
        public string DialingPrefix { get; }

#pragma warning disable 1591
        public Country(string name, string officialName, double latitude, double longitude, string topLevelDomainCode, string capital, string region, string subregion, string[] languages, string nameOfResidents, string emojiFlag, string isoAlfa2Code, string isoAlfa3Code, string isoNumeric, string[] currencies, string dialingPrefix)
#pragma warning restore 1591
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
            //NameOfResidents = nameOfResidents;
            EmojiFlag = emojiFlag;
            IsoAlfa2Code = isoAlfa2Code;
            IsoAlfa3Code = isoAlfa3Code;
            IsoNumeric = isoNumeric;
            Currencies = currencies;
            DialingPrefix = dialingPrefix;
        }
    }
}
