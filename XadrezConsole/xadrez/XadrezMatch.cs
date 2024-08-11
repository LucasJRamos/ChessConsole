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

            if (TestCheckMate(Opponent(playerCurrent)))
            {
                End = true;
            }
            else
            {
                turn++;
                ChangePlayer();
            }
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

        public bool TestCheckMate(Colors colors)
        {
            if (!InCheck(colors))
            {
                return false;
            }
            foreach (Piece x in PiecesInGame(colors))
            {
                bool[,] mat = x.PossibleMovements();
                for (int i = 0; i < tab.lines; i++)
                {
                    for (int j = 0; j < tab.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = MovementPerform(origin, destination);
                            bool testCheck = InCheck(colors);
                            UndoMovement(origin, destination, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            tab.PutPiece(piece, new PositionXadrez(column, line).ToPosition());
            pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('a', 1, new Tower(Colors.White, tab));
            PutNewPiece('b', 1, new Horse(Colors.White, tab));
            PutNewPiece('c', 1, new Pontiff(Colors.White, tab));
            PutNewPiece('d', 1, new King(Colors.White, tab));
            PutNewPiece('e', 1, new Lady(Colors.White, tab));
            PutNewPiece('f', 1, new Pontiff(Colors.White, tab));
            PutNewPiece('g', 1, new Horse(Colors.White, tab));
            PutNewPiece('h', 1, new Tower(Colors.White, tab));
            PutNewPiece('a', 2, new Peon(Colors.White, tab));
            PutNewPiece('b', 2, new Peon(Colors.White, tab));
            PutNewPiece('c', 2, new Peon(Colors.White, tab));
            PutNewPiece('d', 2, new Peon(Colors.White, tab));
            PutNewPiece('e', 2, new Peon(Colors.White, tab));
            PutNewPiece('f', 2, new Peon(Colors.White, tab));
            PutNewPiece('g', 2, new Peon(Colors.White, tab));
            PutNewPiece('h', 2, new Peon(Colors.White, tab));


            PutNewPiece('a', 8, new Tower(Colors.Black, tab));
            PutNewPiece('b', 8, new Horse(Colors.Black, tab));
            PutNewPiece('c', 8, new Pontiff(Colors.Black, tab));
            PutNewPiece('d', 8, new King(Colors.Black, tab));
            PutNewPiece('e', 8, new Lady(Colors.Black, tab));
            PutNewPiece('f', 8, new Pontiff(Colors.Black, tab));
            PutNewPiece('g', 8, new Horse(Colors.Black, tab));
            PutNewPiece('h', 8, new Tower(Colors.Black, tab));
            PutNewPiece('a', 7, new Peon(Colors.Black, tab));
            PutNewPiece('b', 7, new Peon(Colors.Black, tab));
            PutNewPiece('c', 7, new Peon(Colors.Black, tab));
            PutNewPiece('d', 7, new Peon(Colors.Black, tab));
            PutNewPiece('e', 7, new Peon(Colors.Black, tab));
            PutNewPiece('f', 7, new Peon(Colors.Black, tab));
            PutNewPiece('g', 7, new Peon(Colors.Black, tab));
            PutNewPiece('h', 7, new Peon(Colors.Black, tab));
        }


    }
}
