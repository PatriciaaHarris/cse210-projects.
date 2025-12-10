using System;
using System.Collections.Generic;

abstract class Activity
{
    private string date;
    private int minutes;

    public Activity(string date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public string Date { get { return date; } }
    public int Minutes { get { return minutes; } }

    public abstract double GetDistance(); 
    public abstract double GetSpeed();    
    public abstract double GetPace();    

    public virtual string GetSummary()
    {
        return $"{Date} {this.GetType().Name} ({Minutes} min) - Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.00} min per mile";
    }
}

class Running : Activity
{
    private double distance; 

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / distance;
    }
}

class Cycling : Activity
{
    private double speed; 

    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * Minutes) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}

class Swimming : Activity
{
    private int laps;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0 * 0.62; 
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }
}

class Program
{
    static void Main()
    {
        Running run = new Running("03 Nov 2022", 30, 3.0);
        Cycling bike = new Cycling("03 Nov 2022", 45, 15.0);
        Swimming swim = new Swimming("03 Nov 2022", 60, 40);

        List<Activity> activities = new List<Activity> { run, bike, swim };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
