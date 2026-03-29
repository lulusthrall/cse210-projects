using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        // Setup the managers
        DebtManager myDebt = new DebtManager();
        BudgetBook myBook = new BudgetBook();

        // Adding some starting data so the list isn't empty
        myDebt.AddDebtor("Credit Card", 1000);
        myDebt.AddDebtor("Car Loan", 5000);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Finance Tracker ---");
            Console.WriteLine("1. Show Debts");
            Console.WriteLine("2. Pay a Debt");
            Console.WriteLine("3. Add Income");
            Console.WriteLine("4. See History");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                myDebt.ShowDebts();
            }
            else if (choice == "2")
            {
                myDebt.ShowDebts();
                Console.Write("Which debt number? ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("How much are you paying? ");
                double amt = double.Parse(Console.ReadLine());

                myDebt.MakePayment(id, amt);
                // Also log it in the budget book
                myBook.AddEntry(new DebtPayment(amt, "2026-03-29", id));
            }
            else if (choice == "3")
            {
                Console.Write("Income amount: ");
                double amt = double.Parse(Console.ReadLine());
                myBook.AddEntry(new Income(amt, "2026-03-29"));
            }
            else if (choice == "4")
            {
                myBook.PrintHistory();
            }
            else
            {
                running = false;
            }
        }
    }
}