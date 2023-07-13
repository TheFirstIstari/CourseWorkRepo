using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //array of 100  random 6 digit integers
            //use mod 100 and mod 150 to generate hash values
            int iterations = 10000;
            int listlength = 100;
            Random random = new Random();
            int[] numbers = new int[listlength];
            int divisor = 462;
            int[] collisions = new int[divisor];
             
            int coll = 0;
            
            for (int a = 0; a < iterations; a++)
            {
                for (int b = 0; b < listlength; b++)
                {
                    numbers[b] = random.Next(1000000,10000000);
                    
                }
                for (int f =0; f < divisor; f++)
                {
                    collisions[f] = -1;

                }
                for (int c = 0; c < listlength; c++)
                {
                    collisions[numbers[c] % divisor]++;

                }
                for (int d = 0; d < divisor; d++)
                {
                    if (collisions[d] > 0)
                    {
                        coll = coll + collisions[d];
                    }
                }
                

            }
            Console.WriteLine("collisions (%)");
            Console.WriteLine((float)((float)coll / ((float)divisor * (float)iterations)) * 100);

        }
    }
}