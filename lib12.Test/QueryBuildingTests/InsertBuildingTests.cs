using FluentAssertions;
using lib12.Data.QueryBuilding;
using lib12.Data.QueryBuilding.Builders;
using System;
using Xunit;

namespace lib12.Test.QueryBuildingTests
{
    public class InsertBuildingTests
    {
        [Fact]
        public void one_column_insert()
        {
            const string toBuild = "INSERT INTO product(type) VALUES('4')";
            SqlBuilder.Insert.Into("product").Columns("type").Values(4).Build()
                .Should().Be(toBuild);
        }

        [Fact]
        public void three_column_insert()
        {
            const string toBuild = "INSERT INTO product(type, price, name) VALUES('4', '5', 'test')";
            SqlBuilder.Insert.Into("product").Columns("type", "price", "name").Values(4, 5, "test").Build()
                .Should().Be(toBuild);
        }

        [Fact]
        public void throw_exception_if_columns_count_differs_from_values_count()
        {

            Action action = () => SqlBuilder.Insert.Into("product").Columns("type", "price", "name").Values(4).Build();
            action.ShouldThrow<QueryBuilderException>();
        }
    }
}