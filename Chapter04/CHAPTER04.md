# Implementing the tester-doer patern

The tester-doer pattern can avoid some thrown exceptions (but not eliminate them completely). 

This pattern uses pairs of functions: one **to perform a test**, the other **to perform an action** that would fail if the test is not passed.

.NET implements this pattern itself. 

## Problems with the tester-doer pattern

The tester-doer pattern can add performance overhead, so you can also implement the **try pattern**, which in effect combines the test and do parts into a single function, as we saw with TryParse.

### What are some differences between imperative and functional programming styles?

With an imperative approach, a developer writes code that specifies the steps that the computer must take to accomplish the goal (**algorithmic programming**).
It mainly focuses on describing how the program executes or operates i.e., process.

The functional programming paradigm was explicitly created to support a pure functional approach to problem solving. Functional programming is a form of (**declarative programming**).
It mainly focuses on what programs should be executed or operate i.e., results.

 This type of programming is mainly used when solutions are easily expressed in function and have very little physical meaning.

### Where does the Trace.WriteLine method write its output to?

By default, the output is written to **an instance of DefaultTraceListener**.

### What statement should you use to rethrow a caught exception named ex without losing the stack trace?

throw.