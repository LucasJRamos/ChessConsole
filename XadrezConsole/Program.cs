using System;
using board;
using xadrez;

namespace XadrezConsole
{
    class program
    {
        static void Main(string[] args)
        {
            try
            {
                XadrezMatch match = new XadrezMatch();

                while (!match.End)
                {
                    try
                    {

                        Console.Clear();
                        Screen.PrintBoard(match.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turn: " + match.turn);
                        Console.WriteLine("Waiting play: " + match.playerCurrent);

                        Console.WriteLine();
                        Console.WriteLine("Origin: ");
                        Position origin = Screen.ReadPosition().ToPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possibilities = match.tab.piece(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(match.tab, possibilities);

                        Console.WriteLine();
                        Console.WriteLine("Destination: ");
                        Position destination = Screen.ReadPosition().ToPosition();
                        match.ValidateDestinationPosition(origin, destination);

                        match.PlayPerform(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch(BoardException e) 
            {
                Console.WriteLine(e.Message);
            }
        Console.ReadLine();
        }
    }
}