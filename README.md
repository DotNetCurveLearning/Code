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

## Releasing unmanaged resources

There is a standadr mechanism for doing this by implementing the **IDisposable** interface:

```
public class Animal : IDisposable
{
    public Animal()
    {
        // allocate unmanaged resource
    }

    ~Animal() // Finalizer
    {
        Dispose(false);
    }

    bool disposed = false; // have resources been released?

    public void Dispose()
    {
        Dispose(true);

        // tell garbage collector it does not need to call the finalizer
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if(disposed) return;

        // deallocate the unmanaged resource
        // ...

        if(disposing)
        {
            // deallocate any other managed resources
            // ...
        }
        disposed = true;
    }
}
```

There are two **Dispose** methods, one public and one protected:

* The public void Dispose method will be called by a developer using your type. When called, both unmanaged and managed resources need to be deallocated.

* The protected virtual void Dispose method with a bool parameter is used internally to implement the deallocation of resources. It need to check the
disposing parameter and disposed field because if the finalizer thread has already run and it called the ~Animal method, then only unmanaged resources
need to be deallocated.

## Ensuring that Dispose is called

When someone uses a type that implements IDisposable, they can ensure that the public Dispose method is called with the **using** statement:

```
using (Animal a = new())
{
    // code that uses the Animal instance
}
```

The compiler converts your code into something like the following, which guarantees that even if an exception occurs, the Dispose method will still be called>

```
Animal a ) new*(<

try
{
    // code that uses the Animal instance
}
finally
{
    if (a != null) a.Dispose();
}
```

# Working with null values

C# has the concepto of a **null** value, which can be used to indicate that a variable has not been set.

## Making a value type nullable

Sometimes, for example, when reading values stored in a database that allows empty, missing, or null values, it is convenient to allow a value type to
be null. we call this a **nullable value type**.

We can enable this by adding a question mark (?) as a suffix to the type when declaring a variable.

```
int thisCannotBeNulll = 4;
// thisCannotBeNulll = null;   // compile error!

int? thisCouldBeNulll = null;
WriteLine(thisCouldBeNulll);
WriteLine(thisCouldBeNulll.GetValueOrDefault());

thisCouldBeNulll = 7;
WriteLine(thisCouldBeNulll);
WriteLine(thisCouldBeNulll.GetValueOrDefault());
```

## Understading nullable reference types

There are many scenarios where we could write better, simpler code if a variable is not allowed to have a null value.

Even if reference types are already nullable, in C# 8 and later, reference types can be configured to no longer allow the null value by setting a file- or
project-lvel option to enable this useful new feature.

We can choose between several approaches for our projects:

* **Default**: No changes are needed. Non-nullable reference types are not supported.

* **Opt-in project, opt-out files**: Enable the feature at the project level and, for any files that need to remain compatible with old behavior,
opt out. This is the approach Microsoft is using internally while it updates its own packages to use this new feature.

```
<PropertyGroup>
    ...
    <Nullable>enable</Nullable>
</PropertyGroup>
```

* **Opt-in files**: Only enable the feature for individual files.

To disable the feature at the file level, add the following to the top of a code file:

```
#nullable disable
```

For the ooposite:

```
#nullable enable
```

## Checming for null

It's important becuase if we not, a NulReferenceException can be thrown, which results in an error:

```
// check that the variable is not null before using it
if (thisCouldBeNull != null)
{
    // access a member of thisCouldBeNull
    int length = thisCouldBeNull.Length;    // could throw exception
    ...
}
```

If we are trying to use a member of a variable that might be null, we must use the null-conditional operator ?:

```
string authorName = null;

// the following throws a NullReferenceException
int x = authorName.Length;

// instead of throwing an exception, null is assigned to y
int? y = authorName?.Length;
```

Sometimes we want either assign a variable to a result or use an alternative value, such as 3, if the variable is null. We do this using the
**null-coalescing** operator (??):

```
// result will be 3 if authorName?.Length is null
int  result = authorName?.Length ?? 3;
Cosnole.WriteLine(result);
```

