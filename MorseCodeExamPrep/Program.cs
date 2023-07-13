// Skeleton for the AQA A1 Summer 2018 examination
// this code should be used in conjunction with the Preliminary Material
// written by the AQA AS Programmer Team
// developed in Visual Studio 2015
//
// Version Number : 1.7

using System;
using System.IO;

namespace MorseCodeExamPrep
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

        private static void SendMorseCode(string[] MorseCode)
        {
            Console.Write("Enter your message (uppercase letters and spaces only): ");
            string PlainText = Console.ReadLine();
            int PlainTextLength = PlainText.Length;
            string MorseCodeString = EMPTYSTRING;
            char PlainTextLetter = SPACE;
            int Index = 0;
            for (int i = 0; i < PlainTextLength; i++)
            {
                PlainTextLetter = PlainText[i];
                if (PlainTextLetter == SPACE)
                {
                    Index = 0;
                }
                else
                {
                    Index = (int)PlainTextLetter - (int)'A' + 1;
                }
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
            int[] Dash = new int[] { 20, 23, 0, 0, 24, 1, 0, 17, 0, 21, 0, 25, 0, 15, 11, 0, 0, 0, 0, 22, 13, 0, 0, 10, 0, 0, 0 };
            int[] Dot = new int[] { 5, 18, 0, 0, 2, 9, 0, 26, 0, 19, 0, 3, 0, 7, 4, 0, 0, 0, 12, 8, 14, 6, 0, 16, 0, 0, 0 };
            char[] Letter = new char[] { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string[] MorseCode = new string[] { " ", ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
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
            }
        }

        static void Main(string[] args)
        {
            SendReceiveMessages();
            Console.ReadLine();
        }

    }
}
