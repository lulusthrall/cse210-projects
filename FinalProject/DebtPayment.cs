using System;

public class DebtPayment : Transaction
{
    public int debtorId; // This tracks which person I paid

    public DebtPayment(double a, string d, int id) : base(a, d)
    {
        debtorId = id;
    }

    public override void Show()
    {
        Console.WriteLine("PAID DEBT: -$" + amount + " to ID " + debtorId + " date: " + date);
    }
}