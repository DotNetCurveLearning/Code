using static System.Console;

string password = "ninja";

if (password.Length < 8)
{
    WriteLine("Your password is too short. Use at leas 8 characters.");
}
else
{
    WriteLine("Your password is strong.");
}

// add and remove the "" to change the behavior
object o = 3;
int j = 4;

if (o is int i)
{
    WriteLine($"{i} x {j} = {i * j}");
}
else
{
    WriteLine("o is not an int so it cannot multiply!");
}

// ------------- Branching with the switch statement
int number = (new Random()).Next(1, 7);
WriteLine($"My random number is {number}");

switch (number)
{
    case 1:
        WriteLine("One");
        break;
    case 2:
        WriteLine("Two");
        goto case 1;
    case 3:
    case 4:
        WriteLine("Three or four");
        goto case 1;
    case 5:
        WriteLine("Three or four");
        goto A_label;
    default:
        WriteLine("Default");
        break;
}

WriteLine("After end of the switch");
A_label:
WriteLine($"After A_label");

// --------- Pattern matching with the switch statement
string path = @"/home/eara/Corsi/DotNetTraining/Code/Chapter03/SelectionStatements";

Write("Press R for read-only or W for writeable: ");
ConsoleKeyInfo key = Console.ReadKey();
WriteLine();

Stream? s;

if (key.Key == ConsoleKey.R)
{
    s = File.Open(
        Path.Combine(path, "file.txt"),
        FileMode.OpenOrCreate,
        FileAccess.Read);
}
else
{
    s = File.Open(
        Path.Combine(path, "file.txt"),
        FileMode.OpenOrCreate,
        FileAccess.Write);
}

string message;

/* switch (s)
{
    case FileStream writeableFile when s.CanWrite:
        message = "The stream is a file that I can write too.";
        break;
    case FileStream readOnlyFile:
        message = "The stream is a read-only file.";
        break;
    case MemoryStream ms:
        message = "The stream is a memory address.";
        break;
    default:
        message = "The stream is some other type.";
        break;
    case null:
        message = "The stream is null.";
        break;
}

WriteLine(message); */

// ---------------- Simplifying switch statements with switch expressions
message = s switch
{
    FileStream writeableFile when s.CanWrite => "The stream is a file that I can write too.",
    FileStream readOnlyFile => "The stream is a read-only file.",
    MemoryStream  ms => "The stream is a memory address.",
    null => "The stream is null",
    _ => "The stream is some other type.",
};

WriteLine(message);