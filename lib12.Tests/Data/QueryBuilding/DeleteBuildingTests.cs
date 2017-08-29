using lib12.Data.QueryBuilding.Builders;
using lib12.Data.QueryBuilding.Structures;
using Shouldly;
using Xunit;

namespace lib12.Tests.Data.QueryBuilding
{
    public class DeleteBuildingTests
    {
        [Fact]
        public void clear_table()
        {
            const string toBuild = "DELETE FROM product";
            SqlBuilder.Delete.From("product").Build()
                .ShouldBe(toBuild);
        }

        [Fact]
        public void two_field_delete_with_where()
        {
            const string toBuild = "DELETE FROM product WHERE price='1'";
            SqlBuilder.Delete.From("product").Where("price", Compare.Equals, 1).Build()
                .ShouldBe(toBuild);
        }

        [Fact]
        public void delete_with_where_and_brackets()
        {
            const string toBuild = "DELETE FROM product WHERE (price='1' AND type='3') OR type!='3'";
            SqlBuilder.Delete.From("product").OpenBracket()
                .Where("price", Compare.Equals, 1).And.Where("type", Compare.Equals, 3).CloseBracket()
                .Or.Where("type", Compare.NotEquals, 3)
                .Build()
                .ShouldBe(toBuild);
        }
    }
}