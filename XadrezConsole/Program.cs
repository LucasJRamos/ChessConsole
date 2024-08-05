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
                    Console.WriteLine("Origem: ");
                    Position origin = Screen.ReadPosition().ToPosition();
                    Console.WriteLine("Destino: ");
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