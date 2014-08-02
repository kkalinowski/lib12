using FluentAssertions;
using lib12.Data.QueryBuilding;
using lib12.Data.QueryBuilding.Builders;
using System;
using System.Collections.Generic;
using lib12.Exceptions;
using Xunit;

namespace lib12.Test.QueryBuildingTests
{
    public class InsertBuildingTests
    {
        private class Values
        {
            public string Prop1 { get; set; }
            public int Prop2 { get; set; }
        }

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

        [Fact]
        public void batch_insert_test()
        {
            const string expected = "INSERT INTO product(Prop1, Prop2) VALUES('test', '21'), ('test2', '8')";
            SqlBuilder.Insert.Into("product").Columns("Prop1", "Prop2").Batch(
                new[]{
                    new Values{Prop1 = "test", Prop2 = 21},
                    new Values{Prop1 = "test2", Prop2 = 8}
                }).Build().Should().Be(expected);
        }

        [Fact]
        public void batch_insert_test_using_anonymous_object()
        {
            const string expected = "INSERT INTO product(Prop1, Prop2) VALUES('test', '21'), ('test2', '8')";
            SqlBuilder.Insert.Into("product").Columns("Prop1", "Prop2").Batch(
                new[]{
                    new {Prop1 = "test", Prop2 = 21},
                    new {Prop1 = "test2", Prop2 = 8}
                }).Build().Should().Be(expected);
        }

        [Fact]
        public void throw_exception_if_given_collection_for_batch_insert_is_null()
        {
            List<Values> list = null;
            Assert.Throws<QueryBuilderException>(() => SqlBuilder.Insert.Into("product").Columns("Prop1", "Prop2").Batch(list).Build());
        }

        [Fact]
        public void throw_exception_if_given_collection_for_batch_insert_is_empty()
        {
            var list = new List<Values>();
            Assert.Throws<QueryBuilderException>(() => SqlBuilder.Insert.Into("product").Columns("Prop1", "Prop2").Batch(list).Build());
        }

        [Fact]
        public void throw_exception_if_accessing_not_existing_property_in_batch_insert()
        {
            var collection = new[] { new Values { Prop1 = "test", Prop2 = 21 } };
            Assert.Throws<lib12Exception>(() => SqlBuilder.Insert.Into("product").Columns("Prop1", "Prop2", "Prop3").Batch(collection).Build());
        }
    }
}