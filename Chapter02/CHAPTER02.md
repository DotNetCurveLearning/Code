# Comparing double and decimal types

The double type is not guaranteed to be accurate because some numbers like 0.1 literally cannot be represented as floating-point values.
Commpare them using **greater than** or **less than**, but **never equals**.

**Never compare double values using == .**

The decimal type is accurate because it **stores the number as a large integer and shifts the decimal point**.

# Using target-typed new to instantiate objects

It's another syntax for instantiating objects known as **target-typed new**. When instantiating an object, you can specify the type first and then use new without repeating the type:

```
XmlDocument xml3 = new();
```

**Good Practice**: Use target-typed new to instantiate objects unless you must use a pre-version 9 C# compiler.

# Understanding format strings

A variable or expression can be formatted using a format string after a comma or colon.

**N0**: It means a number with a thousand separators and no decimal places.
**C**: It means currency.

The full syntax of a format item is:
```
{ index [, alignment ] [ : formatString ] }
```

# Getting text input from the user

We can get text input from the user using the **ReadLine** method.

# Getting key input from the user

We can get key input from the user using the **ReadKey** method. This method waits for the user to press a key or key combination that is then returned as a **ConsoleKeyInfo** value.

# Passing arguments to a console app

**TEST**

### What statement can you type in a C# file to discover the compiler and language version?

Put **#error version** (case sensitive) in your code.

### What are the two types of comments in C#?

In C#, there are 3 types of comments:
* Single Line Comments ( // )
* Multi Line Comments ( /* */ )
* XML Comments ( /// )

### What is the difference between a verbatim string and an interpolated string?

The verbatim string is that one where there's no need to escape special characters.
The interpolated string enables us to insert expression values into literal strings.

### How can you determine how many bytes a type like double uses in memory?

Using the **sizeof()** operator.

### Why should you be careful when using the dynamic type?

Because dynamic keyword refers to type late binding, which means **the system will check type only during execution instead of during compilation**.

### How do you right-align a format string?

The alignment (or length) field is the minimum number of characters to be written to the output. If we use **{0,10}**, the output is right-aligned. For left-alignment, we specify a negative length field: **{0,-10}**