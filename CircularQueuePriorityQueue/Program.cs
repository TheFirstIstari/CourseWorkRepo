using System.Reflection.Metadata;

namespace CircularQueue
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            CircularQueue queue = new CircularQueue();
            queue.EnQueue("memes");
            queue.EnQueue("wojak");
            queue.EnQueue("dudebros");
            queue.EnQueue("3174656");
            queue.EnQueue("fifth");
            queue.PrintQueue();
            queue.DeQueue();
            queue.PrintQueue();

            PriorityQueue Pqueue = new PriorityQueue();
        }

    }
    class CircularQueue
    {
        private const int MaxSize = 4;
        private string[] queue = new string[MaxSize];
        private int front = -1;
        private int rear = -1;

        public bool IsFull()
        {
            if ((rear+1) % MaxSize == front)
                return true;
            else
                return false;
        }
        public bool IsEmpty()
        {
            if (front == -1)
                return true;
            else
                return false;
        }
        public void EnQueue(string data)
        {
            if (IsFull() == true)
                Console.WriteLine($"queue is full - {data} not added");
            else
            {
                rear = (rear +1)% MaxSize;
                queue[rear] = data;
                if (front == -1) //first item to be queued
                    front = 0;
            }
        }
        public string DeQueue()
        {
            string DeQueueItem;
            if (IsEmpty() == true)
            {
                Console.WriteLine("queue is empty - nothing to add");
                DeQueueItem = " ";
            }
            else
            {
                DeQueueItem = queue[front];
                queue[front] = "";
                if(front == rear)
                {
                    front = -1;
                    rear = -1;
                }
                else
                {
                    front = (front+1)%MaxSize;
                }
            }
            return DeQueueItem;
        }
        public void PrintQueue()
        {
            for (int i = front; i <= rear; i++)
            {
                Console.WriteLine(queue[i]);
            }


            if(front == -1)
            {
                Console.WriteLine("No element in the circular queue");
            }
            else if (rear >= front)
            {
                for (int i = front; i <= rear; i++)
                {
                    Console.WriteLine(queue[i]);
                }
            }
            else
            {
                for (int i = front; i < MaxSize; i++)
                {
                    Console.WriteLine(queue[i]);
                }
                for (int i = 0; i <+ rear; i++)
                {
                    Console.WriteLine(queue[i]);
                }
            }

        }
    }
    class PriorityQueue
    {

    }
}