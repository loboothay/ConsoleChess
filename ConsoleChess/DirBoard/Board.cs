using Exceptions;
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

        public ChessPiece Piece(Position position)
        {
            return ChessPieces[position.Line, position.Column];
        }

        public bool ExistPiece(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void PushPiece(ChessPiece piece, Position position)
        {
            if(ExistPiece(position))
            {
                throw new BoardException("A piece already exists in this position");
            }
            ChessPieces[position.Line, position.Column] = piece;
            piece.position = position;
        }

        public bool ValidPosition(Position position)
        {
            if(position.Line<0 || position.Line>=Lines || position.Column<0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Position");
            }
        }
    }
}
