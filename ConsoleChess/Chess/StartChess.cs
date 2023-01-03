using Chess;
using DirBoard;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public StartChess()
        {
            board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            PushPieces();
            Finished = false;
        }

        public void ExecuteMovement(Position origin, Position target)
        {
            ChessPiece piece = board.RemovePiece(origin);
            piece.AddMovedMovements();
            ChessPiece pieceTarget = board.RemovePiece(target);
            board.PushPiece(piece, target);
        }

        public void PerformGame(Position origin, Position target)
        {
            ExecuteMovement(origin, target);
            Shift++;
            InvertPlayer();
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

        private void PushPieces()
        {
            board.PushPiece(new TowerPiece(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.PushPiece(new TowerPiece(board, Color.White), new ChessPosition('a', 1).toPosition());
            board.PushPiece(new TowerPiece(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.PushPiece(new TowerPiece(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.PushPiece(new KingPiece(board, Color.Black), new ChessPosition('f', 1).toPosition());
        }
    }
}
