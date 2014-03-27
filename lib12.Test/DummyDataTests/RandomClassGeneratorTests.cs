using FluentAssertions;
using lib12.Data.Dummy;
using Xunit;

namespace lib12.Test.DummyDataTests
{
    public class RandomClassGeneratorTests
    {
        #region Const
        private const int CollectionSize = 12; 
        #endregion

        #region Fields
        private readonly RandomClassGenerator generator; 
        #endregion

        #region ctor
        public RandomClassGeneratorTests()
        {
            generator = new RandomClassGenerator();
        } 
        #endregion

        [Fact]
        public void basic_generation_test()
        {
            var generated = generator.Generate<ClassToGenerate>(CollectionSize, new StringGenerator<ClassToGenerate>(x => x.Text, 3, 7));

            Assert.Equal(CollectionSize, generated.Count);
            foreach (var item in generated)
            {
                Assert.NotNull(item);
                Assert.IsType<ClassToGenerate>(item);
            }
        }

        [Fact]
        public void string_generation_test()
        {
            const int minLength = 3;
            const int maxLength = 7;
            var generated = generator.Generate<ClassToGenerate>(CollectionSize, new StringGenerator<ClassToGenerate>(x => x.Text, minLength, maxLength));

            foreach (var item in generated)
            {
                Assert.NotNull(item.Text);
                Assert.True(item.Text.Length >= minLength && item.Text.Length < maxLength);
            }
        }

        [Fact]
        public void enum_generation_test()
        {
            var generated = generator.Generate<ClassToGenerate>(CollectionSize, new EnumGenerator<ClassToGenerate, ClassToGenerate.EnumToGenerate>(x => x.Enum));

            foreach (var item in generated)
            {
                Assert.NotNull(item);
            }
        }

        [Fact]
        public void bool_generation_test()
        {
            var generated = generator.Generate<ClassToGenerate>(CollectionSize, new BoolGenerator<ClassToGenerate>(x => x.Bool));

            foreach (var item in generated)
            {
                Assert.NotNull(item);
            }
        }

        [Fact]
        public void int_generation_test()
        {
            var generated = generator.Generate<ClassToGenerate>(CollectionSize, new IntGenerator<ClassToGenerate>(x => x.Int, 50, 100));

            foreach (var item in generated)
            {
                item.Should().NotBeNull();
                item.Int.Should().BeInRange(50, 100);
            }
        }

        [Fact]
        public void double_generation_test()
        {
            var generated = generator.Generate<ClassToGenerate>(CollectionSize, new DoubleGenerator<ClassToGenerate>(x => x.Double, 70, 120));

            foreach (var item in generated)
            {
                item.Should().NotBeNull();
                item.Double.Should().BeInRange(70, 120);
            }
        }
    }
}
