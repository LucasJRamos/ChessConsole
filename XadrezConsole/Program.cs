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
                Board tab = new Board(8, 8);

                tab.PutPiece(new King(Colors.Black, tab), new Position(1, 1));

                tab.PutPiece(new Tower(Colors.White, tab), new Position(7, 6));

                tab.PutPiece(new King(Colors.White, tab), new Position(1, 3));

                Screen.PrintBoard(tab);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        Console.ReadLine();
        }
    }
}