using System;
using board;

namespace xadrez
{
    class Peon : Piece
    {
        public Peon(Colors colors, Board tab)
            : base(colors, tab)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExistEnemie(Position pos)
        {
            Piece p = tab.piece(pos);
            return p != null && p.colors != this.colors;
        }

        private bool Free(Position pos)
        {
            return tab.piece(pos) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[tab.lines, tab.columns];

            Position pos = new Position(0, 0);

            if (colors == Colors.White)
            {
                pos.Values(position.Line - 1, position.Column);
                if (tab.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.Values(position.Line - 2, position.Column);
                if (tab.ValidPosition(pos) && Free(pos) &&  movement == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.Values(position.Line - 1, position.Column - 1);
                if (tab.ValidPosition(pos) && ExistEnemie(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.Values(position.Line - 1, position.Column + 1);
                if (tab.ValidPosition(pos) && ExistEnemie(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.Values(position.Line + 1, position.Column);
                if (tab.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.Values(position.Line + 2, position.Column);
                if (tab.ValidPosition(pos) && Free(pos) && movement == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.Values(position.Line + 1, position.Column - 1);
                if (tab.ValidPosition(pos) && ExistEnemie(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.Values(position.Line + 1, position.Column + 1);
                if (tab.ValidPosition(pos) && ExistEnemie(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            return mat;
        }
    }
}