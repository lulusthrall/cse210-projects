using System;

// This is the base class for the transactions
public class Transaction
{
    // using public variables because it is easier to access
    public double amount;
    public string date;

    public Transaction(double amount, string date)
    {
        this.amount = amount;
        this.date = date;
    }

    // virtual so the other classes can override this later
    public virtual void Show()
    {
        Console.WriteLine("Date: " + date + " Amount: " + amount);
    }
}