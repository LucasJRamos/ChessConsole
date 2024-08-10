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
        public bool check { get; private set; }


        public XadrezMatch()
        {
            tab = new Board(8, 8);
            turn = 1;
            playerCurrent = Colors.White;
            End = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece MovementPerform(Position origin, Position destination)
        {
            Piece p = tab.RemovePiece(origin);
            p.AmountMovement();
            Piece capturedPiece = tab.RemovePiece(destination);
            tab.PutPiece(p, destination);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destination, Piece capturedPiece) 
        {
            Piece p = tab.RemovePiece(destination);
            p.DecreaseAmountMovement();
            if (capturedPiece != null)
            {
                tab.PutPiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            tab.PutPiece(p, origin);
        }

        public void PlayPerform(Position origin, Position destination)
        {
            Piece capturedPiece = MovementPerform(origin, destination);
            if (InCheck(playerCurrent))
            {
                UndoMovement(origin, destination, capturedPiece);
                throw new BoardException("You can't check yourself! ");
            }

            if (InCheck(Opponent(playerCurrent)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

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

        private Piece king(Colors colors)
        {
            foreach (Piece x in PiecesInGame(colors))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        private Colors Opponent(Colors colors)
        {
            if (colors == Colors.White)
            {
                return Colors.Black;
            }
            else
            {
                return Colors.White;
            }
        }

        public bool InCheck(Colors colors)
        {
            Piece R = king(colors);
            if (R == null)
            {
                throw new BoardException("No have this color king on board!");
            }
            foreach (Piece x in PiecesInGame(Opponent(colors)))
            {
                bool[,] mat = x.PossibleMovements();
                if (mat[R.position.Line, R.position.Column])
                {
                    return true;
                }
            }
            return false;
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
