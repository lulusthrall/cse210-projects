public class Debtor
{
    public string name;
    private double balance;

    public Debtor(string n, double b)
    {
        name = n;
        balance = b;
    }

    // This is the only way to change the balance
    public void Pay(double amt)
    {
        balance = balance - amt;
    }

    public double GetBalance()
    {
        return balance;
    }
}