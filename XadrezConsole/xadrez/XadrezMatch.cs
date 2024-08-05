using System;
using board;

namespace xadrez
{
    class XadrezMatch
    {
        public Board tab { get; private set; }
        private int turn { get; set; }
        private Colors playerCurrent { get; set; }
        public bool End { get; private set; }

        public XadrezMatch()
        {
            tab = new Board(8, 8);
            turn = 1;
            playerCurrent = Colors.White;
            PutPieces();
        }

        public void MovimentPerform(Position origin, Position destination)
        {
            Piece p = tab.RemovePiece(origin);
            p.AmountMovement();
            Piece captured = tab.RemovePiece(destination);
            tab.PutPiece(p, destination);
        }

        private void PutPieces()
        {
            tab.PutPiece(new Tower(Colors.White, tab), new PositionXadrez('c', 1).ToPosition());
            tab.PutPiece(new Tower(Colors.White, tab), new PositionXadrez('c', 2).ToPosition());
            tab.PutPiece(new Tower(Colors.White, tab), new PositionXadrez('d', 3).ToPosition());

            tab.PutPiece(new King(Colors.Black, tab), new PositionXadrez('e', 8).ToPosition());
        }


    }
}
