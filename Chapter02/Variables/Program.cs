using System.Xml;

object height = 1.88;   // storing a double in an object
object name = "Amir";   // storing a string in an object
Console.WriteLine($"{name} is {height} metres tall.");

// int length1 = name.Length;   // gives compile error!
int length2 = ((string)name).Length;   // tell compiler it is a string
Console.WriteLine($"{name} has {length2} metres tall.");

// storing a string in a dynamic object. string has a Length property
dynamic something = "Ahmed";
Console.WriteLine($"Lenght is {something.Length}");

// ---- Specifying the type of a local variable
var population = 66_000_000;
var weight = 1.88;
var price = 4.99M;
var fruit = "Apples";
var letter = 'Z';
var happy = true;

// good use of var because it avoids the repeated type
// as shown in the more verbose second statement
var xml1 = new XmlDocument();
XmlDocument xml2 = new XmlDocument();

/*
bad use of var because we cannot tell the type, so we
should use a specific type declaration as shown in the
second statement.
*/
var file = File.CreateText("something1.txt");
StreamWriter file2 = File.CreateText("something2.txt");

XmlDocument xml3 = new();

// --- Getting and setting the default values for types
Console.WriteLine($"default(int) = {default(int)}");
Console.WriteLine($"default(bool) = {default(bool)}");
Console.WriteLine($"default(DateTime) = {default(DateTime)}");
Console.WriteLine($"default(string) = {default(string)}");

int number = 13;
Console.WriteLine($"number has been set to: {number}");
number = default;
Console.WriteLine($"number has been reset to its default: {number}");

string [] names;

// allocating memory for four strings
names = new string[4];

// storing items at index positions
names[0] = "Kate";
names[1] = "Jack";
names[2] = "Rebecca";
names[3] = "Tom";

// looping through the names
for (int i = 0; i < names.Length; i++)
{
    // output the item at index i
    Console.WriteLine(names[i]);
}

string [] names2 = new[] {"Kate", "Jack", "Rebecca", "Tom"};

for (int i = 0; i < names2.Length; i++)
{
    // output the item at index i
    Console.WriteLine(names[i]);
}