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
            private int field_not_marked_with_attribute;

            [AttributeWithoutParameters]
            private int field_marked_with_parameterless_attribute;

            [AttributeWithIntParameter(Parameter = 12)]
            private int field_marked_with_parameter_attribute;

            public string Property_not_marked_with_attribute { get; set; }

            [AttributeWithoutParameters]
            public string Property_marked_with_parameterless_attribute { get; set; }

            [AttributeWithIntParameter(Parameter = 5)]
            public string Property_marked_with_parameter_attribute { get; set; }
        }

        [Fact]
        public void IsMarkedWithAttribute_for_field_is_correct()
        {
            typeof(MarkedClass).GetField("field_marked_with_parameterless_attribute", BindingFlags.NonPublic | BindingFlags.Instance)
                .IsMarkedWithAttribute<AttributeWithoutParameters>()
                .ShouldBeTrue();

            typeof(MarkedClass).GetField("field_not_marked_with_attribute", BindingFlags.NonPublic | BindingFlags.Instance)
                .IsMarkedWithAttribute<AttributeWithoutParameters>()
                .ShouldBeFalse();
        }

        [Fact]
        public void IsMarkedWithAttribute_for_property_is_correct()
        {
            typeof(MarkedClass).GetProperty(nameof(MarkedClass.Property_marked_with_parameterless_attribute), BindingFlags.Public | BindingFlags.Instance)
                .IsMarkedWithAttribute<AttributeWithoutParameters>()
                .ShouldBeTrue();

            typeof(MarkedClass).GetProperty(nameof(MarkedClass.Property_not_marked_with_attribute), BindingFlags.Public | BindingFlags.Instance)
                .IsMarkedWithAttribute<AttributeWithoutParameters>()
                .ShouldBeFalse();
        }
    }
}