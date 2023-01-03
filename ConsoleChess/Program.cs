// See https://aka.ms/new-console-template for more information
using Design;
using DirBoard;
using Chess;
using ConsoleChess.Chess;
using Exceptions;

try
{
    StartChess matchChess = new StartChess();

    while (!matchChess.Finished)
    {
		try
		{
            Console.Clear();
            Screen.PrintCurrentMatch(matchChess);

            Console.WriteLine();
            Console.Write("Origin:");
            Position origin = Screen.WritePositionChess().toPosition();
            matchChess.ValidPositionOrigin(origin);

            bool[,] possiblePositions = matchChess.board.Piece(origin).PossibleMovements();

            Console.Clear();
            Screen.PrintBoardGame(matchChess.board, possiblePositions);

            Console.WriteLine();
            Console.Write("Target:");
            Position target = Screen.WritePositionChess().toPosition();
            matchChess.ValidPositionTarget(origin, target);

            matchChess.PerformGame(origin, target);
        }
		catch (BoardException ex)
		{

            Console.WriteLine(ex.Message);
            Console.ReadLine();
		}
    }

    Console.Clear();
    Screen.PrintCurrentMatch(matchChess);
}
catch (BoardException e)
{

    Console.WriteLine(e.Message);
}

Console.ReadLine();
