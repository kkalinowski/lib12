![alt tag](https://raw.github.com/kkalinowski/lib12/master/lib12.png)

lib12 is set of useful classes and extension created for .net 4 core and WPF. During my work with .net and WPF I created many classes and function that can be reused across different projects.

Current version 1.2 available on nuget - https://www.nuget.org/packages/lib12

Dependency injection - lib12.DependencyInjection
--------------------
I wanted to create as simple as possible dependency injection container. To register class you have to only decorate it with Singleton or Transient attribute:
```csharp
    [Singleton]
    public class SingletonClass
    {
    //...
    }

    [Transient]
    public class TransientClass
    {
    //...
    }
```

You can also register it manually:
```csharp
	Instances.RegisterSingleton<SingletonClass>();
	Instances.RegisterTransient<TransientClass>();
	
	//or with service
	Instances.RegisterSingleton<ISingletonContract, SingletonService>();
	Instances.RegisterTransient<ITransientContract, TransientService>();
	
	//or with string key
	Instances.RegisterSingleton<SingletonClassRegisteredByKey>("resolve_singleton_by_key");
	Instances.RegisterTransient<TransientClassRegisteredByKey>("resolve_transient_by_key");
```

To resolve class use Instances.Get<Type>() method:
```csharp
	var singletonInstance = Instances.Get<SingletonClass>()
	
	//or with string key
	var singletonInstanceByKey = Instances.Get("resolve_singleton_by_key");
```

Dependencies are resolved in constructor and properties. In constructor it occurs automatically. To resolve property you have to mark it with WireUp property:
```csharp
	[WireUp]
	public TransientClass Wired { get; set; }
```

You can also use WireAllProperties attribute to tell container to resolve all properties:
```csharp
	[Singleton, WireUpAllProperties]
	class WireAllPropertiesSingleton
```

DI container was designed to inform you every time you did something wrong using exceptions. I wanted to avoid situations that occurs in other libraries, when during runtime you discovered that some property is null and you don't know why. Also container can resolve some simple circular dependencies.

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

Dummy and random data - lib12.Data.Dummy
--------------------
Sometimes when you start developing new project you don't have data to test your solution. lib12 contains classes that will help you to quickly solve this problem. RandomClassGenerator contains methods to quickly generate collection of random data, using property generators to describe how to generate data for class's properties:
```csharp
var generator = new RandomClassGenerator();
var generated = generator.Generate<ClassToGenerate>(CollectionSize,
	new StringGenerator<ClassToGenerate>(x => x.Text, 3, 7),
	new EnumGenerator<ClassToGenerate, ClassToGenerate.EnumToGenerate>(x => x.Enum),
	new BoolGenerator<ClassToGenerate>(x => x.Bool),
	new IntGenerator<ClassToGenerate>(x => x.Int, 50, 100),
	new DoubleGenerator<ClassToGenerate>(x => x.Double, 70, 120));
```
lib12 contains also extensions for System.Random class for generating bool, char, string and DateTime.

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
- TreeHelper class easier working with hierarchical data structures. It works on top of the ITreeBranch interface providing methods for manipulation of this hierarchy like Organazing list into hierarchy, flattening hierarchy, checking position of given element in tree
- IEnumerableExtension contains methods that easier working with standard collections like Foreach, IsNullOrEmpty, ToNullPatternObject, ToDelimitedString, etc.
- lib12.Collections namespace contains also extensions for List and Dictionary classes

Other classes
---
- lib12.Misc.Range - generic class for dealing with ranges
- lib12.Misc.Empty - returns empty array, list and dictionary
- lib12.Misc.PropertyComparer - implements IEqualityComparer using lambda expressions
- lib12.Misc.TimesLoop - do given function X times
- lib12.Misc.IoHelper - additional methods for IO
- lib12.Crypto.SaltedHash - implemention of salted hash mechanism for password storing
- lib12.Serialization - namespace contains classes that simplifying implementation of serialization

Set of extensions for standard classes
--------------------
- DateTime
- EventHandler
- Nullable
- Reflection

lib12.WPF
===
FluidTextBox control
--------------------
It is extension of TextBox control that adds:
- Watermark
- IntOnly, DoubleOnly enter mode
- Build in label

Converters for WPF
--------------------
lib12 contains set of WPF converters build using markup extensions for easier using:
- NegateConverter - negates bool
- AndMultiConverer - AND operation from multiple bool values
- OrMultiConverer - OR operation from multiple bool values
- BoolToVisibilityConverter - converters bool value to Visibility
- BrushToColorConverter - converts SolidColorBrush to Color
- SubstringConverter - get substring of given length from string

Event to command transcription
--------------------
WPF events don't play well with MVVM pattern. To bypass this problem I created EventTranscription logic which translates WPF events into WPF commands

and more...
--------------------
- FluidGrid - set of attached properties for Grid control to simplify declaration of rows and columns
- ImageButton - button with Image content, supports disabled and hover states
- FluidPopup - more robust popup
- DataGridSelectedItemsBinding, ListBoxSelectedItemsBinding - OneWayToSource binding for SelectedItems property for DataGrid and ListBox
- PushBinding - OneWayToSource binding for ReadOnly dependency property
- TypeTemplateSelector - TemplateSelector based on data type
- Inject markup extension - markup extension that uses dependency injection from lib12 to resolve objects
- Serialization - serialization for ViewModels that uses serialization mechanism from lib12
- other classes - ControlTreeHelper, DelegateCommand, NotifyingObject, WpfUtilities
- extension methods - for Application, ContextMenu, DependencyObject and Popup

Use freely without limitation and let me know what you think about.
