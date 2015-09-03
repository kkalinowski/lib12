using System;
using System.Linq;
using lib12.Data.Dummy;
using Should;
using Xunit;

namespace lib12.Test.DummyData
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
        public void Generate_returns_not_null_items_of_correct_type()
        {
            var generated = generator.Generate<Account>(CollectionSize);
            generated.Count.ShouldEqual(CollectionSize);

            foreach (var item in generated)
            {
                item.ShouldNotBeNull();
                item.ShouldBeType<Account>();
            }
        }

        [Fact]
        public void string_generation_test()
        {
            const int minLength = 3;
            const int maxLength = 7;
            var generated = generator.Generate(CollectionSize, new StringGenerator<ClassToGenerate>(x => x.Text, minLength, maxLength));

            foreach (var item in generated)
            {
                item.Text.ShouldNotBeEmpty();
                item.Text.Length.ShouldBeInRange(minLength, maxLength);
            }
        }

        [Fact]
        public void enum_generation_test()
        {
            var generated = generator.Generate(CollectionSize, new EnumGenerator<ClassToGenerate, ClassToGenerate.EnumToGenerate>(x => x.Enum));

            foreach (var item in generated)
            {
                item.ShouldNotBeNull();
            }
        }

        [Fact]
        public void bool_generation_test()
        {
            var generated = generator.Generate(CollectionSize, new BoolGenerator<ClassToGenerate>(x => x.Bool));

            foreach (var item in generated)
            {
                item.ShouldNotBeNull();
            }
        }

        [Fact]
        public void int_generation_test()
        {
            var generated = generator.Generate(CollectionSize, new IntGenerator<ClassToGenerate>(x => x.Int, 50, 100));

            foreach (var item in generated)
            {
                item.ShouldNotBeNull();
                item.Int.ShouldBeInRange(50, 100);
            }
        }

        [Fact]
        public void double_generation_test()
        {
            var generated = generator.Generate(CollectionSize, new DoubleGenerator<ClassToGenerate>(x => x.Double, 70, 120));

            foreach (var item in generated)
            {
                item.ShouldNotBeNull();
                item.Double.ShouldBeInRange(70, 120);
            }
        }

        [Fact]
        public void creation_of_complex_class_test()
        {
            var generated = generator.Generate<Account>(CollectionSize);

            foreach (var item in generated)
            {
                item.Name.ShouldNotBeEmpty();
                Data.Dummy.DummyData.Surnames.ShouldContain(item.Surname);
                item.Address.ShouldNotBeEmpty();
                Data.Dummy.DummyData.Countries.ShouldContain(item.Country);
                Data.Dummy.DummyData.Companies.ShouldContain(item.Company);
                item.Info.ShouldNotBeEmpty();
                item.Created.ShouldNotEqual(new DateTime());
            }

            generated.Any(x => Math.Abs(x.Number) > double.Epsilon).ShouldBeTrue();
        }

        [Fact]
        public void available_values_generator()
        {
            var names = new[] { "name1", "name2", "name3" };
            var generated = generator.Generate(CollectionSize, new AvailableValuesGenerator<Account, string>(x => x.Name, names));

            foreach (var item in generated)
            {
                names.ShouldContain(item.Name);
            }
        }
    }
}
