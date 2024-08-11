using System;
using board;

namespace xadrez
{
    class Horse : Piece
    {
        public Horse(Colors colors, Board tab)
            : base(colors, tab)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool CanMove(Position pos)
        {
            Piece p = tab.piece(pos);
            return p == null || p.colors != this.colors;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[tab.lines, tab.columns];

            Position pos = new Position(0, 0);

            pos.Values(position.Line - 1, position.Column - 2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line - 2, position.Column - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line - 2, position.Column + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line - 1, position.Column + 2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line + 1, position.Column + 2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line + 2, position.Column + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line + 2, position.Column - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line + 1, position.Column - 2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}
