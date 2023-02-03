using Packt.Shared;
using PacktLibrary;
using System.Collections;
using static System.Console;

Person harry = new() { Name = "Harry" };
//Person mary = new() { Name = "Mary" };
//Person jill = new() { Name = "Jill" };

//// call instance mthod
//Person baby1 = mary.ProcreateWith(harry);
//baby1.Name = "Gary";

//// call static method
//Person baby2 = Person.Procreate(harry, jill);

//// call an operator
//Person baby3 = harry * mary;


//WriteLine($"{harry.Name} has {harry.Children.Count} children.");
//WriteLine($"{mary.Name} has {mary.Children.Count} children.");
//WriteLine($"{jill.Name} has {jill.Children.Count} children.");
//WriteLine(    
//    format: "{0}'s first child is named \"{1}\".",
//    arg0: harry.Name,
//    arg1: harry.Children[0].Name);

//WriteLine($"5! is {Person.Factorial(5)}");

//// defining and handling delegates

///*
// * This method has a signature that match that one of the EventHandler class.
// * It gets a reference to the Person object from the sender parameter and outputs
// * some information about them.
//*/
//static void Harry_Shout(object? sender, EventArgs e)
//{
//    if (sender is null)
//    {
//        return;
//    }

//    Person pe = (Person)sender;
//    WriteLine($"{pe.Name} is this angry: {pe.AngerLevel}");
//}

//// assigning the method to the delegate field
//harry.Shout += Harry_Shout;

//// calling the Poke method several times
//harry.Poke();
//harry.Poke();
//harry.Poke();
//harry.Poke();

// making types reusable with generics

// generic lookup collection
Dictionary<int, string> lookupIntString = new();

lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

// using the key to look up its value in the hash table
//int key = 2; // lookup the value that has 2 as its key
//WriteLine(format: "Key {0} has value: {1}", arg0: key, arg1: lookupIntString[key]);

//// using the harry object to look up its value
//WriteLine(format: "Key {0} has value: {1}", arg0: 4, arg1: lookupIntString[4]);

// Comparing objects when sorting
Person[] people =
{
    new() { Name = "Simon" },
    new() { Name = "Jenny" },
    new() { Name = "Adam" },
    new() { Name = "Richard" },
};

//WriteLine("Initial list of people:");

//foreach (Person person in people)
//{
//    WriteLine($"    {person.Name}");
//}

//WriteLine($"Use Person's IComprable implementation to sort:");
//Array.Sort(people);

//foreach (Person person in people)
//{
//    WriteLine($"    {person.Name}");
//}

// Comparing objects using a separate class

//WriteLine($"Use PersonCompare's IComprable implementation to sort:");
//Array.Sort(people, new PersonComparer());

//foreach (Person person in people)
//{
//    WriteLine($"    {person.Name}");
//}

// Defining struct types

//DisplacementVector dv1 = new(3, 5);
//DisplacementVector dv2 = new(-2, 7);
//DisplacementVector dv3 = dv1 + dv2;

//WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

// Inheriting from classes

Employee john = new()
{
    Name = "John Jones",
    DateOfBirth = new(year: 1990, month: 7, day: 28)
};

john.WriteToConsole();

// Extending classes to add functionality
john.EmployeeCode = "JJ001";
john.HireDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");

//Understanding polymorphism

Employee aliceInEmployee = new() { Name = "Alice", EmployeeCode = "AA123" };

Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

// Avoiding casting exceptions

if (aliceInPerson is Employee explicitAlice)
{
    WriteLine($"{nameof(aliceInPerson)} IS an Employee");
    WriteLine(explicitAlice.ToString());
}

// using the as keyword alternatively

//Employee? aliceAsEmployee = aliceInPerson as Employee; // could be null

//if (aliceAsEmployee != null)
//{
//    WriteLine($"{nameof(aliceAsEmployee)} AS an Employee");   
//}

// Inheriting exceptions

//try
//{
//    john.TimeTravel(when: new(1999, 12, 31));
//    john.TimeTravel(when: new(1950, 12, 25));
//}
//catch (PersonException ex)
//{

//    WriteLine(ex.Message);
//}

// 

// Using static methods to reuse functionality

string email1 = "pamela@test.com";
string email2 = "ian&test.com";

//WriteLine("{0} is valid e-mail address: {1}", arg0: email1, arg1: StringExtensions.IsValidEmail(email1));
//WriteLine("{0} is valid e-mail address: {1}", arg0: email2, arg1: StringExtensions.IsValidEmail(email2));

// Using extension methods to reuse functionality

WriteLine("{0} is valid e-mail address: {1}", arg0: email1, arg1: email1.IsValidEmail());
WriteLine("{0} is valid e-mail address: {1}", arg0: email2, arg1: email2.IsValidEmail());
