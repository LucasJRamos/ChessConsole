using System;
using System.Text.RegularExpressions;
using board;
using xadrez;

namespace XadrezConsole
{
    class Screen
    {

        public static void PrintMatch(XadrezMatch match)
        {
            PrintBoard(match.tab);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);
            Console.WriteLine("Waiting play: " + match.playerCurrent);
        }

        public static void PrintCapturedPieces(XadrezMatch match)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintSet(match.CapturedPieces(Colors.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPieces(Colors.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + ", ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board tab)
        {
            for (int i = 0; i < tab.lines; i++)
            {
                Console.Write(8 - i + "   ");
                for (int j = 0; j < tab.columns; j++)
                {
                    {
                        Screen.PrintPiece(tab.piece(i, j));
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("    a  b  c  d  e  f  g  h");
        }

        public static void PrintBoard(Board tab, bool[,] possibilities)
        {
            ConsoleColor Back = Console.BackgroundColor;
            ConsoleColor BackAltered = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.lines; i++)
            {
                Console.Write(8 - i + "   ");
                for (int j = 0; j < tab.columns; j++)
                {
                    {
                        if (possibilities[i, j])
                        {
                            Console.BackgroundColor = BackAltered;
                        }
                        else
                        {
                            Console.BackgroundColor = Back;
                        }
                        Screen.PrintPiece(tab.piece(i, j));
                        Console.BackgroundColor = Back;
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("    a  b  c  d  e  f  g  h");
            Console.BackgroundColor = Back;
        }

        public static PositionXadrez ReadPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionXadrez(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("-");
            }
            else
            {

                if (piece.colors == Colors.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write("");
            }
        }
    }
}
