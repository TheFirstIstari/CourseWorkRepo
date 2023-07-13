namespace Multiplearraes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = new char[][]
            {
            new char[] { 'F', 'A', 'C', 'I' },
            new char[] { 'O', 'B', 'Q', 'P' },
            new char[] { 'A', 'N', 'O', 'B' },
            new char[] { 'M', 'A', 'S', 'S' }
            };

            Console.WriteLine(FindWord(matrix, "FOAM"));  // Should return True
            Console.WriteLine(FindWord(matrix, "MASS"));  // Should return True
            Console.WriteLine(FindWord(matrix, "FOB"));   // Should return False
        }
        public static bool FindWord(char[][] matrix, string word)
        {
            // Check if the word can be found by going left-to-right.
            foreach (var row in matrix)
            {
                if (string.Join("", row) == word)
                {
                    return true;
                }
            }

            // Check if the word can be found by going up-to-down.
            for (int i = 0; i < matrix[0].Length; i++)
            {
                string column = "";
                for (int j = 0; j < matrix.Length; j++)
                {
                    column += matrix[j][i];
                }

                if (column == word)
                {
                    return true;
                }
            }

            return false;
        }

    }
}