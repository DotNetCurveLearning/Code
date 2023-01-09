using static System.Console;

/*
Replace any number divisible by three with the word fizz, 
any number divisible by five with the word buzz, 
and any number divisible by both with fizzbuzz. 
*/

for (int i = 1; i <= 100; i++)
{
    //string result = i switch {
    //    i % 3 == 0b0 => i.ToString()
    //};
    if (i%3 == 0 && i%5 == 0)
	{
		Console.Write("Fizzbuzz");
	}
	else if (i % 3 == 0)
    {
        Console.Write("Fizz");
    }
    else if (i % 5 == 0)
    {
        Console.Write("Buzz");
    }
    else
    {
        Console.Write(i);
    }

    Console.Write(i <= 99 ? ", " : "");
}