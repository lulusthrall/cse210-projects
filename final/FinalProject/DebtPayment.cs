public class DebtPayment : Transaction
{
    public int debtorId;

    public DebtPayment(double a, string d, int id) : base(a, d)
    {
        debtorId = id;
    }

    public override void Show()
    {
        Console.WriteLine("DEBT PAY: -" + amount + " for ID " + debtorId);
    }
}