namespace Euler3and5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    total += 1;
                }

            }
            Console.WriteLine(total);
        }
    }
}