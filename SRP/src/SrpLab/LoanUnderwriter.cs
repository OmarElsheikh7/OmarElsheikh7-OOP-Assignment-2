namespace SrpLab.srpLabRefactor
{
    public class LoanUnderwriter
    {
        public decimal RiskScore(LoanApplication app)
        {
            decimal score = 100m - (Math.Max(0, 700 - app.CreditScore) * 0.15m);
            if (app.EmploymentMonths < 6) score -= 20m;
            if (app.Amount > 50_000m && !app.HasCollateral) score -= 25m;
            if (app.Amount > 150_000m) score -= 10m;
            return Math.Clamp(score, 0m, 100m);
        }
        public bool IsEligible(decimal risk, int creditScore) => risk >= 55m && creditScore >= 580;
    }
}
