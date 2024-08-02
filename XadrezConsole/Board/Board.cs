using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    class Board
    {

        public int lines { get; set; }
        public int columns { get; set; }

        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        public bool ExistPiece(Position pos)
        {
            ValidatePosition(pos);
            return piece(pos) != null;
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (ExistPiece(pos))
            {
                throw new BoardException("Position is full! ");
            }
            pieces[pos.Line, pos.Column] = p;
            p.position = pos;
        }


        public bool ValidPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= lines || pos.Column < 0 || pos.Column >= columns)
            {
                return false;
            } 
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Invalid Position! ");
            }
        }

    }
}
