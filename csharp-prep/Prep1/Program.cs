using System;
using System.Runtime.ExceptionServices;

class Program
{
    static void Main(string[] args)
    {
        //Ask user for first name
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        //Ask the user for the last name
        Console.Write("What is your last name? " );
        string last = Console.ReadLine();

        Console.WriteLine($"Your name is {last}, {first} {last}.");
        Console.ReadKey();
    }
}