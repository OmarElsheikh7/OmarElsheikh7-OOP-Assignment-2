namespace SrpLab.srpLabRefactor
{
    // --- 7. Subscription Billing ---
    public class ProrationCalculator
    {
        public decimal Prorate(DateOnly start, DateOnly end, DateOnly activeFrom, decimal monthlyPrice)
        {
            if (activeFrom <= start) return monthlyPrice;
            if (activeFrom >= end) return 0m;
            var total = end.DayNumber - start.DayNumber;
            return total <= 0 ? monthlyPrice : Math.Round(monthlyPrice * (end.DayNumber - activeFrom.DayNumber) / total, 2);
        }
    }
}
