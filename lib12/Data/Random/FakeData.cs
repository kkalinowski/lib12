
namespace lib12.Data.Random
{
    /// <summary>
    /// Contains fake data
    /// </summary>
    public static class FakeData
    {
        #region Props
        /// <summary>
        /// Gets one paragraph of Lorem ipsum text
        /// </summary>
        public static string LoremIpsumParagraph { get; }

        /// <summary>
        /// Gets two paragraphs of Lorem ipsum text
        /// </summary>
        public static string LoremIpsumTwoParagraphs { get; }

        /// <summary>
        /// Gets five paragraphs of Lorem ipsum text
        /// </summary>
        public static string LoremIpsumFiveParagraphs { get; }

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
        #endregion Props

        #region sctor
        static FakeData()
        {
            LoremIpsumParagraph = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            LoremIpsumTwoParagraphs = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In et sapien sit amet lacus dapibus imperdiet eu ac felis. Integer at justo ac risus egestas varius et in ligula. Suspendisse id mi eget lectus euismod consequat eget id neque. Maecenas sed nisi enim. Maecenas sit amet diam nisl. Ut eleifend felis eu libero accumsan rhoncus. Etiam vel risus elit. Donec ultricies orci id dui porta cursus laoreet mauris feugiat. Nulla facilisi. Cras molestie dui et risus pulvinar quis elementum odio vulputate. Duis dapibus ligula quis dui ullamcorper eu mattis tellus interdum. Morbi quis ligula neque. Nullam interdum, purus at pulvinar vehicula, dui libero faucibus ipsum, quis cursus massa nulla ac libero. Fusce eu ligula a ligula tristique ultrices. Vestibulum semper massa ut turpis ornare at posuere dui elementum. Pellentesque egestas iaculis nulla at dictum. Proin tristique, odio eget aliquam vulputate, ipsum sem rhoncus metus, nec elementum ante magna sed ipsum. Nullam porttitor bibendum varius. Phasellus eleifend dapibus ante, nec interdum mi eleifend sit amet. Cras ullamcorper lacus et sapien placerat vitae consectetur nisl euismod. Etiam vitae ligula eu nulla aliquet tincidunt. Vestibulum id enim ac est rhoncus elementum. Vivamus tincidunt lorem non nulla tincidunt sed pulvinar quam aliquet. Vivamus erat ante, pharetra vel laoreet quis, tincidunt a felis. Curabitur hendrerit condimentum erat, quis blandit augue imperdiet vitae. Praesent varius ante ipsum, in venenatis tortor. Nunc non nisl ac mi mollis aliquet placerat at ipsum. Duis posuere dolor nec mauris porttitor eu sodales turpis malesuada.";
            LoremIpsumFiveParagraphs = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In et sapien sit amet lacus dapibus imperdiet eu ac felis. Integer at justo ac risus egestas varius et in ligula. Suspendisse id mi eget lectus euismod consequat eget id neque. Maecenas sed nisi enim. Maecenas sit amet diam nisl. Ut eleifend felis eu libero accumsan rhoncus. Etiam vel risus elit. Donec ultricies orci id dui porta cursus laoreet mauris feugiat. Nulla facilisi. Cras molestie dui et risus pulvinar quis elementum odio vulputate. Duis dapibus ligula quis dui ullamcorper eu mattis tellus interdum. Morbi quis ligula neque. Nullam interdum, purus at pulvinar vehicula, dui libero faucibus ipsum, quis cursus massa nulla ac libero. Fusce eu ligula a ligula tristique ultrices. Vestibulum semper massa ut turpis ornare at posuere dui elementum. Pellentesque egestas iaculis nulla at dictum. Proin tristique, odio eget aliquam vulputate, ipsum sem rhoncus metus, nec elementum ante magna sed ipsum. Nullam porttitor bibendum varius. Phasellus eleifend dapibus ante, nec interdum mi eleifend sit amet. Cras ullamcorper lacus et sapien placerat vitae consectetur nisl euismod. Etiam vitae ligula eu nulla aliquet tincidunt. Vestibulum id enim ac est rhoncus elementum. Vivamus tincidunt lorem non nulla tincidunt sed pulvinar quam aliquet. Vivamus erat ante, pharetra vel laoreet quis, tincidunt a felis. Curabitur hendrerit condimentum erat, quis blandit augue imperdiet vitae. Praesent varius ante ipsum, in venenatis tortor. Nunc non nisl ac mi mollis aliquet placerat at ipsum. Duis posuere dolor nec mauris porttitor eu sodales turpis malesuada. Ut imperdiet volutpat ullamcorper. Nulla eget metus et enim rutrum gravida. Fusce iaculis aliquam arcu a aliquam. Etiam in tincidunt arcu. Cras a diam magna, id ultrices purus. Integer scelerisque pulvinar blandit. In hac habitasse platea dictumst. Nam eu massa ut lorem auctor porta et at est. Vivamus purus turpis, ornare a hendrerit vitae, egestas eu nunc. Pellentesque nunc magna, ullamcorper non fringilla ac, rutrum at lacus. Duis vestibulum, enim vitae elementum aliquam, est risus placerat arcu, ut dapibus est ante tincidunt quam. Maecenas a turpis odio, non feugiat erat. Donec varius venenatis erat. Nam imperdiet justo vel diam mattis ac ullamcorper felis lobortis. Nam ligula quam, vehicula in vehicula in, ornare eget nisl. Suspendisse ac tortor sed quam ornare vulputate ac sagittis mi. In porttitor tristique sagittis. In tristique sapien eget mauris viverra luctus. Ut fermentum metus vel tellus vulputate fringilla. Sed quis ligula odio, dapibus elementum nibh. Sed lorem turpis, pellentesque et commodo eu, ultricies ut libero. Quisque blandit pulvinar orci ut tristique. Cras at diam eu justo convallis adipiscing. Aenean libero urna, aliquam vitae ultricies vel, pharetra eu lorem. Mauris consectetur fermentum diam. Vivamus pretium urna non sem rhoncus consectetur. Aliquam placerat elit sit amet justo varius ullamcorper. Vestibulum tempus hendrerit est, vel gravida orci ullamcorper vitae.";

            #region Cities and streets
            Cities = new[]
            {
                "New York", "Lisbon", "San Fransisco", "Boston", "Los Angeles", "Madrid", "Cracow",
                "Hong Kong", "London", "Paris", "Tokio", "Sao Paolo", "Rome", "Buenos Aires"
            };

            Streets = new[]
            {
                "First", "Second", "Third", "Forth", "Five", "Main", "Oak", "Pine",
                "Elm", "View", "Lake", "Hill", "Church", "Prospect"
            };
            #endregion Cities and streets

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
            #endregion Names

            #region Companies

            Companies = new[]
            {
                "Acme", "Macrohard", "Pear Foods", "Gogles", "Tanmung", "Intellico", "Specific Motors", "Testral",
                "SpaceZ", "TonyX", "Cantuso", "DealMan", "Shoping Co", "United Motors", "Express Deliveries",
                "Validity Corp.", "Investment Searcher", "Banking Unlimited", "Gruthorp", "Watch Maker"
            };
            #endregion Companies
        }
        #endregion sctor
    }
}
