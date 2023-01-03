﻿namespace DirBoard
{
    public class Position
    {
        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public int Line { get; set; }
        public int Column { get; set; }

        public void SetValues(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return Line+ ", " + Column;
        }
    }
}
