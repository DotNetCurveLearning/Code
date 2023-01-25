# Chapter 06 - Implementing interfaces and inheriting classes

## Implementing functionality using methods

**GOOD PRACTICE**: 

A method that created a new object, or modifies an existing object, **should return** a reference to that object so that the called can access the results.

## Implementing functionality using operators

Example: For the multiply symbol (*).

This is done by defining a **static** operator for the * symbol. The syntaz is rather like a method, because in effect, an operator is a method, but uses a symbol
instead of a method name, which makes the syntax more concise.

```
public static Person operator *(Person p1, Person p2)
{
    return Person.Procreate(p1, p2);
}

...

Person baby3 = harry * mary
```

## Implementing functionality using local functions

Local functions are the method equivalent of local variables. In other words, they are methods that are only accesible from within the containing method in
which they have been defined.

```
public static int Factorial (int number)
{
    if (number < 0)
    {
        throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
    }

    return localFactorial(number);

    int localFactorial(int localNumber) // local function
    {
        if (localNumber < 1)
        {
            return 1;
        }

        return localNumber * localFactorial(localNumber - 1);
    }
}
```

## Raising and handling events

Events are often described as **actions that happen to an object**. Another way of thinking about them, is that they provide a way of exchanging messages
between objects.

Events are built on **delegates**.

## Calling methods using delegates

The other way to call or execute a method is to use a **delegate**. 

A delegate contains the memory address of a method that matches the same signature as the delegate, so that it can be called safely with the correct parameter types.

For example, imagine there is a method in the Person class that must have a string type passed as its only parameter, and it returns an int type:

```
public int MethodIWantTocall(string input)
{
    return input.Length;
}
```

Then, we can define a delegate with a matching signature to call the method indirectly. Only the types of parameters and return values must match:

```
delegate int DelegateWithMatchingSignature(string s);
```

Now, we can create an instance of the delegate, point it at the method, and finally, call the delegate (which calls the method):

```
// create a delegate instance that poinsts to the method
DelegateWithMatchingSignature d = new(p1.MethodIWantToCall);

// call the delegate, which calls the method
int answer2 = d("Frog");
```

Delegates provides flexibility.

For example, we could use delegates to create a queue of methods that need to be called in order. Queuing actions that need to be performed is common in
services to provide improved scalability.

Another example is to allow multiple actions to perform in parallel. Delegates have built-in support for asynchronous operations that run on a different thread,
and that can provide improved responsiveness.

The most important example is that delegates allow us to implement events for sendind messages between different objects that do not need to know about each other.

The delegates implement the most important functionality of events: the ability to define a signature for a method that can be implemented by a completely
different piece of code, and then call that method and any others that are hooked up to the delegate field.

## Defining and handling delegates

**GOOD PRACTICE**:

When you want to define an event in your own types, you shoudl use one of these two predefined delegates:

```
public delegate void EventHandler(object? sender, EventArgs e);
public delegate void EventHandler<TEventArgs>(object? sender, TEventArgs e);
```

## Defining and handling events

Delegates are multicast, meaning that you can assign multiple delegates to a single delegate field. Instead of the = assignment, we could have use the
+= operator so we could  add more methods to the same delegate field.
When the delegate is called, all the assigned methods are called, although we have no control over the order in which they are called.

```
public event EventHandler? Shout;

...

harry.Shout += Harry_Shout;
```

## Making types safely reusable with generics

**GOOD PRACTICE**:

When a generic type has one definable type, it should be named **T**, for example, **List<T>**, where **T** is the type stored in the list. 

When a generic type has multiple definable types, they should use **T** as a name prefix and have a sensible name, for example, **Dictionary<TKey, TValue>**.

## Comparing objects when sorting

**GOOD PRACTICE**:

If anyone will want to sort an array or collection if instances of your type, then implement the **IComparable** interface.

## Comparing objects using a separate class

You can create a separate class that implements a slightly different interface, named **IComparer**:

```
public class PersonComparer : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x is null || y is null)
        {
            return 0;   
        }

        // compare the Name lengths..
        int result = x.Name.Length.CompareTo(y.Name.Length);

        // if they are equal..
        if (result == 0)
        {
            // then compare by the Names...
            return x.Name.CompareTo(y.Name);
        }
        else // result will be -1 or 1
        {
            // otherwise compare by the Lengths.
            return result;
        }
    }
}

...

Array.Sort(people, new PersonComparer());

foreach (Person person in people)
{
    WriteLine($"    {person.Name}");
}
```

## Defining interfaces with default implementations

A language feature introduced in C# 8.0 is **default implementations** for an interface.

```
public interface IPlayable
{
    void Play();
    void Pause();
    // default interface implementation
    void Stop()
    {
        WriteLine("Default implementation of Stop.");
    }
}
```

## Defining reference and value types

There are three C# keywords that we can use to define object types: **class**, **record** and **struct**.

One difference between them is how memory is allocated.

When we define a type using **record** or **class**, we are difining a **reference type**. This means that the memory for the object itself is allocated on the
heap, and only the memory address of the object (and a little overhead) is stored on the stack.

When we define a type using **record struct** or **struct**, we are defining a **value type**. This means that the memory for the object itself is allocated
on the stack.

If a **struct** uses field types that are not of the **struct** type, then those fields will be stored on the heap, meaning the data for that object
is stored in both the stack and the heap.

All the allocated memory for a reference type is stored on the heap. If a value type such as **DateTime** is used for afield of a reference type like
**Person**, then the **Datetime** value is stored on the heap.

## Equality of types

When we check the equality of two **value type** variables, .NET literally compares the value of those two variables on the stack and returns true if they are equal:

```
int a = 3;
int b = 3;
WriteLine($"a == b: {(a == b)}");   // true
```

When we check the equality of two **reference type** variables, .NET compares the **memory addresses** of those two variables and returns true if they
are equal:

```
Person a = new() { Name = "Kevin" };
Person b = new() { Name = "Kevin" };
WriteLine($"a == b: {(a == b)}");   // false
```

The one exception to this behavior is the **string** type. It is a reference type, but the equality operators have been overriden to make them
behave as if they were value types:

```
string a = "Kevin";
string b = "Kevin";
WriteLine($"a == b: {(a == b)}");   // true
```

## Defining struct types

