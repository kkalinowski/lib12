using lib12.Reflection;
using Shouldly;
using Xunit;

namespace lib12.Tests.Reflection
{
    public class TypeExtensionTests
    {
        private static class StaticClass { }
        private class NonStaticClass { }

        [Fact]
        public void is_static_returns_true_for_static_class()
        {
            typeof(StaticClass).IsStatic().ShouldBeTrue();
        }

        [Fact]
        public void is_static_returns_false_for_non_static_class()
        {
            typeof(NonStaticClass).IsStatic().ShouldBeFalse();
        }
    }
}