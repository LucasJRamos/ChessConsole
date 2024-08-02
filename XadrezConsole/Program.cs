using System;
using board;
using xadrez;

namespace XadrezConsole
{
    class program
    {
        static void Main(string[] args)
        {

            Board tab = new Board(8, 8);

            tab.PutPiece(new King(Colors.Black, tab), new Position(1, 1));
            tab.PutPiece(new Tower(Colors.White, tab), new Position(7, 6));

            Screen.PrintBoard(tab);

            Console.ReadLine();
        }
    }
}