// Base class for everything
public class Transaction
{
    public double amount;
    public string date;

    public Transaction(double amount, string date)
    {
        this.amount = amount;
        this.date = date;
    }

    public virtual void Show()
    {
        Console.WriteLine(date + ": " + amount);
    }
}