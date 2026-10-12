namespace SrpLab.srpLabRefactor
{
    // --- 4. Grade Book ---
    public class StudentScores
    {
        private readonly Dictionary<string, List<decimal>> _scores = new(StringComparer.OrdinalIgnoreCase);
        public void Record(string studentId, decimal score)
        {
            if (!_scores.TryGetValue(studentId, out var list)) _scores[studentId] = list = new List<decimal>();
            list.Add(score);
        }
        public decimal Average(string studentId) => _scores.TryGetValue(studentId, out var list) && list.Count > 0 ? Math.Round(list.Average(), 2) : 0m;
        public IEnumerable<string> StudentIds => _scores.Keys;
    }
}
