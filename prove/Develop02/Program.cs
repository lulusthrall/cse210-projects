using System;
using System.Collections.Generic; //This is required for the list
using System.IO;                  //This is required for saving files and loading those files

class Program
{
    static void Main(string[] args)
    {
        // Creating the objects here to use them in the menu portion
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
            Console.WriteLine("5.Quit");
            Console.WriteLine("What would you like to do? ");

            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                // Get a prompt:
                string randomPrompt = myGenerator.GetRandomPrompt();
                Console.WriteLine(randomPrompt);
                Console.Write("> ");
                string userResponse = Console.ReadLine();

                // Create the users entry
                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = randomPrompt;
                newEntry._entryText = userResponse;

                //Add entry to the journal
                myJournal.AddEntry(newEntry);
            }
            else if (userChoice == "2")
            {
                myJournal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                Console.Write("What is the filename?" );
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

// The Entry Class
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine();
    }
}

// The Journal Class
public class Journal
{
    // This list holds the entry objects
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry (Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry loadedEntry = new Entry();
            loadedEntry._date = parts[0];
            loadedEntry._promptText = parts[1];
            loadedEntry._entryText = parts[2];

            _entries.Add(loadedEntry);
        }
    }
}

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_prompts.Count);
        return _prompts[index];
    }
}
