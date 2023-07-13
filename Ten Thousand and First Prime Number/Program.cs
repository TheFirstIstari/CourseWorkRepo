using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Ten_Thousand_and_First_Prime_Number
{
    class Program
    {

        static void Main(string[] args)
        {
            Stopwatch timerall = new Stopwatch();
            int no_of_primes_found = 0;
            int current_number = 0;
            List<int> found_primes = new List<int>();
            bool n_minus_found = false;
            bool n_plus_found = false;

            found_primes.Add(2);
            found_primes.Add(3);
            found_primes.Add(5);
            found_primes.Add(7);
            found_primes.Add(11);
            found_primes.Add(13);

            current_number = 12;
            no_of_primes_found = 6;
            timerall.Start();
            Stopwatch timerloop = new Stopwatch();
            timerloop.Start();
            while (no_of_primes_found < 10001)
            {
                current_number += 6;
                n_minus_found = false;
                n_plus_found = false;
                foreach (int current_prime in found_primes)
                {
                    if (!n_minus_found && (current_number - 1) % current_prime == 0)
                    {
                        n_minus_found = true;
                    }
                    if (!n_plus_found && (current_number + 1) % current_prime == 0)
                    {
                        n_plus_found = true;
                    }
                    if (n_minus_found && n_plus_found)
                    {
                        break;
                    }
                }
                if (!n_minus_found)
                {
                    found_primes.Add(current_number - 1);
                    no_of_primes_found = no_of_primes_found + 1;
                }
                if (!n_plus_found && no_of_primes_found < 10001)
                {
                    found_primes.Add(current_number + 1);
                    no_of_primes_found = no_of_primes_found + 1;
                }
            }
            timerall.Stop();
            timerloop.Stop();
            Console.WriteLine(no_of_primes_found);
            Console.WriteLine(Convert.ToString(found_primes[found_primes.Count - 1]));
            Console.WriteLine(timerall.ElapsedMilliseconds);
            Console.WriteLine(timerloop.ElapsedMilliseconds);
        }
    }
}