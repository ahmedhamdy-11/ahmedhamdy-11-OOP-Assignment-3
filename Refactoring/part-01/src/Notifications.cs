
namespace RefactoringLab;

public interface INotificationSender
{
    void Send(string to, string message);
}

public class EmailNotificationSender : INotificationSender
{
    public void Send(string to, string message) =>
        Console.WriteLine($"[email] {to}: {message}");
}

public class SmsNotificationSender : INotificationSender
{
    public void Send(string to, string message) =>
        Console.WriteLine($"[sms] {to}: {message}");
}

public class WhatsAppNotificationSender : INotificationSender
{
    public void Send(string to, string message) =>
        Console.WriteLine($"[whatsapp] {to}: {message}");
}

public class UrgentNotificationSender(INotificationSender innerSender) : INotificationSender
{
    public void Send(string to, string message) =>
        innerSender.Send(to, $"[URGENT] {message}");
}

public class ScheduledNotificationSender(INotificationSender innerSender, DateTime sendAt) : INotificationSender
{
    public DateTime SendAt { get; set; } = sendAt;

    public void Send(string to, string message)
    {
        Console.WriteLine($"[scheduled for {SendAt:g}]");
        innerSender.Send(to, message);
    }
}