namespace SrpLab.srpLabRefactor
{
    public class HandoffNoteFormatter
    {
        public string BuildNote(int bed, string? patient, int acuity) => patient == null ? $"Bed {bed}: empty" :
            $"[HANDOFF {DateTime.UtcNow:yyyy-MM-dd}] Bed {bed} · {patient} · acuity={acuity} · {(acuity >= 8 ? "ESCALATE" : acuity >= 4 ? "WATCH" : "STABLE")}";
    }
}
