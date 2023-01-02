using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirBoard
{
    public class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private ChessPiece[,] ChessPieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            ChessPieces = new ChessPiece[Lines, Columns];
        }

        public ChessPiece Piece(int line, int columns)
        {
            return ChessPieces[line, columns];
        }
    }
}
