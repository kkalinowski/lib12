using System;
// ReSharper disable InconsistentNaming
#pragma warning disable 169

namespace lib12.Tests.Reflection
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

    [AttributeWithIntParameter(Parameter = 20)]
    public class TypeWithParameterAttribute
    {
    }

    [AttributeWithoutParameters]
    public class TypeWithParameterlessAttribute
    {
    }

    public class TypeWithoutAttributes
    {
    }
}