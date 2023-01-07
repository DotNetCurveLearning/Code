using static System.Console;

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
string [] names = {"Adam", "Barry", "Charlie"};

foreach (string name in names)
{
    WriteLine($"{name} has {name.Length} characters.");
}
