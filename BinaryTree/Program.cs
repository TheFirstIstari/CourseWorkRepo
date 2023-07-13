namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] Data = { 'C', 'I', 'E', 'H', 'B', 'Y', 'Q' };
            int[] Dir1 = { 1, 2, -1, -1, 5, -1, -1 };
            int[] Dir2 = { 4, 3, -1, -1, 6, -1, -1 };

            InOrderTraversal(0, Data, Dir1, Dir2);
            PostOrderTraversal(0, Data, Dir1, Dir2);
        }
        static void InOrderTraversal(int StartNode, char[] Data, int[] Dir1, int[] Dir2)
        {
            int current = StartNode;
            int pos = 0;
            int[] stack = new int[4];
            while(pos != -1)
            {
                current = stack[pos];
                pos--;
                Console.WriteLine($"{current} {pos} {stack[0]} {stack[1]} {stack[2]} {stack[3]} {Data[current]}");
                if (Dir2[current] != -1)
                {
                    pos++;
                    stack[pos] = Dir2[current];
                }
                if (Dir1[current] != -1)
                {
                    pos++;
                    stack[pos] = Dir1[current];
                    //only if that node has right daughter
                    //Console.WriteLine($"{current} {pos} {stack[0]} {stack[1]} {stack[2]} {stack[3]} {Data[current]}");
                }
            }

        }
        static void PostOrderTraversal(int P, char[] data, int[] Dir1, int[] Dir2)
        {
           
            if (Dir1[P] != -1)
            {
                PostOrderTraversal(Dir1[P], data, Dir1, Dir2);
            }
            if (Dir2[P] != -1)
            {
                PostOrderTraversal(Dir2[P], data, Dir1, Dir2);
            }
            Console.WriteLine(data[P]);

        }

    }
}