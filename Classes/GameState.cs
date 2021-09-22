using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChineseCheckers.Enums;
using Windows.Foundation;

namespace ChineseCheckers.Classes
{
    class GameState
    {
        public Board GameBoard;
        public BoardStatus CurrentPlayer;
        public (int x, int y) SelectedCell;
        public (int a, int b) NewSelectedCell;
        public bool PieceSelected;

        //vems tur
        //om man har selectad en piece
        //vilken piece

        public GameState()
        {
            GameBoard = new Board();
            CurrentPlayer = BoardStatus.Player1;
            PieceSelected = false;
        }

        public (int x, int y) GetSelectedCell(int x, int y)
        {
            for (int i = 0; i < GameBoard.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.Cells.GetLength(1); j++)
                {
                    if (GameBoard.Cells[i, j].bounds.Contains(new Point(x, y)))
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }
        public bool CheckIfPlayersPiece((int x, int y) cellPosition)
        {
            return CurrentPlayer == GameBoard.Cells[cellPosition.x, cellPosition.y].Item1;
        }
        public void Move((int x, int y) newPosition)
        {
            GameBoard.Cells[newPosition.x, newPosition.y].Item1 = CurrentPlayer;
            GameBoard.Cells[SelectedCell.x, SelectedCell.y].Item1 = BoardStatus.Empty;
        }
        //NorthEast and SouthWest moves are illegal
        ////The difference between two points is in the form (n,-n) when making this type of move

        public bool CheckIfIllegalDiagonalMove((int x, int y) newPosition)
        {
            if ((SelectedCell.x - newPosition.x) * -1 == SelectedCell.y - newPosition.y)
            {
                return true;
            }
            return false;
        }
        //Only one step at a time is allowed(unless you jump over someone)
        //The difference between two points is in the form (±1,0) when making a one-step horizontal move
        //A vertical move is in the form (0,±1)
        //A diagonal move is in the form ±(1,1)
        public bool CheckIfMoveIsOneStep((int x, int y) newPosition)
        {
            int diffX = newPosition.x - SelectedCell.x;
            int diffY = newPosition.y - SelectedCell.y;
            if (Math.Abs(diffX) == 1 && diffY == 0)
            {
                return true;
            }
            if (Math.Abs(diffY) == 1 && diffX == 0)
            {
                return true;
            }
            return diffX == diffY && Math.Abs(diffX) == 1;
        }

        public bool CheckIfNewPositionIsEmpty((int x, int y) newPosition)
        {
            return GameBoard.Cells[newPosition.x, newPosition.y].Item1 == BoardStatus.Empty;
        }
        public void HandleTurn(int x, int y)
        {
            //Check if player clicked on a cell

            if (GetSelectedCell(x, y) == (-1, -1))
            {
                SelectedCell = (-1, -1);
                PieceSelected = false;
                return;
            }
            if (CheckIfPlayersPiece(GetSelectedCell(x, y)))
            {
                SelectedCell = GetSelectedCell(x, y);
                PieceSelected = true;
                return;
            }
            if (PieceSelected)
            {
                (int x, int y) newPos = GetSelectedCell(x, y);
                if (!CheckIfIllegalDiagonalMove(newPos) && CheckIfMoveIsOneStep(newPos) && CheckIfNewPositionIsEmpty(newPos))
                {
                    Move(newPos);
                    PieceSelected = false;
                    //Takes the integral int value behind the enum and flips it from 0 : Player1 and 1: Player2
                    CurrentPlayer = (BoardStatus)(((int)CurrentPlayer) ^ 1);
                }
            }
        }
    }
}
