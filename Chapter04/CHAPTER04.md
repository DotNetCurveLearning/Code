# Implementing the tester-doer patern

The tester-doer pattern can avoid some thrown exceptions (but not eliminate them completely). 

This pattern uses pairs of functions: one **to perform a test**, the other **to perform an action** that would fail if the test is not passed.

.NET implements this pattern itself. 

## Problems with the tester-doer pattern

The tester-doer pattern can add performance overhead, so you can also implement the **try pattern**, which in effect combines the test and do parts into a single function, as we saw with TryParse .