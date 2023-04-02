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

### Comnpressing streams

XML is relatively verbose, so it takes more space in bytes than plain text. We can squeeze the XML using a common compression algorithm knows as GZIP.

### Comnpressing with the Brotli algorithm

In .NET Core 2.1, Microsoft introduced an implementation of the Brotli compression algorithm, which output is 20% denser.

### Encoding and decoding text

Sometimes, we will need to move text outside .NET for use by systems that do not use Unicode or use a variation of Unicode, so it is important to learn how to convert between encodings.

**GOOD PRACTICE**: In most cases today, UTF-8 is a good default, which is why it is literally the default encoding, that is, **Encoding.Default**.

### Encoding and decoding text in files

When using stream helper classes, such as StreamReader and StreamWriter , we can specify the encoding we want to use. As we write to the helper, the text will automatically be encoded, and as you read from the helper, the bytes will be 
automatically decoded. To specify an encoding, pass the encoding as a second parameter to the helper type's constructor, as shown in the following code: 

```
StreamReader reader = new(stream, Encoding.UTF8); 
StreamWriter writer = new(stream, Encoding.UTF8);
```

### Serializing object graphs

**Serialization** is the process of converting a live object into a sequence of bytes using a specified format. **Deserialization** is the reverse process. You would do this to save the current state of a live object so that you can 
recreate it in the future. 
For example, saving the current state of a game so that you can continue at the same place tomorrow. Serialized objects are usually stored in a file or database. There are dozens of formats you can specify, but the two most common ones 
are **eXtensible Markup Language** ( XML ) and **JavaScript Object Notation** ( JSON ).

.NET has multiple classes that will serialize to and from XML and JSON. We will start by looking at **XmlSerializer** and **JsonSerializer**.

#### Serializing as XML

For this, we use **XmlSerializer**.

#### Generating compact XML

We could make the XML more compact using attributes instead of elements for some fields, and decorating some properties with the **[XmlAttribute]** attribute.

Ex.:
```
[XmlAttribute("fname")] 
public string FirstName { get; set; } 

[XmlAttribute("lname")] 
public string LastName { get; set; } 

[XmlAttribute("dob")] 
public DateTime DateOfBirth { get; set; }
```

#### Deserializing XML files

**GOOD PRACTICE**
When using **XmlSerializer**, remember that only the public fields and properties are included, and the 
type must have **a parameterless constructor**. You can customize the output with attributes.

### Serializing with JSON

One of the most popular .NET libraries for working with the JSON serialization format is **Newtonsoft.Json**,
known as Json.NET. It is mature and powerful. 

#### High-performance JSON processing

.NET Core 3.0 introduced a new namespace for working with JSON, **System.Text.Json**, which is optimized 
for performance by leveraging APIs like Span<T>.

With the new API, Microsoft achieved between 1.3x and 5x improvement, depending on the scenario.

#### Controlling JSON processing

There are many options for taking control of how JSON is processed, as shown in the following list: 

* Including and excluding fields. 
* Setting a casing policy.
* Selecting a case-sensitivity policy.
* Choosing between compact and prettified whitespace.

# CHAPTEr 09 - TEST

1. What is the difference between using the File class and the FileInfo class?

**File** is a static type class whereas **FileInfo** is an instance type class. Therefore, to access the members of FileInfo class we need to create an instance, whereas in File class we can directly access its
members without the need to create an instance.

```
//Create a file Using the File class
using FileStream fileCreatedUsingFileClass = File.Create("myFileOne.txt");
           
//Create a file using the FileInfo class
FileInfo fileInfo = new("myFileTwo.txt");
FileStream fileCreatedUsingFileInfoClass = fileInfo.Create();
```

2. What is the difference between the ReadByte method and the Read method of a stream?

The **ReadByte** method and the **Read** method of a stream are used to read data from a stream.

