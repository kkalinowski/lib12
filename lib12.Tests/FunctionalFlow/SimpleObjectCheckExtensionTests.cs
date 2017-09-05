using lib12.FunctionalFlow;
using Shouldly;
using Xunit;

namespace lib12.Tests.FunctionalFlow
{
    public class SimpleObjectCheckExtensionTests
    {
        private const string nullObject = null;
        private const string notNullObject = "test_string";

        [Fact]
        public void null_returns_true_if_object_is_null()
        {
            nullObject.IsNull().ShouldBeTrue();
        }

        [Fact]
        public void null_returns_false_if_object_is_not_null()
        {
            notNullObject.IsNull().ShouldBeFalse();
        }
    }
}