using System;
using static System.Console;

//WriteLine("Before parsing");
//Write("What is your age? ");

//string? input = Console.ReadLine();

//try
//{
//	int age = int.Parse(input);
//    WriteLine($"You are {age} years old.");
//}
//catch (Exception ex)
//{
//    WriteLine($"{ex.GetType()} says {ex.Message}");
//}
//WriteLine("After parsing");

// --- Catching with filters
// We can add filters to a catch statement using the "when" keyword.
Write("Enter an amount: ");
string? amount = Console.ReadLine();

try
{
	decimal amountValue = decimal.Parse(amount);
}
catch (FormatException) when (amount.Contains("$"))
{

    WriteLine("Amounts cannot use the dollar sign!");
}
catch (FormatException)
{
    WriteLine("Amounts must only contains digits!");
}