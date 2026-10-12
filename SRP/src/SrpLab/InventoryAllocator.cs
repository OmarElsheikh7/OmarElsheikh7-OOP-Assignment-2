namespace SrpLab.srpLabRefactor
{
    public class InventoryAllocator
    {
        public IReadOnlyList<(string Sku, int Allocated)> Allocate(PickListRequirements reqs) =>
            reqs.Lines.Select(l => (l.Sku, Math.Min(l.Needed, l.OnHand))).ToList();
    }
}
