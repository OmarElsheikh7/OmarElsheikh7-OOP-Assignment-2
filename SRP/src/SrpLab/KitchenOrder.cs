namespace SrpLab.srpLabRefactor
{
    // --- 5. Kitchen Ticket ---
    public class KitchenOrder
    {
        public List<(string Item, List<string> Ingredients, int PrepMinutes)> Items { get; } = new();
        public void AddItem(string item, IEnumerable<string> ingredients, int prep) =>
            Items.Add((item, ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList(), prep));
    }
}
