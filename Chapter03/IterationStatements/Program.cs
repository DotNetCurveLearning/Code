using System;
using static System.Console;
using static System.Convert;

// ------- while loop (the boolean expression is checked at the top of the block)
/* int x = 0;

while (x < 10)
{
    WriteLine(x);
    x++;
} */

// ------- do while loop (the boolean expression is checked at the bottom of the block)
/* string? password;
int attemptsCount = 0;

do
{
    Write("Enter your password: ");
    password = ReadLine();
    attemptsCount++;
} while (password != "Pa$$w0rd" && attemptsCount < 10);

WriteLine(attemptsCount == 10 ? "Number of attempts equals 10" : "Correct!"); */

// ------- Looping with the foreach statement
//string [] names = {"Adam", "Barry", "Charlie"};

//foreach (string name in names)
//{
//    WriteLine($"{name} has {name.Length} characters.");
//}

// ------ Converting with the System.Convert type
//double g = 9.8;
//int h = ToInt32( g );
//WriteLine($"g is {g} and h is {h}");

//// ------ Default rounding rules
//double[] doubles = new[] { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };

//foreach (double n in doubles)
//{
//    WriteLine($"ToInt32{n} is {ToInt32(n)}");
//}

//// ----- Taking control of rounding rules (using the Round() method of the Math class)
//foreach (double n in doubles)
//{
//    WriteLine(
//        format: "Math.Round{0}, 0, MidpointRounding.AwayFromZero) is {1}",
//        arg0: n,
//        arg1: Math.Round(value: n, digits: 0,
//        mode: MidpointRounding.AwayFromZero));
//}

//// ----- Converting from any type to string
//int number = 12;
//WriteLine(number.ToString());

//bool boolean = true;
//WriteLine(boolean.ToString());

//DateTime now = DateTime.Now;
//WriteLine(now.ToString());

//object me = new();
//WriteLine(me.ToString());

// ----- Converting from a binary object to string
// The safest thing to do is to convert the binary object into a string of safe characters (Base64 encoding).
// The Convert type has a pair of methods, ToBase64String and FromVase64String, that perform this conversion for us.

// allocate array of 128 bytes
//byte[] binaryObject = new byte[128];

//// populate array with random bytes
//(new Random()).NextBytes(binaryObject);

//WriteLine("Binary Object as bytes:");

//for (int index = 0; index < binaryObject.Length; index++)
//{
//    Write($"{binaryObject[index]:X}");
//}
//WriteLine();

//// convert to Base64 string and output as text
//string encoded = ToBase64String( binaryObject );

//WriteLine($"Binary Object as Base64: {encoded}");

// ----- Parsing from strings to numbers or dates and times
// The opposite of ToString is Parse. Only a few types have a Parse method, including all the number types and DateTime.
// String format codes:
/*
C (Currency) - A currency value.
D (Decimal): Integer digists with optional negative sign.
E (Exponential): Exponential notation.
F (Fixed-point): Integral and decimal digits with optional negative sign.
G (General): The more compact of either fixed-poin or scientific notation.
N (Number): Integral and decimal digits, group separators, and a decimal separator with optional negativer sign.
P (Percentage): Number multiplied by 100 and displayed with a percent symbol.
R (Round-trip): A string that can round-trip to an identical number.
X (Hexadecimal): A hexadecimal string.
 */

int age = int.Parse("27");
DateTime birthday = DateTime.Parse("4 July 1980");

WriteLine($"I was born {age} years ago.");
WriteLine($"My birthday is {birthday}.");
WriteLine($"My birthday is {birthday:D}.");

// ----- Avoiding exceptions using the TryParse method
// TryParse attempts to convert the input string and returns true if it can convert it and false if it cannot.
Write("How many eggs are there? ");
string? input = Console.ReadLine(); 

if (int.TryParse(input, out int count))
{
    WriteLine($"There are {count} eggs");
}
else 
{
    WriteLine("I could not parse the input.");
}