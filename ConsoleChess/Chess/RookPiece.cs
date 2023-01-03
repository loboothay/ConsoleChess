using DirBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class RookPiece : ChessPiece
    {
        public RookPiece(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position pos)
        {
            ChessPiece p = board.Piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            // Up
            pos.SetValues(position.Line - 1, position.Column);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            // Down
            pos.SetValues(position.Line + 1, position.Column);
            while (board.ValidPosition (pos) && CanMove(pos))
            {
                mat[pos.Line, position.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }

            // Right
            pos.SetValues(position.Line, position.Column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            // Left
            pos.SetValues(position.Line, position.Column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return mat;
        }
    }
}

