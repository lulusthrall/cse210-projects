public class Income : Transaction
{
    // Just a basic income class
    public Income(double a, string d) : base(a, d) { }

    public override void Show()
    {
        Console.WriteLine("INCOME: +" + amount + " on " + date);
    }
}