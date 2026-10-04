namespace RefactoringLab;

public class OrderProcessor(IOrderRepository repo, IEmailSender email)
{
    public void Process(int orderId, string customerEmail)
    {
        var processedAt = DateTime.UtcNow;
        repo.Save(orderId, processedAt);
        email.Send(customerEmail, $"Your order {orderId} has been processed at {processedAt:O}");
    }
}

public interface IOrderRepository
{
    void Save(int orderId, DateTime processedAt);
}

public interface IEmailSender
{
    void Send(string to, string body);
}

public class SqlOrderRepository : IOrderRepository
{
    public void Save(int orderId, DateTime processedAt) =>
        Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
}

public class SmtpEmailSender : IEmailSender
{
    public void Send(string to, string body) =>
        Console.WriteLine($"[SMTP] to={to} body={body}");
}