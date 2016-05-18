
namespace lib12.Data.Dummy
{
    /// <summary>
    /// Lorem ipsum text
    /// </summary>
    public static class FakeData
    {
        #region Props
        /// <summary>
        /// Gets one paragraph of Lorem ipsum text
        /// </summary>
        public static string Paragraph { get; private set; }

        /// <summary>
        /// Gets two paragraphs of Lorem ipsum text
        /// </summary>
        public static string TwoParagraphs { get; private set; }

        /// <summary>
        /// Gets five paragraphs of Lorem ipsum text
        /// </summary>
        public static string FiveParagraphs { get; private set; }

        /// <summary>
        /// List of countries
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        public static string[] Countries { get; private set; }

        /// <summary>
        /// List of country codes.
        /// </summary>
        /// <value>
        /// The country codes.
        /// </value>
        public static string[] CountryCodes { get; private set; }

        /// <summary>
        /// List of cities
        /// </summary>
        /// <value>
        /// The cities.
        /// </value>
        public static string[] Cities { get; set; }

        /// <summary>
        /// List of streets
        /// </summary>
        /// <value>
        /// The streets.
        /// </value>
        public static string[] Streets { get; set; }

        /// <summary>
        /// List of male names
        /// </summary>
        /// <value>
        /// The male names.
        /// </value>
        public static string[] MaleNames { get; set; }

        /// <summary>
        /// List of female names
        /// </summary>
        /// <value>
        /// The female names.
        /// </value>
        public static string[] FemaleNames { get; set; }

        /// <summary>
        /// List of surnames
        /// </summary>
        /// <value>
        /// The surnames.
        /// </value>
        public static string[] Surnames { get; set; }

        /// <summary>
        /// List of companies
        /// </summary>
        /// <value>
        /// The companies.
        /// </value>
        public static string[] Companies { get; set; }
        #endregion

