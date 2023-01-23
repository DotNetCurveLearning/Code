// --- Checking for overflow
/*
When casting between number types, it's possible to lose information. For example,
when casting from a long variable to an int variable. If the value stored in a type
is too big, it will overflow.
The "checked" statement tells .NET to thorw an exception when an overflow happens
instead of allowing it to happen silently, which is done by default for performance reasons.

In this example, if the loop cycle is not enclosed withih the checked statement it will loop forever,
because the value of i can only be between 0 and 255.
*/


try
{
    checked
    {
        int max = 500;

        for (byte i = 0; i < max; i++)
        {
            Console.WriteLine(i);
        }
    }    
}
catch (OverflowException ex)
{

	Console.WriteLine("The code overflowed. The exception was caughted.");
}
