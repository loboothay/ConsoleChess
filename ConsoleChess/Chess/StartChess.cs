using Chess;
using DirBoard;
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
        private int Round;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }

        public StartChess()
        {
            board = new Board(8, 8);
            Round = 1;
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

        private void PushPieces()
        {
            board.PushPiece(new TowerPiece(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.PushPiece(new TowerPiece(board, Color.White), new ChessPosition('a', 1).toPosition());
            board.PushPiece(new TowerPiece(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.PushPiece(new TowerPiece(board, Color.Black), new ChessPosition('e', 8).toPosition());
        }
    }
}
