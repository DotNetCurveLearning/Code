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