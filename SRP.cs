using System;
using System.Collections.Generic;

public class Item
{
    public string Name { get; set; }
    public double Price { get; set; }
}

public class Invoice
{
    public int Id { get; set; }
    public List<Item> Items { get; set; }
    public double TaxRate { get; set; }

    public Invoice()
    {
        Items = new List<Item>();
    }
}

public class InvoiceCalculator
{
    public double CalculateTotal(Invoice invoice)
    {
        double subTotal = 0;
        foreach (var item in invoice.Items)
        {
            subTotal += item.Price;
        }
        return subTotal + (subTotal * invoice.TaxRate);
    }
}

public class InvoiceRepository
{
    public void SaveToDatabase(Invoice invoice)
    {
        // Логика для сохранения счета в базу данных
        Console.WriteLine($"Счет с ID {invoice.Id} сохранен в базу данных.");
    }
}

class Program
{
    static void Main()
    {
        // Создаем счет-фактуру
        Invoice invoice = new Invoice { Id = 1, TaxRate = 0.15 };
        invoice.Items.Add(new Item { Name = "Товар 1", Price = 100 });
        invoice.Items.Add(new Item { Name = "Товар 2", Price = 200 });

        // Используем калькулятор для расчета суммы счета
        InvoiceCalculator calculator = new InvoiceCalculator();
        double totalAmount = calculator.CalculateTotal(invoice);
        Console.WriteLine($"Итоговая сумма счета: {totalAmount}");

        // Сохраняем счет в базу данных
        InvoiceRepository repository = new InvoiceRepository();
        repository.SaveToDatabase(invoice);
    }
}
