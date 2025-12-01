using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Select a choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    BreathingActivity breath = new BreathingActivity();
                    breath.Run();
                    break;

                case "2":
                    ReflectingActivity reflect = new ReflectingActivity();
                    reflect.Run();
                    break;

                case "3":
                    ListingActivity list = new ListingActivity();
                    list.Run();
                    break;

                case "4":
                    running = false;
                    break;
            }
        }
    }
}
