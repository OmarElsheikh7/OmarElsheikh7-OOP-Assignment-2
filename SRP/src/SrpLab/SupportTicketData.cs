namespace SrpLab.srpLabRefactor
{
    // --- 8. Support Ticket ---
    public class SupportTicketData
    {
        public string Id { get; }
        public string Subject { get; }
        public string Body { get; set; }
        public DateTimeOffset OpenedAt { get; }
        public SupportTicketData(string id, string sub, string body, DateTimeOffset opened) { Id = id; Subject = sub; Body = body; OpenedAt = opened; }
    }
}
