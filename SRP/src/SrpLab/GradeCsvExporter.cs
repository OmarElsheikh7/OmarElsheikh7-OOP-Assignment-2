namespace SrpLab.srpLabRefactor
{
    public class GradeCsvExporter
    {
        public string ExportCsv(StudentScores scores, AcademicPolicyEvaluator policy)
        {
            var rows = new List<string> { "studentId,average,letter,honor" };
            foreach (var id in scores.StudentIds.OrderBy(x => x))
            {
                var avg = scores.Average(id);
                rows.Add($"{id},{avg},{policy.Letter(avg)},{(policy.MeetsHonorRoll(avg, policy.Letter(avg)) ? 1 : 0)}");
            }
            return string.Join('\n', rows);
        }
    }
}
