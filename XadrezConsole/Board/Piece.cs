using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    abstract class Piece
    {

        public Position position { get; set; }
        public Colors colors { get; protected set; }
        public int movement { get; protected set; }
        public Board tab { get; protected set; }

        public Piece(Colors colors, Board tab)
        {
            this.position = null;
            this.colors = colors;
            this.tab = tab;
            this.movement = 0;
        }

        public void AmountMovement()
        {
            movement++;
        }

        public void DecreaseAmountMovement()
        {
            movement--;
        }

        public bool ExistMovement()
        {
            bool[,] mat = PossibleMovements();
            for (int i = 0; i < tab.lines;  i++)
            {
                for (int j = 0; j < tab.columns; j++)
                {
                    if (mat[i, j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Column];
        }

        public abstract bool [,] PossibleMovements();

    }
}