The main difference between the two methods is that **ReadByte** reads a single byte from the stream and returns it as an integer, while **Read** reads a block of bytes from the stream and stores them in an array.

The **ReadByte** method is useful when you need to read individual bytes from a stream. It returns -1 if the end of the stream has been reached. Here's an example of using ReadByte to read a byte from a stream:

```
using (var stream = new FileStream("myfile.bin", FileMode.Open))
{
    int byteRead = stream.ReadByte();
    // do something with the byte
}
```

On the other hand, the **Read** method is used to read a block of bytes from a stream into a buffer. It returns the number of bytes read from the stream. Here's an example of using **Read** to read a block of bytes 
from a stream:

```
using (var stream = new FileStream("myfile.bin", FileMode.Open))
{
    byte[] buffer = new byte[1024];
    int bytesRead = stream.Read(buffer, 0, buffer.Length);
    // do something with the bytes in the buffer
}
```

In summary, use **ReadByte** to read individual bytes from a stream, and use **Read** to read a block of bytes into a buffer.


3. When would you use the StringReader , TextReader , and StreamReader classes?

The **StringReader**, **TextReader**, and **StreamReader** classes are all used to read characters from a stream of data in .NET Framework. However, they have different use cases.

* **StringReader**: This class is used to read characters from a string. You would use StringReader if you have a string that you want to read character by character. For example, if you have a CSV file that you 
  want to parse, you could read the file into a string and then use a StringReader to read the string character by character.

* **TextReader**: This is an abstract class that provides a common interface for reading characters from a stream of data. It can be used to read characters from various sources, such as a file, a network stream, or 
  a string. You would use TextReader when you want to read characters from a stream of data, but you don't know the exact source of the data at design time.

* **StreamReader**: This class is used to read characters from a stream of data, such as a file or a network stream. You would use StreamReader when you know the source of the data is a stream and you want to read 
  characters from it. For example, if you want to read the contents of a text file, you could create a StreamReader and pass it the path to the file, and then use it to read the file character by character.

In summary, use **StringReader** if you have a string that you want to read character by character, use **TextReader** if you want to read characters from a stream of data but don't know the source of the data at 
design time, and use **StreamReader** if you know the source of the data is a stream and you want to read characters from it.


4. What does the DeflateStream type do?

The DeflateStream type is a class in the .NET Framework that provides a way to compress and decompress data using the DEFLATE algorithm.

DEFLATE is a lossless data compression algorithm that is widely used in many applications, including HTTP (via the gzip and deflate Content-Encoding schemes), ZIP file compression, and PNG image compression.


5. How many bytes per character does UTF-8 encoding use?

UTF-8 encoding uses 1 byte per character for characters in the ASCII range (U+0000 to U+007F), and a varying number of bytes per character for characters outside that range.


6. What is an object graph?

An object graph is a collection of objects in a computer program or system, where each object has references to other objects in the graph. The object graph can be thought of as a network of interconnected objects, 
where the connections between objects represent the relationships between them.


7. What is the best serialization format to choose for minimizing space requirements?

JSON serialization format.


8. What is the best serialization format to choose for cross-platform compatibility?

The best serialization format for cross-platform compatibility depends on the specific requirements of your application, including the programming languages and platforms being used, as well as the performance and 
space requirements of your application.

One format that is widely used for cross-platform compatibility is JSON (JavaScript Object Notation). JSON is a text-based format that is supported by many programming languages and platforms, including JavaScript, 
Python, Java, C++, and others. JSON is also human-readable, which makes it easy to work with in many contexts.

Another format that is commonly used for cross-platform compatibility is XML (Extensible Markup Language). XML is a text-based format that is widely supported by many programming languages and platforms, and can be 
used to represent complex data structures. However, XML can be more verbose than other formats like JSON, which can make it less efficient in terms of space.

For applications that require high performance and space efficiency, binary serialization formats like Google's Protocol Buffers or Apache Avro may be a better choice. These formats can be more efficient than 
text-based formats like JSON or XML, and are also supported by many programming languages and platforms.

