using System.Collections.Generic;
using lib12.Data.QueryBuilding;
using lib12.Data.QueryBuilding.Builders;
using lib12.Data.QueryBuilding.Structures;
using lib12.Data.QueryBuilding.Structures.Select;
using lib12.Misc;
using Xunit;

namespace lib12.Test.QueryBuilding
{
    public class SelectBuildingTests
    {
        [Fact]
        public void select_all_from_test()
        {
            var toBuild = "select * from products";
            var query = SqlBuilder.Select.AllFields.From("products").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void select_fields_from_test()
        {
            var toBuild = "select id, name as b from products";
            var fields = new List<SelectField>() { new SelectField("id"), new SelectField("name", "b") };
            var query = SqlBuilder.Select.Fields(fields).From("products").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void one_join_test()
        {
            var toBuild = "select * from products p join groups g on p.group_id=g.id";
            var query = SqlBuilder.Select.AllFields.From("products", "p").Join("groups", "g", "p.group_id", "g.id").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void standard_and_left_join_test()
        {
            var toBuild = "select * from products p join groups g on p.group_id=g.id left join stores s on g.id=s.group_id";
            var query = SqlBuilder.Select.AllFields.From("products", "p").Join("groups", "g", "p.group_id", "g.id").Join("stores", "s", "g.id", "s.group_id", JoinType.Left).Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void where_test()
        {
            var toBuild = "select * from products where price>'100'";
            var query = SqlBuilder.Select.AllFields.From("products").Where("price", Compare.GreaterThan, 100).Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void explicit_where_test()
        {
            var toBuild = "select * from products where price>'100' and type is not null";
            var query = SqlBuilder.Select.AllFields.From("products").Where("price", Compare.GreaterThan, 100).And.Where("type is not null").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void two_wheres_test()
        {
            var toBuild = "select * from products where price>'100' and price<='1000'";
            var query = SqlBuilder.Select.AllFields.From("products").Where("price", Compare.GreaterThan, 100).And.Where("price", Compare.LessOrEquals, 1000).Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void three_wheres_test()
        {
            var toBuild = "select * from products where (price>'100' and price<='1000') or code like 'a%'";
            var query = SqlBuilder.Select.AllFields.From("products").OpenBracket().Where("price", Compare.GreaterThan, 100).And.Where("price", Compare.LessOrEquals, 1000)
                .CloseBracket().Or.Where("code", Compare.Like, "a%").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void throw_exception_when_unclosed_bracket()
        {
            Assert.Throws<QueryBuilderException>(() => SqlBuilder.Select.AllFields.From("products").OpenBracket().Where("price", Compare.GreaterThan, 100).Build());
        }

        [Fact]
        public void throw_exception_when_not_opened_bracket()
        {
            Assert.Throws<QueryBuilderException>(() => SqlBuilder.Select.AllFields.From("products").Where("price", Compare.GreaterThan, 100).CloseBracket().Build());
        }

        [Fact]
        public void group_by_test()
        {
            var toBuild = "select * from products group by product_group";
            var query = SqlBuilder.Select.AllFields.From("products").GroupBy("product_group").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void having_test()
        {
            var toBuild = "select * from products group by product_group having avg(price)>100";
            var query = SqlBuilder.Select.AllFields.From("products").GroupBy("product_group").Having("avg(price)>100").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void order_by_test()
        {
            var toBuild = "select * from products order by price";
            var query = SqlBuilder.Select.AllFields.From("products").OrderBy("price").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void order_by_desc_test()
        {
            var toBuild = "select * from products order by price desc";
            var query = SqlBuilder.Select.AllFields.From("products").OrderByDesc("price").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void complex_test()
        {
            var toBuild = "select id, name as b from products p join groups g on p.group_id=g.id left join stores s on g.id=s.group_id where (price>'100' and price<='1000') or code like 'a%' group by product_group having avg(price)>100 order by price desc";
            var fields = new List<SelectField>() { new SelectField("id"), new SelectField("name", "b") };
            var query = SqlBuilder.Select.Fields(fields).From("products", "p").Join("groups", "g", "p.group_id", "g.id").Join("stores", "s", "g.id", "s.group_id", JoinType.Left).OpenBracket()
                .Where("price", Compare.GreaterThan, 100).And.Where("price", Compare.LessOrEquals, 1000)
                .CloseBracket().Or.Where("code", Compare.Like, "a%")
                .GroupBy("product_group").Having("avg(price)>100").OrderByDesc("price").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void complex_non_fluent_test()
        {
            var toBuild = "select id, name as b from products p join groups g on p.group_id=g.id left join stores s on g.id=s.group_id where (price>'100' and price<='1000') or code like 'a%' group by product_group having avg(price)>100 order by price desc";
            var fields = new List<SelectField>() { new SelectField("id"), new SelectField("name", "b") };
            var qbuilder = new SelectBuilder();
            qbuilder.Fields(fields).From("products", "p").Join("groups", "g", "p.group_id", "g.id").Join("stores", "s", "g.id", "s.group_id", JoinType.Left).OpenBracket()
                .Where("price", Compare.GreaterThan, 100).And.Where("price", Compare.LessOrEquals, 1000)
                .CloseBracket().Or.Where("code", Compare.Like, "a%")
                .GroupBy("product_group").Having("avg(price)>100").OrderByDesc("price").Build();
            Assert.Equal(toBuild.ToLower(), qbuilder.Build().ToLower());
        }

        [Fact]
        public void top_test()
        {
            var toBuild = "select top 10 * from products";
            var query = SqlBuilder.Select.AllFields.Top(10).From("products").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void top_in_postgresql_test()
        {
            var toBuild = "select * from products limit 50";
            var query = new SelectBuilder().DB(DBType.PostreSql).AllFields.Top(50).From("products").Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void in_test()
        {
            var toBuild = "select * from products where id in ('5', '30', '400')";
            var query = SqlBuilder.Select.AllFields.From("products").Where("id", Compare.In, new List<int>(3) { 5, 30, 400 }).Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void in_one_item_test()
        {
            var toBuild = "select * from products where id in ('5')";
            var query = SqlBuilder.Select.AllFields.From("products").Where("id", Compare.In, new List<int>(1) { 5 }).Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void in_empty_collection_test()
        {
            var toBuild = "select * from products where 1 = 1";
            var query = SqlBuilder.Select.AllFields.From("products").Where("id", Compare.In, Empty.List<int>()).Build();
            Assert.Equal(toBuild.ToLower(), query.ToLower());
        }

        [Fact]
        public void throw_exception_when_argument_for_in_statement_is_not_enumerable_test()
        {
            Assert.Throws<lib12Exception>(() => SqlBuilder.Select.AllFields.From("products").Where("id", Compare.In, 12).Build());
        }
    }
}
