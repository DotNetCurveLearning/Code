using PrimeFactorsClassLib;
using Xunit;

namespace ReturnPrimeFactorsTests
{
    public class UnitTest1
    {
        [Fact]
        public void WhenPassInAnIntegerValue_ThenReturnPrimeFactors()
        {
            // arrange
            var userInput = 50;

            // act
            var result = PrimeFactorsEngine.PrimeFactors(userInput);

            // assert
            Assert.Contains("5", result);
            Assert.Contains("2 5 5", result);
        }
    }
}