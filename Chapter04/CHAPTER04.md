# Using lambdas in function implementations

Some of the important attributes of functional languages are defined in the following list: 
* **Modularity**: The same benefit of defining functions in C# applies to functional languages. Break up a large complex code base into smaller pieces. 
* **Immutability**: Variables in the C# sense do not exist. Any data value inside a function cannot change. Instead, a new data value can be created from an existing one. This reduces bugs.
* **Maintainability**: Code is cleaner and clearer (for mathematically inclined programmers!).

Since C# 6, Microsoft has worked to add features to the language to support a more functional approach. For example, adding **tuples** and **pattern matching** 
in C# 7, **non-null reference types** in C# 8, and improving pattern matching and adding records, that is, **immutable objects** in C# 9. 

In C# 6, Microsoft added support for **expression-bodied function members**.

```
static int FibFunctional(int term) =>
    term switch {
        1 => 0,
        2 => 1,
        _ => FibFunctional(term -1) + FibFunctional(term - 2)
    };
```

# Instrumenting logging with Debug and Trace

There are two types that can be used to add simple logging to your code: **Debug** and **Trace**:
* The Debug class is used to add logging that gets written only during development. 
* The Trace class is used to add logging that gets written during both development and runtime.

# Switching trace levels

It means to have fine control with the **Trace.WriteLine** calls.

The value of a trace switch can be set using a number or a word. For example, the number 3 can be replaced with the word Info , as shown in the following table:

Number      Word        Description
0           Off         This will output nothing
1           Error       This will output only errors
0           Warning     This will output errors and warnings
0           Info        This will output errors, warnings and information
0           Verbose     This will output all levels