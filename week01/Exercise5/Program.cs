using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, userNumber, squaredNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        int number;
        Console.Write("Please enter your favorite number: ");
        
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }

        return number;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int number, int square)
    {
        Console.WriteLine($"{name}, the square of {number} is {square}.");
    }
}
