using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dijkstras_shortest_path_algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] Graph = new int[5, 5];
            Graph[0, 1] = 6;
            Graph[0, 3] = 1;
            Graph[1, 0] = 6;
            Graph[1, 2] = 5;
            Graph[1, 3] = 2;
            Graph[1, 4] = 2;
            Graph[2, 1] = 5;
            Graph[2, 4] = 5;
            Graph[3, 0] = 1;
            Graph[3, 1] = 2;
            Graph[3, 4] = 1;
            Graph[4, 1] = 2;
            Graph[4, 2] = 5;
            Graph[4, 3] = 1;


            Dictionary<char, int> DictionaryQueue = new Dictionary<char, int>();
            Dictionary<char,int> Visited = new Dictionary<char,int>();
            int NewDistance = 0;
            Console.WriteLine("Queue set up with nodes and default distances");
            for(int i = 0; i<5; i++)
            {
                if (i == 0)
                {
                    DictionaryQueue.Add((char)(i + 65), 0);
                }
                else
                    DictionaryQueue.Add((char)(i + 65), Int32.MaxValue);
            }
            foreach(KeyValuePair<char, int> item in DictionaryQueue)
            {
                Console.WriteLine("Node" + item.Key + " distance" + item.Value);
            }
            Console.ReadLine();
            while(DictionaryQueue.Count > 0)
            {
                var NextNode = DictionaryQueue.First();
                Console.WriteLine("Node" + NextNode.Key + " distance" + NextNode.Value + " removed");

                DictionaryQueue.Remove(NextNode.Key);
                Visited.Add(NextNode.Key,NextNode.Value);

                Console.WriteLine("Neighbours of Node" + NextNode.Key + "removed from Queue");
                for (int i = 0;i < DictionaryQueue.Count;i++)
                {
                    int Distance = Graph[((int)NextNode.Key-65), (int)DictionaryQueue.ElementAt(i).Key - 65];
                    if ( Distance > 0)
                    {
                        Console.WriteLine("Update Node " + DictionaryQueue.ElementAt(i).Key + " distance" + Graph[((int)NextNode.Key-65),((int)DictionaryQueue.ElementAt(i).Key -65)]);
                        NewDistance = NextNode.Value + Distance;
                        if(NewDistance < DictionaryQueue[DictionaryQueue.ElementAt(i).Key])
                        {
                            DictionaryQueue[DictionaryQueue.ElementAt(i).Key] = NewDistance;
                            DictionaryQueue = DictionaryQueue.OrderBy(x=>x.Value).ToDictionary(x=>x.Key,x=>x.Value);
                        }
                    }
                }
                Console.WriteLine("the sorted queue");
                foreach (KeyValuePair<char, int> item in DictionaryQueue)
                {
                    Console.WriteLine("Node" + item.Key + " distance" + item.Value);
                }
                Console.WriteLine();
            }
            foreach(KeyValuePair<char, int> item in Visited)
            {
                Console.WriteLine("Visited " + item);

            }
            Console.ReadLine();



        }
    }
}