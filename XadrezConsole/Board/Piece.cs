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

        public Piece(Position position, Colors colors, Board tab)
        {
            this.position = position;
            this.colors = colors;
            this.tab = tab;
            this.movement = 0;
        }
    }
}
