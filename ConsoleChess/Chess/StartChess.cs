using Chess;
using DirBoard;
using Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Chess
{
    public class StartChess
    {
        public Board board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<ChessPiece> pieces;
        private HashSet<ChessPiece> captured;
        public bool Check { get; private set; } = false;
        public ChessPiece vulneravelEnPassant { get; private set; }

        public StartChess()
        {
            board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            pieces = new HashSet<ChessPiece>();
            captured = new HashSet<ChessPiece>();
            PushPieces();
        }

        public ChessPiece ExecuteMovement(Position origin, Position target)
        {
            ChessPiece piece = board.RemovePiece(origin);
            piece.AddMovedMovements();
            ChessPiece pieceTarget = board.RemovePiece(target);
            board.PushPiece(piece, target);
            if(pieceTarget != null)
            {
                captured.Add(pieceTarget);
            }
            return pieceTarget;
        }

        public void PerformGame(Position origin, Position target)
        {
            ChessPiece pieceCaptured = ExecuteMovement(origin, target);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMove(origin, target, pieceCaptured);
                throw new BoardException("You can't put yourself in check");
            }

            if (IsInCheck(AdversaryColor(CurrentPlayer)))
            {
                Check= true;
            }
            else
            {
                Check= false;
            }

            if (IsInCheckmate(AdversaryColor(CurrentPlayer)))
            {
                Finished= true;
            }
            else
            {
                Shift++;
                InvertPlayer();
            }
            
        }

        public void UndoMove(Position origin, Position target, ChessPiece pieceCaptured)
        {
            ChessPiece piece = board.RemovePiece(target);
            piece.UndoMovedMovements(); 
            if(pieceCaptured != null)
            {
                board.PushPiece(pieceCaptured, target);
                captured.Remove(pieceCaptured);
            }
            board.PushPiece(piece, origin);
        }

        public void ValidPositionOrigin(Position pos)
        {
            if (board.Piece(pos) == null)
            {
                throw new BoardException("There is no piece in the chosen origin position");
            }
            if(CurrentPlayer != board.Piece(pos).color)
            {
                throw new BoardException("The source piece chosen is not yours");
            }
            if (!board.Piece(pos).ExistingMovemientsPossibles())
            {
                throw new BoardException("There are no possible moves for the chosen piece");
            }
        }

        public void ValidPositionTarget(Position origin, Position target)
        {
            if (!board.Piece(origin).CanMoveToPosition(target))
            {
                throw new BoardException("Invalid target position");
            }
        }

        private void InvertPlayer()
        {
            if(CurrentPlayer== Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer= Color.White;
            }
        }

        public HashSet<ChessPiece> PiecesCaptured(Color color)
        {
            HashSet<ChessPiece> aux = new HashSet<ChessPiece>();
            foreach (ChessPiece x in captured)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<ChessPiece> PiecesInGame(Color color)
        {
            HashSet<ChessPiece> aux = new HashSet<ChessPiece>();
            foreach (ChessPiece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PiecesCaptured(color));
            return aux;
        }

        private Color AdversaryColor(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private ChessPiece King(Color color)
        {
            foreach (ChessPiece x in PiecesInGame(color))
            {
                if(x is KingPiece)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            ChessPiece K = King(color);
            if (K == null)
            {
                throw new BoardException("There is no color king " + color + " in the board!");
            }
            foreach (ChessPiece x in PiecesInGame(AdversaryColor(color)))
            {
                bool[,] mat = x.PossibleMovements();
                if (mat[K.position.Line, K.position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsInCheckmate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (ChessPiece x in PiecesInGame(color))
            {
                bool[,] mat = x.PossibleMovements();
                for (int i = 0; i < board.Lines; i++)
                {
                    for (int j = 0; j < board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position target = new Position(i, j);
                            ChessPiece pecaCapturada = ExecuteMovement(origin, target);
                            bool testeCheckmate = IsInCheck(color);
                            UndoMove(origin, target, pecaCapturada);
                            if (!testeCheckmate)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PushNewPiece(char column, int line, ChessPiece piece)
        {
            board.PushPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void PushPieces()
        {
            PushNewPiece('a', 1, new RookPiece(board, Color.White));
            PushNewPiece('b', 1, new KnightPiece(board, Color.White));
            PushNewPiece('c', 1, new BishopPiece(board, Color.White));
            PushNewPiece('d', 1, new QueenPiece(board, Color.White));
            PushNewPiece('e', 1, new KingPiece(board,Color.White));
            PushNewPiece('f', 1, new BishopPiece(board, Color.White));
            PushNewPiece('g', 1, new KnightPiece(board, Color.White));
            PushNewPiece('h', 1, new RookPiece(board, Color.White));
            PushNewPiece('a', 2, new PawnPiece(board, Color.White, this));
            PushNewPiece('b', 2, new PawnPiece(board, Color.White, this));
            PushNewPiece('c', 2, new PawnPiece(board, Color.White, this));
            PushNewPiece('d', 2, new PawnPiece(board, Color.White, this));
            PushNewPiece('e', 2, new PawnPiece(board, Color.White, this));
            PushNewPiece('f', 2, new PawnPiece(board, Color.White, this));
            PushNewPiece('g', 2, new PawnPiece(board, Color.White, this));
            PushNewPiece('h', 2, new PawnPiece(board, Color.White, this));

            PushNewPiece('a', 8, new RookPiece(board, Color.Black));
            PushNewPiece('b', 8, new KnightPiece(board, Color.Black));
            PushNewPiece('c', 8, new BishopPiece(board, Color.Black));
            PushNewPiece('d', 8, new QueenPiece(board, Color.Black));
            PushNewPiece('e', 8, new KingPiece(board, Color.Black));
            PushNewPiece('f', 8, new BishopPiece(board, Color.Black));
            PushNewPiece('g', 8, new KnightPiece(board, Color.Black));
            PushNewPiece('h', 8, new RookPiece(board, Color.Black));
            PushNewPiece('a', 7, new PawnPiece(board, Color.Black, this));
            PushNewPiece('b', 7, new PawnPiece(board, Color.Black, this));
            PushNewPiece('c', 7, new PawnPiece(board, Color.Black, this));
            PushNewPiece('d', 7, new PawnPiece(board, Color.Black, this));
            PushNewPiece('e', 7, new PawnPiece(board, Color.Black, this));
            PushNewPiece('f', 7, new PawnPiece(board, Color.Black, this));
            PushNewPiece('g', 7, new PawnPiece(board, Color.Black, this));
            PushNewPiece('h', 7, new PawnPiece(board, Color.Black, this));
        }
    }
}
