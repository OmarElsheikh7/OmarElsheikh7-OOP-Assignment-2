namespace SrpLab.srpLabRefactor
{
    public class WelcomePacketGenerator
    {
        public string WelcomePacketMarkdown(string courseCode, string studentName, string status) =>
            $"# Welcome to {courseCode}\nHi {studentName},\nYour status: **{status}**.\nBring a laptop. Discord onboarding link: https://example.invalid/{courseCode.ToLowerInvariant()}\n";
    }
}
