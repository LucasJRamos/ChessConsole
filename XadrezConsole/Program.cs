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

                    Console.Clear();
                    Screen.PrintBoard(match.tab);

                    Console.WriteLine();
                    Console.WriteLine("Origin: ");
                    Position origin = Screen.ReadPosition().ToPosition();

                    bool[,] possibilities = match.tab.piece(origin).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(match.tab, possibilities);

                    Console.WriteLine("Destination: ");
                    Position destination = Screen.ReadPosition().ToPosition();

                    match.MovimentPerform(origin, destination);
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