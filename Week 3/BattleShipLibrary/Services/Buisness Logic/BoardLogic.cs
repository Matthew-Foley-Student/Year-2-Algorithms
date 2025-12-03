/*
 * Matthew Foley
 * CST-201-O500
 * December 2025
 * BattleShips
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BattleShipLibrary.Models;

namespace BattleShipLibrary.Services.Buisness_Logic
{
    public class BoardLogic
    {
        private bool IsOnBoard(BoardModel board, int row, int col)
        {
            int size = board.Size;
            bool IsRowSafe = row >= 0 && row < size;
            bool IsColumnSafe = col >= 0 && col < size;
            return IsRowSafe && IsColumnSafe;
        }
        public BoardModel MarkLegalLocation(BoardModel board, CellModel currentCell, string shipName)
        {
            switch (shipName.ToLower())
            {
                //The destroyer placements in the 4 cardnal directions
                case "destroyerul":
                    board = AttemptPlaceDestroyerUpLeft(board, currentCell);
                    break;
                case "destroyerur":
                    board = AttemptPlaceDestroyerUpRight(board, currentCell);
                    break;
                case "destroyerdr":
                    board = AttemptPlaceDestroyerDownRight(board, currentCell);
                    break;
                case "destroyerdl":
                    board = AttemptPlaceDestroyerDownLeft(board, currentCell);
                    break;


                //The submarines placemnt in the 4 cardnial directions
                case "submarineul":
                    board = AttemptPlaceSubmarineUpLeft(board, currentCell);
                    break;
                case "submarineur":
                    board = AttemptPlaceSubmarineUpRight(board, currentCell);
                    break;
                case "submarinedr":
                    board = AttemptPlaceSubmarineDownRight(board, currentCell);
                    break;
                case "submarinedl":
                    board = AttemptPlaceSubmarineDownLeft(board,currentCell);
                    break;


                //3 connected non diangnal
                case "cruiserul":
                    board = AttemptPlaceCruiserUpLeft(board, currentCell);
                    break;
                case "cruiserur":
                    board = AttemptPlaceCruiserUpRight(board, currentCell);
                    break;
                case "cruiserdr":
                    board = AttemptPlaceCruiserDownLeft(board, currentCell);
                    break;
                case "cruiserdl":
                    board = AttemptPlaceCruiserDownRight(board, currentCell);
                    break;


                default:
                    return board;
            }
            return board;
            
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //The 4 methods for submarine placements (3 long diagnal)
        //--------------------------------------------------------------------------------------------------------------------------------------

        private BoardModel AttemptPlaceSubmarineUpLeft(BoardModel board, CellModel currentCell)
        {
            int SubCheck = 0;
            int[] SubRow = {0,-1,-2};
            int[] SubCol = {0, 1, 2};
            for (int i = 0; i < SubRow.Length; i++)
            {
                if (IsOnBoard(board, currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]) 
                    && 
                    board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType == "")
                {
                    board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType = "Sul";
                    SubCheck++;
                }
            }
            if (SubCheck == 3)
            {
                return board;
            }
            else
            {
                for (int i = 0; i < SubRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]) 
                        && 
                        board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType == "Sul")
                    {
                        board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType = "";
                    }
                }
                SubCheck = 0;
                return board;
            }
        }
        private BoardModel AttemptPlaceSubmarineUpRight(BoardModel board, CellModel currentCell)
        {
            int SubCheck = 0;
            int[] SubRow = { 0, 1, 2 };
            int[] SubCol = { 0, 1, 2 };
            for (int i = 0; i < SubRow.Length; i++)
            {
                if (IsOnBoard(board, currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]) 
                    && 
                    board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType == "")
                {
                    board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType = "Sur";
                    SubCheck++;
                }
            }
            if (SubCheck == 3)
            {
                return board;
            }
            else
            {
                for (int i = 0; i < SubRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]) 
                        && 
                        board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType == "Sur")
                    {
                        board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType = "";
                    }
                }
                SubCheck = 0;
                return board;
            }
        }
        private BoardModel AttemptPlaceSubmarineDownLeft(BoardModel board, CellModel currentCell)
        {
            int SubCheck = 0;
            int[] SubRow = { 0, -1, -2 };
            int[] SubCol = { 0, -1, 2 };
            for (int i = 0; i < SubRow.Length; i++)
            {
                if (IsOnBoard(board, currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]) 
                    && 
                    board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType == "")
                {
                    board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType = "Sdl";
                    SubCheck++;
                }
            }
            if (SubCheck == 3)
            {
                return board;
            }
            else
            {
                for (int i = 0; i < SubRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]) 
                        && 
                        board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType == "Sdl")
                    {
                        board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType = "";
                    }
                }
                SubCheck = 0;
                return board;
            }
        }
        private BoardModel AttemptPlaceSubmarineDownRight(BoardModel board, CellModel currentCell)
        {
            int SubCheck = 0;
            int[] SubRow = { 0,  1,  2 };
            int[] SubCol = { 0, -1, -2 };
            for (int i = 0; i < SubRow.Length; i++)
            {
                if (IsOnBoard(board, currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]) 
                    && 
                    board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType == "")
                {
                    board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType = "Sdr";
                    SubCheck++;
                }
            }
            if (SubCheck == 3)
            {
                return board;
            }
            else
            {
                for (int i = 0; i < SubRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]) 
                        && 
                        board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType == "Sdr")
                    {
                        board.Grid[currentCell.Row + SubRow[i], currentCell.Collumn + SubCol[i]].ShipType = "";
                    }
                }
                SubCheck = 0;
                return board;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------
        //The 4 methods for the Destroyer placements (2X2 square)
        //--------------------------------------------------------------------------------------------------------------------------------
        private BoardModel AttemptPlaceDestroyerUpRight(BoardModel board, CellModel currentCell)
        {
            int destroyCheck = 0;
            int[] destroyerRow = { 0, 1, 1, 0 };
            int[] destroyerCol = { 0, 0, 1, 1 };
            for (int i = 0; i < destroyerRow.Length; i++)
            {
                if (IsOnBoard(board, currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]) 
                    && 
                    board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType == "")
                {
                    board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType = "D";
                    destroyCheck++;
                }
            }
            if (destroyCheck == 4)
            {
                return board;
            }
            else
            {
                for (int i = 0; i < destroyerRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]) 
                        && 
                        board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType == "D")
                    {
                        board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType = "";
                    }
                }
                destroyCheck = 0;
                return board;
            }
        }
        private BoardModel AttemptPlaceDestroyerDownLeft(BoardModel board, CellModel currentCell)
        {
            int destroyCheck = 0;
            int[] destroyerRow = { 0, -1, -1, 0 };
            int[] destroyerCol = { 0, 0, -1, -1 };
            for (int i = 0; i < destroyerRow.Length; i++)
            {
                if (IsOnBoard(board, currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]) 
                    && 
                    board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType == "")
                {
                    board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType = "D";
                    destroyCheck++;
                }
            }
            if (destroyCheck == 4)
            {
                return board;
            }
            else
            {
                for (int i = 0; i < destroyerRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]) 
                        && 
                        board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType == "D")
                    {
                        board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType = "";
                    }
                }
                destroyCheck = 0;
                return board;
            }
        }
        private BoardModel AttemptPlaceDestroyerDownRight(BoardModel board, CellModel currentCell)
        {
            int destroyCheck = 0;
            int[] destroyerRow = { 0, 1, 1, 0 };
            int[] destroyerCol = { 0, 0, -1, -1 };
            for (int i = 0; i < destroyerRow.Length; i++)
            {
                if (IsOnBoard(board, currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]) 
                    && 
                    board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType == "")
                {
                    board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType = "Ddr";
                    destroyCheck++;
                }
            }
            if (destroyCheck == 4)
            {
                return board;
            }
            else
            {
                for (int i = 0; i < destroyerRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]) 
                        && 
                        board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType == "D")
                    {
                        board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType = "";
                    }
                }
                destroyCheck = 0;
                return board;
            }
        }
        private BoardModel AttemptPlaceDestroyerUpLeft(BoardModel board, CellModel currentCell)
        {
                int destroyCheck = 0;
                int[] destroyerRow = { 0, -1, -1, 0 };
                int[] destroyerCol = { 0, 0, 1, 1 };
                for (int i = 0; i < destroyerRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]) 
                    && 
                    board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType == "")
                    {
                        board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType = "D";
                        destroyCheck++;
                    }
                }
                if (destroyCheck == 4)
                {
                    return board;
                }
                else
                {
                    for (int i = 0; i < destroyerRow.Length; i++)
                    {
                        if (IsOnBoard(board, currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]) 
                        && 
                        board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType == "D")
                        {
                            board.Grid[currentCell.Row + destroyerRow[i], currentCell.Collumn + destroyerCol[i]].ShipType = "";
                        }
                    }
                    destroyCheck = 0;
                    return board;            
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------
        //The 4 methods for the Cruiser (3 long horizontal)
        //--------------------------------------------------------------------------------------------------------------------------------
        private BoardModel AttemptPlaceCruiserUpLeft(BoardModel board, CellModel currentCell)
        {
            int CruiserCheck = 0;
            int[] CruiserRow = {0,1,2};
            int[] CruiserCol = {0,0,0};
            for (int i = 0; i < CruiserRow.Length; i++)
            {
                if (IsOnBoard(board, currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]) 
                    && 
                    board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn 
                    + CruiserCol[i]].ShipType == "")
                {
                    board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType = "C";
                    CruiserCheck++;
                }
            }
            if (CruiserCheck == 3)
            {
                return board;
            }
            else
            {
                for (int i = 0; i < CruiserRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]) 
                        && 
                        board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType == "C")
                    {
                        board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType = "";
                    }
                }
                CruiserCheck = 0;
                return board;
            }
        }
        private BoardModel AttemptPlaceCruiserUpRight(BoardModel board, CellModel currentCell)
        {
            int CruiserCheck = 0;
            int[] CruiserRow = { 0, 0, 0 };
            int[] CruiserCol = { 0, 1, 2 };
            for (int i = 0; i < CruiserRow.Length; i++)
            {
                if (IsOnBoard(board, currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]) 
                    && 
                    board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType == "")
                {
                    board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType = "C";
                    CruiserCheck++;
                }
            }
            if (CruiserCheck == 3)
            {
                return board;
            }
            else
            {
                for (int i = 0; i < CruiserRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]) 
                        && 
                        board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType == "C")
                    {
                        board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType = "";
                    }
                }
                CruiserCheck = 0;
                return board;
            }
        }
        private BoardModel AttemptPlaceCruiserDownRight(BoardModel board, CellModel currentCell)
        {
            int CruiserCheck = 0;
            int[] CruiserRow = { 0, 0, 0 };
            int[] CruiserCol = { 0, -1, -2 };
            for (int i = 0; i < CruiserRow.Length; i++)
            {
                if (IsOnBoard(board, currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]) 
                    && 
                    board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType == "")
                {
                    board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType = "C";
                    CruiserCheck++;
                }
            }
            if (CruiserCheck == 3)
            {
                return board;
            }
            else
            {
                for (int i = 0; i < CruiserRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]) 
                        && 
                        board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType == "C")
                    {
                        board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType = "";
                    }
                }
                CruiserCheck = 0;
                return board;
            }
        }
        private BoardModel AttemptPlaceCruiserDownLeft(BoardModel board, CellModel currentCell)
        {
            int CruiserCheck = 0;
            int[] CruiserRow = { 0, -1, -2 };
            int[] CruiserCol = { 0, 0, 0 };
            for (int i = 0; i < CruiserRow.Length; i++)
            {
                if (IsOnBoard(board, currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]) 
                    && 
                    board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType == "")
                {
                    board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType = "C";
                    CruiserCheck++;
                }
            }
            if (CruiserCheck == 3)
            {
                return board;
            }
            else
            {
                for (int i = 0; i < CruiserRow.Length; i++)
                {
                    if (IsOnBoard(board, currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]) 
                        && 
                        board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType == "C")
                    {
                        board.Grid[currentCell.Row + CruiserRow[i], currentCell.Collumn + CruiserCol[i]].ShipType = "";
                    }
                }
                CruiserCheck = 0;
                return board;
            }
        }


    }
}
