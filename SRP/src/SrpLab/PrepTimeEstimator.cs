namespace SrpLab.srpLabRefactor
{
    public class PrepTimeEstimator
    {
        public int EstimatedReadyMinutes(KitchenOrder order, int stations, bool hasAllergens)
        {
            if (stations <= 0) stations = 1;
            var seq = order.Items.Sum(i => i.PrepMinutes);
            var par = (int)Math.Ceiling(seq / (double)stations) + (hasAllergens ? 3 : 0);
            return Math.Max(par, order.Items.Count == 0 ? 0 : order.Items.Max(i => i.PrepMinutes));
        }
    }
}
