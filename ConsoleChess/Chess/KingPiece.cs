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
        public KingPiece(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position position)
        {
            ChessPiece piece = board.Piece(position);
            return piece == null || piece.color != this.color;
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

            return kill;
        }
    }
}
