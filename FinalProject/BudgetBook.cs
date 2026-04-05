using System;
using System.Collections.Generic;

public class BudgetBook
{
    // Holds the history of all income and expenses
    private List<Transaction> history = new List<Transaction>();

    public void AddEntry(Transaction t)
    {
        history.Add(t);
    }

    public void PrintHistory()
    {
        Console.WriteLine("\n--- ALL TRANSACTIONS ---");
        foreach (Transaction t in history)
        {
            t.Show(); // Polymorphism will pick the right Show method
        }
    }
}