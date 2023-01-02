// See https://aka.ms/new-console-template for more information
using ConsoleChess.Design;
using DirBoard;

Board board = new Board(8, 8);

Screen.PrintBoardGame(board);

Console.ReadLine();
