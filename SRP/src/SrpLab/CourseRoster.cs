namespace SrpLab.srpLabRefactor
{
    // --- 3. Course Enrollment ---
    public class CourseRoster
    {
        private readonly HashSet<string> _seated = new(StringComparer.OrdinalIgnoreCase);
        private readonly List<string> _waitlist = new();
        public int Capacity { get; }
        public CourseRoster(int capacity) => Capacity = capacity;
        public string Register(string email)
        {
            if (_seated.Contains(email) || _waitlist.Contains(email)) return "ALREADY_REGISTERED";
            if (_seated.Count < Capacity) { _seated.Add(email); return "SEATED"; }
            _waitlist.Add(email); return $"WAITLIST:{_waitlist.Count}";
        }
        public int WaitlistPosition(string email) => _waitlist.FindIndex(x => x.Equals(email, StringComparison.OrdinalIgnoreCase)) + 1;
        public bool IsSeated(string email) => _seated.Contains(email);
    }
}
