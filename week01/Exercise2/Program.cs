using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("From 1 to 100 ,what's your score?");
        String score = Console.ReadLine()
        int percent = int.Parse(score);
        
        if(percent < 60)
        {
            Console.WriteLine("F");
        }
        else if (percent >= 60)
        {
            Console.WriteLine("D");
        }
        else if (percent >= 70)
        {
            Console.WriteLine("C");
        }
        else if (percent >= 80)
        {
            Console.WriteLine("B");
        }
        else if (percent >= 90)
        {
            Console.WriteLine("A");
        }
    if (percent >= 70)
    {
        Console.WriteLine("You are approved!")

    }
    else 
    {
        Console.WriteLine("I sorry, you are disapproved")
    }
    }
}