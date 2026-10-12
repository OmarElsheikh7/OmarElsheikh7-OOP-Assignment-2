namespace SrpLab.srpLabRefactor
{
    public class PagerNotifier
    {
        public List<string> Log { get; } = new();
        public void CheckAndAlert(int bed, int acuity) { if (acuity >= 8) Log.Add($"CODE-YELLOW bed={bed} at {DateTime.UtcNow:HH:mm}"); }
    }
}
