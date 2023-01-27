using static System.Console;

// Working with null values

//int thisCannotBeNulll = 4;
//// thisCannotBeNulll = null;   // compile error!

//int? thisCouldBeNulll = null;
//WriteLine(thisCouldBeNulll);
//WriteLine(thisCouldBeNulll.GetValueOrDefault());

//thisCouldBeNulll = 7;
//WriteLine(thisCouldBeNulll);
//WriteLine(thisCouldBeNulll.GetValueOrDefault());

// Declaring non-nullable variables and parameters

Address address = new();
address.Building = null;
address.Street = null;
address.City = "London";
address.Region = null;
class Address
{
    public string? Building;
    public string Street = string.Empty;
    public string City = string.Empty;
    public string Region = string.Empty;
}