In summary, the choice of serialization format for cross-platform compatibility depends on the specific requirements of your application, including performance, space efficiency, and the programming languages and 
platforms being used.

# CHAPTER 10 - Working with data using Entity Framework Core


## Using the legacy Entity Framework 6.3 or later

We must add a package reference to it in your project file:

```
<PackageReference Include="EntityFramework" Version="6.4.4" />
```

**GOOD PRACTICE**:

Only use legacy EF6 if you have to, for example, when migrating a WPF app that uses it. Regarding modern cross-platform development, we cover the modern Entity Framework Core. We will not need to reference the legacy 
EF6 package.

## Understanding Entity Framework Core

The truly cross-platform version, EF Core , is different from the legacy Entity Framework. Although EF Core has a similar name, we should be aware of how it varies from EF6. The latest EF Core is version 6.0 to match
.NET 6.0.

As well as traditional RDBMSs, EF Core supports modern cloud-based, nonrelational, schema- less data stores, such as Microsoft Azure Cosmos DB and MongoDB, sometimes with third- party providers.

There are two approaches to working with EF Core: 

1. **Database First**: A database already exists, so you build a model that matches its structure and features. 

2. **Code First**: No database exists, so you build a model and then use EF Core to create a database that matches its structure and features.

## Using a sample relational database (Northwind database)

## Setting up EF Core

### Choosing an EF Core database provider

To manage data in a specific database, we need classes that know how to efficiently talk to that database. EF Core database providers are sets of classes that are optimized for a specific data store. There is even a 
provider for storing the data in the memory of the current process, which can be useful for high-performance unit testing since it avoids hitting an external system. They are distributed as NuGet packages:

**To manage ths data store**            **Install this NuGet package**

Microsoft SQL Server 2012 or later      Microsoft.EntityFrameworkCore.SqlServer
SQLite 3.7 or later                     Microsoft.EntityFrameworkCore.SQLite
MySQL                                   MySQL.Data.EntityFrameworkCore
In-memory                               Microsoft.EntityFrameworkCore.InMemory
Azure Cosmos DB SQL API                 Microsoft.EntityFrameworkCore.Cosmos
Oracle DB 11.2                          Oracle.EntityFrameworkCore

We can install as many EF Core database providers in the same project as you need. Each package includes the shared types as well as provider-specific types.

### Connecting to a database

To connect to an SQLite database, we just need to know the database filename, set using the parameter **Filename**. 

To connect to an SQL Server database, we need to know multiple pieces of information, as shown in the following list: 

* The name of the server (and the instance if it has one). 
* The name of the database. 
* Security information, such as username and password, or if we should pass the currently logged-on user's credentials automatically. 

We specify this information in a **connection string **.

For backward compatibility, there are multiple possible keywords we can use in an SQL Server connection string for the various parameters, as shown in the following list:

* **Data Source** or **server** or **addr**: These keywords are the name of the server (and an optional instance). You can use a dot . to mean the local server. 

* **Initial Catalog** or **database**: These keywords are the name of the database. 

* **Integrated Security** or **trusted_connection**: These keywords are set to true or SSPI to pass the thread's current user credentials. 

* **MultipleActiveResultSets**: This keyword is set to true to enable a single connection to be used to work with multiple tables simultaneously to improve efficiency. It is used for lazy loading rows 
from related tables.

**SQL Server edition**              **Server name\Instance name**

LocalDB 2012                        (localdb)\v11.0
LocalDB 2016 or later               (localdb)\mssqllocaldb
Express                             .\sqlexpress
Full/Developer (default instance)   .
Full/Developer (named instance)     .\cs10dotnet6

**GOOD PRACTICE**:

Use a dot . as shorthand for the local computer name. Remember that server names for SQL Server are made of two parts: the name of the computer and the name of an SQL Server instance. We provide instance names 
during custom installation.

