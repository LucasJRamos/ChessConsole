using System;
using board;

namespace xadrez
{
    class Pontiff : Piece
    {
        public Pontiff(Colors colors, Board tab)
            : base(colors, tab)
        {
        }

        public override string ToString()
        {
            return "B";
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

            pos.Values(position.Line - 1, position.Column - 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (tab.piece(pos) != null && tab.piece(pos).colors != this.colors)
                {
                    break;
                }
                pos.Values(pos.Line - 1, pos.Column - 1);
            }

            pos.Values(position.Line - 1, position.Column + 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (tab.piece(pos) != null && tab.piece(pos).colors != this.colors)
                {
                    break;
                }
                pos.Values(pos.Line - 1, pos.Column + 1);
            }

            pos.Values(position.Line + 1, position.Column + 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (tab.piece(pos) != null && tab.piece(pos).colors != this.colors)
                {
                    break;
                }
                pos.Values(pos.Line + 1, pos.Column + 1);
            }

            pos.Values(position.Line + 1, position.Column - 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (tab.piece(pos) != null && tab.piece(pos).colors != this.colors)
                {
                    break;
                }
                pos.Values(pos.Line + 1, pos.Column - 1);
            }
            return mat;
        }
    }
}