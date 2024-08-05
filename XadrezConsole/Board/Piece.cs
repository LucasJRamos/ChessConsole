using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    class Piece
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
    }
}
