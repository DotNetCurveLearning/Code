# Inheriting from abstract classes

When a class is marked as **abstract**. this means that it cannot be instantiated becuase you are indicating, that the class is not complete. It needs
more implementation before it can be instantiated.

# Preventing inheritance and overriding

You can prevent this by applying the **sealed** keyword to its definition:

```
public sealed class ScroogeMcDuck
{
}
```

We can prevent someone from further overriding a **virtual** method in a class by applying the **sealed** keyword to the method:

```
public class Singer
{
	// virtual allows this method to be overriden
	public virtual void Sing()
	{
		WriteLine("Singing...");
	}
}

public class LadyGaga : Singer
{
	// sealed prevents overriding the method in subclasses
	public sealed override void Sing()
	{
		WriteLine("Singing with style...");
	}
}
```

**NOTE**: you can only seal an overriden method.

## Understanding polymorphism

**GOOD PRACTICE**: You should use **virtual** and **override** rather than **new** to change the implementation of an inherited method whenever possible.

# Casting within inheritance hierarchies

## Avoiding casting exceptions

We can handle this checking the type of an object using the **is** keyword:

```
Employee aliceInEmployee = new()
{
	Name = "Alice",
	EmployeeCode = "AA123"
};

Person aliceInPerson = aliceInEmployee;

if (aliceInPerson is Employee explicitAlice)
{
	WriteLine($"{nameof(aliceInPerson)} IS an Employee");

	// safely do something with explicitAlice
}
```

Alternatively, we can use the **as** keyword to cast. Instead of throwing an exception, the **as** keyword return nusll if the type cannot be cast.

```
Employee? aliceAsEmployee = aliceInPerson as Employee;	// could be null

if (aliceAsEmployee != null)
{
	WriteLine($"{nameof(aliceInPerson)} AS an Employee");

	// safely do something with explicitAlice
}
```

Since accessing a member of a null variable will throw a **NullPointerException** error, we should always check for null before using the result.