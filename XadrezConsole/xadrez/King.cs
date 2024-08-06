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

        private bool CanMove(Position pos)
        {
            Piece p = tab.piece(pos);
            return p == null || colors != this.colors;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[tab.lines, tab.columns];

            Position pos = new Position(0, 0);

            pos.Values(position.Line - 1, position.Column);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line, position.Column + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line + 1, position.Column + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line + 1, position.Column);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line - 1, position.Column);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line + 1, position.Column - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line, position.Column - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.Values(position.Line - 1, position.Column - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
