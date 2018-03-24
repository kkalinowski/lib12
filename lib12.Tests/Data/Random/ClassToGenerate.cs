
using System;

namespace lib12.Tests.Data.Random
{
    internal class ClassToGenerate
    {
        internal enum EnumToGenerate
        {
            First,
            Second,
            Third
        }

        public class Nested
        {
            public string NestedText { get; set; }
        }

        public string Text { get; set; }
        public EnumToGenerate Enum { get; set; }
        public bool Bool { get; set; }
        public int Int { get; set; }
        public double Double { get; set; }
        public int NumberThatShouldntBeSet { get; private set; } = 12;
        public int NumberImpossibleToSet { get { return 12; } }
        public Nested NestedClass { get; set; }
    }

    internal class Account
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string Info { get; set; }
        public double Number { get; set; }
        public DateTime Created { get; set; }
    }
}
