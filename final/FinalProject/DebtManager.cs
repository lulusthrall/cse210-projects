using System;
using System.Collections.Generic;

public class DebtManager
{
    private List<Debtor> debtors = new List<Debtor>();

    // Adds a new bill to the list
    public void AddDebtor(string n, double b)
    {
        debtors.Add(new Debtor(n, b));
    }

    // Finds the right debt in the list and pays it
    public void MakePayment(int index, double amt)
    {
        if (index >= 0 && index < debtors.Count)
        {
            debtors[index].Pay(amt);
        }
    }
    public void ShowDebts()
    {
        Console.WriteLine("\n--- YOUR DEBTS ---");
        for (int i = 0; i < debtors.Count; i++)
        {
            Console.WriteLine(i + ". " + debtors[i].name + ": $" + debtors[i].GetBalance());
        }
    }
}