using Chess;
using ConsoleChess.Chess;
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

        public static void PrintCurrentMatch(StartChess matchChess)
        {
            PrintBoardGame(matchChess.board);

            PrintCapturedPieces(matchChess);

            Console.WriteLine();
            Console.WriteLine("Shift : " + matchChess.Shift);
            Console.WriteLine("Waiting current move: " + matchChess.CurrentPlayer);
            if (matchChess.Check)
            {
                Console.WriteLine("Check");
            }
        }

        public static void PrintCapturedPieces(StartChess matchChess)
        {
            Console.WriteLine();
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintingSet(matchChess.PiecesCaptured(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintingSet(matchChess.PiecesCaptured(Color.Black));
            Console.ForegroundColor= aux;
            Console.WriteLine();
        }

        public static void PrintingSet(HashSet<ChessPiece> chessPieces)
        {
            Console.Write("[");
            foreach (ChessPiece x in chessPieces)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
    }
}