**GOOD PRACTICE**: Even if we enable nullable reference types, we should still check non-nullable parameters for null and throw an ArgumentNullException.

## Understanding polymorphism

**GOOD PRACTICE**: You should use virtual and override rather than new to change the implementation of an inherited method whenever possible.

# Avoiding casting exceptions

The better way is to check the type of an object using the **is** keyword:

```
if (aliceInPerson is Employee)
{
    WriteLine($"{nameof(aliceInPerson)} IS an Employee");
    Employee explicitAlice = (Employee)aliceInPerson;

    // safely do something with explicitAlice
}
```

We can simplify the code further using a declaration pattern and this will avoid needing to perform an **explicit cast**:

```
if (aliceInPerson is Employee explicitAlice)
{
    WriteLine($"{nameof(aliceInPerson)} IS an Employee");

    // safely do something with explicitAlice
}
```

Alternatively, we can use the **as** keyword to cast. Instead of throwing an exception, the **as** keyword returns null if the type cannot be cast.

```
Employee? aliceAsEmployee = aliceInPerson as Employee; // could be null

if (aliceAsEmployee != null)
{
    WriteLine($"{nameof(aliceInPerson)} AS an Employee");

    // safely do something with explicitAlice
}
```

**GOOD PRACTICE**: Use the **is** and **as** keywords to avoid throwing exceptions when casting between derived types. If we don't do this,  we must
write **try*catch** statements for **InvalidCastException**.

## Inheriting exceptions

Unlike ordinary methods, **constructor are not inherited**, so we must explicitly declarre and explicitly call the base constructor implementation in
**System.Exception** to make them available to programmers who might want to use those constructors with out custom exception.

# Extending types when you can't inherit

We can do it, using a language feature named **extension methods**, which was introduced with C# 3.0.

## Using static methods to reuse functionality

```
public class StringExtensions
{
    public static bool IsValidEmail(string input)
    {
        // use simple regular expression to check
        // that the input string is a valid email
        return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
    }
}
```

## Using extension methods to reuse functionality

It's easy to make **static** methods into extension methods:

1. To add the **static** modifier before the **class** keyword, and adding the **this** modifier before the **string** type:
```
public static class StringExtensions
{
    public static bool IsValidEmail(this string input)
    {
    }
}
```

These two changes tells the compiler that it should treat the method as one that extends the **string** type.

In this wat, the **IsvalidEmail** extension method appears to be a method just like all the actual instance methods of the **string** type, such as
**IsNormalized** and **Insert**.

**GOOD PRACTICE**: Extension methods cannot replace or override existing instance methods. An instance method will be called in preference to an extension
method with the same name and signature.

# QUZ

1. What is a delegate?

**It's a type that represents references to methods with a particular parameter list and return type**. When we instantiate a delegate, we can
associate its instance with any method with a compatible signature and return type. We can invoke (or vall) the method through the delegate instance.

2. What is an event?

Events **enable a class or object to notify other classes or objects when something of interest occurs**. The class that sends (or raises) the event is
called the **publisher** and the classes that receive (or handle) the events are called **subscribers**.

4. What is the difference between is and as operators?

The **is** operator is used to check if the run-time type of an object is compatible with the given type or not, whereas the **as** operator is used
to perform conversion between compatible types or nullable types.

# Chapter 07

## Sharing code with legacy platforms using .NET Standard

**GOOD PRACTICE**: Since many of the API additions in .NET Standard 2.1 required runtime changes, and .NET Framework is Microsoft's legacy platform that
needs to remain as unchanging as possible, .NET Framework 4.8 remained on .NET Standard 2.0 rather than implementing .NET Standard 2.1.
If you need to support .NET Framework customers, then you should create class libraries on .NET Standard 2.0 even though it is not the latest and does
not support all the recent language and BCL new features.

## Publishing your code for deployment

There are three wways to publish and deploy a .NET application:

1. **Framework-dependent deploymwent (FDD)**.
2. **Framework-dependent executables (FDEs)**.
3. Self-contained.

