namespace SrpLab.srpLabRefactor
{
    public class InvoiceNumberGenerator
    {
        private static int _seq = 1000;
        public string Next(DateOnly periodStart) => $"INV-{periodStart:yyyyMM}-{++_seq:D5}";
    }
}
