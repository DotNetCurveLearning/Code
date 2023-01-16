using PrimeFactorsClassLib;

namespace Prime
{
    public class ReturnPrimeFactors
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(PrimeFactorsEngine.PrimeFactors(userInput));
        }
    }
}