using System;
using board;

namespace xadrez
{
    class Tower: Piece
    {
        public Tower(Colors colors, Board tab)
           : base(colors, tab)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
