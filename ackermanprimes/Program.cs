
using System;
using System.Collections.Generic;

namespace ackermanprimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            Int16 n = Int16.Parse(Console.ReadLine());

            if (IsPrime(n))
            {
                Console.WriteLine($"{n} is a prime number.");
            }
            else
            {
                Console.WriteLine($"{n} is not a prime number.");
            }
        }

        static bool IsPrime(int n)
        {
            int m = Ackerman(n, n);

            if (m % n == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int Ackerman(int m, int n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            else if (m > 0 && n == 0)
            {
                return Ackerman(m - 1, 1);
            }
            else if (m > 0 && n > 0)
            {
                return Ackerman(m - 1, Ackerman(m, n - 1));
            }
            else
            {
                return -1;
            }
        }
    }
}
