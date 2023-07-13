using System;
using System.IO;
using System.Collections.Generic;
namespace Strings

{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            /*try
            {
                //something
                int input;
                Console.WriteLine("PICK A NUMBER: ");
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("your not an idiot");
            }
            catch(Exception Ex)
            {
                //go to something here
                Console.WriteLine(Ex.Message);
            }
            Console.ReadLine();*/
            /*string Line = " ";
            StreamReader file = new StreamReader("quotes.txt");
            foreach (char Line in file.ReadLine())
            {
                Console.WriteLine(Line);
            }
            Console.WriteLine();
            file.Close();*/
            StreamWriter File = new StreamWriter("quotes.txt", true);
            File.WriteLine("\"If you stand for nothing, Burr, what will you fall for?\"");
            File.WriteLine("immigrants, we get the job done");
            File.WriteLine("\"I will kill your friends and family to remind you of my love.\"");
            File.Close();
        }
    }
}