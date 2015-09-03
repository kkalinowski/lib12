
using System;

namespace lib12.Test.DummyData
{
    internal class ClassToGenerate
    {
        internal enum EnumToGenerate
        {
            First,
            Second,
            Third
        }

        public string Text { get; set; }

        public EnumToGenerate Enum { get; set; }

        public bool Bool { get; set; }
        public int Int { get; set; }

        public double Double { get; set; }
    }

    internal class Account
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string Info { get; set; }
        public double Number { get; set; }
        public DateTime Created { get; set; }
    }
}
