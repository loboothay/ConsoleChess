using ConsoleChess.Chess;
using DirBoard;

namespace Chess
{
    public class PawnPiece : ChessPiece
    {
        private StartChess chessmatches;

        public PawnPiece(Board board, Color color, StartChess chessMatches) : base(board, color)
        {
            this.chessmatches = chessMatches;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExistEnemy(Position pos)
        {
            ChessPiece p = board.Piece(pos);
            return p != null && p.color != color;
        }

        private bool Free(Position pos)
        {
            return board.Piece(pos) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];
            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.SetValues(position.Line - 1, position.Column);
                if (board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(position.Line - 2, position.Column);
                Position p2 = new Position(position.Line - 1, position.Column);
                if (board.ValidPosition(p2) && Free(p2) && board.ValidPosition(pos) && Free(pos) && MovimentsQtd == 0)
                {
                    mat[position.Line, pos.Column] = true;
                }
                pos.SetValues(position.Line - 1, position.Column - 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(position.Line - 1, position.Column + 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #jogadaespecial en passant
                if (position.Line == 3)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if (board.ValidPosition(left) && ExistEnemy(left) && board.Piece(left) == chessmatches.vulneravelEnPassant)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if (board.ValidPosition(right) && ExistEnemy(right) && board.Piece(right) == chessmatches.vulneravelEnPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.SetValues(position.Line + 1, position.Column);
                if (board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(position.Line + 2, position.Column);
                Position p2 = new Position(position.Line + 1, position.Column);
                if (board.ValidPosition(p2) && Free(p2) && board.ValidPosition(pos) && Free(pos) && MovimentsQtd == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(position.Line + 1, position.Column - 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(position.Line + 1, position.Column + 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #jogadaespecial en passant
                if (position.Line == 4)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if (board.ValidPosition(left) && ExistEnemy(left) && board.Piece(left) == chessmatches.vulneravelEnPassant)
                    {
                        mat[left.Line + 1, left.Line] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if (board.ValidPosition(right) && ExistEnemy(right) && board.Piece(right) == chessmatches.vulneravelEnPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