### Defining the Northwind database context class

It will be used to represent the database. To use EF Core, the class must inherit from DbContext . This class understands how to communicate with databases and dynamically generate SQL statements to query and 
manipulate data.

The DbContext-derived class should have an overridden method named OnConfiguring , which will set the database connection string.

## Defining EF core models

EF Core uses a combination of **conventions**, **annotation attributes**, and **Fluent API** statements to build an entity model at runtime so that any actions performed on the classes can later be automatically 
translated into actions performed on the actual database. 

An **entity class** represents the **structure of a table** and an instance of the class represents a row in that table.

### Using EF Core conventions to define the model

* The name of a table is assumed to match the name of a **DbSet<T>** property in the DbContext class, for example, Products. 

* The names of the columns are assumed to match the names of properties in the entity model class, for example, ProductId . 

* The string .NET type is assumed to be a **nvarchar** type in the database. 

* The int .NET type is assumed to be an int type in the database. 

* The primary key is assumed to be a property that is named **Id** or **ID**, or when the entity model class is named Product, then the property can be named ProductId or ProductID. 
  If this property is an integer type or the Guid type, then it is also assumed to be an **IDENTITY column** (a column type that automatically assigns a value when inserting).

### Using EF Core annotation attributes to define the model

A simple way of adding more smarts besides the conventions to our models is to apply annotation attributes. Some common attributes are:

**Attribute**                                       **Description**

