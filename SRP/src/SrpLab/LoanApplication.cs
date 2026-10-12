namespace SrpLab.srpLabRefactor
{
    // --- 6. Loan Desk ---
    public record LoanApplication(decimal Amount, int CreditScore, int EmploymentMonths, bool HasCollateral);
}
