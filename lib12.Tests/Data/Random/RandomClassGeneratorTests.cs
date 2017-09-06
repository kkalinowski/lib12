using System;
using System.Linq;
using lib12.Data.Random;
using Shouldly;
using Xunit;

namespace lib12.Tests.Data.Random
{
    public class RandomClassGeneratorTests
    {
        #region Const
        private const int CollectionSize = 12;
        #endregion

        [Fact]
        public void Generate_returns_not_null_items_of_correct_type()
        {
            var generated = Rand.NextArrayOf<Account>(CollectionSize);
            generated.Length.ShouldBe(CollectionSize);

            foreach (var item in generated)
            {
                item.ShouldNotBeNull();
                item.ShouldBeOfType<Account>();
            }
        }

        [Fact]
        public void string_generation_test()
        {
            const int minLength = 3;
            const int maxLength = 7;
            var generated = Rand.NextArrayOf<ClassToGenerate>(CollectionSize);

            foreach (var item in generated)
            {
                item.Text.ShouldNotBeEmpty();
                //item.Text.Length.ShouldBeInRange(minLength, maxLength);
            }
        }

        [Fact]
        public void int_generation_test()
        {
            var constrains = ConstrainFactory.For<ClassToGenerate>()
                .AddIntConstrain(x => x.Int, 50, 100)
                .Build();
            var generated = Rand.NextArrayOf<ClassToGenerate>(CollectionSize, constrains);

            foreach (var item in generated)
            {
                item.ShouldNotBeNull();
                item.Int.ShouldBeInRange(50, 100);
            }
        }

        [Fact]
        public void double_generation_test()
        {
            var generated = Rand.NextArrayOf<ClassToGenerate>(CollectionSize);

            foreach (var item in generated)
            {
                item.ShouldNotBeNull();
                //item.Double.ShouldBeInRange(70, 120);
            }
        }

        [Fact]
        public void creation_of_complex_class_test()
        {
            var generated = Rand.NextArrayOf<Account>(CollectionSize);

            foreach (var item in generated)
            {
                item.Name.ShouldNotBeEmpty();
                item.Email.ShouldContain("@");
                FakeData.Surnames.ShouldContain(item.Surname);
                item.Address.ShouldNotBeEmpty();
                FakeData.Countries.ShouldContain(item.Country);
                FakeData.Companies.ShouldContain(item.Company);
                item.Info.ShouldNotBeEmpty();
                item.Created.ShouldNotBe(new DateTime());
            }

            generated.Any(x => Math.Abs(x.Number) > double.Epsilon).ShouldBeTrue();
        }

        [Fact(Skip = "Viable after adding again generation options")]
        public void available_values_generator()
        {
            var names = new[] { "name1", "name2", "name3" };
            var generated = Rand.NextArrayOf<Account>(CollectionSize);

            foreach (var item in generated)
            {
                names.ShouldContain(item.Name);
            }
        }

        [Fact]
        public void private_properties_arent_override() 
        {
            var generated = Rand.Next<ClassToGenerate>();
            generated.NumberThatShouldntBeSet.ShouldBe(12);
        }

        [Fact]
        public void nested_classes_are_generated_properly()
        {
            var generated = Rand.Next<ClassToGenerate>();
            generated.NestedClass.ShouldNotBeNull();
            generated.NestedClass.NestedText.ShouldNotBeEmpty();
        }
    }
}
