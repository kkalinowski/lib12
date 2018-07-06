![alt tag](https://raw.github.com/kkalinowski/lib12/master/lib12.png)

[![Build Status](https://travis-ci.org/kkalinowski/lib12.svg?branch=master)](https://travis-ci.org/kkalinowski/lib12)

lib12 is set of useful classes and extension created for .NET framework. During my work with .NET framework I created many classes and function that can be reused across different projects. lib12 is using .NET Standard 2.0

Current version 2.0 available on nuget - https://www.nuget.org/packages/lib12

Fluent SQL query builder - lib12.Data.QueryBuilding
--------------------
In spite of overwhelming popularity of various ORMs you still have to write some SQL query from time to time. Maintaining and storing those queries can be tricky. To help with that I created fluent SQL query builder. It supports most important SQL keywords for select, insert, update and delete. Using it is quite simple:

```csharp
var select = SqlBuilder.Select.Fields(fields).From("products", "p")
	.Join("groups", "g", "p.group_id", "g.id")
	.Join("stores", "s", "g.id", "s.group_id", JoinType.Left)
	.OpenBracket()
	.Where("price", Compare.GreaterThan, 100).And.Where("price", Compare.LessOrEquals, 1000)
	.CloseBracket()
	.Or.Where("code", Compare.Like, "a%")
	.GroupBy("product_group").Having("avg(price)>100")
	.OrderByDesc("price").Build();
	
var insert = SqlBuilder.Insert.Into("product").Columns("type", "price", "name").Values(4, 5, "test").Build();

var batchInsertQuery = SqlBuilder.Insert.Into("product").Columns("Prop1", "Prop2").Batch(
    new[]{
		new Values{Prop1 = "test", Prop2 = 21},
		new Values{Prop1 = "test2", Prop2 = 8}
    }).Build();
    
var insertIntoSelect = SqlBuilder.Insert.Into("product").Columns("name","price")
	.Select(SqlBuilder.Select.AllFields.From("product_test").Build())
    .Build();

var update = SqlBuilder.Update.Table("product").Set("price", 5).Set("name", "test").OpenBracket()
	.Where("price", Compare.Equals, 1).And.Where("type", Compare.Equals, 3).CloseBracket()
	.Or.Where("type", Compare.NotEquals, 3)
	.Build();
	
var delete = SqlBuilder.Delete.From("product").OpenBracket()
	.Where("price", Compare.Equals, 1).And.Where("type", Compare.Equals, 3).CloseBracket()
	.Or.Where("type", Compare.NotEquals, 3)
	.Build()
```

Dummy and random data - lib12.Data.Random
--------------------
Sometimes when you start developing new project you don't have data to test your solution. lib12 contains classes that will help you to quickly solve this problem. Rand contains methods to quickly generate collection of random data:
```csharp
var generated = Rand.NextArrayOf<ClassToGenerate>(CollectionSize);
```
lib12.Data.Random contains also methods from System.Random class and additional methods for generating bool, char, string, enums and DateTime in one easy to use static class

Mathematical functions - lib12.Mathematics
---
Formula class use Reverse Polish Notation to parse and compute mathematical expressions:
```csharp
var formula = new Formula("-12*3 + (5-3)*6 + 9/(4-1)");
var result = formula.Evaluate();
```
This class understands variables, so you can compile it once and use for many computations:
```csharp
var formula = new Formula("a*(5-b)");
formula.Evaluate(new { a = 10, b = 3 });
```
Mathematics namespace contains also QuadraticEquation and MathExt classes which contains many helper functions for less standard mathematical operations like Iverson operator, Factorial or BinomialCoefficent

Collections - lib12.Collections
---
- IEnumerableExtension contains methods that easier working with standard collections like Foreach, IsNullOrEmpty, ToNullPatternObject, ToDelimitedString, IntersectBy, MaxBy, LeftJoin, etc.
- lib12.Collections.CollectionFactory - creates collections in functional way
- lib12.Collections.Empty - creates empty collections using fluent syntax
- lib12.Collections namespace contains also extensions for List and Dictionary classes

Other classes
---
- lib12.Misc.Range - generic class for dealing with ranges
- lib12.Misc.PropertyComparer - implements IEqualityComparer using lambda expressions
- lib12.Misc.IoHelper - additional methods for IO
- lib12.Misc.Logger - simple logger, that doesn't need additional configuration
- lib12.Misc.PerformanceCheck - shortcut for performance checking
- lib12.Data.Xml - set of extentions methods to linq-to-xml which simplifies edition of xml files by allowing to use easy to read fluent style

Set of extensions for standard classes
--------------------
- DateTime
- String
- Reflection
