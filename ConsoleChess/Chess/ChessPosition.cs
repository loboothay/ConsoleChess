﻿using DirBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessPosition
    {
        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public char Column { get; set; }
        public int Line { get; set; }

        public Position toPosition()
        {
            return new Position(8-Line, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
