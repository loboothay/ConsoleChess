// See https://aka.ms/new-console-template for more information
using Design;
using DirBoard;
using Chess;

Board board = new Board(8, 8);

board.PushPiece(new TowerPiece(board, Color.Black), new Position(0, 0));
board.PushPiece(new TowerPiece(board, Color.Black), new Position(1, 4));
board.PushPiece(new KingPiece(board, Color.Yellow), new Position(2, 5));

Screen.PrintBoardGame(board);

Console.ReadLine();
