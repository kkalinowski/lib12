﻿using FluentAssertions;
using lib12.Data.QueryBuilding.Builders;
using lib12.Data.QueryBuilding.Structures;
using Xunit;

namespace lib12.Test.QueryBuildingTests
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
    }
}