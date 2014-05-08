using FluentAssertions;
using lib12.Mathematics;
using Xunit;

namespace lib12.Test.MathematicsTests
{
    public class FormulaTests
    {
        [Fact]
        public void simple_addition()
        {
            var formula = new Formula("5+7");

            formula.IsValid.Should().BeTrue();
            formula.Evaluate().Should().Be(12);
        }  
    }
}