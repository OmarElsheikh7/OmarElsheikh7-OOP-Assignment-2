namespace SrpLab.srpLabRefactor
{
    public class SlaCalculator
    {
        public DateTimeOffset Deadline(DateTimeOffset opened, string priority) => opened.AddHours(priority == "P1" ? 4 : priority == "P2" ? 24 : 72);
    }
}
