using System;
using board;

namespace xadrez
{
    class XadrezMatch
    {
        public Board tab { get; private set; }
        public int turn { get; private set; }
        public Colors playerCurrent { get; private set; }
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

        public void PlayPerform(Position origin, Position destination)
        {
            MovimentPerform(origin, destination);
            turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos)
        {
            if (tab.piece(pos) == null)
            {
                throw new BoardException("Choosed position has no piece! ");
            }
            if (playerCurrent != tab.piece(pos).colors)
            {
                throw new BoardException("It`s not your turn! ");
            }
            if (!tab.piece(pos).ExistMovement())
            {
                throw new BoardException("Don`t have possible movements! ");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination) 
        {
            if (!tab.piece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Destination position is invalid");
            }
        }

        public void ChangePlayer()
        {
            if (playerCurrent == Colors.White)
            {
                playerCurrent = Colors.Black;
            }
            else
            {
                playerCurrent = Colors.White;
            }
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
