using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator myGenerator = new PromptGenerator();
        string userChoice = "";

        Console.WriteLine("Hello, Welcome to your journal!");

        while (userChoice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                string randomPrompt = myGenerator.GetRandomPrompt();
                Console.WriteLine($"\n{randomPrompt}");
                Console.Write("> ");
                string userResponse = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = randomPrompt;
                newEntry._entryText = userResponse;

                myJournal.AddEntry(newEntry);
            }
            else if (userChoice == "2")
            {
                myJournal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                myJournal.LoadFromFile(fileName);
            }
            else if (userChoice == "4")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                myJournal.SaveToFile(fileName);
            }
        }
    }
}