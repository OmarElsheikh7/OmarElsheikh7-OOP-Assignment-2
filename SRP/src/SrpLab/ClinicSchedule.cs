namespace SrpLab.srpLabRefactor
{
    public class ClinicSchedule
    {
        private readonly HashSet<DateTimeOffset> _booked = new();
        public TimeOnly Open { get; }
        public TimeOnly Close { get; }
        public int SlotMinutes { get; }

        public ClinicSchedule(TimeOnly open, TimeOnly close, int slotMinutes)
        {
            Open = open; Close = close; SlotMinutes = slotMinutes;
        }
        public bool IsWithinBusinessHours(DateTimeOffset when)
        {
            if (when.DayOfWeek is DayOfWeek.Friday or DayOfWeek.Saturday) return false;
            var t = TimeOnly.FromDateTime(when.DateTime);
            return t >= Open && t.AddMinutes(SlotMinutes) <= Close;
        }
        public bool TryBook(DateTimeOffset slot)
        {
            if (!IsWithinBusinessHours(slot) || _booked.Contains(slot)) return false;
            _booked.Add(slot); return true;
        }
        public DateTimeOffset Align(DateTimeOffset from) => new(from.Year, from.Month, from.Day, from.Hour, from.Minute - (from.Minute % SlotMinutes), 0, from.Offset);
    }
}
