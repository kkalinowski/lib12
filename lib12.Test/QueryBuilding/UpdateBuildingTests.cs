using FluentAssertions;
using lib12.Data.QueryBuilding.Builders;
using lib12.Data.QueryBuilding.Structures;
using Xunit;

namespace lib12.Test.QueryBuilding
{
    public class UpdateBuildingTests
    {
        [Fact]
        public void one_field_update()
        {
            const string toBuild = "UPDATE product SET price='5'";
            SqlBuilder.Update.Table("product").Set("price", 5).Build()
                .Should().Be(toBuild);
        }

        [Fact]
        public void two_field_update()
        {
            const string toBuild = "UPDATE product SET price='5', name='test'";
            SqlBuilder.Update.Table("product").Set("price", 5).Set("name", "test").Build()
                .Should().Be(toBuild);
        }

        [Fact]
        public void two_field_update_with_where()
        {
            const string toBuild = "UPDATE product SET price='5', name='test' WHERE price='1'";
            SqlBuilder.Update.Table("product").Set("price", 5).Set("name", "test").Where("price", Compare.Equals, 1).Build()
                .Should().Be(toBuild);
        }

        [Fact]
        public void update_with_where_and_brackets()
        {
            const string toBuild = "UPDATE product SET price='5', name='test' WHERE (price='1' AND type='3') OR type!='3'";
            SqlBuilder.Update.Table("product").Set("price", 5).Set("name", "test").OpenBracket()
                .Where("price", Compare.Equals, 1).And.Where("type", Compare.Equals, 3).CloseBracket()
                .Or.Where("type", Compare.NotEquals, 3)
                .Build()
                .Should().Be(toBuild);
        }
    }
}