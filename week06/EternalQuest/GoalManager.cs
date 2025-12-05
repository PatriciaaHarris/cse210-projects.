using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private int _score;
    private List<Goal> _goals;

    public GoalManager()
    {
        _score = 0;
        _goals = new List<Goal>();
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("\n=== Eternal Quest ===");
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");

        int level = _score / 1000;
        Console.WriteLine($"Level: {level}");

        List<string> badges = new List<string>();
        if (_score >= 1000) badges.Add("Bronze");
        if (_score >= 5000) badges.Add("Silver");
        if (_score >= 10000) badges.Add("Gold");

        Console.WriteLine($"Badges: {(badges.Count > 0 ? string.Join(", ", badges) : "None")}");
    }

    public void ListGoalNames()
    {
        int i = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetShortName()}");
            i++;
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals created yet.");
            return;
        }

        Console.WriteLine("\nGoals:");
        int i = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetDetailsString()}");
            i++;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        if (!int.TryParse(Console.ReadLine(), out int type))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points for each event: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points.");
            return;
        }

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, desc, points));
            Console.WriteLine("Simple goal created.");
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, desc, points));
            Console.WriteLine("Eternal goal created.");
        }
        else if (type == 3)
        {
            Console.Write("Target times to complete: ");
            if (!int.TryParse(Console.ReadLine(), out int target))
            {
                Console.WriteLine("Invalid target.");
                return;
            }

            Console.Write("Bonus points on completion: ");
            if (!int.TryParse(Console.ReadLine(), out int bonus))
            {
                Console.WriteLine("Invalid bonus.");
                return;
            }

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
            Console.WriteLine("Checklist goal created.");
        }
        else
        {
            Console.WriteLine("Unknown goal type.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        ListGoalDetails();
        Console.Write("Which goal did you accomplish? (enter number) ");
        if (!int.TryParse(Console.ReadLine(), out int index))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        index = index - 1;
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[index];
        int gained = goal.RecordEvent();
        _score += gained;

        Console.WriteLine($"You earned {gained} points for '{goal.GetShortName()}'.");
    }

    public void SaveGoals()
    {
        Console.Write("File name to save: ");
        string file = Console.ReadLine();

        try
        {
            using (StreamWriter output = new StreamWriter(file))
            {
                output.WriteLine(_score);

                foreach (Goal g in _goals)
                {
                    output.WriteLine(g.GetStringRepresentation());
                }
            }

            Console.WriteLine("Saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("File name to load: ");
        string file = Console.ReadLine();

        if (!File.Exists(file))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(file);
            if (lines.Length == 0)
            {
                Console.WriteLine("File is empty.");
                return;
            }

            if (!int.TryParse(lines[0], out int loadedScore))
            {
                Console.WriteLine("Invalid file format (score).");
                return;
            }

            _score = loadedScore;
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split('|');
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    string shortName = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);
                    _goals.Add(new SimpleGoal(shortName, desc, points, isComplete));
                }
                else if (type == "EternalGoal")
                {
                    string shortName = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    _goals.Add(new EternalGoal(shortName, desc, points));
                }
                else if (type == "ChecklistGoal")
                {
                    string shortName = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    int amountCompleted = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);
                    _goals.Add(new ChecklistGoal(shortName, desc, points, amountCompleted, target, bonus));
                }
            }

            Console.WriteLine("Loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}
