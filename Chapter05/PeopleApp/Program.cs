﻿using Microsoft.VisualBasic;
using Packt.Shared;
using System.Drawing;
using static System.Console;

//Person bob = new(); // C# 9.0 or later
//bob.Name = "Bob Smith";
//bob.DateOfBirth = new DateTime(1965, 12, 22);
//bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
//bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

//WriteLine(format: "{0}'s favorite wonder is {1}. Its integer is {2}",
//    arg0: bob.Name,
//    arg1: bob.FavoriteAncientWonder,
//    arg2: (int)bob.FavoriteAncientWonder);

//WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

//bob.Children.Add(new Person { Name = "Alfred" });   // C# 3.0 and later
//bob.Children.Add(new() { Name = "Zoe" });           // C# 9.0 and later    

//WriteLine($"{bob.Name} has {bob.Children.Count} children:");
//WriteLine($"{bob.Name} is a {Person.Species}");
//WriteLine($"{bob.Name} was born on {bob.HomePlanet}");
//bob.WriteToConsole();
//WriteLine(bob.GetOrigin());

//(string, int) fruit = bob.GetFruit();
//WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

//var fruitNamed = bob.GetNamedFruit();
//WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

//foreach (var children in bob.Children)
//{
//    WriteLine($"{children.Name}");
//}

//Person alice = new()
//{
//    Name = "Alice Jones",
//    DateOfBirth = new(1998, 3, 7)  // C# 9.0 or later
//};

//WriteLine(format: "{0} was born on {1:dd MMM yy}",
//    arg0: alice.Name,
//    arg1: alice.DateOfBirth);

//BankAccount.InterestRate = 0.012M;

//BankAccount jonesAccount = new();
//jonesAccount.AccountName = "Mrs. Jones";
//jonesAccount.Balance = 2400;

//WriteLine(format: "{0} earned {1:C} interest.",
//    arg0: jonesAccount.AccountName,
//    arg1: jonesAccount.Balance * BankAccount.InterestRate);

//BankAccount gerrierAccount = new();
//gerrierAccount.AccountName = "Ms. Gerrier";
//gerrierAccount.Balance = 98;

//WriteLine(format: "{0} earned {1:C} interest.",
//    arg0: gerrierAccount.AccountName,
//    arg1: gerrierAccount.Balance * BankAccount.InterestRate);

//Person blankPerson = new();

//WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
//    arg0: blankPerson.Name,
//    arg1: blankPerson.HomePlanet,
//    arg2: blankPerson.Instantiated);

//Person gunny = new(initialName: "Gunny", homePlanet: "Mars");

//WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
//    arg0: gunny.Name,
//    arg1: gunny.HomePlanet,
//    arg2: gunny.Instantiated);

//var thing1 = ("Neville", 4); 
//WriteLine($"{thing1.Item1} has {thing1.Item2} children."); 

//var thing2 = (bob.Name, bob.Children.Count);
//WriteLine($"{thing2.Name} has {thing2.Count} children.");

//// Deconstructing a Person

//var (name1, dob1) = bob;
//WriteLine($"Deconstructed: {name1}, {dob1}");

//var (name2, dob2, fav2) = bob;
//WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");

//WriteLine(bob.OptionalParameters());
//WriteLine(bob.OptionalParameters("Jump!", 98.5));


//int a = 10;
//int b = 20;
//int c = 30;

//WriteLine($"Before: a = {a}, b = {b}, c = {c}");
//bob.PassingParameters(a, ref b, out c);
//WriteLine($"After: a = {a}, b = {b}, c = {c}");

//int d = 20;
//int e = 30;

//WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
//bob.PassingParameters(d, ref e, out int f);
//WriteLine($"After: d = {d}, e = {e}, f = {f}");

//// Using read-only properties
//Person sam = new()
//{
//    Name = "Sam",
//    DateOfBirth = new(1972, 1, 27)
//};

//sam.FavoriteIceCream = "Chocolate Fudge";
//WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");

//sam.FavoritePrimaryColor = "Red";
//WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");

//WriteLine(sam.Origin);
//WriteLine(sam.Greeting);
//WriteLine(sam.Age);

//// Defining indexers

//sam.Children.Add(new() { Name = "Charlie"} );
//sam.Children.Add(new() { Name = "Ella"} );

//WriteLine($"Sam's first child is {sam.Children[0].Name}.");
//WriteLine($"Sam's second child is {sam.Children[1].Name}.");

//WriteLine($"Sam's first child is {sam[0].Name}.");
//WriteLine($"Sam's second child is {sam[1].Name}.");

// Pattern matching with objects

//object[] passengers = {
//    new FirstClassPassenger { AirMiles = 1_419 },
//    new FirstClassPassenger { AirMiles = 16_562 },
//    new BusinessClassPassenger(),
//    new CoachClassPassenger { CarryOnKG = 25.7 },
//    new CoachClassPassenger { CarryOnKG = 0 }
//};

//foreach (object passenger in passengers)
//{
//    decimal flightCost = passenger switch
//    {
//        /* C# 8 syntax
//        FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
//        FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
//        FirstClassPassenger _                         => 2000M, */

//        // C# 9 or latter syntax
//        FirstClassPassenger p => p.AirMiles switch
//        {
//            > 35000 => 1500M,
//            > 15000 => 1750M,
//            _       => 2000M
//        },
//        BusinessClassPassenger _                      => 1000M,
//        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
//        CoachClassPassenger _                         => 650M,
//        _                                             => 800M
//    };

//    WriteLine($"Flighc costs {flightCost:C} for {passenger}");
//}

// Initt-only properties

//ImmutablePerson jeff = new()
//{
//    FirstName = "Jeff",
//    LastName = "Winger"
//};

// Using records

//ImmutableVehicle car = new()
//{
//    Brand = "Mazda MX-5 RF",
//    Color = "Soul Red Crystal Metallic",
//    Wheels = 4,
//};

//ImmutableVehicle repaintedCar = car
//    with
//{ Color = "Polymetal Grey Metallic" };

//WriteLine($"Original car color was {car.Color}");
//WriteLine($"New car color was {repaintedCar.Color}");

//// Simplifying data members in records

//ImmutableAnimal oscar = new("Oscar", "Labrador");
//var (who, what) = oscar; // calls Deconstruct method
//WriteLine($"{who} is a {what}");

// Inheriting from classes

Employee john = new()
{
    Name = "John Jones",
    DateOfBirth = new(year: 1990, month: 7, day: 28)
};

john.WriteToConsole();

john.EmployeeCode = "JJ001" ?? default;
john.HireDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yyyy}");
WriteLine(john.ToString());