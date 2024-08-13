using System;
using board;

namespace xadrez
{
    class Peon : Piece
    {

        private XadrezMatch match;

        public Peon(Colors colors, Board tab, XadrezMatch match)
            : base(colors, tab)
        {
            this.match = match;
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

                if (position.Line== 3)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if (tab.ValidPosition(left) && ExistEnemie(left) && tab.piece(left) == match.vulnerable)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if (tab.ValidPosition(right) && ExistEnemie(right) && tab.piece(right) == match.vulnerable)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
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

                if (position.Line == 4)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if (tab.ValidPosition(left) && ExistEnemie(left) && tab.piece(left) == match.vulnerable)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if (tab.ValidPosition(right) && ExistEnemie(right) && tab.piece(right) == match.vulnerable)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }
            return mat;
        }
    }
}