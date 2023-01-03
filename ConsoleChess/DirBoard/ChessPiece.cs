namespace DirBoard
{
    public abstract class ChessPiece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int MovimentsQtd {get; protected set;}
        public Board board { get; protected set; }

        public ChessPiece(Board board, Color color)
        {
            this.position = null;
            this.color = color;
            MovimentsQtd = 0;
            this.board = board;
        }

        public void AddMovedMovements()
        {
            MovimentsQtd++;
        }

        public void UndoMovedMovements()
        {
            MovimentsQtd--;
        }

        public bool ExistingMovemientsPossibles()
        {
            bool[,] kill = PossibleMovements();
            for (int i = 0; i < board.Lines; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (kill[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveToPosition(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Column];
        }

        public abstract bool[,] PossibleMovements();
    }
}
