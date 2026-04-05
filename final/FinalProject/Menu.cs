using System;

public class Menu
{
    private DebtManager myDebts = new DebtManager();
    private BudgetBook myBook = new BudgetBook();

    public void Run()
    {
        // Adding some test data so the screen isn't blank
        myDebts.AddDebtor("Credit Card", 1500.00);
        myDebts.AddDebtor("Medical Bill", 300.00);

        bool go = true;
        while (go)
        {
            Console.WriteLine("\n*** FINANCE TRACKER MENU ***");
            Console.WriteLine("1. Show My Debts");
            Console.WriteLine("2. Pay a Debt");
            Console.WriteLine("3. Record Income");
            Console.WriteLine("4. Record Expense");
            Console.WriteLine("5. View History");
            Console.WriteLine("6. Quit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                myDebts.ShowAllDebts();
            }
            else if (choice == "2")
            {
                myDebts.ShowAllDebts();
                Console.Write("Select debt ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("How much? ");
                double pay = double.Parse(Console.ReadLine());
                Console.Write("Date? ");
                string d = Console.ReadLine();

                myDebts.MakePayment(id, pay);
                myBook.AddEntry(new DebtPayment(pay, d, id));
                Console.WriteLine("Payment added.");
            }
            else if (choice == "3")
            {
                Console.Write("Amount: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Date: ");
                string d = Console.ReadLine();
                myBook.AddEntry(new Income(a, d));
            }
            else if (choice == "4")
            {
                Console.Write("Amount: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Date: ");
                string d = Console.ReadLine();
                Console.Write("Category: ");
                string c = Console.ReadLine();
                myBook.AddEntry(new Expense(a, d, c));
            }
            else if (choice == "5")
            {
                myBook.PrintHistory();
            }
            else
            {
                go = false;
            }
        }
    }
}