# Storing multiple values using an enum type

We can combine multiple choices into a single value using enum **flags**.

This is achieved decorating the enum with the **[System.Flags]** attribute, and explicitly set a byte value for each enum item:

```
public enum WondersOfTheAncientWorld : byte
{
	None = 0b_0000_0000,                        // 0
	GreatPyramidOfGiza = 0b_0000_0001,          // 1
	HangingGardensOfBabylon = 0b_0000_0010,     // 2
	StatueOfZeusAtOlympia = 0b_0000_0100,       // 4           
	TempleOfArtemiseAtEphesus = 0b_0000_1000,   // 8
	MausoleumAtHalicarnassus = 0b_0001_0000,    // 16
	ColossusOfRhodes = 0b_0010_0000,            // 32
	LighthouseOfAlexandria = 0b_0100_0000       // 64
}
```

Using the **[System.Flags]** attribute, when the value is returned it can automatically match with multiple values as comma-separated string instead of returning an int value.

# Generic collections

The <> brackets it's a fancy term for making a collection strongly typed , that is, the compiler knows specifically what type of object can be stored in the collection. 

Generics improve the performance and correctness of your code.

# Making a field static

When the fields are **instance members** that means that a different value of each field exists for each instance of the class that is created (*alice* and *bob* variables have different *Name* values).

If we want to define a field that only has one value that is shared across all instances, we have to use **static** members.

Fields are not the only members that can be static. Constructors, methods, properties and other members can also be **static**.

# Making a field read-only

This is the better choice for fields that should not change.

**GOOD PRACTICE**: 
Constants are not always the best choice because the value must be known at compile time, and it must be expressible as a literal string, Boolean or number value, and since every reference to the const field
is replaced with the literal value at compile time, it won't be reflected if the value changes in a future version and we don't recompile any assembles that reference it to get the new value.

Use read-only fields over constant fields for two important reasons: the vaule can be calculated or loaded at runtime and can be expressed using any executable statement.
So, a read-only field can be set using a constructor or a field assignment.
Every reference to the field is a live reference, so any future changes will be correctly reflected by the calling code.

# Defining multiple constructors 

You can have multiple constructors in a type. This is especially useful to encourage developers to set initial values for fields.

# Writing and calling methods

## Combining multiple returned values using tuples

Tuples are an efficient way to combine two or more values into a single unit.

## Naming the fields of a tuple 

To access the fields of a tuple, the default names are Item1 , Item2 , and so on. You can explicitly specify the field names:

```
public (string Name, int Number) GetNamedFruit()
{
	return (Name: "Apples", Number: 5);
} 

...

var fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");
```

## Deconstructing types 

Tuples are not the only type that can be deconstructed. Any type can have special methods named **Deconstruct** that break down the object into parts.

```
public void Deconstruct(out string name, out DateTime dob)
{
	name = Name;
	dob = DateOfBirth;
}

public void Deconstruct(out string name, out DateTime dob, out WondersOfTheAncientWorld fav)
{
	name = Name;
	dob = DateOfBirth;
	fav = FavoriteAncientWonder;
}

...

var (name1, dob1) = bob;
WriteLine($"Deconstructed: {name1}, {dob1}");

var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");
```

## Passing optional and named parameters

Another way to simplify methods is to make parameters optional. You make a parameter optional by **assigning a default value inside the method parameter list**. 

Optional parameters must always **come last in the list of parameters**.

```
public string OptionalParameters(
            string command = "Run!",
            double number = 0.0,
            bool active = true) 
{
	return string.Format(
		format: "command is {0}, number is {1}, active is {2}",
		arg0: command,
		arg1: number,
		arg2: active);
}
```

## Naming parameter values when calling methods 

**Optional parameters are often combined with naming parameters** when you call the method, because naming a parameter **allows the values to be passed in a different order than how they were declared**.

## Controlling how parameters are passed 

When a parameter is passed into a method, it can be passed in one of three ways: 

* By **value** (this is the default): Think of these as being *in-only*. 
* By **reference** as a *ref* parameter: Think of these as being *in-and-out*. 
* As an out parameter: Think of these as being *out-only*.

**NOTE**: *out* parameters cannot have a default and must be initialized inside the method.

* When passing a variable as a parameter **by default**, its current value gets passed, **not the variable itself**. Therefore, x has a copy of the value of the a variable. The a variable retains its original value of 10. 
* When passing a variable as a **ref** parameter, **a reference to the variable gets passed into the method**. Therefore, **y is a reference to b**. The b variable gets incremented when the y parameter gets incremented. 
* When passing a variable as an **out** parameter, **a reference to the variable gets passed into the method**. Therefore, z is a reference to c. The value of the c variable gets replaced by whatever code executes inside the method. We could simplify the code in the Main method by not assigning the value 30 to the c variable since it will always be replaced anyway.

## Simplified out parameters 

In C# 7.0 and later, we can simplify code that uses the out variables.

```
int d = 20;
int e = 30;

WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
bob.PassingParameters(d, ref e, out int c);
WriteLine($"After: d = {d}, e = {e}, f = {f}");
```

# Controlling access with properties and indexers

A **property** is simply a method (or a pair of methods) that acts and looks like a field when we want to get or set a value, threby simplifying the syntax.

## Defining read-only properties

A *readonly* property only has a *get* implementation.

```
// a property defined using C# 1 - 5 syntax
public string Origin
{
	get
	{
		return $"{Name} was born on {HomePlanet}";
	}
}

// two properties defined using C# 6+ lambda expression boy syntax
public string Greeting => $"{Name} says 'Hello!'";

public int Age => System.DateTime.Today.Year - DateOfBirth.Year;
```
## Defining settable properties