**Framework-dependent deploymwent (FDD)** means we deploy a DLL that must be executed by the **dotnet** command-line tool.

**Framework-dependent executables (FDEs)** means we deploy an EXE that can be run directly from the command line.

Both require a .NET to be alreay installed on the system.

Sometimes we want to be able to give someone a USB stick containing the application and know that it can be executed on their computer. We want to
perform a self-contained deployment. While the size of the deployment files will be larger, we'll know that it will work.

## Creating a console application to publish

Open the .csproj file and add the runtime identifiers to target the operating systems wanted inside the **<PropertyGroup>** element:

```
<PropertyGroup>
    ...
    <RuntimeIdentifiers>
        win10-x64;osx-x64;osx.11.0-arm64;linux-x64;linux-arm64
    </RuntimeIdentifiers>
</PropertyGroup>
```

## Publishing a self-contained app

The following command will build and publish the release version of the console application for Windows 10:

```
dotnet publish -c Release -r win10-x64
```

## Publishing a single-file app

For this, we can specify flags when publishing. With .NET 6, we can now create proper single-file apps on Windows. If we assume that .NET 6 is alreadt installed
on the computer on which we want to run the app, then we can use the extra flags when we publish the app for release to say that it does not need to be
self-contained and that we want to publish it as a single-file (if possible):

```
dotnet publish -r win10-x64 -c Release --self-contained=false /p:PublishSingleFile=true
```

## Reducing the size of apps using app trimming

We can reduce this size by not packaging unused assemblies with our deployments. Introduced with .NET Core 3.0, the app trimming system can identify the
assembiels needed by our code and remove those that are not needed.

With .NET 5, the trimming went further by removing individual types, and even members like methods from within an assembly if they are not used.

With .NET 6, Microsoft added annotations to their libraries to indicate how they can be safley trimmed so the trimming of types and members was made the
default. This is know as **link trim mode**.

### Enabling assembly-level trimming

There are two ways:

1. To add an element in the project file:

```
<PublishTrimmed>true</PublishTrimmed>
```

2. To add a flag when publishing:

```
dotnet publish ... -p:PublishTrimmed=True
```

### Enabling type-level and member-level trimming

There are two ways:

1. To add two elements in the project file:

```
<PublishTrimmed>true</PublishTrimmed>
<TrimMode>Link</TrimMode>
```

2. To add two flags when publishing:

```
dotnet publish ... -p:PublishTrimmed=True -p:TrimMode=Link
```

For .NET 6, link trim is the default, so we only need to specify the switch if we ant to set an alternative trim mode like **copyused**, which means
assembly-level trimming.

# EXERCISES

1. What is the difference between a namespace and an assembly?

A **namespace** is a logical group of related classes that can be used by the languages targeted by Microsoft .NET Framework.

An **assembly** is a building block of .NET Framework applications that form the fundamental unit of deployment, version control, reuse, activation scoping,
and security permissions.

8. What is the difference between the dotnet pack and dotnet publish commands?

**dotnet pack**: The output is a package that is mean to be reused by other projects.

**dotnet publish**: The output is mean to be deployed/""shipped" - it is not a single "package file" but a directory with all the project's output.

# Chapter 09 - Working with files, streams and serialization

## Handling cross-platform environments and filesystems

**GOOD PRACTICE**:
Windows usws a backslash \ for the directory separator character. macOS and Linux use a forward slash / for the directory separator character. **Do not assume what character is used in your code when combining paths**.

## Managing drives

T omanage drives, use the **DriverInfo** type, which has a static method that returns information about all the drives connected to the computer. Each driver has a drive type.

**GOOD PRACTICE**:
Check that a drive is ready before reading properties such as **TotalSize** or you will see an exception thrown with removable drives.

## Managing directories

To manage directories, use the **Directory**, **Path** and **Environment** static classes. These types include many members for working with the filesystem.

When constructing custom paths, we must be careful to write the code so that it makes no assumptions about the platform, for example, what to use for the directory separator character.

