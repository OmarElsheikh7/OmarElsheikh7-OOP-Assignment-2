namespace SrpLab.srpLabRefactor
{
    public class TicketCommsFormatter
    {
        public string DraftPublicReply(string id, string priority, string agent, DateTimeOffset deadline) =>
            $"Hi,\n{(priority == "P1" ? "We are treating this as a critical incident." : "Thanks for reaching out.")}\nTicket {id} is with {agent}. Next update before {deadline:u}.\n";
    }
}
