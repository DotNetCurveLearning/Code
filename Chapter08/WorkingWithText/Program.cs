using static System.Console;

string city = "London";
WriteLine($"{city} is {city.Length} characters long.");

// Getting part of a string

string fullName = "Alan Jones";
int indexOfTheSpace = fullName.IndexOf(' ');  

string firstName = fullName.Substring(startIndex: 0, length: indexOfTheSpace);
string lastName = fullName.Substring(startIndex: indexOfTheSpace + 1);

WriteLine($"Original: {fullName}");
WriteLine($"Swapped: {lastName}, {firstName}");

// Working with dates and times