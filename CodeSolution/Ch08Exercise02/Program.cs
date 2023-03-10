using System.Text.RegularExpressions;
using static System.Console;

Regex defaultRegex = new(@"^\d+$");
bool isNotEscPressed;

do
{

    WriteLine("tThe default regular expression checks for at least one digit.");

    Write("Enter a regular expression (or press ENTER to use the default): ");
    string? regularExp = ReadLine();
    Regex regularExpChecker = regularExp != null ? new(regularExp) : defaultRegex;

    Write("Enter some input: ");
    string? textToVerifiy = ReadLine();

    WriteLine($"{textToVerifiy} matches {regularExpChecker.ToString()}?: {regularExpChecker.IsMatch(textToVerifiy)}");

    WriteLine("Press ESC to end or any key to try again");
    ConsoleKey readKey = ReadKey().Key;
    isNotEscPressed = readKey != ConsoleKey.Escape;
} while (isNotEscPressed);

