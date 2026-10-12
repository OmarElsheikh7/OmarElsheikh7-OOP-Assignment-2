namespace SrpLab.srpLabRefactor
{
    public class DunningEmailFormatter
    {
        public string DunningEmail(string name, DateOnly asOf, decimal amount, string invoice, int fails)
        {
            var severity = fails <= 1 ? "friendly reminder" : fails == 2 ? "second notice" : "final notice before suspension";
            return $"Subject: {severity} {invoice}\nHi {name},\nBalance {amount:C} as of {asOf:o} ({fails} failures).\n";
        }
    }
}
