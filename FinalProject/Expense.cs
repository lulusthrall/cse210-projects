using System;

public class Expense : Transaction
{
    public string category;

    public Expense(double a, string d, string c) : base(a, d)
    {
        category = c;
    }

    public override void Show()
    {
        Console.WriteLine("EXPENSE: -" + amount + " for " + category + " date: " + date);
    }
}