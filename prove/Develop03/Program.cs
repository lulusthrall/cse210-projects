using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Reference ref1 = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        Scripture scripture = new Scripture(ref1, text);

        string userInput = "";

        while (userInput.ToLower() != "quit")
        {
            Console.Clear();
            
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit:");
            
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nAll words are hidden! Great job.");
                    break; 
                }
            }
        }

        Console.WriteLine("Goodbye!");
    }
}