using System;
using System.Security.Cryptography.X509Certificates;
using board;

namespace xadrez
{
    class King: Piece
    {
        public King(Colors colors, Board tab)
            : base(colors, tab)
        {
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
