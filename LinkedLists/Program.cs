using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace LinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList mylist = new LinkedList();
            mylist.InsertAtFront("56");
            mylist.InsertAtFront("5");
            mylist.InsertAtFront("78");
            mylist.InsertAtFront("98");
            mylist.InsertAtEnd("321");
            mylist.InsertInOrder("897645");
            mylist.InsertInOrder("456");
            mylist.InsertInOrder("7");
            mylist.PrintList();
            mylist.Delete("78");
            mylist.Delete("5");
            mylist.PrintList();
        }
        
    }
    class Node
    {
        public string data;
        public Node next;

        public Node(string Data)
        {
            data = Data;
        }

    }
    class LinkedList
    {
        public Node? head;
        public Node end;
        public void InsertAtFront(string data)
        {
            //create new node
            Node newNode = new Node(data);
            //check if head node exists
            if (head == null)
            {
                head = newNode;
                end = newNode;
            }
            else
            {
                //update pointers so the new node is the head
                newNode.next = head;
                head = newNode;
            }
        }
        public void InsertAtEnd(string data)
        {
            //create new node
            Node newNode = new Node(data);
            //check if head node exists
            if (head == null)
            {
                head = newNode;
                end = newNode;
            }
            else
            {
                //update the pointers
                end.next = newNode;
                end = newNode;
            }
        }
        public void PrintList()
        {
            Node node = head;
            while (node!= null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }
        }
        public void InsertInOrder(string data)
        {
            Node newNode = new Node(data);
            Node current = head;
            if (head == null)
            {
                head = newNode;
                end = newNode;
            }
            //check if the new node data is before the head data
            else if (string.Compare(newNode.data, current.data) < 0)
            {
                //set new node as head of the list
                newNode.next = head;
                head = newNode;
            }
            //otherwise find where node should be positioned
            else
            {
                //repeate until the point of insertion is found
                while (current.next != null && string.Compare(current.next.data,newNode.data) < 0)
                {
                    //get the current node
                    current = current.next;
                }
                //update the pointers of the new and current nodes
                newNode.next = current.next;
                current.next = newNode;
                //update the end pointer if we are inserting at the end
                if (current.next.next == null)
                {
                    end = newNode;
                }
            }
        }
        public void Delete(string data)
        {
            Node current = head;
            //check if head node is to be deleted
            if(current.data == data)
            {
                //update the head pointer
                head = current.next;
            }
            else
            {
                //repeat until node found
                while(current.next.data != data)
                {
                    //change current node to next node
                    current = current.next;
                }
                //set pointer to next nodes pointer
                current.next = current.next.next;
                //update end pointer if inserting at the end
                if(current.next == null)
                {
                    end = current;
                }
            }
        }
    }
}