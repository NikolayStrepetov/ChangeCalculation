using Xunit;
using ChangeCalculation;
using System.Collections.Generic;

namespace ChangeCalculationTests
{
    public class ChangeCalculatorTest
    {
        [Fact]
        public void CalculateChange_ReturnSingleValue_AvailableCoinMatchesWithChange()
        {
            int change = 100;
            var availableCoins = new List<int> { 100 };

            var functionResult = ChangeCalculator.CalculateChange(change, availableCoins);

            Assert.Equal(new List<int> { 100 }, functionResult);
        }
    }
}