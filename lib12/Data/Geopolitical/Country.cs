using System;
using System.Collections.Generic;
using System.Text;

namespace lib12.Data.Geopolitical
{
    public class Country
    {
        public string Name { get; set; }
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
    }
}