        #region sctor
        static FakeData()
        {
            Paragraph = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            TwoParagraphs = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In et sapien sit amet lacus dapibus imperdiet eu ac felis. Integer at justo ac risus egestas varius et in ligula. Suspendisse id mi eget lectus euismod consequat eget id neque. Maecenas sed nisi enim. Maecenas sit amet diam nisl. Ut eleifend felis eu libero accumsan rhoncus. Etiam vel risus elit. Donec ultricies orci id dui porta cursus laoreet mauris feugiat. Nulla facilisi. Cras molestie dui et risus pulvinar quis elementum odio vulputate. Duis dapibus ligula quis dui ullamcorper eu mattis tellus interdum. Morbi quis ligula neque. Nullam interdum, purus at pulvinar vehicula, dui libero faucibus ipsum, quis cursus massa nulla ac libero. Fusce eu ligula a ligula tristique ultrices. Vestibulum semper massa ut turpis ornare at posuere dui elementum. Pellentesque egestas iaculis nulla at dictum. Proin tristique, odio eget aliquam vulputate, ipsum sem rhoncus metus, nec elementum ante magna sed ipsum. Nullam porttitor bibendum varius. Phasellus eleifend dapibus ante, nec interdum mi eleifend sit amet. Cras ullamcorper lacus et sapien placerat vitae consectetur nisl euismod. Etiam vitae ligula eu nulla aliquet tincidunt. Vestibulum id enim ac est rhoncus elementum. Vivamus tincidunt lorem non nulla tincidunt sed pulvinar quam aliquet. Vivamus erat ante, pharetra vel laoreet quis, tincidunt a felis. Curabitur hendrerit condimentum erat, quis blandit augue imperdiet vitae. Praesent varius ante ipsum, in venenatis tortor. Nunc non nisl ac mi mollis aliquet placerat at ipsum. Duis posuere dolor nec mauris porttitor eu sodales turpis malesuada.";
            FiveParagraphs = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In et sapien sit amet lacus dapibus imperdiet eu ac felis. Integer at justo ac risus egestas varius et in ligula. Suspendisse id mi eget lectus euismod consequat eget id neque. Maecenas sed nisi enim. Maecenas sit amet diam nisl. Ut eleifend felis eu libero accumsan rhoncus. Etiam vel risus elit. Donec ultricies orci id dui porta cursus laoreet mauris feugiat. Nulla facilisi. Cras molestie dui et risus pulvinar quis elementum odio vulputate. Duis dapibus ligula quis dui ullamcorper eu mattis tellus interdum. Morbi quis ligula neque. Nullam interdum, purus at pulvinar vehicula, dui libero faucibus ipsum, quis cursus massa nulla ac libero. Fusce eu ligula a ligula tristique ultrices. Vestibulum semper massa ut turpis ornare at posuere dui elementum. Pellentesque egestas iaculis nulla at dictum. Proin tristique, odio eget aliquam vulputate, ipsum sem rhoncus metus, nec elementum ante magna sed ipsum. Nullam porttitor bibendum varius. Phasellus eleifend dapibus ante, nec interdum mi eleifend sit amet. Cras ullamcorper lacus et sapien placerat vitae consectetur nisl euismod. Etiam vitae ligula eu nulla aliquet tincidunt. Vestibulum id enim ac est rhoncus elementum. Vivamus tincidunt lorem non nulla tincidunt sed pulvinar quam aliquet. Vivamus erat ante, pharetra vel laoreet quis, tincidunt a felis. Curabitur hendrerit condimentum erat, quis blandit augue imperdiet vitae. Praesent varius ante ipsum, in venenatis tortor. Nunc non nisl ac mi mollis aliquet placerat at ipsum. Duis posuere dolor nec mauris porttitor eu sodales turpis malesuada. Ut imperdiet volutpat ullamcorper. Nulla eget metus et enim rutrum gravida. Fusce iaculis aliquam arcu a aliquam. Etiam in tincidunt arcu. Cras a diam magna, id ultrices purus. Integer scelerisque pulvinar blandit. In hac habitasse platea dictumst. Nam eu massa ut lorem auctor porta et at est. Vivamus purus turpis, ornare a hendrerit vitae, egestas eu nunc. Pellentesque nunc magna, ullamcorper non fringilla ac, rutrum at lacus. Duis vestibulum, enim vitae elementum aliquam, est risus placerat arcu, ut dapibus est ante tincidunt quam. Maecenas a turpis odio, non feugiat erat. Donec varius venenatis erat. Nam imperdiet justo vel diam mattis ac ullamcorper felis lobortis. Nam ligula quam, vehicula in vehicula in, ornare eget nisl. Suspendisse ac tortor sed quam ornare vulputate ac sagittis mi. In porttitor tristique sagittis. In tristique sapien eget mauris viverra luctus. Ut fermentum metus vel tellus vulputate fringilla. Sed quis ligula odio, dapibus elementum nibh. Sed lorem turpis, pellentesque et commodo eu, ultricies ut libero. Quisque blandit pulvinar orci ut tristique. Cras at diam eu justo convallis adipiscing. Aenean libero urna, aliquam vitae ultricies vel, pharetra eu lorem. Mauris consectetur fermentum diam. Vivamus pretium urna non sem rhoncus consectetur. Aliquam placerat elit sit amet justo varius ullamcorper. Vestibulum tempus hendrerit est, vel gravida orci ullamcorper vitae.";

            #region Countries
            Countries = new[]
            {
                "Afghanistan",
                "Albania",
                "Algeria",
                "American Samoa",
                "Andorra",
                "Angola",
                "Anguilla",
                "Antarctica",
                "Antigua and Barbuda",
                "Argentina",
                "Armenia",
                "Aruba",
                "Australia",
                "Austria",
                "Azerbaijan",
                "Bahamas",
                "Bahrain",
                "Bangladesh",
                "Barbados",
                "Belarus",
                "Belgium",
                "Belize",
                "Benin",
                "Bermuda",
                "Bhutan",
                "Bolivia",
                "Bosnia and Herzegovina",
                "Botswana",
                "Bouvet Island",
                "Brazil",
                "British Indian Ocean Territory",
                "Brunei Darussalam",
                "Bulgaria",
                "Burkina Faso",
                "Burundi",
                "Cambodia",
                "Cameroon",
                "Canada",
                "Cape Verde",
                "Cayman Islands",
                "Central African Republic",
                "Chad",
                "Chile",
                "China",
                "Christmas Island",
                "Cocos (Keeling) Islands",
                "Colombia",
                "Comoros",
                "Congo",
                "Congo, the Democratic Republic of the",
                "Cook Islands",
                "Costa Rica",
                "Cote D'Ivoire",
                "Croatia",
                "Cuba",
                "Cyprus",
                "Czech Republic",
                "Denmark",
                "Djibouti",
                "Dominica",
                "Dominican Republic",
                "Ecuador",
                "Egypt",
                "El Salvador",
                "Equatorial Guinea",
                "Eritrea",
                "Estonia",
                "Ethiopia",
                "Falkland Islands (Malvinas)",
                "Faroe Islands",
                "Fiji",
                "Finland",
                "France",
                "French Guiana",
                "French Polynesia",
                "French Southern Territories",
                "Gabon",
                "Gambia",
                "Georgia",
                "Germany",
                "Ghana",
                "Gibraltar",
                "Greece",
                "Greenland",
                "Grenada",
                "Guadeloupe",
                "Guam",
                "Guatemala",
                "Guinea",
                "Guinea-Bissau",
                "Guyana",
                "Haiti",
                "Heard Island and Mcdonald Islands",
                "Holy See (Vatican City State)",
                "Honduras",
                "Hong Kong",
                "Hungary",
                "Iceland",
                "India",
                "Indonesia",
                "Iran, Islamic Republic of",
                "Iraq",
                "Ireland",
                "Israel",
                "Italy",
                "Jamaica",
                "Japan",
                "Jordan",
                "Kazakhstan",
                "Kenya",
                "Kiribati",
                "Korea, Democratic People's Republic of",
                "Korea, Republic of",
                "Kuwait",
                "Kyrgyzstan",
                "Lao People's Democratic Republic",
                "Latvia",
                "Lebanon",
                "Lesotho",
                "Liberia",
                "Libyan Arab Jamahiriya",
                "Liechtenstein",
                "Lithuania",
                "Luxembourg",
                "Macao",
                "Macedonia, the Former Yugoslav Republic of",
                "Madagascar",
                "Malawi",
                "Malaysia",
                "Maldives",
                "Mali",
                "Malta",
                "Marshall Islands",
                "Martinique",
                "Mauritania",
                "Mauritius",
                "Mayotte",
                "Mexico",
                "Micronesia, Federated States of",
                "Moldova, Republic of",
                "Monaco",
                "Mongolia",
                "Montserrat",
                "Morocco",
                "Mozambique",
                "Myanmar",
                "Namibia",
                "Nauru",
                "Nepal",
                "Netherlands",
                "Netherlands Antilles",
                "New Caledonia",
                "New Zealand",
                "Nicaragua",
                "Niger",
                "Nigeria",
                "Niue",
                "Norfolk Island",
                "Northern Mariana Islands",
                "Norway",
                "Oman",
                "Pakistan",
                "Palau",
                "Palestinian Territory, Occupied",
                "Panama",
                "Papua New Guinea",
                "Paraguay",
                "Peru",
                "Philippines",
                "Pitcairn",
                "Poland",
                "Portugal",
                "Puerto Rico",
                "Qatar",
                "Reunion",
                "Romania",
                "Russian Federation",
                "Rwanda",
                "Saint Helena",
                "Saint Kitts and Nevis",
                "Saint Lucia",
                "Saint Pierre and Miquelon",
                "Saint Vincent and the Grenadines",
                "Samoa",
                "San Marino",
                "Sao Tome and Principe",
                "Saudi Arabia",
                "Senegal",
                "Serbia and Montenegro",
                "Seychelles",
                "Sierra Leone",
                "Singapore",
                "Slovakia",
                "Slovenia",
                "Solomon Islands",
                "Somalia",
                "South Africa",
                "South Georgia and the South Sandwich Islands",
                "Spain",
                "Sri Lanka",
                "Sudan",
                "Suriname",
                "Svalbard and Jan Mayen",
                "Swaziland",
                "Sweden",
                "Switzerland",
                "Syrian Arab Republic",
                "Taiwan, Province of China",
                "Tajikistan",
                "Tanzania, United Republic of",
                "Thailand",
                "Timor-Leste",
                "Togo",
                "Tokelau",
                "Tonga",
                "Trinidad and Tobago",
                "Tunisia",
                "Turkey",
                "Turkmenistan",
                "Turks and Caicos Islands",
                "Tuvalu",
                "Uganda",
                "Ukraine",
                "United Arab Emirates",
                "United Kingdom",
                "United States",
                "United States Minor Outlying Islands",
                "Uruguay",
                "Uzbekistan",
                "Vanuatu",
                "Venezuela",
                "Viet Nam",
                "Virgin Islands, British",
                "Virgin Islands, US",
                "Wallis and Futuna",
                "Western Sahara",
                "Yemen",
                "Zambia",
                "Zimbabwe"
            };
            #endregion

            #region CountryCodes
            CountryCodes = new[]
            {
                "AF",
                "AL",
                "DZ",
                "AS",
                "AD",
                "AO",
                "AI",
                "AQ",
                "AG",
                "AR",
                "AM",
                "AW",
                "AU",
                "AT",
                "AZ",
                "BS",
                "BH",
                "BD",
                "BB",
                "BY",
                "BE",
                "BZ",
                "BJ",
                "BM",
                "BT",
                "BO",
                "BA",
                "BW",
                "BV",
                "BR",
                "IO",
                "BN",
                "BG",
                "BF",
                "BI",
                "KH",
                "CM",
                "CA",
                "CV",
                "KY",
                "CF",
                "TD",
                "CL",
                "CN",
                "CX",
                "CC",
                "CO",
                "KM",
                "CG",
                "CD",
                "CK",
                "CR",
                "CI",
                "HR",
                "CU",
                "CY",
                "CZ",
                "DK",
                "DJ",
                "DM",
                "DO",
                "EC",
                "EG",
                "SV",
                "GQ",
                "ER",
                "EE",
                "ET",
                "FK",
                "FO",
                "FJ",
                "FI",
                "FR",
                "GF",
                "PF",
                "TF",
                "GA",
                "GM",
                "GE",
                "DE",
                "GH",
                "GI",
                "GR",
                "GL",
                "GD",
                "GP",
                "GU",
                "GT",
                "GN",
                "GW",
                "GY",
                "HT",
                "HM",
                "VA",
                "HN",
                "HK",
                "HU",
                "IS",
                "IN",
                "ID",
                "IR",
                "IQ",
                "IE",
                "IL",
                "IT",
                "JM",
                "JP",
                "JO",
                "KZ",
                "KE",
                "KI",
                "KP",
                "KR",
                "KW",
                "KG",
                "LA",
                "LV",
                "LB",
                "LS",
                "LR",
                "LY",
                "LI",
                "LT",
                "LU",
                "MO",
                "MK",
                "MG",
                "MW",
                "MY",
                "MV",
                "ML",
                "MT",
                "MH",
                "MQ",
                "MR",
                "MU",
                "YT",
                "MX",
                "FM",
                "MD",
                "MC",
                "MN",
                "MS",
                "MA",
                "MZ",
                "MM",
                "NA",
                "NR",
                "NP",
                "NL",
                "AN",
                "NC",
                "NZ",
                "NI",
                "NE",
                "NG",
                "NU",
                "NF",
                "MP",
                "NO",
                "OM",
                "PK",
                "PW",
                "PS",
                "PA",
                "PG",
                "PY",
                "PE",
                "PH",
                "PN",
                "PL",
                "PT",
                "PR",
                "QA",
                "RE",
                "RO",
                "RU",
                "RW",
                "SH",
                "KN",
                "LC",
                "PM",
                "VC",
                "WS",
                "SM",
                "ST",
                "SA",
                "SN",
                "CS",
                "SC",
                "SL",
                "SG",
                "SK",
                "SI",
                "SB",
                "SO",
                "ZA",
                "GS",
                "ES",
                "LK",
                "SD",
                "SR",
                "SJ",
                "SZ",
                "SE",
                "CH",
                "SY",
                "TW",
                "TJ",
                "TZ",
                "TH",
                "TL",
                "TG",
                "TK",
                "TO",
                "TT",
                "TN",
                "TR",
                "TM",
                "TC",
                "TV",
                "UG",
                "UA",
                "AE",
                "GB",
                "US",
                "UM",
                "UY",
                "UZ",
                "VU",
                "VE",
                "VN",
                "VG",
                "VI",
                "WF",
                "EH",
                "YE",
                "ZM",
                "ZW"
            };
            #endregion

            #region Cities and streets
            Cities = new[]
            {
                "New York", "Lisbon", "San Fransisco", "Boston", "Los Angeles", "Madrid", "Cracow",
                "Hong Kong", "London", "Paris", "Tokio", "Sao Paolo", "Rome", "Buenos Aires"
            };

            Streets = new[]
            {
                "First", "Second", "Third", "Forth", "Five", "Main", "Oak", "Pine",
                "Elm", "View", "Lake", "Hill", "Church", "Park Avenue", "Prospect"
            };
            #endregion

            #region Names
            MaleNames = new[]
            {
                "John", "Michael", "Jack", "Sebastian", "Christopher", "Hugh", "James", "Harry",
                "Albert", "Adam", "Andrew", "Arthur", "Benjamin", "Daniel", "Emmanuel", "Harrison",
                "Jarvis", "Keith", "Leon", "Manuel", "Oscar", "Phillip", "Robert", "Samuel", "Thomas"
            };

            FemaleNames = new[]
            {
                "Ann", "Catherine", "Jennifer", "Emma", "Monique", "Marie", "Beth", "Nancy",
                "Camilla", "Caroline", "Collette", "Debbie", "Eileen", "Gwyneth", "Isabelle",
                "Jackie", "Jacqualine", "Lelah", "Lindsey", "Lorilee", "Luise", "Natalie", "Paulene"
            };

            Surnames = new[]
            {
                "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez",
                "Wilson", "House", "Potter", "Anderson", "Taylor", "Moore", "Jackson", "White", "Black", "Walker",
                "Allen", "King", "Wright", "Scott", "Green", "Baker", "Murphy", "Edwards", "Steward", "Collins", "Evans"
            };
            #endregion

            #region Companies
            Companies = new[]
            {
                "Acme", "Macrohard", "Pear", "Gogles", "Tanmung", "Intellico", "Specific Motors", "Testral",
                "Philip", "Tony"
            };
            #endregion
        }
        #endregion
    }
}
