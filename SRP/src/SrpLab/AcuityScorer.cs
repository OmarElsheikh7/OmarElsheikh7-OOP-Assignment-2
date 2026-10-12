namespace SrpLab.srpLabRefactor
{
    public class AcuityScorer
    {
        public int Score(int hr, int spo2)
        {
            var s = (hr > 120 || hr < 45) ? 4 : (hr > 100) ? 2 : 0;
            s += spo2 < 90 ? 5 : spo2 < 94 ? 2 : 0;
            return Math.Min(s, 10);
        }
    }
}
