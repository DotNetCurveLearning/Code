## Exploring logical operators

For the **XOR** ^ logical operator, either operand can be true (but not both!) for the result to be true.

## Bitwise operators

**&**: Binary AND Operator copies a bit to the result if **it exists in both operands**.
**|**: Binary OR Operator copies a bit if **it exists in either operands**.
**^**: Binary XOR Operator copies the bit if **it is set in one operand but not both**.  If the corresponding bits are **same**, the result is 0. If the corresponding bits **are different**, the result is 1
**<<**: Binary Left Shift Operator. It shifts a number to the left by a specified number of bits. Zeroes are added to the least significant bits. In decimal, it is equivalent to **num * 2bits**.
**>>**: Binary Right Shift Operator. It shifts a number to the right by a specified number of bits. The first operand is shifted to right by the number of bits specified by second operand. In decimal, it is equivalent to **floor(num / 2bits)**.

## Pattern matching with the if statement

A feature introduced with C# 7.0 and later is **pattern matching**. The if statement can use the **is** keyword in combination with declaring a local variable to make your code safer.

```
object o = 3;
int j = 4;

if (o is int i)
{
    WriteLine($"{i} x {j} = {i * j}");
}
else
{
    WriteLine("o is not an int so it cannot multiply!");
}
```
## Pattern matching with the switch statement

In C# 7.0 and later. The case values no longer need to be literal values; they can be patterns. Additionally, case statements can include a **when** keyword to perform more specific pattern matching. In the first case statement in the preceding code, s will only be a match if the stream is a FileStream and its CanWrite property is true .

In C# 8.0 or later, you can simplify switch statements using **switch expressions**.
```

```