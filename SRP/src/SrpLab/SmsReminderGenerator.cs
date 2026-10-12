namespace SrpLab.srpLabRefactor
{
    public class SmsReminderGenerator
    {
        public string SmsReminder(DateTimeOffset slot, string clinicPhone) => $"Reminder: appointment {slot:MMM dd HH:mm}. Call {clinicPhone} to reschedule.";
    }
}
