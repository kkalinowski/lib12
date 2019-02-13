using System;
using System.Reflection;
using lib12.Reflection;
using Shouldly;
using Xunit;

namespace lib12.Tests.Reflection
{
    public class FieldInfoExtensionTests
    {
        [AttributeUsage(AttributeTargets.All)]
        public sealed class AttributeWithIntParameter : Attribute
        {
            public int Parameter { get; set; }
        }

        [AttributeUsage(AttributeTargets.All)]
        public sealed class AttributeWithoutParameters : Attribute
        {
        }

        public class MarkedClass
        {
            [AttributeWithoutParameters]
            private int number;
        }

        [Fact]
        public void IsMarkedWithAttribute_is_correct()
        {
            typeof(MarkedClass).GetField("number", BindingFlags.NonPublic | BindingFlags.Instance)
                .IsMarkedWithAttribute<AttributeWithoutParameters>()
                .ShouldBeTrue();
        }
    }
}