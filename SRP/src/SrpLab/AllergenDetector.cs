namespace SrpLab.srpLabRefactor
{
    public class AllergenDetector
    {
        public IReadOnlyList<string> DetectAllergens(KitchenOrder order)
        {
            var hits = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var ing in order.Items.SelectMany(i => i.Ingredients))
            {
                if (ing.Contains("milk") || ing.Contains("cheese")) hits.Add("dairy");
                if (ing.Contains("wheat") || ing.Contains("flour")) hits.Add("gluten");
                if (ing.Contains("peanut") || ing.Contains("almond")) hits.Add("nuts");
                if (ing.Contains("shrimp") || ing.Contains("crab")) hits.Add("shellfish");
            }
            return hits.OrderBy(x => x).ToList();
        }
    }
}
