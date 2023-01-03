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
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoardGame(Board board, bool[,]possiblesPositions)
        {
            ConsoleColor originalColor = Console.BackgroundColor;
            ConsoleColor customColor = ConsoleColor.DarkGray; 

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblesPositions[i, j])
                    {
                        Console.BackgroundColor = customColor;
                    }
                    else
                    {
                        Console.BackgroundColor=originalColor;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalColor;
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
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
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
                Console.Write(" ");
            }            
        }
    }
}
