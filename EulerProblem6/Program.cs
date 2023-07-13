namespace EulerProblem6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((Sumofnumbers(100) * Sumofnumbers(100)) - Sumofsquareofnumbers(100));

            Console.ReadLine();
        }

        static long Sumofsquareofnumbers(int n)

        {

            return ((n * (n + 1) * (2 * n + 1) / 6));

        }

        static long Sumofnumbers(int n)

        {
            return n * (n + 1) / 2;

        }
    }
}