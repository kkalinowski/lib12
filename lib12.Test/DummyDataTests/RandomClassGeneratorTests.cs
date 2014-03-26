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
            var generated = generator.Generate<ClassToGenerate>(CollectionSize, new StringPropertyGenerator<ClassToGenerate>(x => x.Text, 3, 7));

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
            var generated = generator.Generate<ClassToGenerate>(CollectionSize, new StringPropertyGenerator<ClassToGenerate>(x => x.Text, minLength, maxLength));

            foreach (var item in generated)
            {
                Assert.NotNull(item.Text);
                Assert.True(item.Text.Length >= minLength && item.Text.Length < maxLength);
            }
        }
    }
}
