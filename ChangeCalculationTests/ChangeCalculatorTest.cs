using ChangeCalculation;

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

        [Fact]
        public void CalculateChange_ThrowsException_WhenChangeIsNegativeValue()
        {
            int change = -100;
            var availableCoins = new List<int> { 100, 50 };

            Assert.Throws<ArgumentException>(() => ChangeCalculator.CalculateChange(change, availableCoins));
        }

        [Fact]
        public void CalculateChange_ThrowsException_WhenAvailableCoinsAreInvalid()
        {
            int change = 100;
            var availableCoins = new List<int> { 100, 50, 10, 5, 2, 1, 15 };

            Assert.Throws<ArgumentException>(() => ChangeCalculator.CalculateChange(change, availableCoins));
        }

        [Fact]
        public void CalculateChange_ThrowsException_WhenAvailableCoinsAreNull()
        {
            int change = 100;
            List<int> availableCoins = null;

            Assert.Throws<ArgumentNullException>(() => ChangeCalculator.CalculateChange(change, availableCoins));
        }
    }
}