namespace SrpLab.srpLabRefactor
{
    public class GiftMessageFormatter
    {
        public string GiftMessageCard(string fromName, IEnumerable<string> skus, decimal grandTotal) =>
            $"Dear friend,\nA gift from {fromName} awaits ({string.Join(", ", skus)}).\nTotal surprise value: {grandTotal:C}\n";
    }
}
