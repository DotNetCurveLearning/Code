using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

//static void TimesTable(byte number)
//{
//    WriteLine($"This is the {number} times table:");

//	for (int row = 0; row <= 12; row++)
//	{
//        WriteLine($"{row} x {number} = {row * number}");
//    }
//    WriteLine();
//}

//TimesTable(6);

// function to calculate taxes in various regions around the world
//static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
//{
//    decimal rate = 0.0M;

//    rate = twoLetterRegionCode switch
//    {
//        string code when (code.ToUpper() == "CH") => 0.08M,
//        string code when (code.ToUpper() == "ND" || code.ToUpper() == "DK" || code.ToUpper() == "NO") => 0.25M,
//        string code when (code.ToUpper() == "ND" || code.ToUpper() == "GB" || code.ToUpper() == "FR") => 0.2M,
//        string code when (code.ToUpper() == "HU") => 0.27M,
//        string code when (code.ToUpper() == "ND" || code.ToUpper() == "OR" || code.ToUpper() == "AK" || code.ToUpper() == "MT") => 0.0M,
//        string code when (code.ToUpper() == "ND" || code.ToUpper() == "WI" || code.ToUpper() == "ME" || code.ToUpper() == "VA") => 0.05M,
//        string code when (code.ToUpper() == "CA") => 0.0825M,
//        _ => 0.06M
//    };

//    return amount * rate;
//}

//decimal taxToPay = CalculateTax(amount: 149, twoLetterRegionCode: "FR");
//WriteLine("You must pay {0:C} in tax.", taxToPay);

//taxToPay = CalculateTax(amount: 149, twoLetterRegionCode: "fr");
//WriteLine("You must pay {0:C} in tax.", taxToPay);

//taxToPay = CalculateTax(amount: 149, twoLetterRegionCode: "UK");
//WriteLine("You must pay {0:C} in tax.", taxToPay);

// function that converts a cardinal int value into an ordinal string value
static string DefaultSwitch(int number)
{
    int lastDigit = number % 10;

    string suffix = lastDigit switch
    {
        1 => "st",
        2 => "nd",
        3 => "rd",
        _ => "th"
    };

    return $"{number}{suffix}";
}
static string CardinalToOrdinal(int number)
{
    string result = number switch
    {
        int currentValue when (currentValue == 11 || currentValue == 12 || currentValue == 13) => $"{number}th",
        _ => DefaultSwitch(number)
    };

    return result;
}

//static void RunCardinalToOrdinal()
//{
//    for (int number = 1; number <= 40; number++)
//    {
//        Write($"{CardinalToOrdinal(number)} ");
//    }
//    WriteLine();
//}

//RunCardinalToOrdinal();
//static int Factorial(int number)
//{
//    if (number < 1)
//    {
//        return 0;
//    }
//    else if (number == 1)
//    {
//        return 1;
//    }
//    else
//    {
//        checked
//        {
//            return number * Factorial(number - 1);
//        }        
//    }
//}

//static void RunFactorial()
//{
//    for (int i = 0; i < 15; i++)
//    {
//        try
//        {
//            WriteLine($"{i}! = {Factorial(i):N0}");
//        }
//        catch (System.OverflowException ex)
//        {

//            WriteLine($"{i}! is too big for a 32-bit integer.");
//        }        
//    }
//}

//RunFactorial();


// Fibonacci sequence
static int FibImperative(int term)
{
    if (term == 1)
    {
        return 0;
    }
    else if (term == 2)
    {
        return 1;
    }
    else
    {
        return FibImperative(term - 1) + FibImperative(term - 2);
    }
}

//static void RunFibImperative()
//{
//    for (int i = 1; i <= 30; i++)
//    {
//        WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
//            arg0: CardinalToOrdinal(i),
//            arg1: FibImperative(term: i));
//    }
//}

//RunFibImperative();

static int FibFunctional(int term) =>
    term switch {
        1 => 0,
        2 => 1,
        _ => FibFunctional(term -1) + FibFunctional(term - 2)
    };

static void RunFibFunctional()
{
    for (int i = 1; i <= 30; i++)
    {
        WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
            arg0: CardinalToOrdinal(i),
            arg1: FibFunctional(term: i));
    }
}

RunFibFunctional();