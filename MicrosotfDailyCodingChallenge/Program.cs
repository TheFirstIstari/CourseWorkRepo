namespace MicrosotfDailyCodingChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] data = { 
                { 'F','O','A','M'},
                { 'O','B','Q','P'},
                { 'A','N','O','B'},
                { 'M','A','S','S'} 
            };
            string target = "FOAM";
            
            for (int row = 0; row < 3; row++)
            {
                if (data[row,0] == target[0])
                {
                    for (int column =0; column < 3; column++)
                    {
                        if (data[row,column] == target[column])
                        {
                            Console.WriteLine("found");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("not found");
                }
            }
        }
    }
}