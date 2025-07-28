using System.Linq;

namespace ChangeCalculation
{
    public static class ChangeCalculator
    {
        public static object CalculateChange(int change, List<int> availableCoins)
        {
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