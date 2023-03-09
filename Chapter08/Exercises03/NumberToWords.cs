using System.Collections.Immutable;
using System.Numerics;

namespace NumberExtensions.Shared;

public static class NumberToWords
{
    private ImmutableArray<string> numbersArr = ImmutableArray.Create(new string[] { "one", "two", "three",
        "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen",
        "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" });
    private ImmutableArray<string> tensArr = ImmutableArray.Create(new string[] { "twenty", "thirty", "fourty",
        "fifty", "sixty", "seventy", "eighty", "ninty" });
    private ImmutableArray<string> suffixesArr = ImmutableArray.Create(new string[] { "thousand", "million",
    "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion",
    "decillion", "undecillion", "duodecillion", "tredecillion", "Quattuordecillion", "Quindecillion",
    "Sexdecillion", "Septdecillion", "Octodecillion", "Novemdecillion", "Vigintillion" });

    private string result = "";
    private string buff = "";
    private int single, tens, hundreds;
    public static BigInteger ToWords(this BigInteger aNumber)
    {
        if (aNumber > 1000)
        {
            return false;
        }
        return 0;
    }
}
