using static System.Console;

int numberOfApples = 12;
decimal pricePerApple = 0.35M;

WriteLine(
    format: "{0} apples cost {1:C}",
    arg0: numberOfApples,
    arg1: pricePerApple * numberOfApples);

// WriteToFile(formatted); // writes the string into a file

WriteLine($"{numberOfApples} apples costs {pricePerApple * numberOfApples:C}");

string applesText = "Apples";
int applesCount = 1234;

string bananasText = "Bananas";
int bananasCount = 56789;

// to output a table with left-align for the names within a column of 10 characters
// and right align for the counts formatted as numbers with zero decimal places
// within a column of six characters.
WriteLine(
    format: "{0, -10} {1,6:N0}",
    arg0: "Name",
    arg1: "Count");

WriteLine(
    format: "{0, -10} {1,6:N0}",
    arg0: applesText,
    arg1: applesCount);

WriteLine(
    format: "{0, -10} {1,6:N0}",
    arg0: bananasText,
    arg1: bananasCount);

// -------- Getting text input from the user
WriteLine("Type your first name and press ENTER: ");
string? firstName = ReadLine();

WriteLine("Type your age and press ENTER: ");
string? age = ReadLine();

WriteLine($"Hello, {firstName}, you look good for {age}");

// -------- Getting key input from the user
Write("Press any key combination: ");
ConsoleKeyInfo key = ReadKey();
WriteLine();
WriteLine("Key: {0}, Char: {1}, Modifiers: {2}",
    arg0: key.Key,
    arg1: key.KeyChar,
    arg2: key.Modifiers
);