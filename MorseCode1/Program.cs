// Skeleton for the AQA A1 Summer 2018 examination
// this code should be used in conjunction with the Preliminary Material
// written by the AQA AS Programmer Team
// developed in Visual Studio 2015
//
// Version Number : 1.7

using System;
using System.Diagnostics;
using System.IO;

namespace SkeletonProgramCS
{
    class Program
    {

        public const char SPACE = ' ';
        public const char EOL = '#';
        public const string EMPTYSTRING = "";

        private static void ReportError(string s)
        {
            Console.WriteLine("{0,-5} {1} {2,5}", "*", s, "*");
        }

        private static string StripLeadingSpaces(string Transmission)
        {
            int TransmissionLength = Transmission.Length;
            if (TransmissionLength > 0)
            {
                char FirstSignal = Transmission[0];
                while (FirstSignal == SPACE && TransmissionLength > 0)
                {
                    TransmissionLength--;
                    Transmission = Transmission.Remove(0, 1);
                    if (TransmissionLength > 0)
                    {
                        FirstSignal = Transmission[0];
                    }
                }
            }
            if (TransmissionLength == 0)
            {
                ReportError("No signal received");
            }
            return Transmission;
        }

        private static string StripTrailingSpaces(string Transmission)
        {
            int LastChar = Transmission.Length - 1;
            while (Transmission[LastChar] == SPACE)
            {
                Transmission = Transmission.Remove(LastChar);
                LastChar--;
            }
            return Transmission;
        }

        private static string GetTransmission()
        {
            string FileName = EMPTYSTRING;
            Console.Write("Enter file name: ");
            FileName = Console.ReadLine();
            string Transmission;
            FileName = FileName.Contains(".txt") ? FileName : FileName + ".txt";
            try
            {
                Transmission = File.ReadAllText(FileName);
                Transmission = StripLeadingSpaces(Transmission);
                if (Transmission.Length > 0)
                {
                    Transmission = StripTrailingSpaces(Transmission);
                    Transmission = Transmission + EOL;
                }
            }
            catch
            {
                ReportError("No transmission found");
                Transmission = EMPTYSTRING;
            }
            return Transmission;
        }

        private static char GetNextSymbol(ref int i, string Transmission)
        {
            char Symbol;
            if (Transmission[i] == EOL)
            {
                Console.WriteLine();
                Console.WriteLine("End of transmission");
                Symbol = SPACE;
            }
            else
            {
                int SymbolLength = 0;
                char Signal = Transmission[i];
                while (Signal != SPACE && Signal != EOL)
                {
                    i++;
                    Signal = Transmission[i];
                    SymbolLength++;
                }
                if (SymbolLength == 1)
                {
                    Symbol = '.';
                }
                else if (SymbolLength == 3)
                {
                    Symbol = '-';
                }
                else if (SymbolLength == 0)
                {
                    Symbol = SPACE;
                }
                else
                {
                    ReportError("Non-standard symbol received");
                    Symbol = SPACE;
                }
            }
            return Symbol;
        }

        private static string GetNextLetter(ref int i, string Transmission)
        {
            string SymbolString = EMPTYSTRING;
            char Symbol = SPACE;
            bool LetterEnd = false;
            while (!LetterEnd)
            {
                Symbol = GetNextSymbol(ref i, Transmission);
                if (Symbol == SPACE)
                {
                    LetterEnd = true;
                    i += 4;
                }
                else if (Transmission[i] == EOL)
                {
                    LetterEnd = true;
                }
                else if (Transmission[i + 1] == SPACE && Transmission[i + 2] == SPACE)
                {
                    LetterEnd = true;
                    i += 3;
                }
                else
                {
                    i++;
                }
                SymbolString = SymbolString + Symbol;
            }
            return SymbolString;
        }

        private static char Decode(string CodedLetter, int[] Dash, char[] Letter, int[] Dot)
        {
            int CodedLetterLength = CodedLetter.Length;
            int Pointer = 0;
            char Symbol = SPACE;
            for (int i = 0; i < CodedLetterLength; i++)
            {
                Symbol = CodedLetter[i];
                if (Symbol == SPACE)
                {
                    return SPACE;
                }
                else if (Symbol == '-')
                {
                    Pointer = Dash[Pointer];
                }
                else
                {
                    Pointer = Dot[Pointer];
                }
            }
            return Letter[Pointer];
        }

