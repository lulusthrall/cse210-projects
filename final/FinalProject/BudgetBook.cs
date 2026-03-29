public class BudgetBook
{
    private List<Transaction> allItems = new List<Transaction>();

    public void AddEntry(Transaction t)
    {
        allItems.Add(t);
    }

    public void PrintHistory()
    {
        foreach (Transaction t in allItems)
        {
            t.Show(); 
        }
    }
}