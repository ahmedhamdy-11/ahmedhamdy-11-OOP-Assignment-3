namespace RefactoringLab;

public class ShippingCostCalculator(ICarrier carrier)
{
    public decimal Calculate(decimal weightKg)
    {
        return carrier.CalculateShippingCost(weightKg);
    }
}

public interface ICarrier
{
    decimal CalculateShippingCost(decimal weightKg);
}

public class FedExCarrier : ICarrier
{
    public decimal CalculateShippingCost(decimal weightKg)
        => weightKg * 15m;
}

public class DHLCarrier : ICarrier
{
    public decimal CalculateShippingCost(decimal weightKg)
        => weightKg * 18m;
}

public class AramexCarrier : ICarrier
{
    public decimal CalculateShippingCost(decimal weightKg)
        => weightKg * 12m;
}