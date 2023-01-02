namespace DirBoard
{
    public class ChessPiece
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
    }
}
