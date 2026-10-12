namespace SrpLab.srpLabRefactor
{
    // --- 10. Warehouse Pick List ---
    public class PickListRequirements
    {
        public List<(string Sku, string Aisle, int Bin, int Needed, int OnHand)> Lines { get; } = new();
        public void AddNeed(string sku, string aisle, int bin, int needed, int onHand) => Lines.Add((sku, aisle, bin, needed, onHand));
    }
}
