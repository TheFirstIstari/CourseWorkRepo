namespace csharptest
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer greater than 1: ");
            int x = Int32.Parse(Console.ReadLine());
            int product = 1;
            int factor = 0;
            while (product < x)
            {
                factor++;
                product = product *factor;
            }
            if (x == product)
            {
                product = 1;
                for (int i = 0; i < factor; i++)
                {
                    product = product * i;
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("no result");
            }
        }
    }
}