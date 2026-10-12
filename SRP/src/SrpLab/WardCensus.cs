namespace SrpLab.srpLabRefactor
{
    // --- 9. Ward Board ---
    public class WardCensus
    {
        public Dictionary<int, string> BedPatient { get; } = new();
        public void AssignBed(int bed, string patient) => BedPatient[bed] = patient.Trim().ToUpperInvariant();
    }
}
