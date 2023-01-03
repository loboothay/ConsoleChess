using ConsoleChess.Chess;
using DirBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class KingPiece : ChessPiece
    {
        private StartChess startChess;
        public KingPiece(Board board, Color color, StartChess startChess) : base(board, color)
        {
            this.startChess = startChess;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            ChessPiece piece = board.Piece(position);
            return piece == null || piece.color != this.color;
        }

        private bool TestRookCastling(Position pos)
        {
            ChessPiece piece = board.Piece(pos);
            return piece != null && piece is RookPiece && piece.color == color && piece.MovimentsQtd == 0;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] kill = new bool[board.Lines, board.Columns];
            Position pos = new Position(0, 0);

            //Up
            pos.SetValues(position.Line - 1, position.Column);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                kill[pos.Line, pos.Column] = true;
            }

            //Northeast
            pos.SetValues(position.Line - 1, position.Column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                kill[pos.Line, pos.Column] = true;
            }

            //right
            pos.SetValues(position.Line, position.Column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                kill[pos.Line, pos.Column] = true;
            }

            //Southeast
            pos.SetValues(position.Line + 1, position.Column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                kill[pos.Line, pos.Column] = true;
            }

            //Down
            pos.SetValues(position.Line + 1, position.Column);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                kill[pos.Line, pos.Column] = true;
            }

            //South-West
            pos.SetValues(position.Line + 1, position.Column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                kill[pos.Line, pos.Column] = true;
            }

            //left
            pos.SetValues(position.Line, position.Column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                kill[pos.Line, pos.Column] = true;
            }

            //North-West
            pos.SetValues(position.Line - 1, position.Column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                kill[pos.Line, pos.Column] = true;
            }

            //Castling 

            if(MovimentsQtd==0 && !startChess.Check)
            {
                Position positionRook = new Position(position.Line, position.Column + 3);
                if(TestRookCastling(positionRook))
                {
                    Position p1 = new Position(position.Line, position.Column + 1);
                    Position p2 = new Position(position.Line, position.Column + 2);
                    if(board.Piece(p1) == null && board.Piece(p2) == null)
                    {
                        kill[position.Line, position.Column] = true;
                    }
                }

                Position positionBigRook = new Position(position.Line, position.Column -4);
                if (TestRookCastling(positionBigRook))
                {
                    Position p1 = new Position(position.Line, position.Column - 1);
                    Position p2 = new Position(position.Line, position.Column - 2);
                    Position p3 = new Position(position.Line, position.Column - 3);
                    if (board.Piece(p1) == null && board.Piece(p2) == null && board.Piece(p3) == null)
                    {
                        kill[position.Line, position.Column-2] = true;
                    }
                }
            }

            return kill;
        }
    }
}
