using System;
namespace RunLengthEncoding;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the string to be encoded: ");
        string inputString = Console.ReadLine();
        string outputString = EncodeString(inputString);
        Console.WriteLine("Encoded string: {0}", outputString);
    }

    public static string EncodeString(string inputString)
    {
        string outputString = "";
        int count = 1;
        char prevCharacter = inputString[0];
        for (int i = 1; i < inputString.Length; i++)
        {
            if (inputString[i] == prevCharacter)
            {
                count++;
            }
            else
            {
                outputString = outputString + count + prevCharacter;
                prevCharacter = inputString[i];
                count = 1;
            }
        }
        outputString = outputString + count + prevCharacter;
        return outputString;
    }
}