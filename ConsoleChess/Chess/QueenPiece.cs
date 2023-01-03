using DirBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class QueenPiece : ChessPiece
    {
        public QueenPiece(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        private bool CanMove(Position position)
        {
            ChessPiece piece = board.Piece(position);
            return piece == null || piece.color != this.color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            // esquerda
            pos.SetValues(position.Line, position.Column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.Line, pos.Column - 1);
            }

            // direita
            pos.SetValues(position.Line, position.Column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.Line, pos.Column + 1);
            }

            // acima
            pos.SetValues(position.Line - 1, position.Column);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.Line - 1, pos.Column);
            }

            // abaixo
            pos.SetValues(position.Line + 1, position.Column);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.Line + 1, pos.Column);
            }

            // NO
            pos.SetValues(position.Line - 1, position.Column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.Line - 1, pos.Column - 1);
            }

            // NE
            pos.SetValues(position.Line - 1, position.Column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.Line - 1, pos.Column + 1);
            }

            // SE
            pos.SetValues(position.Line + 1, position.Column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.Line + 1, pos.Column + 1);
            }

            // SO
            pos.SetValues(position.Line + 1, position.Column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.SetValues(pos.Line + 1, pos.Column - 1);
            }

            return mat;
        }
    }
}
