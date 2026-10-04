using RefactoringLab;

Console.WriteLine();
Console.WriteLine("---------------------------------------");
Console.WriteLine();

var aramexShippingCalculator = new ShippingCostCalculator(new AramexCarrier());
Console.WriteLine($"Aramex 2kg → {aramexShippingCalculator.Calculate(2)}");

var fedexShippingCalculator = new ShippingCostCalculator(new FedExCarrier());
Console.WriteLine($"FedEx 2kg → {fedexShippingCalculator.Calculate(2)}");

var dhlShippingCalculator = new ShippingCostCalculator(new DHLCarrier());
Console.WriteLine($"DHL 2kg → {dhlShippingCalculator.Calculate(2)}");

Console.WriteLine();

var repo = new SqlOrderRepository();
var email = new SmtpEmailSender();
var orderProcessor = new OrderProcessor(repo, email);

orderProcessor.Process(1001, "customer@example.com");

Console.WriteLine();

var urgentScheduledEmail = new UrgentNotificationSender(
    new ScheduledNotificationSender(
        new EmailNotificationSender(),
        DateTime.Today.AddHours(18)
    )
);

urgentScheduledEmail.Send("customer@example.com", "Your order ships tomorrow");