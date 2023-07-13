namespace LinearandBinarysearches;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;
class Program

    {
        static void Main(string[] args)

        {
        long[] numbers = new long[100]; 
        Random random = new Random();
        int a = 0;
        while (a < numbers.Length)
        {
            numbers[a] = random.Next(1, 100);
            a++;
        }
        Array.Sort(numbers);
        Console.WriteLine("Please enter the number you want to search for:");
        string searchnumbers = Console.ReadLine();
        long i = Array.BinarySearch(numbers, searchnumbers);
        if (i >= 0)
            Console.WriteLine("number found at position " + i + "\n");
        else
            Console.WriteLine("number not found\n");
        Console.WriteLine("press any key to close\n");
        Console.ReadKey();

        }

    }

