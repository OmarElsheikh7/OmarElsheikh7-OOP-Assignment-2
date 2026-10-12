namespace PatternsLab.Problems.Builder;

public class CourseRegistrationBuilder
{
    private string _studentEmail;
    private string _courseCode;
    private string _accessMode;
    private string? _groupCode;
    private string? _discountCode;
    private bool _sendWhatsApp;
    private bool _sendEmailWelcome;
    private string? _mentorNote;
    private DateOnly? _preferredStart;


    public CourseRegistrationBuilder(string studentEmail, string courseCode)
    {
        if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email required");
        if (string.IsNullOrWhiteSpace(courseCode)) throw new ArgumentException("course required");

        _studentEmail = studentEmail;
        _courseCode = courseCode;
    }

    public CourseRegistrationBuilder AsLiveGroup(string groupCode)
    {
        _accessMode = "LiveGroup";
        _groupCode = groupCode;
        return this;
    }

    public CourseRegistrationBuilder AsVideosOnly()
    {
        _accessMode = "VideosOnly";
        _groupCode = null;
        return this;
    }

    public CourseRegistrationBuilder WithDiscount(string discountCode)
    {
        _discountCode = discountCode;
        return this;
    }

    public CourseRegistrationBuilder EnableWhatsApp()
    {
        _sendWhatsApp = true;
        return this;
    }

    public CourseRegistrationBuilder EnableEmailWelcome()
    {
        _sendEmailWelcome = true;
        return this;
    }

    public CourseRegistrationBuilder WithMentorNote(string note)
    {
        _mentorNote = note;
        return this;
    }

    public CourseRegistrationBuilder WithPreferredStart(DateOnly start)
    {
        _preferredStart = start;
        return this;
    }

    public CourseRegistration Build()
    {
        if (string.IsNullOrWhiteSpace(_accessMode))
            throw new InvalidOperationException("Access mode must be set using AsLiveGroup() or AsVideosOnly().");

        if (_accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");

        if (_accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");

        return new CourseRegistration(
            _studentEmail,
            _courseCode,
            _accessMode,
            _groupCode,
            _discountCode,
            _sendWhatsApp,
            _sendEmailWelcome,
            _mentorNote,
            _preferredStart);
    }
}
