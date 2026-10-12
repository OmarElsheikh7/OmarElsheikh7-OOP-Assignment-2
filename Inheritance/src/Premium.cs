
public class Premium : Member
{
    public Premium(string id, string name, string phone, decimal discountPercentage)
        : base(id, name, phone, 10, discountPercentage) { } // 10 max items, custom discount

    public int ReadingPoints
    {
        get
        {
            int points = 0;
            // No LINQ allowed
            foreach (var loan in Loans)
            {
                if (loan.Status == LoanStatus.Returned) points += 5;
            }
            return points;
        }
    }
}