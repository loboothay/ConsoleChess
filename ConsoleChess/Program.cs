// See https://aka.ms/new-console-template for more information
using Design;
using DirBoard;
using Chess;
using ConsoleChess.Chess;

try
{
    StartChess matchChess = new StartChess();

    while (!matchChess.Finished)
    {
        Console.Clear();
        Screen.PrintBoardGame(matchChess.board);

        Console.WriteLine();
        Console.Write("Origin:");
        Position origin = Screen.WritePositionChess().toPosition();

        bool[,] possiblePositions = matchChess.board.Piece(origin).PossibleMovements();

        Console.Clear();
        Screen.PrintBoardGame(matchChess.board, possiblePositions);

        Console.WriteLine();
        Console.Write("Target:");
        Position target = Screen.WritePositionChess().toPosition();

        matchChess.ExecuteMovement(origin, target);
    }


}
catch (Exception e)
{

    Console.WriteLine(e.Message);
}

Console.ReadLine();
