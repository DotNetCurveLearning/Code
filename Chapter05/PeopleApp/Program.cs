using Packt.Shared;
using static System.Console;

Person bob = new(); // C# 9.0 or later
bob.Name = "Bob Smith";
bob.DateOfBirth = new DateTime(1965, 12, 22);
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

WriteLine(format: "{0}'s favorite wonder is {1}. Its integer is {2}",
    arg0: bob.Name,
    arg1: bob.FavoriteAncientWonder,
    arg2: (int)bob.FavoriteAncientWonder);

WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

bob.Children.Add(new Person { Name = "Alfred" });   // C# 3.0 and later
bob.Children.Add(new() { Name = "Zoe" });           // C# 9.0 and later    

WriteLine($"{bob.Name} has {bob.Children.Count} children:");
WriteLine($"{bob.Name} is a {Person.Species}");
WriteLine($"{bob.Name} was born on {bob.HomePlanet}");
bob.WriteToConsole();
WriteLine(bob.GetOrigin());

(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

var fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

foreach (var children in bob.Children)
{
    WriteLine($"{children.Name}");
}

Person alice = new()
{
    Name = "Alice Jones",
    DateOfBirth = new(1998, 3, 7)  // C# 9.0 or later
};

WriteLine(format: "{0} was born on {1:dd MMM yy}",
    arg0: alice.Name,
    arg1: alice.DateOfBirth);

BankAccount.InterestRate = 0.012M;

BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;

WriteLine(format: "{0} earned {1:C} interest.",
    arg0: jonesAccount.AccountName,
    arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;

WriteLine(format: "{0} earned {1:C} interest.",
    arg0: gerrierAccount.AccountName,
    arg1: gerrierAccount.Balance * BankAccount.InterestRate);

Person blankPerson = new();

WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
    arg0: blankPerson.Name,
    arg1: blankPerson.HomePlanet,
    arg2: blankPerson.Instantiated);

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");

WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
    arg0: gunny.Name,
    arg1: gunny.HomePlanet,
    arg2: gunny.Instantiated);

var thing1 = ("Neville", 4); 
WriteLine($"{thing1.Item1} has {thing1.Item2} children."); 

var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");