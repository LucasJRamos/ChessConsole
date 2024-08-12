using System;
using System.Security.Cryptography.X509Certificates;
using board;

namespace xadrez
{
    class King: Piece
    {

        private XadrezMatch match;

        public King(Colors colors, Board tab, XadrezMatch match)
            : base(colors, tab)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position pos)
        {
            Piece p = tab.piece(pos);
            return p == null || p.colors != this.colors;
        }

        private bool TowerTest(Position pos)
        {
            Piece p = tab.piece(pos);
            return p != null && p is Tower && p.colors == this.colors && p.movement == 0;
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

            if (movement == 0 && !match.check)
            {
                Position posT1 = new Position(position.Line, position.Column + 3);
                if (TowerTest(posT1))
                {
                    Position p1 = new Position(position.Line, position.Column + 1);
                    Position p2 = new Position(position.Line, position.Column + 2);
                    if (tab.piece(p1) == null && tab.piece(p2) == null)
                    {
                        mat[position.Line, position.Column + 2] = true;
                    }
                }
                Position posT2 = new Position(position.Line, position.Column - 4);
                if (TowerTest(posT2))
                {
                    Position p1 = new Position(position.Line, position.Column - 1);
                    Position p2 = new Position(position.Line, position.Column - 2);
                    Position p3 = new Position(position.Line, position.Column - 3);
                    if (tab.piece(p1) == null && tab.piece(p2) == null && tab.piece(p3) == null)
                    {
                        mat[position.Line, position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