To create a settable property, we must use the older syntax and provide a pair of methods - not just a *get* part, but also a *set* part.

```
public string FavoriteIceCream { get; set; };
```
In case you have to add further implementation in the get/set:

```
public string MyProperty { 
    get => _favoritePrimaryColor;
    set
    {
        switch (value.ToLower())
        {
            case "red":
            case "green":
            case "blue":
                _favoritePrimaryColor = value;
                break;
            default:
                throw new System.ArgumentException($"{value} is not a primary color. Choose from: red, green, blue");
        }
    }
}
```

## Requiring properties to be set during instantiation

C# 10 introduces the **required** modifier. Use it on a property, the compiler will ensure that we set the property to a value when we instantiate it:

```
public class Book
{
	public required string Isbn { get; set; }
	public string Title { get; set; }
}
```

Trying to instantiate a Book without setting the Isbn property it will trigger a compiler error.

## Defining indexers

Indexers allow the calling code to use the array syntax to access a property.

```
// indexers
public Person this[int index]
{
	get
	{
		return Children[index];	// pass on to the List<T> indexer
	}

	set
	{
		Children[index] = value;
	}
}
```

We can overload indexers so that different types can be used for their parameters. For instance, as well as passing an int value, we could also pass a string value.

## Pattern matching with objects

* To èattern match on properties of an object, we must name a local variable that can then be used in an expression like p.
* To pattern match on a type only, we can use _ to discaerd the local variable.
* The switch expression also uses _ to represent its default branch.

```
decimal flightCost = passenger switch
{
    /* C# 8 syntax
    FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
    FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
    FirstClassPassenger _                         => 2000M, */

    // C# 9 or latter syntax
    FirstClassPassenger p => p.AirMiles switch
    {
        > 35000 => 1500M,
        > 15000 => 1750M,
        _       => 2000M
    },
    BusinessClassPassenger _                      => 1000M,
    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
    CoachClassPassenger _                         => 650M,
    _                                             => 800M
};
```

## Working with records

### Init-only properties

The **init** keyword enables to treat properties like readonly fields so they can be set during instantiation but not after. It can be used in place of the **set** keyword:

## Understanding records

Init-only properties provide some immutability to C#.

With **records** we can make the whole object immutable, and it acts like a value when compared.

Records should not have any state (properties and fields) that changes after instantiation. Instead, the idea is that we create new records from existing ones
with any changed state. This is called **non-destructive mutation**.

To do this, C# 9 introduces the **with** keyword:

```
ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red Crystal Metallic",
    Wheels = 4,
};

ImmutableVehicle repaintedCar = car
    with
{ Color = "Polymetal Grey Metallic" };

WriteLine($"Original car color was {car.Color}");
WriteLine($"New car color was {repaintedCar.Color}");
```

### Simplifying data members in records

Instead of using object initialization syntaz with curly braces, sometimes we might prefer to provide a constructor with positional parameters.

We can also combine this with a deconstructor for splitting the object into individual parts:

```
// simpler way to define a record
// auto-generates the properties, constructor and deconstructor
public record ImmutableAnimal(string Name, string Species);
```

# Practicing and exploring

1. What are the six combinations of access modifer keywords and what they do?

**public**: Member is accesible everywhere.  
**protected**: Member is accesible inside the type and any type that inherits from the type. 
**private**: Member is accesible inside the type only. 
**internal**: Member is accesible inside the type and any type inside the assembly.
**internal protected**: Member is accesible inside the type and any type inside the assembly, and any type that inherits from the type.
**private protected**: Member is accesible inside the type, and any type that inherits from the type and is in the same assembly.

2. What is the difference between static, const, and readonly keywords when applied to a type member?

**static**: The data has one value that is shared accross all instances; the opposite of instance member where a different value of each field exists for each instance of the class that is created.
**const**: The data never changes. The compiler literally copies the data into any code that reads it.
**readonly**: The data cannot change after the class is instantiated, but the data can be calculated or loaded from an external source at the time of instantiation.

3. What a constructor do?

A constructor is an special method that is automatically called when an object of a class is created to initialize all the class data members.

4. Why should you apply the [Flags] attribute to an enum type when you want to store combined values?

The [Flags] attribute allow us to use bitmasking inside the enum type. This allow us to combine enumeration values, while retaining which ones are specified.

```
// The values are power of 2 (binary)
[Flags]
public enum UserType
{                
    None = 0,    
    Customer = 1,             
    Driver = 2,               
    Admin = 4,                
    Employee = Driver | Admin
}
```

We can use the bitwise operators to work with Flags.

### Initialize a value

We should use the value 0 named None, which means the collection is empty.

```
var flags = UserType.None;
```

### Add a value

```
var flags |= UserType.None;
```

Now the flags variable equals **Driver**.

### Remove a value

We can remove value by use &, ~ operators:

```
var flags &= ~UserType.None;
```

Now the flags variable equals **None**.

6. What is a tuple?

It's a data structure which may consist of multiple parts. They are used when we want to return multiple values from a method without using ref or out parameters.

7. What does the record keyword do?

It allow us to create immutable types. They are designed for the common case of "data only" types.

8. What does overloading mean?

Overloading happens when we have two methods with the same name but different signatures (or arguments).

9. What is the difference between a field and a property?

A field is a variable of any type that is declared in the class, while property is a member that provides a flexible mechanism to read, wirte or compute the value of a private field.

10. How do you make a method parameter optiona?

By assigning default values for that parameter:
```
public static void Sum(int a, int b, in[] n = null){...}
```