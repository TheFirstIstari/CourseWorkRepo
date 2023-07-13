//Skeleton Program for the AQA AS1 Summer 2016 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA AS1 Programmer Team
//developed in a Visual Studio 2015 Community programming environment

//Version Number 1.0

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    public struct ShipType
    {
        public string Name;
        public int Size;
    }

    const string TrainingGame = "Training.txt";

    private static void GetRowColumn(ref int Row, ref int Column)
    {
        bool i = false;
        while (i == false)
        {
            Console.WriteLine();
            Console.Write("Please enter column: ");
            Column = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter row: ");
            Row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (Column > 9 || Column < 0)
            {
                Console.WriteLine("Invalid value entered");
            }
            else
            {
                i = true;
            }
        }
    }
    private static void MakePlayerMove(ref char[,] Board, ref ShipType[] Ships)
    {
        int Row = 0;
        int Column = 0;
        GetRowColumn(ref Row, ref Column);
        if (Board[Row, Column] == 'm' || Board[Row, Column] == 'h')
        {
            Console.WriteLine("Sorry, you have already shot at the square (" + Column + "," + Row + "). Please try again.");
        }
        else if (Board[Row, Column] == '-')
        {
            Console.WriteLine("Sorry, (" + Column + "," + Row + ") is a miss.");
            Board[Row, Column] = 'm';
        }
        else
        {
            switch (Board[Row, Column])
            {
                case 'A':
                    Console.WriteLine($"A {Ships[0].Name} has been hit");
                    break;
                case 'B':
                    Console.WriteLine($"A {Ships[1].Name} has been hit");
                    break;
                case 'S':
                    Console.WriteLine($"A {Ships[2].Name} has been hit");
                    break;
                case 'D':
                    Console.WriteLine($"A {Ships[3].Name} has been hit");
                    break;
                case 'P':
                    Console.WriteLine($"A {Ships[4].Name} has been hit");
                    break;
            }
            Console.WriteLine("Hit at (" + Column + "," + Row + ").");
            Board[Row, Column] = 'h';
        }
    }

    private static void SetUpBoard(ref char[,] Board)
    {
        for (int Row = 0; Row < 10; Row++)
        {
            for (int Column = 0; Column < 10; Column++)
            {
                Board[Row, Column] = '-';
            }
        }
    }

    private static void LoadGame(string TrainingGame, ref char[,] Board)
    {
        string Line = "";
        StreamReader BoardFile = new StreamReader(TrainingGame);
        for (int Row = 0; Row < 10; Row++)
        {
            Line = BoardFile.ReadLine();
            for (int Column = 0; Column < 10; Column++)
            {
                Board[Row, Column] = Line[Column];
            }
        }
        BoardFile.Close();
    }

    private static void SaveGame(char[,] Board)
    {
        StreamWriter BoardFile = new StreamWriter("game.txt");
        for (int Row = 0; Row < 10; Row++)
        {
            for (int column = 0; column < 10; Row++)
            {
                BoardFile.Write(Board[Row, column]);
            }
            BoardFile.WriteLine();
        }
        BoardFile.Close();
    }
    private static void PlaceRandomShips(ref char[,] Board, ShipType[] Ships)
    {
        Random RandomNumber = new Random();
        bool Valid;
        char Orientation = ' ';
        int Row = 0;
        int Column = 0;
        int HorV = 0;
        foreach (var Ship in Ships)
        {
            Valid = false;
            while (Valid == false)
            {
                Row = RandomNumber.Next(0, 10);
                Column = RandomNumber.Next(0, 10);
                HorV = RandomNumber.Next(0, 2);
                if (HorV == 0)
                {
                    Orientation = 'v';
                }
                else
                {
                    Orientation = 'h';
                }
                Valid = ValidateBoatPosition(Board, Ship, Row, Column, Orientation);
            }
            Console.WriteLine("Computer placing the " + Ship.Name);
            PlaceShip(ref Board, Ship, Row, Column, Orientation);
        }
    }

    private static void PlaceShip(ref char[,] Board, ShipType Ship, int Row, int Column, char Orientation)
    {
        if (Orientation == 'v')
        {
            for (int Scan = 0; Scan < Ship.Size; Scan++)
            {
                Board[Row + Scan, Column] = Ship.Name[0];
            }
        }
        else if (Orientation == 'h')
        {
            for (int Scan = 0; Scan < Ship.Size; Scan++)
            {
                Board[Row, Column + Scan] = Ship.Name[0];
            }
        }
    }

    private static bool ValidateBoatPosition(char[,] Board, ShipType Ship, int Row, int Column, char Orientation)
    {
        if (Orientation == 'v' && Row + Ship.Size > 10)
        {
            return false;
        }
        else if (Orientation == 'h' && Column + Ship.Size > 10)
        {
            return false;
        }
        else
        {
            if (Orientation == 'v')
            {
                for (int Scan = 0; Scan < Ship.Size; Scan++)
                {
                    if (Board[Row + Scan, Column] != '-')
                    {
                        return false;
                    }
                }
            }
            else if (Orientation == 'h')
            {
                for (int Scan = 0; Scan < Ship.Size; Scan++)
                {
                    if (Board[Row, Column + Scan] != '-')
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    private static bool CheckWin(char[,] Board)
    {
        for (int Row = 0; Row < 10; Row++)
        {
            for (int Column = 0; Column < 10; Column++)
            {
                if (Board[Row, Column] == 'A' || Board[Row, Column] == 'B' || Board[Row, Column] == 'S' || Board[Row, Column] == 'D' || Board[Row, Column] == 'P')
                {
                    return false;
                }
            }
        }
        return true;
    }

    private static void PrintBoard(char[,] Board)
    {
        Console.WriteLine();
        Console.WriteLine("The board looks like this: ");
        Console.WriteLine();
        Console.Write(" ");
        for (int Column = 0; Column < 10; Column++)
        {
            Console.Write(" " + Column + "  ");
        }
        Console.WriteLine();
        for (int Row = 0; Row < 10; Row++)
        {
            Console.Write(Row + " ");
            for (int Column = 0; Column < 10; Column++)
            {
                if (Board[Row, Column] == '-')
                {
                    Console.Write(" ");
                }
                //else if (Board[Row, Column] == 'A' || Board[Row, Column] == 'B' || Board[Row, Column] == 'S' || Board[Row, Column] == 'D' || Board[Row, Column] == 'P')
                //{
                //   Console.Write(" ");
                //}
                else
                {
                    Console.Write(Board[Row, Column]);
                }
                if (Column != 9)
                {
                    Console.Write(" | ");
                }
            }
            Console.WriteLine();
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("MAIN MENU");
        Console.WriteLine("");
        Console.WriteLine("1. Start new game");
        Console.WriteLine("2. Load training game");
        Console.WriteLine("9. Quit");
        Console.WriteLine();
    }

    private static int GetMainMenuChoice()
    {
        int Choice = 0;
        Console.Write("Please enter your choice: ");
        Choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        return Choice;
    }
    private static void CalculateBoard(char[,] Board)
    {
        int shipno = 100;
        int hit = 0;
        int miss = 0;
        for (int Row = 0; Row < 10; Row++)
        {
            for (int Column = 0; Column < 10; Column++)
            {
                if (Board[Row, Column] == 'A' || Board[Row, Column] == 'B' || Board[Row, Column] == 'S' || Board[Row, Column] == 'D' || Board[Row, Column] == 'P')
                {
                    shipno--;
                }
            }
        }
        
        for (int Row = 0; Row < 10; Row++)
        {
            for (int Column = 0; Column < 10; Column++)
            {
                if (Board[Row, Column] == 'h')
                {
                    hit ++;
                }
                else if (Board[Row, Column] == 'm')
                {
                    miss ++;
                }

            }
        }
        Console.WriteLine($"ratio of hits to misses is {hit}:{miss}");
        if (shipno == 0)
        {
            Console.WriteLine("no ships left");
        }
        else
        {
            Console.WriteLine("percentage of ship cells sunk" ,shipno);
        }
        
       
    }
    private static void PlayGame(ref char[,] Board, ref ShipType[] Ships)
    {
        bool GameWon = false;
        while (GameWon == false)
        {
            CalculateBoard(Board);
            PrintBoard(Board);
            MakePlayerMove(ref Board, ref Ships);
            GameWon = CheckWin(Board);
            if (GameWon == true)
            {
                Console.WriteLine("All ships sunk!");
                Console.WriteLine("save game? y/n");
                string save = Console.ReadLine();
                if (save =="y")
                {
                    SaveGame(Board);
                }

            }
        }
    }

    private static void SetUpShips(ref ShipType[] Ships)
    {
        Ships[0].Name = "Aircraft Carrier";
        Ships[0].Size = 5;
        Ships[1].Name = "Battleship";
        Ships[1].Size = 4;
        Ships[2].Name = "Submarine";
        Ships[2].Size = 3;
        Ships[3].Name = "Destroyer";
        Ships[3].Size = 3;
        Ships[4].Name = "Patrol Boat";
        Ships[4].Size = 2;
    }


    static void Main(string[] args)
    {
        ShipType[] Ships = new ShipType[5];
        char[,] Board = new char[10, 10];
        int MenuOption = 0;
        while (MenuOption != 9)
        {
            SetUpBoard(ref Board);
            SetUpShips(ref Ships);
            DisplayMenu();
            MenuOption = GetMainMenuChoice();
            if (MenuOption == 1)
            {
                PlaceRandomShips(ref Board, Ships);
                PlayGame(ref Board, ref Ships);
            }
            if (MenuOption == 2)
            {
                LoadGame(TrainingGame, ref Board);
                PlayGame(ref Board, ref Ships);
            }
        }
    }
}
