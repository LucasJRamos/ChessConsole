using System;
using board;
using System.Collections.Generic;

namespace xadrez
{
    class XadrezMatch
    {
        public Board tab { get; private set; }
        public int turn { get; private set; }
        public Colors playerCurrent { get; private set; }
        public bool End { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;


        public XadrezMatch()
        {
            tab = new Board(8, 8);
            turn = 1;
            playerCurrent = Colors.White;
            End = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            PutPieces();
        }

        public void MovimentPerform(Position origin, Position destination)
        {
            Piece p = tab.RemovePiece(origin);
            p.AmountMovement();
            Piece capturedPiece = tab.RemovePiece(destination);
            tab.PutPiece(p, destination);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturedPieces(Colors colors)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.colors == colors)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Colors colors)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.colors == colors)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(colors));
            return aux;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            tab.PutPiece(piece, new PositionXadrez(column, line).ToPosition());
            pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('a', 1, new Tower(Colors.White, tab));
            PutNewPiece('h', 1, new Tower(Colors.White, tab));
            PutNewPiece('e', 1, new King(Colors.White, tab));

            PutNewPiece('a', 8, new Tower(Colors.Black, tab));
            PutNewPiece('h', 8, new Tower(Colors.Black, tab));
            PutNewPiece('d', 8, new King(Colors.Black, tab));
        }


    }
}
