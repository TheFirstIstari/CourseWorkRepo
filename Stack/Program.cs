using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Stack
{

    internal class Program
    {
        public const int MaxSize = 4;

        public static bool IsFull(int top)
        {
            if (top == MaxSize - 1)
                return true;
            else
                return false;
        }
        public static bool IsEmpty(int top)
        {
            if (top == -1)
                return true;
            else
                return false;
        }
        
        public static void Push(string[] stack, ref int top, string data)
        {
            if (IsFull(top) == true)
                Console.WriteLine($"stack is full - {data} not added");
            else
            {
                top++;
                stack[top] = data;
            }
        }
        static void PrintStack(string[] stack, int top)
        {
            for (int i = 0; i <= top; i++)
            {
                Console.WriteLine(stack[i]);
            }
        }
        static string Pop(string[] stack, ref int top)
        {
            string poppedItem;
            if (IsEmpty(top) == true)
            {
                Console.WriteLine("Stack is empty - nothing to add");
                poppedItem = " ";
            }
            else
            {
                poppedItem = stack[top];
                top = top - 1;
            }
            return poppedItem;
        }
        static void PopAll(string[] stack, ref int top)
        {
            string poppedItem = string.Empty;
            for (int i = -1; i >= top; i++)
            {
                poppedItem = stack[top];
                top = top - 1;
                Console.WriteLine(poppedItem);
            }
            
        }
        static void Main(string[] args)
        {
            string[] stack = new string[MaxSize];
            int top = -1;

            Push(stack, ref top, "One");
            Push(stack, ref top, "Two");
            Push(stack, ref top, "Three");
            Push(stack, ref top, "Four");
            Push(stack, ref top, "Five");
            PrintStack(stack, top);
            Console.WriteLine(Pop(stack, ref top));
            //PopAll(stack,ref top);
            //stack is [LIFO last in first out]
            //Queue - First in First out
            //pushing, put item on stack
            //popping, take item off the stack
            //pointer tells where the top of the stack stack is
            //peek looks at the top of the stack
            //need to test if stack is empty or full


        }
    }
}