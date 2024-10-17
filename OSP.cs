using System;
using System.Collections.Generic;

public interface IDiscountStrategy
{
    double CalculateDiscount(double amount);
}

public class RegularCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount;
    }
}

public class SilverCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.9;
    }
}

public class GoldCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.8;
    }
}

public class PlatinumCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.7;
    }
}

public class DiscountCalculator
{
    private readonly IDiscountStrategy _discountStrategy;

    public DiscountCalculator(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public double CalculateDiscount(double amount)
    {
        return _discountStrategy.CalculateDiscount(amount);
    }
}

class Program
{
    static void Main()
    {
        double amount = 1000;

        DiscountCalculator regularCustomerCalculator = new DiscountCalculator(new RegularCustomerDiscount());
        Console.WriteLine($"Скидка для обычного клиента: {regularCustomerCalculator.CalculateDiscount(amount)}");

        DiscountCalculator silverCustomerCalculator = new DiscountCalculator(new SilverCustomerDiscount());
        Console.WriteLine($"Скидка для клиента Silver: {silverCustomerCalculator.CalculateDiscount(amount)}");

        DiscountCalculator goldCustomerCalculator = new DiscountCalculator(new GoldCustomerDiscount());
        Console.WriteLine($"Скидка для клиента Gold: {goldCustomerCalculator.CalculateDiscount(amount)}");

        DiscountCalculator platinumCustomerCalculator = new DiscountCalculator(new PlatinumCustomerDiscount());
        Console.WriteLine($"Скидка для клиента Platinum: {platinumCustomerCalculator.CalculateDiscount(amount)}");
    }
}
