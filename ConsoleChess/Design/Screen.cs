using Chess;
using DirBoard;

namespace Design
{
    public class Screen
    {
        public static void PrintBoardGame(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.Piece(i, j));
                        Console.Write(" ");
                    }                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static ChessPosition WritePositionChess()
        {
            string s = Console.ReadLine();
            char line = s[0];
            int column = int.Parse(s[1] + "");
            return new ChessPosition(line, column);
        }


        public static void PrintPiece(ChessPiece piece)
        {
            if(piece.color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
