namespace SrpLab.srpLabRefactor
{
    public class AcademicPolicyEvaluator
    {
        public string Letter(decimal avg) => avg >= 90 ? "A" : avg >= 80 ? "B" : avg >= 70 ? "C" : avg >= 60 ? "D" : "F";
        public bool MeetsHonorRoll(decimal avg, string letter) => avg >= 85 && letter is "A" or "B";
    }
}
