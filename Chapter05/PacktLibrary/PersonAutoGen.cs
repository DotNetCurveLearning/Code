using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared
{
    // The rest of the code for this chapter will be written in this file
    public partial class Person
    {
        private string _favoritePrimaryColor;
        private int myProperty;

        public string FavoriteIceCream { get; set; }

        // a property defined using C#1 - 5 syntax
        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }
        }

        // two properties defined using C# 6+ lambda expression body syntax
        public string Greeting => $"{Name} says 'Hello'";
        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

        public string FavoritePrimaryColor
        {
            get => _favoritePrimaryColor;
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        _favoritePrimaryColor = value;
                        break;
                    default:
                        throw new System.ArgumentException($"{value} is not a primary color. Choose from: red, green, blue");
                }
            }
        }

        public Person this[int index] 
        { 
            get => Children[index]; 
            set => Children[index] = value; 
        }
    }
}
