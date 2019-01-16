![alt tag](https://raw.github.com/kkalinowski/lib12/master/lib12.png)

[![Build Status](https://travis-ci.org/kkalinowski/lib12.svg?branch=master)](https://travis-ci.org/kkalinowski/lib12)
[![NuGet Version](https://badge.fury.io/nu/lib12.svg)](https://badge.fury.io/nu/lib12.svg)

lib12 is set of useful classes and extension created for .NET framework. During my work with .NET framework I created many classes and function that can be reused across different projects. lib12 is using .NET Standard 2.0

Current version available on nuget - https://www.nuget.org/packages/lib12
My blog describing library setup and content - https://kkalinowski.net/2018/10/07/lib12-my-helper-library/

## Table of Contents
1. [Fluent SQL query builder](#fluent-sql-query-builder)
2. [Dummy and random data](#dummy-and-random-data)
3. [Mathematical functions](#mathematical-functions)
4. [Collections](#collections)
5. [Checking utilities](#checking-utilities)
6. [Extensions methods](#extensions-methods)
7. [Reflection](#reflection)
8. [Utilities](#utilities)

Fluent SQL query builder 
--------------------
Namespace - lib12.Data.QueryBuilding

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

Dummy and random data
--------------------
Namespace - lib12.Data.Random

Sometimes when you start developing new project you don't have data to test your solution. lib12 contains classes that will help you to quickly solve this problem. __Rand__ contains methods to quickly generate collection of random data:

```csharp
public class ClassToGenerate
{
    public enum EnumToGenerate
    {
        First,
        Second,
        Third
    }

    public class Nested
    {
        public string NestedText { get; set; }
    }

    public string Text { get; set; }
    public EnumToGenerate Enum { get; set; }
    public bool Bool { get; set; }
    public int Int { get; set; }
    public double Double { get; set; }
    public int NumberThatShouldntBeSet { get; } = 12;
    public int NumberImpossibleToSet { get { return 12; } }
    public Nested NestedClass { get; set; }
}

var generated = Rand.NextArrayOf<ClassToGenerate>(CollectionSize);
```
__lib12.Data.Random__ contains also methods from System.Random class and additional methods for generating bool, char, string, enums and DateTime in one easy to use static __Rand__ class. Also __FakeData__ class contains preprogramed set of names, companies, geodata to quickly generate useful data for your application tests.

lib12.Data.Xml
---
Contains extensions methods for Xml classes to create xmls in fluent way. 

Mathematical functions
---
Namespace - lib12.Mathematics

__Formula__ class use Reverse Polish Notation to parse and compute mathematical expressions:

```csharp
var formula = new Formula("-12*3 + (5-3)*6 + 9/(4-1)");
var result = formula.Evaluate();
```
This class understands variables, so you can compile it once and use for many computations:
```csharp
var formula = new Formula("a*(5-b)");
formula.Evaluate(new { a = 10, b = 3 });
```
Mathematics namespace contains also __Math2__ class which contains many helper functions like Next, Prev, IsEven or IsOdd.

Collections
---
Namespace - lib12.Collections
- IEnumerableExtension contains methods that easier working with standard collections like Foreach, IsNullOrEmpty, Recover (which acts as null pattern object simplifying null checking), ToDelimitedString, IntersectBy, MaxBy, LeftJoin, etc.
- lib12.Collections.CollectionFactory - creates collections in functional way
- lib12.Collections.Empty - creates empty collections using fluent syntax
- lib12.Collections.Packing - contains class __Pack__ to quickly pack set of loose objects into collection and extension methods for single object to do that
- lib12.Collections.Paging - contains extension methods GetPage, GetNumberOfPages and GetPageItems to simplify working with paging
- lib12.Collections namespace contains also extensions for ICollection, IDictionary and array

Checking utilities
---
Namespace - lib12.Checking

Contains __Check__ class to quickly simplify null checking on set objects like __Check.AllAreNull__ or __Check.AnyIsNull__. This namespace also contains extensions for equality check against set of objects like __object.IsAnyOf(object1, object2, object3)__

Extensions methods
---
Namespace - lib12.Extensions

- String - methods like EqualsCaseInsensitive, Truncate, ContainsCaseInsensitive, RemoveDiacritics or GetNumberOfOccurrences
- DateTime - allows to manipulate weeks and quarter, get start and end of week and month, get persons age or check date (__IsWorkday, IsWeekend, IsInPast, IsInFuture__)
- Nullable bool - quick checks remove redundant code like __IsTrue__ or __IsNullOrFalse__
- Exception - __GetInnerExceptions__ and __GetMostInnerException__
- Func

Reflection
---
Namespace - lib12.Reflection

Set of extensions to easier work with Reflection

Utilities
---
- lib12.Utlity.Comparing - contains generic __PropertyOrderComparer__ and __PropertyEqualityComparer__ can implements __IComparer__ and __IEqualityComparer__ respectively so for simple one property checks you don't have to implement whole Comparer
- lib12.Utility.Execution - utilities to work with function calls - __Repeat__, __Benchmark__, __Retry__ and __Memoize__
- lib12.Utility.Range - generic class for dealing with ranges
- lib12.Utility.IoHelper - additional methods for IO
- lib12.Utility.Logger - simple logger, that doesn't need additional configuration
- lib12.Utility.UnknownEnumException - exception to better interpret  missing case for enum
