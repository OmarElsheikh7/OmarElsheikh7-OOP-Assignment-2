namespace SrpLab.srpLabRefactor
{
    public class ThermalTicketPrinter
    {
        public string RenderThermalTicket(KitchenOrder order, int num, int eta, IReadOnlyList<string> allergens)
        {
            var line = new string('=', 32);
            var body = string.Join('\n', order.Items.Select(i => $"* {i.Item.ToUpperInvariant()} ({i.PrepMinutes}m)"));
            var alg = allergens.Count == 0 ? "none" : string.Join(",", allergens);
            return $"{line}\nORDER #{num}\nETA {eta} MIN\n{body}\nALLERGENS: {alg}\n{line}\n";
        }
    }
}
