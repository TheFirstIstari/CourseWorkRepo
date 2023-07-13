namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, char[]> Graph = new Dictionary<char, char[]>
            {
                {'A', new[] {'B','D','E'} },
                {'B', new[] {'A','C','D'} },
                {'C', new[] {'B','G'}},
                {'D', new[] {'A','B','E','F' } },
                {'E', new[] {'A','D'} },
                {'F', new[] {'D' } },
                {'G', new[] {'C'} }
            };
            List<char> Visited = new List<char>();
            Console.WriteLine("Recusive Depth First Search: ");
            DFSRECURSIVE(Graph,'A',Visited);
            foreach(char node in Visited) 
            { 
                Console.WriteLine(node); 
            }
            

            Console.WriteLine("Iterative Depth First Search");
            Visited.ForEach((char el)=> Console.WriteLine(el));

            Console.WriteLine("Iterative Breadth First Search");
            foreach(char node in BFSITERATIVE(Graph, 'A'))
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("im alive");
            static void DFSRECURSIVE(Dictionary<char, char[]> Graph, char currentVertex, List<char> Visited)
            {
                Visited.Add(currentVertex);
                foreach(char vertex in Graph[currentVertex])
                {
                    if (!Visited.Contains(vertex))
                    {
                        DFSRECURSIVE(Graph, vertex, Visited);
                    }
                }
            }
            static List<char> DFSITERATIVE(Dictionary<char, char[]> Graph,char currentVertex)
            {
                List<char> visited = new List<char>();
                List<char> stack = new List<char>();
                stack.Add(currentVertex);
                while(stack.Count != 0)
                {
                    currentVertex = stack[stack.Count -1];
                    stack.RemoveAt(stack.Count - 1);
                    if (!visited.Contains(currentVertex))
                    {
                        visited.Add(currentVertex);
                        foreach(char vertex in Graph[currentVertex])
                        {
                            stack.Add(vertex);
                        }
                    }
                }
                return visited;
            }
            static List<char> BFSITERATIVE(Dictionary<char, char[]> Graph, char currentVertex)
            {
                Queue<char> Queue = new Queue<char>();  
                List<char> visited = new List<char>();
                Queue.Enqueue(currentVertex);
                Console.WriteLine("still alive");
                while (Queue.Count != 0)
                {
                    char vertex = Queue.Dequeue();
                    visited.Add(vertex);
                    Console.WriteLine("still here");
                    foreach (char node in Graph[vertex])
                    {
                        if(!(visited.Contains(vertex) || Queue.Contains(vertex)))
                        {
                            Queue.Enqueue(vertex);
                        }
                    }
                }
                return visited;
            }

        }
    }
}