using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager()
    {
        _score = 0;
    }

    public void Start()
    {
        string input = "";
        while (input != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            input = Console.ReadLine();

            if (input == "1") CreateGoal();
            else if (input == "2") ListGoalDetails();
            else if (input == "3") SaveGoals();
            else if (input == "4") LoadGoals();
            else if (input == "5") RecordEvent();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine("You have " + _score + " points.");
        Console.WriteLine();
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + _goals[i].GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1") _goals.Add(new SimpleGoal(name, desc, points));
        else if (type == "2") _goals.Add(new EternalGoal(name, desc, points));
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + _goals[i].GetName());
        }
        Console.Write("Which goal did you accomplish? ");
        int selection = int.Parse(Console.ReadLine()) - 1;

        Goal goal = _goals[selection];
        goal.RecordEvent();
        
        int pointsEarned = goal.GetPoints();
        if (goal is ChecklistGoal checklist && checklist.IsComplete())
        {
            pointsEarned += checklist.GetBonus();
        }

        _score += pointsEarned;
        Console.WriteLine("Congratulations! You earned " + pointsEarned + " points!");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();
        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                sw.WriteLine(g.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();
        if (!File.Exists(file)) return;

        string[] lines = File.ReadAllLines(file);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] data = parts[1].Split(',');

            if (type == "SimpleGoal")
            {
                SimpleGoal sg = new SimpleGoal(data[0], "Loaded goal", int.Parse(data[1]));
                if (bool.Parse(data[2])) sg.RecordEvent();
                _goals.Add(sg);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(data[0], "Loaded goal", int.Parse(data[1])));
            }
            else if (type == "ChecklistGoal")
            {
                ChecklistGoal cg = new ChecklistGoal(data[0], "Loaded goal", int.Parse(data[1]), int.Parse(data[3]), int.Parse(data[2]));
                int completed = int.Parse(data[4]);
                for (int j = 0; j < completed; j++) cg.RecordEvent();
                _goals.Add(cg);
            }
        }
    }
}