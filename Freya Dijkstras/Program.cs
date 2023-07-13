using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace Dijkstra_s_Final

{

    internal class Program

    {

        static void Main(string[] args)

        {

            //use a matrix array for the graph

            int[,] GRAPH = new int[5, 5];

            GRAPH[0, 1] = 6;

            GRAPH[0, 3] = 1;

            GRAPH[1, 0] = 6;

            GRAPH[1, 2] = 5;

            GRAPH[1, 3] = 2;

            GRAPH[1, 4] = 2;

            GRAPH[2, 1] = 5;

            GRAPH[2, 4] = 5;

            GRAPH[3, 0] = 1;

            GRAPH[3, 1] = 2;

            GRAPH[3, 4] = 1;

            GRAPH[4, 1] = 2;

            GRAPH[4, 2] = 5;

            GRAPH[4, 3] = 1;



            Dictionary<char, int> DictionaryQueue = new Dictionary<char, int>();

            Dictionary<char, int> Visited = new Dictionary<char, int>();

            int NewDistance = 0;



            //populate queue with node and max value

            Console.WriteLine("Queue set up with nodes and default distances");

            for (int i = 0; i < 5; i++)

            {

                //default first item in queue to zero

                if (i == 0) DictionaryQueue.Add((char)(i + 65), 0);

                else DictionaryQueue.Add((char)(i + 65), Int32.MaxValue);

            }



            //print out the queue to ensure it is correctly initialised

            foreach (KeyValuePair<char, int> item in DictionaryQueue)

            {

                Console.WriteLine("Node " + item.Key + " distance " + item.Value);

            }

            Console.ReadLine();



            //while the queue is NOT EMPTY

            while (DictionaryQueue.Count > 0)

            {

                //get next node from queue

                var NextNode = DictionaryQueue.First();

                Console.WriteLine("Node " + NextNode.Key + " distance " + NextNode.Value + " removed.");

                //remove NextNode from Q

                DictionaryQueue.Remove(NextNode.Key);

                Visited.Add(NextNode.Key, NextNode.Value);



                Console.WriteLine("Neighbours of Node " + NextNode.Key + " removed from Queue");

                for (int i = 0; i < DictionaryQueue.Count; i++)

                {

                    int Distance = GRAPH[((int)NextNode.Key - 65), ((int)DictionaryQueue.ElementAt(i).Key - 65)];

                    if (Distance > 0)

                    {

                        Console.WriteLine("Update Node " + DictionaryQueue.ElementAt(i).Key + " distance " + GRAPH[((int)NextNode.Key - 65), ((int)DictionaryQueue.ElementAt(i).Key - 65)]);

                        //add distance from current node to neighbour to the distance of the current node from original vertex

                        NewDistance = NextNode.Value + Distance;

                        //if the new distance is less than the distance currently in the Queue

                        if (NewDistance < DictionaryQueue[DictionaryQueue.ElementAt(i).Key])

                        {

                            //Update the correct item in the Queue

                            DictionaryQueue[DictionaryQueue.ElementAt(i).Key] = NewDistance;

                            //Sort the queue

                            DictionaryQueue = DictionaryQueue.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                        }

                    }

                }

                Console.WriteLine("The sorted Queue");

                foreach (KeyValuePair<char, int> item in DictionaryQueue)

                {

                    Console.WriteLine("Node " + item.Key + " distance " + item.Value);

                }

                Console.WriteLine();

            }

            foreach (KeyValuePair<char, int> item in Visited)

            {

                Console.WriteLine("Visited " + item);

            }

            Console.ReadLine();



        }

    }

}