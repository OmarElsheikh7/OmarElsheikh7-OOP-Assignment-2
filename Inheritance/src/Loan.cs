public class Loan
{
    public string LoanId { get; }
    public DateOnly BorrowDate { get; }
    public DateOnly DueDate { get; }
    public DateOnly? ReturnDate { get; private set; }
    public Member Member { get; }
    public LibraryItem Item { get; }
    public LoanStatus Status { get; private set; }

    // Internal constructor ensures outside code cannot create Loans arbitrarily
    internal Loan(Member member, LibraryItem item, DateOnly borrowDate)
    {
        LoanId = Guid.NewGuid().ToString();
        BorrowDate = borrowDate;
        DueDate = borrowDate.AddDays(item.LoanPeriodDays);
        Member = member;
        Item = item;
        Status = LoanStatus.Borrowed;
    }

    public void ReturnItem(DateOnly returnDate)
    {
        if (Status != LoanStatus.Borrowed) throw new InvalidOperationException("This loan is not currently active.");
        if (returnDate < BorrowDate) throw new ArgumentException("Return date cannot be earlier than the borrow date.");

        Status = LoanStatus.Returned;
        ReturnDate = returnDate;
        Item.IsOnLoan = false; // Frees the item
    }

    public void MarkAsLost()
    {
        if (Status != LoanStatus.Borrowed) throw new InvalidOperationException("Only borrowed items can be marked lost.");
        Status = LoanStatus.Lost;
    }

    public decimal LateFee
    {
        get
        {
            if (Status != LoanStatus.Returned || !ReturnDate.HasValue) return 0;

            int lateDays = ReturnDate.Value.DayNumber - DueDate.DayNumber;
            if (lateDays <= 0) return 0;

            decimal baseCalculatedFee = lateDays * Item.DailyLateFee;
            decimal discountAmount = baseCalculatedFee * Member.DiscountPercentage;

            return baseCalculatedFee - discountAmount;
        }
    }
}