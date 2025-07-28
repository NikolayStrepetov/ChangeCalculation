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
        public void CalculateChange_ReturnCorrectMultipleValues_ChangeIsCombinationOfAvailableCoins()
        {
            int change = 30;
            var availableCoins = new List<int> { 5, 5, 5, 5, 5, 5, 10, 10, 10, 5, 5, 5, 5, 5, 5 };

            var functionResult = ChangeCalculator.CalculateChange(change, availableCoins);

            Assert.Equal(new List<int> { 10, 10, 10 }, functionResult);
        }

        [Fact]
        public void CalculateChange_ReturnPayByCard_NotEnoughAvailableCoinsForChange()
        {
            int change = 100;
            var availableCoins = new List<int> { 50, 10 };

            var functionResult = ChangeCalculator.CalculateChange(change, availableCoins);

            Assert.Equal("Оплатите картой!", functionResult);
        }

        [Fact]
        public void CalculateChange_ReturnPayByCard_WhenNoAvailableCoinsForChange()
        {
            int change = 100;
            var availableCoins = new List<int>();

            var functionResult = ChangeCalculator.CalculateChange(change, availableCoins);

            Assert.Equal("Оплатите картой!", functionResult);
        }

        [Fact]
        public void CalculateChange_ReturnNoChangeRequired_WhenChangeIsZeroValue()
        {
            int change = 0;
            var availableCoins = new List<int> { 100, 50 };

            var functionResult = ChangeCalculator.CalculateChange(change, availableCoins);

            Assert.Equal("Сдача не требуется!", functionResult);
        }
    }
}