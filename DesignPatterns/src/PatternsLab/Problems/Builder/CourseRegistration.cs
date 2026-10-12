namespace PatternsLab.Problems.Builder;

public sealed class CourseRegistration
{
    public string StudentEmail { get; }
    public string CourseCode { get; }
    public string AccessMode { get; }
    public string? GroupCode { get; }
    public string? DiscountCode { get; }
    public bool SendWhatsApp { get; }
    public bool SendEmailWelcome { get; }
    public string? MentorNote { get; }
    public DateOnly? PreferredStart { get; }

    public CourseRegistration(
        string studentEmail,
        string courseCode,
        string accessMode,
        string? groupCode,
        string? discountCode,
        bool sendWhatsApp,
        bool sendEmailWelcome,
        string? mentorNote,
        DateOnly? preferredStart)
    {
        if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email required");
        if (string.IsNullOrWhiteSpace(courseCode)) throw new ArgumentException("course required");

        if (accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");
        if (accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");

        StudentEmail = studentEmail;
        CourseCode = courseCode;
        AccessMode = accessMode;
        GroupCode = groupCode;
        DiscountCode = discountCode;
        SendWhatsApp = sendWhatsApp;
        SendEmailWelcome = sendEmailWelcome;
        MentorNote = mentorNote;
        PreferredStart = preferredStart;
    }

    public override string ToString()
        => $"{StudentEmail} → {CourseCode} [{AccessMode}] group={GroupCode ?? "-"} discount={DiscountCode ?? "-"} wa={SendWhatsApp} mail={SendEmailWelcome}";
}

public static class RegistrationCallSites
{
    public static CourseRegistration CreateLiveStudent()
    {
        return new CourseRegistrationBuilder("sara@mail.com", "SEF-101")
            .AsLiveGroup("G1")
            .WithDiscount("EARLY10")
            .EnableWhatsApp()
            .EnableEmailWelcome()
            .WithMentorNote("Needs evening slot")
            .WithPreferredStart(new DateOnly(2026, 10, 1))
            .Build();
    }

    public static CourseRegistration CreateVideosOnly()
    {
        return new CourseRegistrationBuilder("ali@mail.com", "SEF-101")
            .AsVideosOnly()
            .EnableEmailWelcome()
            .Build();
    }
}
