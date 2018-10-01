using System.Globalization;
using lib12.Mathematics;
using lib12.Mathematics.Formulas;
using Shouldly;
using Xunit;

namespace lib12.Tests.Mathematics
{
    public class FormulaTests
    {
        public FormulaTests()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
        }

        [Fact]
        public void simple_addition()
        {
            var formula = new Formula("5 + 7");

            formula.IsValid.ShouldBeTrue();
            formula.Evaluate().ShouldBe(12);
        }

        [Fact]
        public void operator_order()
        {
            var formula = new Formula("5 * 5 + 7 * 3");

            formula.IsValid.ShouldBeTrue();
            formula.Evaluate().ShouldBe(46);
        }

        [Fact]
        public void complex_formula()
        {
            var formula = new Formula("-12*3 + (5-3)*6 + 9/(4-1)");

            formula.IsValid.ShouldBeTrue();
            formula.Evaluate().ShouldBe(-21);
        }

        [Fact]
        public void decimal_formula()
        {
            var formula = new Formula("-5.5*2 + 24 - 0.25*4");

            formula.IsValid.ShouldBeTrue();
            formula.Evaluate().ShouldBe(12);
        }

        [Fact]
        public void invalid_formula_operator_left_at_the_end()
        {
            var formula = new Formula("5 + 7 +");

            formula.IsValid.ShouldBeFalse();
            Assert.Throws<MathException>(() => formula.Evaluate());
        }

        [Fact]
        public void invalid_formula_empty_bracket()
        {
            var formula = new Formula("5 + 7 + () + 3");

            formula.IsValid.ShouldBeFalse();
            Assert.Throws<MathException>(() => formula.Evaluate());
        }

        [Fact]
        public void invalid_formula_not_closed_bracket()
        {
            var formula = new Formula("5 + 7 + ( (3*5) + 2");

            formula.IsValid.ShouldBeFalse();
            Assert.Throws<MathException>(() => formula.Evaluate());
        }

        [Fact]
        public void invalid_formula_operator_in_wrong_place()
        {
            var formula = new Formula("5 + 7 + (+2 - 3)");

            formula.IsValid.ShouldBeFalse();
            Assert.Throws<MathException>(() => formula.Evaluate());
        }

        [Fact]
        public void invalid_formula_two_operators_in_row()
        {
            var formula = new Formula("5 + 7 ++ 5");

            formula.IsValid.ShouldBeFalse();
            Assert.Throws<MathException>(() => formula.Evaluate());
        }

        [Fact]
        public void invalid_formula_two_negations_in_row()
        {
            var formula = new Formula("--5 + 7");

            formula.IsValid.ShouldBeFalse();
            Assert.Throws<MathException>(() => formula.Evaluate());
        }

        [Fact]
        public void invalid_formula_bracket_closed_before_opened()
        {
            var formula = new Formula(")5 + 7(*5");

            formula.IsValid.ShouldBeFalse();
            Assert.Throws<MathException>(() => formula.Evaluate());
        }

        [Fact]
        public void equation_with_variable()
        {
            var formula = new Formula("a+5");

            formula.IsValid.ShouldBeTrue();
            formula.Evaluate(new { a = 7 }).ShouldBe(12);
        }

        [Fact]
        public void equation_with_two_variables()
        {
            var formula = new Formula("a*(5-b)");

            formula.IsValid.ShouldBeTrue();
            formula.Evaluate(new { a = 10, b = 3 }).ShouldBe(20);
        }

        [Fact]
        public void equation_with_variable_and_null_argument()
        {
            var formula = new Formula("a+5");

            formula.IsValid.ShouldBeTrue();
            Assert.Throws<MathException>(() => formula.Evaluate());
        }

        [Fact]
        public void equation_with_two_variables_and_argument_with_one_value()
        {
            var formula = new Formula("a*(5-b)");

            formula.IsValid.ShouldBeTrue();
            Assert.Throws<MathException>(() => formula.Evaluate(new { a = 7 }));
        }
    }
}