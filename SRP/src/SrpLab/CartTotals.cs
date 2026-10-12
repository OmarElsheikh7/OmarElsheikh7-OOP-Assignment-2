namespace SrpLab.srpLabRefactor
{
    // --- 2. Checkout Basket ---
    public class CartTotals
    {
        private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();
        public IReadOnlyList<(string Sku, decimal Price, int Qty)> Lines => _lines;
        public void AddLine(string sku, decimal price, int qty) => _lines.Add((sku, price, qty));
        public decimal SubTotal() => _lines.Sum(l => l.Price * l.Qty);
    }
}
