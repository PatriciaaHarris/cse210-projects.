//List<int> numbers;
//List<string> words;


using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        Console.WriteLine("Enter a list of numbers,type 0 when finished");
        int number= Console.ReadLine()
        
        While (number != 0)
        Console.Write("Enter number :")
        int idea = Console.ReadLine()








    

        


        Console.Write("Enter ")
    }
}



List<int> numbers = new List<int>();
//numbers = []

int userNumber = -1;
while (userNumber != 0)
{
    userNumber = int.Parse(Console.ReadLine());
    if (userNumber != 0)
        numbers.Add(userNumber);
}
//user_number = -1
while user_number != 0:
    user_number = int(input("Enter a number: "))
    if user_number != 0:
        numbers.append(user_number)


int sum = 0;
foreach (int number in numbers)
{
    sum += number;
}
//total = sum(numbers)


float average = ((float)sum) / numbers.Count;
//average = total / len(numbers)


int max = numbers[0];
foreach (int number in numbers)
{
    if (number > max)
        max = number;
}
//max_number = max(numbers)


int minPositive = int.MaxValue;
foreach (int number in numbers)
{
    if (number > 0 && number < minPositive)
        minPositive = number;
}
//min_positive = min(n for n in numbers if n > 0)

numbers.Sort();
foreach (int number in numbers)
{
    Console.WriteLine(number);
}
//numbers.sort()
for n in numbers:
    print(n)