        private static void ReceiveMorseCode(int[] Dash, char[] Letter, int[] Dot)
        {
            string PlainText = EMPTYSTRING;
            string MorseCodeString = EMPTYSTRING;
            string Transmission = EMPTYSTRING;
            string CodedLetter = EMPTYSTRING;
            char PlainTextLetter = SPACE;
            Console.WriteLine("Load Message file? (Y)es or (N)o: ");
            string direct = Console.ReadLine();
            if (direct == "N")
            {
                Console.WriteLine("Please enter a Transmission signal");
                Transmission = Console.ReadLine() + EOL;

                int LastChar = Transmission.Length - 1;
                int i = 0;
                while (i < LastChar)
                {
                    CodedLetter = GetNextLetter(ref i, Transmission);
                    MorseCodeString = MorseCodeString + SPACE + CodedLetter;
                    PlainTextLetter = Decode(CodedLetter, Dash, Letter, Dot);
                    PlainText = PlainText + PlainTextLetter;
                }
                Console.WriteLine(MorseCodeString);
                Console.WriteLine(PlainText);
            }
            else if (direct == "Y")
            {
                Transmission = GetTransmission();
                int LastChar = Transmission.Length - 1;
                int i = 0;
                while (i < LastChar)
                {
                    CodedLetter = GetNextLetter(ref i, Transmission);
                    MorseCodeString = MorseCodeString + SPACE + CodedLetter;
                    PlainTextLetter = Decode(CodedLetter, Dash, Letter, Dot);
                    PlainText = PlainText + PlainTextLetter;
                }
                Console.WriteLine(MorseCodeString);
                Console.WriteLine(PlainText);
            }
            else
            {
                Console.WriteLine("Try again");
            }

        }

        private static void SendMorseCode(string[] MorseCode)
        {
            Console.Write("Enter your message (uppercase letters and spaces only): ");
            string PlainText = Console.ReadLine();
            int PlainTextLength = PlainText.Length;
            string MorseCodeString = EMPTYSTRING;
            char PlainTextLetter = SPACE;
            int Index = 0;
            Console.WriteLine("Enter your Caesar shift key:  ");
            int Shift = int.Parse(Console.ReadLine());
            int ascii;              // declare new value 'ascii' to store that value.

            for (int i = 0; i < PlainTextLength; i++)
            {
                PlainTextLetter = PlainText[i];
                if (PlainTextLetter == SPACE)
                {
                    Index = 0;
                }
                else
                {
                    if ((int)PlainTextLetter >= 97)             // if ASCII Value of that letter is 97 or above, it is assumed to be lowercase.
                        ascii = (int)PlainTextLetter - 32;      // if lowercase then subtract 32 from its ASCII value
                    else if()
                        ascii = (int)PlainTextLetter;           // else it is uppercase, then use that ASCII value.
                    else if ()
                    Index = (int)CaesarEncrypt(ascii, Shift) - (int)'A' + 1;               // use the 'ascii' value to calculate, just incase lowercase has been used.
                }


                if (PlainTextLetter == SPACE)
                {
                    Index = 0;
                }
                else if (PlainTextLetter >= 97)
                    ascii = (int)PlainTextLetter - 32;
                else if (PlainTextLetter >= 65 && PlainTextLetter < 91)
                    ascii = (int)PlainTextLetter;
                else
                    if (PlainTextLetter <=33)
                        ascii = 



                string CodedLetter = MorseCode[Index];
                MorseCodeString = MorseCodeString + CodedLetter + SPACE;
            }
            Console.WriteLine(MorseCodeString);
        }

        private static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine("=========");
            Console.WriteLine("R - Receive Morse code");
            Console.WriteLine("S - Send Morse code");
            Console.WriteLine("L - List Morse code characters");         // Added - display menu option for this modification
            Console.WriteLine("X - Exit program");
            Console.WriteLine();
        }

        private static string GetMenuOption()
        {
            string MenuOption = EMPTYSTRING;
            while (MenuOption.Length != 1)
            {
                Console.Write("Enter your choice: ");
                MenuOption = Console.ReadLine();
            }
            return MenuOption;
        }

