namespace SrpLab.srpLabRefactor
{
    public class IcsCalendarExporter
    {
        public string ToIcs(DateTimeOffset slot, int duration, string patient, string clinician) =>
            $"BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\nUID:{Guid.NewGuid()}\nDTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\nDTEND:{slot.AddMinutes(duration):yyyyMMdd'T'HHmmss'Z'}\nSUMMARY:Visit {patient} / {clinician}\nEND:VEVENT\nEND:VCALENDAR\n";
    }
}
