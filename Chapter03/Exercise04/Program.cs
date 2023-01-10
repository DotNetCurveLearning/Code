using static System.Console;

try
{
    Write("Enter a number between 0 and 255: ");
    int firstNumber = Convert.ToInt32(Console.ReadLine());

    if (firstNumber < byte.MinValue || firstNumber > byte.MaxValue)
    {
        throw new Exception();
    }

    WriteLine();

    Write("Enter another number between 0 and 255: ");
    int secondNumber = Convert.ToInt32(Console.ReadLine());

    if (secondNumber < byte.MinValue || secondNumber > byte.MaxValue)
    {
        throw new Exception();
    }

    WriteLine("{0} divided by {1} is {2}", firstNumber, secondNumber, (firstNumber/secondNumber).ToString("F3"));
}
catch (FormatException ex)
{
	WriteLine("Input string was not in a correct format.");
}
catch (Exception ex)
{
    WriteLine("One of the numbers is not included into the range between 0 and 255.");
}