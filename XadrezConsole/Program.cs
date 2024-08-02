using System;
using Board;

namespace XadrezConsole
{
    class program
    {
        static void Main(string[] args)
        {

            Position P;

            P = new Position(3, 4);

            Console.WriteLine("Position " + P );

            Console.ReadLine();
        }
    }
}