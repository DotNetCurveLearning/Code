using System;
using System.Text;

namespace PrimeFactorsClassLib
{
    public static class PrimeFactorsEngine
    {
        public static string PrimeFactors(int anIntegerValue)
        {
            var result = new StringBuilder();  

            while (anIntegerValue % 2 == 0)
            {
                result.Append(2).Append(" ");
                anIntegerValue /= 2;
            }

            for (int i = 3; i <= Math.Sqrt(anIntegerValue); i+= 2)
            {
                while (anIntegerValue % i == 0)
                {
                    result.Append(i).Append(" ");                   
                    anIntegerValue /= i;
                }
            }

            if (anIntegerValue > 2) 
            {
                result.Append(anIntegerValue);
            }

            return result.ToString();
        }
    }
}
