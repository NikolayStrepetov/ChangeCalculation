namespace ChangeCalculation
{
    public static class ChangeCalculator
    {
        private static readonly List<int> _validCoins = new List<int> { 100, 50, 10, 5, 2, 1 };

        public static CalculationResult CalculateChange(int change, List<int> availableCoins)
        {
            var invalidCoins = availableCoins.Where(x => !_validCoins.Contains(x)).ToList();
            if (invalidCoins.Count > 0)
                throw new ArgumentException("Invalid coins! Valid are: 100, 50, 10, 5, 2, 1.");

            if (change < 0)
                throw new ArgumentException("Change cannot be negative!", nameof(change));

            if (change == 0) return new CalculationResult { CanReturn = true, Coins = new List<int>() };

            availableCoins = availableCoins.OrderByDescending(x => x).ToList();
            var result = FindCombination(change, availableCoins, new List<int>());

            return result != null ? new CalculationResult { CanReturn = true, Coins = result} : new CalculationResult { CanReturn = false, Coins = new List<int>() };
        }

        private static List<int> FindCombination(int remaining, List<int> coins, List<int> currentCombination)
        {
            if (remaining == 0)
            {
                return new List<int>(currentCombination);
            }

            if (coins.Count == 0)
            {
                return null;
            }

            for (int i  = 0; i < coins.Count; i++)
            {
                if (coins[i] > remaining)
                {
                    continue;
                }

                var newRemaining = remaining - coins[i];
                var newCoins = new List<int>(coins);
                newCoins.RemoveAt(i);
                var newCombination = new List<int>(currentCombination) { coins[i] };

                var result = FindCombination(newRemaining, newCoins, newCombination);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }

    public class CalculationResult
    {
        public bool CanReturn { get; set; }
        public List<int> Coins { get; set; }
    }
}