using System;
using System.Collections.Generic;

public class DebtManager
{
    // A list to hold all the people I owe money to
    private List<Debtor> debtors = new List<Debtor>();

    public void AddDebtor(string n, double b)
    {
        debtors.Add(new Debtor(n, b));
    }

    public void MakePayment(int index, double amt)
    {
        // making sure the index is actually in the list
        if (index >= 0 && index < debtors.Count)
        {
            debtors[index].Pay(amt);
        }
        else
        {
            Console.WriteLine("Error: That debt number does not exist.");
        }
    }

    public void ShowAllDebts()
    {
        Console.WriteLine("\n--- LIST OF DEBTS ---");
        for (int i = 0; i < debtors.Count; i++)
        {
            // getting the info from the debtor class
            Console.WriteLine(i + ". " + debtors[i].name + " balance: $" + debtors[i].GetBalance());
        }
    }
}