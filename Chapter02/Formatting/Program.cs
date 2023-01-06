int numberOfApples = 12;
decimal pricePerApple = 0.35M;

Console.WriteLine(
    format: "{0} apples cost {1:C}",
    arg0: numberOfApples,
    arg1: pricePerApple * numberOfApples);

// WriteToFile(formatted); // writes the string into a file

Console.WriteLine($"{numberOfApples} apples costs {pricePerApple * numberOfApples:C}");

string applesText = "Apples";
int applesCount = 1234;

string bananasText = "Bananas";
int bananasCount = 56789;

// to output a table with left-align for the names within a column of 10 characters
// and right align for the counts formatted as numbers with zero decimal places
// within a column of six characters.
Console.WriteLine(
    format: "{0, -10} {1,6:N0}",
    arg0: "Name",
    arg1: "Count");

Console.WriteLine(
    format: "{0, -10} {1,6:N0}",
    arg0: applesText,
    arg1: applesCount);

Console.WriteLine(
    format: "{0, -10} {1,6:N0}",
    arg0: bananasText,
    arg1: bananasCount);