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

        [Fact]
        public void CalculateChange_ReturnMultipleValues_ChangeIsCombinationOfAvailableCoins()
        {
            int change = 60;
            var availableCoins = new List<int> { 50, 10 };

            var functionResult = ChangeCalculator.CalculateChange(change, availableCoins);

            Assert.Equal(new List<int> { 50, 10 }, functionResult);
        }

        [Fact]
        public void CalculateChange_ReturnPayByCard_NotEnoughAvailableCoinsForChange()
        {
            int change = 100;
            var availableCoins = new List<int> { 50, 10 };

            var functionResult = ChangeCalculator.CalculateChange(change, availableCoins);

            Assert.Equal("Оплатите картой!", functionResult);
        }
    }
}