        private static void SendReceiveMessages()
        {
            int[] Dash = new int[] { 20, 23, 0, 45, 24, 1, 0, 17, 31, 21, 28, 25, 0, 15, 11, 42, 0, 0, 46, 22, 13, 48, 30, 10, 0, 0, 44, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 27, 0, 38, 40, 37, 0, 29 };
            int[] Dot = new int[] { 5, 18, 33, 0, 2, 9, 0, 26, 32, 19, 0, 3, 0, 7, 4, 43, 0, 0, 12, 8, 14, 6, 0, 16, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 36, 35, 0, 0, 46, 39, 47 };
            char[] Letter = new char[] { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ',', '?', '!' };
            string[] MorseCode = new string[] { ' ', '.-', '-...', '-.-.', '-..', '.', '..-.', '--.', '....', '..', '.---', '-.-', '.-..', '--', '-.', '---', '.--.', '--.-', '.-.', '...', '-', '..-', '...-', '.--', '-..-', '-.--', '--..', '-----', '.----', '..---', '...--', '....-', '.....', '-....', '--...', '---..', '----.', '.-.-.-', '--..--', '..--..', '-.-.--' };
            bool ProgramEnd = false;
            string MenuOption = EMPTYSTRING;
            while (!ProgramEnd)
            {
                DisplayMenu();
                MenuOption = GetMenuOption();
                if (MenuOption == "R")
                {
                    ReceiveMorseCode(Dash, Letter, Dot);
                }
                else if (MenuOption == "S")
                {
                    SendMorseCode(MorseCode);
                }
                else if (MenuOption == "X")
                {
                    ProgramEnd = true;
                }
                else if (MenuOption == "L")             // Added - if menu option selected is the 'L' (list Morse code)
                {
                    ListMorseCode(Letter, MorseCode);   // Run ListMorseCode subroutine, passing lists Letter and MorseCode
                }
            }
        }

        //private static string ConvertMorseCode()
        //{

        // }

        private static int CaesarEncrypt(int ascii, int Shift)
        {
            
            int CodedLetter = ascii + Shift;
            if (CodedLetter > (int)'Z')
            {
                CodedLetter = CodedLetter - 26;
            }
            return CodedLetter;
        }

        private static void SaveToFile(string MorseCodeString)
        {
            Console.WriteLine("Would You like to save the message to a file (Y/N)?");
            string SaveChoice = Console.ReadLine();                
            if (SaveChoice[0] == 'y' || SaveChoice[0] == 'Y') 
            {
                try
                {
                    Console.WriteLine("Enter the name of the file to save the message to: ");
                    string FileName = Console.ReadLine();               

                    if (!FileName.Contains(".txt"))   
                    {
                        FileName += ".txt";          
                    }

                    StreamWriter FileSaver = new StreamWriter(FileName);   
                    FileSaver.Write(MorseCodeString);                       

                    FileSaver.Close();
                }
                catch
                {
                    ReportError("Error when writing to file.");     
                }
                Console.WriteLine("File successfully written");
            }
        }

        private static void ListMorseCode(char[] Letter, string[] MorseCode)
        {
            for (int index = 0; index < Letter.Length; index++)      // for loop - loops through all elements in the Letter Array
            {
                Console.WriteLine(Letter[index] + "   " + MorseCode[index]);     // Output the text character, followed by a few spaces, and then the Morse code representation
            }
        }

        private static void EncodeMorseCode(string MorseCode)        // Function to convert MorseCodeString to the '=' and (Space) format in Preliminary Material
        {
            Console.WriteLine("Would You like to save the message to a file (Y/N)?");
            string ShouldSave = Console.ReadLine();                 // Check whether user wants to save to file
            if (ShouldSave[0] == 'y' || ShouldSave[0] == 'Y')       // [0] to only account for first character of input (both cases checked)
            {
                try
                {
                    Console.WriteLine("Enter the name of the file to save the message to: ");
                    string FileName = Console.ReadLine();       // User input file name

                    if (!FileName.Contains(".txt"))             // If it doesn't contain '.txt' then add the ".txt" to FileName
                    {
                        FileName += ".txt";                     // Append .txt if not present
                    }

                    StreamWriter CodedFileSaver = new StreamWriter(FileName);    // Open file in write mode (new StreamWriter)

                    // Use the built-in .Replace(old, new) method to swap out the relevant characters in C#.
                    string CodedOutput = MorseCode.Replace("-", "=== ").Replace(".", "= ").Replace("  ", "   ").Replace("      ", "       ");
                    // This now effectively formats the MorseCodeString message to the '=' and ' ' format

                    CodedFileSaver.Write(CodedOutput);

                    CodedFileSaver.Close();
                }
                catch
                {
                    ReportError("Error when writing to file.");     // Error handling
                }
                Console.WriteLine("Coded File successfully written");
            }
        }


        static void Main(string[] args)
        {
            SendReceiveMessages();
            Console.ReadLine();
        }

    }
}