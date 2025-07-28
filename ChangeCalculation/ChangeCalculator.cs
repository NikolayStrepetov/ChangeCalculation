using System.Linq;

namespace ChangeCalculation
{
    public static class ChangeCalculator
    {
        private static readonly List<int> _validCoins = new List<int> { 100, 50, 10, 5, 2, 1 };

        public static object CalculateChange(int change, List<int> availableCoins)
        {
            var invalidCoins = availableCoins.Where(x => !_validCoins.Contains(x)).ToList();
            if (invalidCoins.Count > 0)
            {
                throw new ArgumentException("Недопустимые номиналы монет! Допустимые: 100, 50, 10, 5, 2, 1.");
            }

            if (change < 0)
            {
                throw new ArgumentException("Сумма сдачи не может быть отрицательной!", nameof(change));
            }

            if (change == 0)
            {
                return "Сдача не требуется!";
            }

            availableCoins = availableCoins.OrderByDescending(x => x).ToList();
            var result = new List<int>();

            foreach (var coin in availableCoins)
            {
                if (change >= coin)
                {
                    change -= coin;
                    result.Add(coin);
                }
            }

            return change == 0 ? result : "Оплатите картой!";
        }
    }
}