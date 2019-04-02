using System;
using System.Reflection;
using lib12.Reflection;
using Shouldly;
using Xunit;

namespace lib12.Tests.Reflection
{
    public class MemberInfoExtensionTests
    {
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

        [Fact]
        public void GetAttribute_for_field_is_correct()
        {
            var attribute = typeof(MarkedClass).GetField("field_marked_with_parameter_attribute", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetAttribute<AttributeWithIntParameter>();

            attribute.ShouldNotBeNull();
            attribute.Parameter.ShouldBe(12);
        }

        [Fact]
        public void GetAttribute_for_property_is_correct()
        {
            var attribute = typeof(MarkedClass).GetProperty(nameof(MarkedClass.Property_marked_with_parameter_attribute), BindingFlags.Public | BindingFlags.Instance)
                .GetAttribute<AttributeWithIntParameter>();

            attribute.ShouldNotBeNull();
            attribute.Parameter.ShouldBe(5);
        }
    }
}