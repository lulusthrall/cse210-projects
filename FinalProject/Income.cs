using System;

public class Income : Transaction
{
    public Income(double a, string d) : base(a, d)
    {
        // empty constructor because it just uses the base
    }

    public override void Show()
    {
        Console.WriteLine("INCOME RECORDED: +" + amount + " on " + date);
    }
}