namespace ChangeCalculation
{
    public static class ChangeCalculator
    {
        public static object CalculateChange(int change, List<int> availableCoins)
        {
            if (availableCoins.Contains(change))
            {
                return new List<int> { change };
            }
            else
            {
                return "Оплатите картой!";
            }
        }
    }
}