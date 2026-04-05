using System;

public class Debtor
{
    public string name;
    private double balance; // Keeping this private for encapsulation

    public Debtor(string n, double b)
    {
        name = n;
        balance = b;
    }

    public void Pay(double amt)
    {
        // Subtract the payment from what I owe
        balance = balance - amt;
    }

    public double GetBalance()
    {
        return balance;
    }
}