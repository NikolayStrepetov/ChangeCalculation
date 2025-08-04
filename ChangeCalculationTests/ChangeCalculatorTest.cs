using ChangeCalculation;

namespace ChangeCalculationTests
{
    public class ChangeCalculatorTest
    {
        [Fact]
        public void CalculateChange_ReturnSingleValue_AvailableCoinMatchesWithChange()
        {
            int amount = 100;
            var availableCoins = new List<int> { 100 };
            var expectedResult = new CalculationResult
            {
                CanReturn = true,
                Coins = new List<int> { 100 }
            };

            var functionResult = ChangeCalculator.CalculateChange(amount, availableCoins);

            Assert.Equal(expectedResult.CanReturn, functionResult.CanReturn);
            Assert.Equal(expectedResult.Coins, functionResult.Coins);
        }

        [Fact]
        public void CalculateChange_ReturnMultipleValues_ChangeIsCombinationOfAvailableCoins()
        {
            int amount = 60;
            var availableCoins = new List<int> { 50, 10 };
            var expectedResult = new CalculationResult
            {
                CanReturn = true,
                Coins = new List<int> { 50, 10 }
            };

            var functionResult = ChangeCalculator.CalculateChange(amount, availableCoins);

            Assert.Equal(expectedResult.CanReturn, functionResult.CanReturn);
            Assert.Equal(expectedResult.Coins, functionResult.Coins);
        }

        [Fact]
        public void CalculateChange_ReturnMultipleValuesOutOfOrder_ChangeIsCombinationOfAvailableCoins()
        {
            int amount = 61;
            var availableCoins = new List<int> { 50, 10, 5, 2, 2, 2 };
            var expectedResult = new CalculationResult
            {
                CanReturn = true,
                Coins = new List<int> { 50, 5, 2, 2, 2 }
            };

            var functionResult = ChangeCalculator.CalculateChange(amount, availableCoins);

            Assert.Equal(expectedResult.CanReturn, functionResult.CanReturn);
            Assert.Equal(expectedResult.Coins, functionResult.Coins);
        }

        [Fact]
        public void CalculateChange_ReturnCorrectMultipleValues_ChangeIsCombinationOfAvailableCoins()
        {
            int amount = 30;
            var availableCoins = new List<int> { 5, 5, 5, 5, 5, 5, 10, 10, 10, 5, 5, 5, 5, 5, 5 };
            var expectedResult = new CalculationResult
            {
                CanReturn = true,
                Coins = new List<int> { 10, 10, 10 }
            };

            var functionResult = ChangeCalculator.CalculateChange(amount, availableCoins);

            Assert.Equal(expectedResult.CanReturn, functionResult.CanReturn);
            Assert.Equal(expectedResult.Coins, functionResult.Coins);
        }

        [Fact]
        public void CalculateChange_CannotReturnChange_WhenNotEnoughAvailableCoinsForChange()
        {
            int amount = 100;
            var availableCoins = new List<int> { 50, 10 };
            var expectedResult = new CalculationResult
            {
                CanReturn = false,
                Coins = new List<int>()
            };

            var functionResult = ChangeCalculator.CalculateChange(amount, availableCoins);

            Assert.Equal(expectedResult.CanReturn, functionResult.CanReturn);
            Assert.Equal(expectedResult.Coins, functionResult.Coins);
        }

        [Fact]
        public void CalculateChange_CannotReturnChange_WhenNoAvailableCoinsForChange()
        {
            int amount = 100;
            var availableCoins = new List<int>();
            var expectedResult = new CalculationResult
            {
                CanReturn = false,
                Coins = new List<int>()
            };

            var functionResult = ChangeCalculator.CalculateChange(amount, availableCoins);

            Assert.Equal(expectedResult.CanReturn, functionResult.CanReturn);
            Assert.Equal(expectedResult.Coins, functionResult.Coins);
        }

        [Fact]
        public void CalculateChange_ReturnEmptyList_WhenChangeIsZeroValue()
        {
            int amount = 0;
            var availableCoins = new List<int> { 100, 50 };
            var expectedResult = new CalculationResult
            {
                CanReturn = true,
                Coins = new List<int>()
            };

            var functionResult = ChangeCalculator.CalculateChange(amount, availableCoins);

            Assert.Equal(expectedResult.CanReturn, functionResult.CanReturn);
            Assert.Equal(expectedResult.Coins, functionResult.Coins);
        }

        [Fact]
        public void CalculateChange_ThrowsException_WhenChangeIsNegativeValue()
        {
            int amount = -100;
            var availableCoins = new List<int> { 100, 50 };

            Assert.Throws<ArgumentException>(() => ChangeCalculator.CalculateChange(amount, availableCoins));
        }

        [Fact]
        public void CalculateChange_ThrowsException_WhenAvailableCoinsAreInvalid()
        {
            int amount = 100;
            var availableCoins = new List<int> { 100, 50, 10, 5, 2, 1, 15 };

            Assert.Throws<ArgumentException>(() => ChangeCalculator.CalculateChange(amount, availableCoins));
        }

        [Fact]
        public void CalculateChange_ThrowsException_WhenAvailableCoinsAreNull()
        {
            int amount = 100;
            List<int> availableCoins = null;

            Assert.Throws<ArgumentNullException>(() => ChangeCalculator.CalculateChange(amount, availableCoins));
        }
    }
}