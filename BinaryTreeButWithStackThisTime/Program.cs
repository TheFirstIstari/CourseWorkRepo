using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BinaryTreeButWithStackThisTime
{
    public class Node
    {
        public int data;
        public Node left, right;
        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    // print inorder tree
    public class BinaryTree
    {
        public Node root;
        public virtual void inorder()
        {
            if (root == null)
            {
                return;
            }
            Stack<Node> stack = new Stack<Node>();
            Node current = root;

            while(current != null || stack.Count > 0)
            {
                while(current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                Console.Write((char)(current.data) + " ");
                current = current.right;
            }
        }
        
        public static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node('C');
            tree.root.left = new Node('I');
            tree.root.right = new Node('B');
            tree.root.left.left = new Node('E');
            tree.root.left.right = new Node('H');
            tree.root.right.left = new Node('Y');
            tree.root.right.right = new Node('Q');
            tree.inorder();
        }
    }

}