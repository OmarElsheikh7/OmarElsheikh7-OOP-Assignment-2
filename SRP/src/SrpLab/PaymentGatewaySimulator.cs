namespace SrpLab.srpLabRefactor
{
    public class PaymentGatewaySimulator
    {
        public string AuthorizePaymentStub(decimal grandTotal, string cardLast4, int lineCount) =>
            $"AUTH-{Math.Abs($"{grandTotal:0.00}|{cardLast4}|{lineCount}".GetHashCode()):X8}";
    }
}