## Managing paths

We can do this with static methods of the **Path** class, to work with parts of a path; for example, you might want to extract just the folder name, the filename, or the extension.

**GetTempFileName** creates a zero-byte file and returns its name, ready for you to use. **GetRandomFileName** just returns a filename; it doesn't create the file.

## Getting file information

To get more information about a file or directory, for example, its size or when it was last accessed, you can create an instance of the **FileInfo** or **DirectoryInfo** class.

FileInfo and DirectoryInfo both inherit from **FileSystemInfo**, so they both have members such as LastAccessTime and Delete, as well as extra members specific to themselves.

## Controlling how we work with files

We often need to control how they are opened. The **File.Open** method has overloads to specify additional options using enum values.

The enum types are as follows:

* **FileMode**: This controls what you want to do with the file, like *CreateNew*, *OpenOrCreate*, or *Truncate* .

* **FileAccess**: This controls what level of access you need, like *ReadWrite*.

* **FileShare**: This controls locks on the file to allow other processes the specified level of access, like *Read*.

```
FileStream file = File.Open(pathToFile, FileMode.Open, FileAccess.Read, FileShare.Read);
```

There is also an enum for attributes of a file as follows:

* **FileAttributes**: This is to check a FileSystemInfo -derived types' Attributes property for values like *Archive* and *Encrypted*.

We could check a file or directory's attributes, as shown in the following code:
```
FileInfo info = new(backupFile);
WriteLine("Is the backup file compressed? {0}", info.Attributes.HasFlag(FileAttributes.Compressed));
```

## Reading and writing with streams

A stream is a sequence of bytes that can be read from and written to. It can be useful to process files as a stream in which the bytes can be accessed in sequential order.

### Understanding abstract and concrete streams

There is an abstract class named **Stream **that represents any type of stream. Remember that an abstract class cannot be instantiated using new; they can only be inherited.

There are many concrete classes that inherit from this base class, including **FileStream**, **MemoryStream**, **BufferedStream**, **GZipStream**, and **SslStream**, so they all work the same way. All streams implement **IDisposable**, so they have a Dispose method to release unmanaged resources.

### Understanding storage streams

Some storage streams that represent a location where the bytes will be stored are described in the following table:

**Namespace**           **Class**       **Description**
System.IO               FileStream      Bytes stored in the filesystem.
System.IO               MemoryStream    Bytes stored in memory in the current process.
System.Net.Sockets      NetworkStream   Bytes stored at a network location.

### Understanding stream helpers

All the helper types for streams implement IDisposable , so they have a Dispose method to release unmanaged resources:

**StreamReader**: This reads from the underlying stream as plain text.
**StreamWriter**: This writes to the underlying stream as plain text.
**BinaryReader**: This reads from streams as .NET types.
**BinaryWriter**: This writes to streams as .NET types.
**XmlReader**: This reads from the underlying stream using XML format.
**XmlWriter**: This writes to the underlying stream using XML format.

### Writing to XML streams

There are two ways to write an XML element, as follows:

* **WriteStartElement** and **WriteEndElement**: Use this pair when an element might have child elements.

* **WriteElementString**: Use this when an element does not have children.

### Simplifying disposal by using the using statement

We can simplify the code that needs to check for a null object and then call its Dispose method by using the using statement. Generally, is recommended to use using rather than manually calling Dispose unless you need a greater level of control.

The compiler changes a using statement block into a try - finally statement without a catch statement. You can use nested try statements; so, if you do want to catch any exceptions, you can, as shown in the following code example:

```
using (FileStream file2 = File.OpenWrite(
    Path.Combine(path, "file2.txt")))
{
    using (StreamWriter writer2 = new StreamWriter(file2))
    {
        try
        {
            writer2.WriteLine("Welcome, .NET!");
        }
        catch(Exception ex)
        {
            WriteLine($"{ex.GetType()} says {ex.Message}");
        }
    } // automatically calls Dispose if the object is not null
} // automatically calls Dispose if the object is not null
```