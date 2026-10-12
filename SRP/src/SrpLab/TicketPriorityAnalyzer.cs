namespace SrpLab.srpLabRefactor
{
    public class TicketPriorityAnalyzer
    {
        public string AnalyzePriority(string subject, string body)
        {
            var b = (subject + " " + body).ToLowerInvariant();
            return b.Contains("down") || b.Contains("outage") ? "P1" : b.Contains("urgent") || b.Contains("asap") ? "P2" : "P3";
        }
    }
}