[Required]                                          Ensures the value is not null.
[StringLength(50                                    Ensures the value is up to 50 characters in length.
[RegularExpression(expression)]                     Ensures the value matches the specified regular expression.
[Column(TypeName = "money", Name = "UnitPrice")]    Specifies the column type and column name used in the table.

When there isn't an obvious map between .NET types and database types, an attribute can be used.

For example, in the database, the column type of UnitPrice for the Products table is money . 
.NET does not have a money type, so it should use decimal instead, as shown in the following code:

```
[Column(TypeName = "money")] 
public decimal? UnitPrice { get; set; }
```

For columns in the table that can be longer than the maximum 8 000 characters, it need to be mapped to ntext instead of nvchar:

```
[Column(TypeName = "ntext")] 
public string Description { get; set; }
```

### Using the EF Core Fluent API to define the model

This API can be used instead of attributes, as well as being used in addition to them. For example, to define the ProductName property, instead of decorating the property with two attributes, an equivalent Fluent API
statement could be written in the OnModelCreating method of the database context class, as shown in the following code:

```
modelBuilder.Entity<Product>() 
    .Property(product => product.ProductName) 
    .IsRequired() 
    .HasMaxLength(40);
```

This keeps the entity model class simpler.

#### Understanding data seeding with the Fluent API

Another benefit of the Fluent API is to provide initial data to populate a database. EF Core automatically works out what insert, update, or delete operations must be executed. 

For example, if we wanted to make sure that a new database has at least one row in the Product table, then we would call the **HasData** method, as shown in the following code: 

```
modelBuilder.Entity<Product>() 
    .HasData(new Product 
    { 
        ProductId = 1, 
        ProductName = "Chai", 
        UnitPrice = 8.99M 
    }); 
```

Our model will map to an existing database that is already populated with data so we will not need to use this technique in our code.

**Columns that are not mapped to properties cannot be read or set using the class instances**. 

If we use the class to create a new object, then the new row in the table will have NULL or some other default value for the unmapped column values in that row. We must make sure that those missing columns **are 
optional or have default values set by the database or an exception will be thrown at runtime**. In this scenario, the rows already have data values and I have decided that I do not need to read those values in this 
application.

We can rename a column by defining a property with a different name, like Cost, and then decorating the property with the [Column] attribute and specifying its column name, like UnitPrice.

#### Adding tables to the Northwind database context class

Inside your DbContext -derived class, we must define at least one property of the **DbSet<T>** type. These properties represent the tables. 

The DbContext-derived class can optionally have an overridden method named OnModelCreating. This is where we can write Fluent API statements as an alternative to decorating your entity classes with attributes.

#### Setting up the dotnet-ef tool

It can be extended with capabilities useful for working with EF Core. It can perform design-time tasks like creating and applying migrations from an older model to a newer model and generating code for a model from 
an existing database.

``
dotnet tool list --global

dotnet tool install --global dotnet-ef --version 6.0.0
``

#### Scaffolding models using an existing database

To add the Microsoft.EntityFrameworkCore.Design package to the project.

Scaffolding is the process of using a tool to create classes that represent the model of an existing database using reverse engineering. A good scaffolding tool allows you to extend the automatically generated 
classes and then regenerate those classes without losing your extended classes. 

If we know that we will never regenerate the classes using the tool, then feel free to change the code for the automatically generated classes as much as you want. The code generated by the tool is just the best 
approximation.

Exmaple:

```
dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite 
--table Categories --table Products --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGen 
--data-annotations --context Northwind
```

* The command action: **dbcontext scaffold**
* The connection string: **"Filename=Northwind.db"**
* The database provider: **Microsoft.EntityFrameworkCore.Sqlite**
* The tables to generate models for: **--table Categories --table Products**
* The output folder: **--output-dir AutoGenModels**
* The namespace: **--namespace WorkingWithEFCore.AutoGen**
* The use data annotations as well as the Fuent API: **--data-annotations**
* The rename the context from [database_name]Context: **--context Northwind**

For SQL Server, change the database provider and connection string as this:

```
dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Northwind;Integrated Security=true;" Microsoft. EntityFrameworkCore.SqlServer --table Categories --table Products --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGen --data-annotations --context Northwind
```

The entity classes generated willhave the following characteristics:

* IT decorated the entity class with the [Index] attribute. This indicates properties that should have an index. Working with an existing database, this is not needed. But if we want to recreate a new empty database
  from our code, then this information will be needed.

* The table name in the database is **Categories** but the dotnet-ef tool uses the **Humanizer** third-part library to automatically singularize the class name to **Category**, which is a more natural name when
  creating a single entity.   
  
* The entity class is declared using the **partial** keywordd so that we can create a matching **partial** class for adding additional code. This allows us to rerun the tool and regenerate the entity class without
  loosing that extra code.

* The **CategoryId** property is decorated with the **[Key]** attribute to indicate that it is the primary key for this entity. The data type for this property is int for SQL Server and long for SQLite.

* The Products property uses the **[InverseProperty]** attribute to define the foreigmn key relationship to the Category property on the Product entity class.


In the **Northwind** class instead note the following:

* It is partial to allow you to extend it and regenerate it in the future.

* It has two constructors: a default parameter-less one and one that allows options to be passed in. This is useful in apps where you want to specify the connection string at runtime.

* The two **DbSet<T>** properties that represent the Categories and Products tables are set to the null -forgiving value to prevent static compiler analysis warnings at compile time. It has no effect at runtime.

* In the OnConfiguring method, if options have not been specified in the constructor, then it defaults to using a connection string that looks for the database file in the current folder. It has a compiler warning to 
  remind you that you should not hardcode security information in this connection string.

* In the OnModelCreating method, the Fluent API is used to configure the two entity classes, and then a partial method named OnModelCreatingPartial is invoked. This allows you to implement that partial method in your 
  own partial Northwind class to add your own Fluent API configuration that will not be lost if you regenerate the model classes.

#### Configuring preconvention models

As models become more complex, relying on conventions to discover entity types and their properties and successfully map them to tables and columns becomes harder. It would be useful if you could configure the 
conventions themselves before they are used to analyze and build a model.

#### Querying EF Core models

We can write some simple LINQ queries to fetch data. 

```
static void QueryingCategories()
{
	// Creating an instance of the Northwind class that will manage the database.
	// Database context instances are desifgned for short lifetimes in a unit of work.
	// They should be disposable asap.
	using (Northwind db = new())
	{
		WriteLine("Categories and how many products they have:");

		// a query to get all categories and their related products
		IQueryable<Category>? categories = db.Categories?.Include(category => category.Products);

		if (categories is null)
		{
			WriteLine("No categories found.");
			return;
		}

		// execute query and enumerate results, outputting the name and number
		// of products for each one
		foreach (Category category in categories)
		{
			WriteLine($"{category.CategoryName} has {category.Products.Count} products.");
		}
	}
}
```

**IMPORTANT**:

If we run with Visual Studio Code using the SQLite database provider, then the path will be the WorkingWithEFCore folder. If we run using the SQL Server database provider, then there is no database file path output.

**WARNING!** 

If we see the following exception when using SQLite with Visual Studio 2022, the most likely problem is that the Northwind.db file is not being copied to the output directory. Make sure Copy to Output Directory is 
set to **Copy always**: 

**Unhandled exception. Microsoft.Data.Sqlite.SqliteException (0x80004005): SQLite Error 1: 'no such table: Categories'**

#### Filtering included entities

EF Core 5.0 introduced **filtered includes**, which means you can specify a lambda expression in the Include method call to filter which entities are returned in the results.

```
static void FilteredIncludes()
{
	// creating an instance of the Northwind class that will manage the database
	using (Northwind database = new())
	{
		// prompt the user to enter a minimum value for units in stock
		Write("Enter a minumum for units in stock: ");
		string unitsInStock = ReadLine() ?? "10";
		int stock = int.Parse(unitsInStock);	

		// creating a query for categories that have products with that minimum
		// number of units in stock
		IQueryable<Category>? categories = database.Categories?
			.Include(category => category.Products.Where(product => product.Stock >= stock));

        // outputting the name and units in stock for each one
        if (categories is null)
        {
            WriteLine("No categories found.");
            return;
        }

        foreach (Category category in categories)
		{
            WriteLine($"{category.CategoryName} has {category.Products.Count} products with a minimum of {stock} units in stock.");

			foreach (Product product in category.Products)
			{
				WriteLine($"	{product.ProductName} has {product.Stock} units in stock.");
			}

			WriteLine();
        }
	}
}
```

#### Filtering and sorting products

```
static void QueryingProducts()
{
	using(Northwind database = new())
	{
		WriteLine("Products that cost more than a price, highest at top");
		string? input;
		decimal price;

		// prompt the user for a price for prodcuts, and loop until the 
		// input is a valid value
		do
		{
			Write("Enter a product price: ");
			input = ReadLine();
		} while (!decimal.TryParse(input, out price));

		IQueryable<Product>? products = database.Products?
			.Where(product => product.Cost > price)
			.OrderByDescending(product => product.Cost);

        if (products is null)
        {
            WriteLine("No products found.");
            return;
        }

        foreach (Product product in products)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00} and has {3} in stock.", 
				product.ProductId, 
				product.ProductName, 
				product.Cost, 
				product.Stock);
        }
    }
}
```

### Getting the generated SQL

```
WriteLine($"ToQueryString: {categories.ToQueryString()}");
```

#### Logging EF Core using a custom logging provider

To monitor the interaction between EF Core and the database, we can enable logging. This requires the following two tasks: 

* The registering of a **logging provider**. 
* The implementation of a **logger**. 

The class that will implement **ILoggerProvider** interface returns an instance of **ConsoleLogger**:

```
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            // we could have a different logger implementation for
            // different categoryName values
            return new ConsoleLogger();
        }

        /// <summary>
        /// If our logger uses unmanaged resources,
        /// then we can release them here
        /// </summary>        
        public void Dispose()
        { }
    }
```

The class that implements the **ILoggerr** interface (in our case, ConsoleLogger), is disabled for log levels None, Trace and Information. Iit is enabled for all other log levels.

```
public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// If our Logger uses unmanaged resources, we can
        /// return the class that implements IDisposable here
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="state"></param>
        /// <returns></returns>        
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // to avoid overloading, we can filter on the log level
            return logLevel switch
            {
                _ when logLevel == LogLevel.Trace || 
                       logLevel == LogLevel.Information || 
                       logLevel == LogLevel.None => false,
                _ when logLevel == LogLevel.Debug || 
                        logLevel == LogLevel.Warning || 
                        logLevel == LogLevel.Error || 
                        logLevel == LogLevel.Critical => true,
                _ => true
            };
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            // log the level and event identifier
            Write($"Level: {logLevel}, Event Id: {eventId.Id}");

            // only output the state or exception if it exists
            if (state != null)
            {
                Write($", State: {state}");
            }

            if (exception != null)
            {
                Write($", Exception: {exception.Message}");
            }

            WriteLine();
        }
    }
```

The, inside the class that wull uses the logger, we have first to get the logging factory and register our custom logger:

```
ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
		loggerFactory.AddProvider(new ConsoleLoggerProvider());
```

#### Filtering logs by provider-specific values

The event id values and what they mean will be specific to the .NET data provider. If we want to know how the LINQ query has been translated into SQL statements and is executing, then the event Id to output has an Id 
value of **20100 **.

We need to modify the **Log** method of the class that implements the ILogger interface for that:

```
if (eventId.Id == 20100)
            {
                // log the level and event identifier
                Write($"Level: {logLevel}, Event Id: {eventId.Id}");

                // only output the state or exception if it exists
                if (state != null)
                {
                    Write($", State: {state}");
                }

                if (exception != null)
                {
                    Write($", Exception: {exception.Message}");
                }
                
```

#### Logging with query tags

EF Core 2.2 introduced the query tags feature to help by allowing you to add SQL comments to the log. You can annotate a LINQ query using the **TagWith** method:

```
		IQueryable<Product>? products = database.Products?
			.TagWith("Products filtered by price and sorted.")
			.Where(product => product.Cost > price)
			.OrderByDescending(product => product.Cost);
```

### Pattern matching with Like

EF Core supports common SQL statements including Like for pattern matching.

```
IQueryable<Product>? products = database.Products?
			.Where(product => EF.Functions.Like(product.ProductName, $"%{input}%"));
```

### Defining global filters

Sometimes it could be useful to ensure that values that meet certain conditions are never returned in the results, even if the
programmer does not use **Where** to filter them out in their queries.

For this, we can add a global filter in the **OnModelCreating** method. For instance:

```
modelBuilder.Entity<Product>()
          .HasQueryFilter(p => !p.Discontinued);
```

## Loading patterns with EF Core

There are three loading patterns that are commonly used with EF Core: 

* **Eager loading**: Load data early. 

* **Lazy loading**: Load data automatically just before it is needed. 

* **Explicit loading**: Load data manually.

### Eager loading entities

In our example, we enabled eager loading by calling the **Include** method for the related products.

Modifying the query to comment out the Include method call:

```
IQueryable<Category>? categories = 
    db.Categories; //.Include(c => c.Products);
```

The output won't display the products count for each category, since tghe original query is only selected from the Categories
table, the Products property ( list od products in each category) will be empty. 

### Enabling lazy loading

Lazy loading was introduced in EF Core 2.1, and **it can automatically load missing related data**. To enable lazy loading, 
developers must: 

* Reference a NuGet package for proxies (Microsoft.EntityFrameworkCore.Proxies NuGet package). 
* Configure lazy loading to use a proxy.

Now, the product lists will be loaded but the problem with lazy loading is that multiple round trips to the database server are 
required to eventually fetch all the data.

### Explicit loading entities

It works in a similar way to lazy loading, with the difference being that you are in control of exactly what related data is loaded.