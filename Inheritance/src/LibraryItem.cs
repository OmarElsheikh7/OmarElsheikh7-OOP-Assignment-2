public class LibraryItem
{
    public string CatalogNumber { get; }
    public string Title { get; }
    public decimal BaseLateFee { get; private set; }
    public bool IsWithdrawn { get; private set; }

    // Internal allows the Loan class to update this safely without exposing it publicly
    internal bool IsOnLoan { get; set; }

    public int LoanPeriodDays { get; }
    private decimal _lateFeeMultiplier;

    // Protected constructor prevents 'new LibraryItem()'
    protected LibraryItem(string catalogNum, string title, decimal baseFee, int loanPeriodDays, decimal feeMultiplier)
    {
        if (string.IsNullOrWhiteSpace(catalogNum)) throw new ArgumentException("Catalog number is required");
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required");
        if (baseFee <= 0) throw new ArgumentException("Base fee must be positive");

        CatalogNumber = catalogNum;
        Title = title;
        BaseLateFee = baseFee;
        LoanPeriodDays = loanPeriodDays;
        _lateFeeMultiplier = feeMultiplier;
    }

    public void SetPrice(decimal newFee)
    {
        if (newFee <= 0) throw new ArgumentException("Fee must be positive");
        BaseLateFee = newFee;
    }

    public void Withdraw() => IsWithdrawn = true;
    public void Restore() => IsWithdrawn = false;

    // One method that handles the math for all child types
    public decimal DailyLateFee => BaseLateFee * _lateFeeMultiplier;
}
