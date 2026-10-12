namespace SrpLab.srpLabRefactor
{
    public class PickerScriptGenerator
    {
        public string PickerScript(IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> path, IEnumerable<string> shortages) =>
            string.Join('\n', path.Select((s, i) => $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}")) + "\nSHORTAGES: " + (shortages.Any() ? string.Join(", ", shortages) : "none");
    }
}
