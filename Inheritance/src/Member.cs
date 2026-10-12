public class Member : Person
{
    private List<Loan> _loans = new List<Loan>();
    public IReadOnlyList<Loan> Loans => _loans.AsReadOnly();

    private int _maxLoans;
    public decimal DiscountPercentage { get; }

    protected Member(string id, string name, string phone, int maxLoans, decimal discountPercentage)
        : base(id, name, phone)
    {
        _maxLoans = maxLoans;
        DiscountPercentage = discountPercentage;
    }

    public Loan Borrow(LibraryItem item, DateOnly borrowDate)
    {
        if (item.IsWithdrawn) throw new InvalidOperationException("Cannot borrow a withdrawn item.");
        if (item.IsOnLoan) throw new InvalidOperationException("Item is already on loan.");

        // Count active loans without LINQ
        int activeLoans = 0;
        foreach (var l in _loans)
        {
            if (l.Status == LoanStatus.Borrowed) activeLoans++;
        }

        if (activeLoans >= _maxLoans) throw new InvalidOperationException($"Cannot exceed maximum limit of {_maxLoans} items.");

        Loan newLoan = new Loan(this, item, borrowDate);
        _loans.Add(newLoan);
        item.IsOnLoan = true;

        return newLoan;
    }
}
